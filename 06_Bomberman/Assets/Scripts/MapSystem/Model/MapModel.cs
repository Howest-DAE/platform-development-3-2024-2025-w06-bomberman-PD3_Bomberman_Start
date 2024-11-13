using System.Collections.Generic;
using System;
using System.Linq;

namespace MapSystem.Model
{
	public class MapModel
	{
		public IEnumerable<HexPosition> AllPositions => _tiles.Keys;
		public IEnumerable<CellModel> AllCells => _tiles.Values;

		private Dictionary<HexPosition, CellModel> _tiles;
		public MapModel()
		{
			_tiles = new Dictionary<HexPosition, CellModel>();
		}

		public CellModel AddCell(HexPosition pos, CellType type)
		{
			CellModel cellModel = new CellModel(pos, type);
			_tiles.Add(pos, cellModel);
			return cellModel;
		}

		public CellModel GetCellAtPosition(HexPosition pos)
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