using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
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
			return (math.sin((x + dx) * sx) + dy) * sy;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Evaluate(float x, SinEquation f)
		{
			return Evaluate(x, f.dx, f.sx, f.dy, f.sy);
		}
	}
}
