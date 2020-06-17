using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	public struct LinearEquation
	{
		public float a, b;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Evaluate(float x)
		{
			return Evaluate(x, this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Evaluate(float x, float a, float b)
		{
			return a * x + b;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Evaluate(float x, LinearEquation f)
		{
			return Evaluate(x, f.a, f.b);
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearEquation Find(float2 A, float2 B)
		{
			float a = (B.y - A.y) / (B.x - A.x);
			float b = A.y - a * A.x;
			return new LinearEquation { a = a, b = b };
		}
	}
}
