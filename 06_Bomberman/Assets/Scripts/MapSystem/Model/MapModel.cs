using System.Collections.Generic;
using System;
using System.Linq;

namespace MapSystem.Model
{
	public class MapModel
	{
		public int Size { get; private set; }
		public IEnumerable<HexPosition> AllPositions => _tiles.Keys;
		public IEnumerable<CellModel> AllCells => _tiles.Values;

		private Dictionary<HexPosition, CellModel> _tiles;
		public MapModel(int size, Dictionary<HexPosition, CellType> customTiles, IEnumerable<HexPosition> allCoordinates)
		{
			Size = size;

			_tiles = new Dictionary<HexPosition, CellModel>(allCoordinates.Count());

			foreach (var pos in allCoordinates)
			{
				CellType t = customTiles.ContainsKey(pos) ? customTiles[pos] : CellType.Grass;

				CellModel model;

				model = new CellModel(pos, t);
				_tiles.Add(pos, model);
			}

		}

		public CellModel GetTile(HexPosition pos)
		{
			return _tiles.GetValueOrDefault(pos);
		}

		public CellModel FindTileOfType(CellType type)
		{
			return _tiles.Values.FirstOrDefault(t => t.CellType == type);
		}
		public IEnumerable<CellModel> FindTilesOfType(CellType type)
		{
			return _tiles.Values.Where(t => t.CellType == type);
		}
	}

}