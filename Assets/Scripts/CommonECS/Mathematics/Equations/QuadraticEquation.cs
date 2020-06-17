using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	public struct QuadraticEquation
	{
		public float a, b, c;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Evaluate(float x)
		{
			return Evaluate(x, this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Evaluate(float x, float a, float b, float c)
		{
			return a * x * x + b * x + c;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Evaluate(float x, QuadraticEquation f)
		{
			return Evaluate(x, f.a, f.b, f.c);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static QuadraticEquation Find(float2 A, float2 B, float2 C)
		{
			return new QuadraticEquation();
		}
	}
}
