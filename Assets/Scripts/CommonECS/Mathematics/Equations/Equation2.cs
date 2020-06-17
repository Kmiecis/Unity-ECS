using System;
using System.Runtime.CompilerServices;

namespace CommonECS.Mathematics
{
	/// <summary> Equation in form of x * a + y * b = z </summary>
	[Serializable]
	public struct Equation2
	{
		public float x, y, z;

		public Equation2(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateA(float b)
		{
			return (z - y * b) / x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateA(Equation2 nb)
		{   // x * a + y * (-nb.x * a + nb.z) = z
			float newx = x + y * -nb.x;
			float newz = z - y * nb.z;
			return newz / newx;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateB(float a)
		{
			return (z - x * a) / y;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateB(Equation2 na)
		{   // x * (-na.y * b + na.z) + y * b = z
			float newy = y + x * -na.y;
			float newz = z - x * na.z;
			return newz / newy;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void NormalizeA()
		{
			this /= x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Equation2 WithNormalizedA()
		{
			return this / x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void NormalizeB()
		{
			this /= y;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Equation2 WithNormalizedB()
		{
			return this / y;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsValid()
		{
			return x != 0.0f && y != 0.0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation2 operator /(Equation2 e, float v)
		{
			return new Equation2(e.x / v, e.y / v, e.z / v);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation2 operator *(Equation2 e, float v)
		{
			return new Equation2(e.x * v, e.y * v, e.z * v);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation2 operator +(Equation2 a, Equation2 b)
		{
			return new Equation2(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation2 operator -(Equation2 a, Equation2 b)
		{
			return new Equation2(a.x - b.x, a.y - b.y, a.z - b.z);
		}
	}
}
