using MapSystem.Model;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MapPresenter))]
public class HexMapDefinition: MonoBehaviour
{
	[SerializeField] private int _size;
	[SerializeField] private CellType _defaultCellType;

	[SerializeField] private HexCellDefinition[] _customCells = new HexCellDefinition[0];

	public int Size => _size;
	public CellType DefaultCellType => _defaultCellType;

	//Hex map is prespawned using custom inspector
	public bool IsPreSpawned => true;

	public IEnumerable<HexPosition> GetAllCoordinates()
	{
		List<HexPosition> coordinates = new List<HexPosition>();

		for (int q = -_size; q <= _size; ++q)
		{
			for(int r = -_size; r <= _size; ++r)
			{
				int s = -q - r;
				if (Mathf.Abs(s) > _size) 
					continue;

				coordinates.Add(new HexPosition(q, r, s));
			}
		}
		return coordinates;
	}

	public Dictionary<HexPosition, CellType> GetCustomCellTypes()
	{
		Dictionary<HexPosition, CellType> customCellTypes = new Dictionary<HexPosition, CellType>();
		foreach(var tileDefinition in _customCells)
		{
			customCellTypes.Add(tileDefinition.HexPosition, tileDefinition.CellType);
		}
		return customCellTypes;
		
	}

}
