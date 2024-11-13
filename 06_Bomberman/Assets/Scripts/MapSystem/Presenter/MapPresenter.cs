using MapSystem.Model;
using System;
using System.Linq;
using UnityEngine;

public class MapPresenter : MonoBehaviour
{
	[SerializeField]
	private CellPresenter[] _cellPrefabs;
	public MapModel Model { get; private set; }

	//[SerializeField]
	//private HexMapDefinition _mapDefinition;


	public void Awake()
	{
		// Find all cell presenters in the scene and make a mapmodel of it
		Model = new MapModel();
		foreach(CellPresenter cellPresenter in GetComponentsInChildren<CellPresenter>())
		{
			HexPosition pos = HexCoordinateConverter.ConvertVector3ToCoordinate(cellPresenter.transform.localPosition);

			CellModel cellModel = Model.AddCell(pos, cellPresenter.CellType);
			cellPresenter.SetModel(cellModel);
		}
	
	}

}

