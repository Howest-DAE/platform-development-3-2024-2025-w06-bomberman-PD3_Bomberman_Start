using System;


namespace MapSystem.Model
{
    public class CellModel
    {
        public HexPosition Position { get; private set; }
        public CellType CellType { get; set; }

        public CellModel(HexPosition pos, CellType type)
        {
            Position = pos;
            CellType = type;
        }

    }
}
