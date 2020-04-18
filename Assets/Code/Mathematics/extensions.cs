using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Mathematics
{
    public static class extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 xy_(this float2 v, float z = 0)
        {
            return new float3(v.x, v.y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 x_y(this float2 v, float y = 0)
        {
            return new float3(v.x, y, v.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 _xy(this float2 v, float x = 0)
        {
            return new float3(x, v.x, v.y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 xy_(this int2 v, int z = 0)
        {
            return new int3(v, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 x_y(this int2 v, int y = 0)
        {
            return new int3(v.x, y, v.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 _xy(this int2 v, int x = 0)
        {
            return new int3(x, v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 xyz_(this float3 v, float w = 0)
        {
            return new float4(v, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 xy_z(this float3 v, float z = 0)
        {
            return new float4(v.x, v.y, z, v.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 x_yz(this float3 v, float y = 0)
        {
            return new float4(v.x, y, v.y, v.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 _xyz(this float3 v, float x = 0)
        {
            return new float4(x, v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 xyz_(this int3 v, int w = 0)
        {
            return new int4(v, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 xy_z(this int3 v, int z = 0)
        {
            return new int4(v.x, v.y, z, v.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 x_yz(this int3 v, int y = 0)
        {
            return new int4(v.x, y, v.y, v.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 _xyz(this int3 v, int x = 0)
        {
            return new int4(x, v);
        }
    }
}