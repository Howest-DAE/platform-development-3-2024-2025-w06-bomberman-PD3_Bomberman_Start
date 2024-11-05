using MapSystem.Model;
using System;
using System.Linq;
using UnityEngine;

public class MapPresenter : MonoBehaviour
{
	[SerializeField]
	private CellPresenter[] _cellPrefabs;

	public MapModel Model { get; private set; }
	[SerializeField]
	private HexMapDefinition _mapDefinition;


	public void Awake()
	{
		Model = new MapModel(_mapDefinition.Size, _mapDefinition.GetCustomCellTypes(), _mapDefinition.GetAllCoordinates());
		

		if (_mapDefinition.IsPreSpawned) //prespawned -> link models to presenters
		{
			foreach (var cell in transform.GetComponentsInChildren<CellPresenter>())
			{
				HexPosition pos = HexCoordinateConverter.ConvertVector3ToCoordinate(cell.transform.localPosition);
				cell.SetModel(Model.GetTile(pos));

			}
		}
		else //Not prespawned, we need to spawn the prefabs
		{
			foreach (var cell in Model.AllCells)
			{
				SpawnCell(cell);
			}
		}
	}

	public void SpawnCell(CellModel model)
	{
		Vector3 position = HexCoordinateConverter.ConvertCoordinateToVector3(model.Position);

		GameObject prefab = _cellPrefabs.FirstOrDefault(p => p.CellType == model.CellType)?.gameObject;
		if (prefab != null)
		{
			GameObject instance = Instantiate(prefab, transform);
			instance.transform.localPosition = position;
			instance.name = $"{prefab.name}-{model.Position}";
		}

	}

}

