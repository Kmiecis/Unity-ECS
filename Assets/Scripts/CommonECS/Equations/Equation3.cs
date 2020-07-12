using System;
using System.Runtime.CompilerServices;

namespace CommonECS.Mathematics
{
	/// <summary> Equation in form of: x * a + y * b + z * c = w </summary>
	[Serializable]
	public struct Equation3
	{
		public float x, y, z, w;

		public static readonly Equation3 invalid;

		public Equation3(float x, float y, float z, float w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateA(float b, float c)
		{
			return (w - y * b - z * c) / x;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateB(float a, float c)
		{
			return (w - x * a - z * c) / y;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float EvaluateC(float a, float b)
		{
			return (w - x * a - y * b) / z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void NormalizeA()
		{
			this /= x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Equation3 WithNormalizedA()
		{
			return this / x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void NormalizeB()
		{
			this /= y;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Equation3 WithNormalizedB()
		{
			return this / y;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void NormalizeC()
		{
			this /= z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Equation3 WithNormalizedC()
		{
			return this / z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsValid()
		{
			return x != 0.0f || y != 0.0f || z != 0.0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Equation2 WithZeroA()
		{
			return new Equation2(y, z, w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Equation2 WithZeroB()
		{
			return new Equation2(x, z, w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Equation2 WithZeroC()
		{
			return new Equation2(x, y, w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation3 operator /(Equation3 e, float v)
		{
			return new Equation3(e.x / v, e.y / v, e.z / v, e.w / v);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation3 operator *(Equation3 e, float v)
		{
			return new Equation3(e.x * v, e.y * v, e.z * v, e.w * v);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation3 operator +(Equation3 a, Equation3 b)
		{
			return new Equation3(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation3 operator -(Equation3 a, Equation3 b)
		{
			return new Equation3(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Equation3 other)
		{
			return this.x == other.x && this.y == other.y && this.z == other.z && this.w == other.w;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override bool Equals(object obj)
		{
			return obj is Equation3 && Equals((Equation3)obj);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode() ^ w.GetHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("{0}a + {1}b + {2}c = {3}", x, y, z, w);
		}
	}
}
