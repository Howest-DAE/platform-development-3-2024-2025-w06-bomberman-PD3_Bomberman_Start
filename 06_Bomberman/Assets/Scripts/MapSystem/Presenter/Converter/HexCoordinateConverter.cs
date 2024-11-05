
using MapSystem.Model;
using UnityEngine;
public static class HexCoordinateConverter
{
	public const float TileSize = 1;

	static readonly float _sqr3over3 = Mathf.Sqrt(3f) / 3f;

	public static Vector3 ConvertCoordinateToVector3(HexPosition coordinate)
	{
		HexPosition hexCoord = (HexPosition)coordinate;

		float z = 3f / 2f * hexCoord.R;
		float x = (hexCoord.Q + z / 3f) / _sqr3over3;
		return new Vector3(x, 0f, z) * TileSize;
	}

	public static HexPosition ConvertVector3ToCoordinate(Vector3 position)
	{
		position /= TileSize;

		float q = (_sqr3over3 * position.x - position.z / 3f);
		float r = (2f / 3f * position.z);
		float s = -q - r;

		return Round(q, r, s);
	}

	private static HexPosition Round(float q, float r, float s)
	{
		HexPosition p = new HexPosition(Mathf.RoundToInt(q), Mathf.RoundToInt(r), Mathf.RoundToInt(s));
		float q_diff = Mathf.Abs(p.Q - q);
		float r_diff = Mathf.Abs(p.R - r);
		float s_diff = Mathf.Abs(p.S - s);


		if (q_diff > r_diff && q_diff > s_diff)
		{
			p.Q = -p.R - p.S;

		}
		else if (r_diff > s_diff)
		{
			p.R = -p.Q - p.S;
		}
		else
		{
			p.S = -p.Q - p.R;
		}

		return p;
	}

}