using System;

namespace MapSystem.Model
{
	[Serializable]
    public struct HexPosition
    {
        public int Q;
        public int R;
        public int S;

        public HexPosition(int q, int r, int s)
        {
            Q = q;
            R = r;
            S = s;
        }

        public static HexPosition operator +(HexPosition pos, HexDirection dir)
        {
            switch (dir)
            {
                default:
                case HexDirection.East:
                    pos.Q += 1;
                    pos.R += 0;
                    pos.S += -1;
                    break;
                case HexDirection.West:
                    pos.Q += -1;
                    pos.R += 0;
                    pos.S += 1;
                    break;
                case HexDirection.SouthWest:
                    pos.Q += 0;
                    pos.R += -1;
                    pos.S += 1;
                    break;
                case HexDirection.NorthEast:
                    pos.Q += 0;
                    pos.R += 1;
                    pos.S += -1;
                    break;
                case HexDirection.SouthEast:
                    pos.Q += 1;
                    pos.R += -1;
                    pos.S += 0;
                    break;
                case HexDirection.NorthWest:
                    pos.Q += -1;
                    pos.R += 1;
                    pos.S += 0;
                    break;
            }
            return pos;
        }
		public bool IsAdjacentTo(HexPosition other)
		{
			if (this.S == other.S)
			{
				return Math.Abs(this.R - other.R) == 1;
			}
			if (this.R == other.R)
			{
				return Math.Abs(this.Q - other.Q) == 1;
			}
			if (this.Q == other.Q)
			{
				return Math.Abs(this.S - other.S) == 1;
			}
			return false;
		}

		public static HexPosition operator -(HexPosition pos, HexDirection dir)
        {
            return pos + FlipDirection(dir);
        }

        public override string ToString()
        {
            return $"(Q: {Q} ,R: {R} ,S: {S} )";
        }

        public static bool operator ==(HexPosition a, HexPosition b)
        {
            return a.Q == b.Q && a.S == b.S && a.R == b.R;
        }
        public static bool operator !=(HexPosition a, HexPosition b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is HexPosition b)) return false;
            return (this == b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Q, R, S);
        }

		public static HexDirection FlipDirection(HexDirection dir)
		{
			switch (dir)
			{
				default:
				case HexDirection.West:
					return HexDirection.East;
				case HexDirection.East:
					return HexDirection.West;
				case HexDirection.NorthEast:
					return HexDirection.SouthWest;
				case HexDirection.SouthWest:
					return HexDirection.NorthEast;
				case HexDirection.NorthWest:
					return HexDirection.SouthEast;
				case HexDirection.SouthEast:
					return HexDirection.NorthWest;
			}
		}
	}
}
