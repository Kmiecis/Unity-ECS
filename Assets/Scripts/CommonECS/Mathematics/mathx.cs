using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	/// <summary>
	/// Extended math library
	/// </summary>
	public static class mathx
	{
		public const float ROOT_2 = 1.41421356237f;
		public const float ROOT_3 = 1.73205080757f;
		public const float EPSILON = 0.000001f;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int floor(float v)
		{
			return (int)v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 floor(float2 v)
		{
			return (int2)v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 floor(float3 v)
		{
			return (int3)v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 floor(float4 v)
		{
			return (int4)v;
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int round(float v)
		{
			return (int)(v + 0.5f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 round(float2 v)
		{
			return (int2)(v + 0.5f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 round(float3 v)
		{
			return (int3)(v + 0.5f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 round(float4 v)
		{
			return (int4)(v + 0.5f);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ceil(float v)
		{
			return (int)(v + 1.0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 ceil(float2 v)
		{
			return (int2)(v + 1.0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 ceil(float3 v)
		{
			return (int3)(v + 1.0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 ceil(float4 v)
		{
			return (int4)(v + 1.0f);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float mod(float v, float m)
		{
			if (m < 0)
				m = -m;

			float r = v < 0 ? -v : v;

			while (r >= m)
				r -= m;

			return v < 0 ? -r : r;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mod(float2 v, float2 m)
		{
			return new float2(mod(v.x, m.x), mod(v.y, m.y));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mod(float3 v, float3 m)
		{
			return new float3(mod(v.x, m.x), mod(v.y, m.y), mod(v.z, m.z));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mod(float4 v, float4 m)
		{
			return new float4(mod(v.x, m.x), mod(v.y, m.y), mod(v.z, m.z), mod(v.w, m.w));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int shift_left(int v)
		{
			if (v > 0)
				return v >> 1;
			else if (v < 0)
				return v << 1;
			return -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int shift_right(int v)
		{
			if (v > 0)
				return v << 1;
			else if (v < 0)
				return v >> 1;
			return 1;
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int log_shift_left(int v)
		{
			if (v > 0)
				return v / 10;
			else if (v < 0)
				return v * 10;
			return -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int log_shift_right(int v)
		{
			if (v > 0)
				return v * 10;
			else if (v < 0)
				return v / 10;
			return 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float log_shift_left(float v)
		{
			if (v > 0)
				return v / 10;
			else if (v < 0)
				return v * 10;
			return -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float log_shift_right(float v)
		{
			if (v > 0)
				return v * 10;
			else if (v < 0)
				return v / 10;
			return 1;
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool is_even(int v)
		{
			return v % 2 == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool is_odd(int v)
		{
			return v % 2 != 0;
		}
		

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 perpendicular(float2 v)
		{
			return new float2(v.y, -v.x);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float absmin(float a, float b)
		{
			return math.abs(a) < math.abs(b) ? a : b;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float absmax(float a, float b)
		{
			return math.abs(a) > math.abs(b) ? a : b;
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool between(float a, float b, float t)
		{
			return a < t && t < b;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool between(int a, int b, int t)
		{
			return a < t && t < b;
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int next(int v, int count, int offset = 1)
		{
			return (v + offset) % count;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int prev(int v, int count, int offset = 1)
		{
			return (v - offset + count) % count;
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double lerp(double v0, double v1, double v2, float3 w)
		{
			return v0 * w.x + v1 * w.y + v2 * w.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 lerp(double2 v0, double2 v1, double2 v2, float3 w)
		{
			return v0 * w.x + v1 * w.y + v2 * w.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 lerp(double3 v0, double3 v1, double3 v2, float3 w)
		{
			return v0 * w.x + v1 * w.y + v2 * w.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 lerp(double4 v0, double4 v1, double4 v2, float3 w)
		{
			return v0 * w.x + v1 * w.y + v2 * w.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float lerp(float v0, float v1, float v2, float3 w)
		{
			return v0 * w.x + v1 * w.y + v2 * w.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 lerp(float2 v0, float2 v1, float2 v2, float3 w)
		{
			return v0 * w.x + v1 * w.y + v2 * w.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 lerp(float3 v0, float3 v1, float3 v2, float3 w)
		{
			return v0 * w.x + v1 * w.y + v2 * w.z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 lerp(float4 v0, float4 v1, float4 v2, float3 w)
		{
			return v0 * w.x + v1 * w.y + v2 * w.z;
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(float a, int2 b)
		{
			return new float2(a * b.x, a * b.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(float a, int3 b)
		{
			return new float3(a * b.x, a * b.y, a * b.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(float a, int4 b)
		{
			return new float4(a * b.x, a * b.y, a * b.z, a * b.w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(int2 a, float b)
		{
			return new float2(a.x * b, a.y * b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(int3 a, float b)
		{
			return new float3(a.x * b, a.y * b, a.z * b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(int4 a, float b)
		{
			return new float4(a.x * b, a.y * b, a.z * b, a.w * b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(float a, uint2 b)
		{
			return new float2(a * b.x, a * b.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(float a, uint3 b)
		{
			return new float3(a * b.x, a * b.y, a * b.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(float a, uint4 b)
		{
			return new float4(a * b.x, a * b.y, a * b.z, a * b.w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(uint2 a, float b)
		{
			return new float2(a.x * b, a.y * b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(uint3 a, float b)
		{
			return new float3(a.x * b, a.y * b, a.z * b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(uint4 a, float b)
		{
			return new float4(a.x * b, a.y * b, a.z * b, a.w * b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(float a, byte2 b)
		{
			return new float2(a * b.x, a * b.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(float a, byte3 b)
		{
			return new float3(a * b.x, a * b.y, a * b.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(float a, byte4 b)
		{
			return new float4(a * b.x, a * b.y, a * b.z, a * b.w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 mul(byte2 a, float b)
		{
			return new float2(a.x * b, a.y * b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 mul(byte3 a, float b)
		{
			return new float3(a.x * b, a.y * b, a.z * b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 mul(byte4 a, float b)
		{
			return new float4(a.x * b, a.y * b, a.z * b, a.w * b);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float lerp(int x, int y, float s)
		{
			return x + (s * (y - x));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 lerp(int2 x, int2 y, float s)
		{
			return x + mul(s, (y - x));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 lerp(int3 x, int3 y, float s)
		{
			return x + mul(s, (y - x));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 lerp(int4 x, int4 y, float s)
		{
			return x + mul(s, (y - x));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float lerp(uint x, uint y, float s)
		{
			return x + (s * (y - x));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 lerp(uint2 x, uint2 y, float s)
		{
			return x + mul(s, (y - x));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 lerp(uint3 x, uint3 y, float s)
		{
			return x + mul(s, (y - x));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 lerp(uint4 x, uint4 y, float s)
		{
			return x + mul(s, (y - x));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float lerp(byte x, byte y, float s)
		{
			return x + (s * (y - x));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 lerp(byte2 x, byte2 y, float s)
		{
			return x + mul(s, (y - x));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 lerp(byte3 x, byte3 y, float s)
		{
			return x + mul(s, (y - x));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 lerp(byte4 x, byte4 y, float s)
		{
			return x + mul(s, (y - x));
		}


		/// <summary> Normalizes value x to a range [a, b] </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float unlerp(float a, float b, float v)
		{
			return (v - a) / (b - a);
		}

		/// <summary> Normalizes componentwise value x to a range [a, b] </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 unlerp(float2 a, float2 b, float2 v)
		{
			return new float2(
				unlerp(a.x, b.x, v.x),
				unlerp(a.y, b.y, v.y)
			);
		}

		/// <summary> Normalizes componentwise value x to a range [a, b] </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 unlerp(float3 a, float3 b, float3 v)
		{
			return new float3(
				unlerp(a.x, b.x, v.x),
				unlerp(a.y, b.y, v.y),
				unlerp(a.z, b.z, v.z)
			);
		}

		/// <summary> Normalizes componentwise value x to a range [a, b] </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 unlerp(float4 a, float4 b, float4 v)
		{
			return new float4(
				unlerp(a.x, b.x, v.x),
				unlerp(a.y, b.y, v.y),
				unlerp(a.z, b.z, v.z),
				unlerp(a.w, b.w, v.w)
			);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool greater(float a, float b, float e = EPSILON)
		{
			return a - e > b;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool lesser(float a, float b, float e = EPSILON)
		{
			return a + e < b;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool equals(float a, float b, float e = EPSILON)
		{
			return a - e < b && a + e > b;
		}
	}
}
