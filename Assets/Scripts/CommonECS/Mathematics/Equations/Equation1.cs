using System;
using System.Runtime.CompilerServices;

namespace CommonECS.Mathematics
{
	/// <summary> Equation in form of x * a = y </summary>
	[Serializable]
	public struct Equation1
	{
		public float x, y;

		public Equation1(float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Value()
		{
			return y / x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Normalize()
		{
			this /= x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Equation1 Normalized()
		{
			return this / x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsValid()
		{
			return x != 0.0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation1 operator /(Equation1 e, float v)
		{
			return new Equation1(e.x / v, e.y / v);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation1 operator *(Equation1 e, float v)
		{
			return new Equation1(e.x * v, e.y * v);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation1 operator +(Equation1 a, Equation1 b)
		{
			return new Equation1(a.x + b.x, a.y + b.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Equation1 operator -(Equation1 a, Equation1 b)
		{
			return new Equation1(a.x - b.x, a.y - b.y);
		}
	}
}
