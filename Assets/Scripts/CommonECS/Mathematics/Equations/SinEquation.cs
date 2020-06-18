using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	[Serializable]
	public struct SinEquation
	{
		public float dx, sx, dy, sy;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Evaluate(float x)
		{
			return Evaluate(x, this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Evaluate(float x, float dx = 0.0f, float sx = 1.0f, float dy = 0.0f, float sy = 1.0f)
		{
			return (math.sin(((x + dx) * sx) * F) + dy) * sy;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Evaluate(float x, SinEquation f)
		{
			return Evaluate(x, f.dx, f.sx, f.dy, f.sy);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SinEquation FromPoints(float2 A, float2 B)
		{
			// TODO
			return new SinEquation();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(SinEquation other)
		{
			return this.dx == other.dx && this.sx == other.sx && this.dy == other.dy && this.sy == other.sy;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override bool Equals(object obj)
		{
			return obj is SinEquation && Equals((SinEquation)obj);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return dx.GetHashCode() ^ sx.GetHashCode() ^ dy.GetHashCode() ^ sy.GetHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("y = (sin((x + {0}) * {1}) + {2}) * {3}", dx, sx, dy, sy);
		}

		const float F = math.PI * 0.5f;
		const float RF = 1.0f / F;
	}
}
