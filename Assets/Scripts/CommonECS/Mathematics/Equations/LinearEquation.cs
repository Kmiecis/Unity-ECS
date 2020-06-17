using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	/// <summary> Equation in form of: y = a * x + b </summary>
	[Serializable]
	public struct LinearEquation
	{
		public float a, b;

		public static readonly LinearEquation invalid;

		public LinearEquation(float a, float b)
		{
			this.a = a;
			this.b = b;
		}

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
		public bool IsValid()
		{
			return a != 0.0f;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LinearEquation FromPoints(float2 A, float2 B)
		{
			if (A.x == 0.0f && B.x == 0.0f)
			{
				return invalid;
			}

			float a = (B.y - A.y) / (B.x - A.x);
			float b = A.y - a * A.x;
			return new LinearEquation(a, b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(LinearEquation other)
		{
			return this.a == other.a && this.b == other.b;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override bool Equals(object obj)
		{
			return obj is LinearEquation && Equals((LinearEquation)obj);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return a.GetHashCode() ^ b.GetHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("y = {0}x + {1}", a, b);
		}
	}
}
