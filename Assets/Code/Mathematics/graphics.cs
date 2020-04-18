using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Common.Mathematics
{
    public static class graphics
    {
        /// <summary>Converts a Color32 to a byte4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 rgba(Color32 c)
        {
            return new byte4(c.r, c.g, c.b, c.a);
        }

        /// <summary>Converts a Color to a float4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 rgba(Color c)
        {
            return new float4(c.r, c.g, c.b, c.a);
        }

        /// <summary>Converts a Color32 to a byte3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 rgb(Color32 c)
        {
            return new byte3(c.r, c.g, c.b);
        }

        /// <summary>Converts a Color to a float3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 rgb(Color c)
        {
            return new float3(c.r, c.g, c.b);
        }

        /// <summary>Converts a byte4 vector to a Color32 by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 color(byte4 v)
        {
            return new Color32(v.x, v.y, v.z, v.w);
        }

        /// <summary>Converts a float4 vector to a Color by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color color(float4 v)
        {
            return new Color(v.x, v.y, v.z, v.w);
        }

        /// <summary>Converts a byte3 vector to a Color32 by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 color(byte3 v, byte a = byte.MaxValue)
        {
            return new Color32(v.x, v.y, v.z, a);
        }

        /// <summary>Converts a float3 vector to a Color by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color color(float3 v, float a = 1f)
        {
            return new Color(v.x, v.y, v.z, a);
        }

        /// <summary>Converts a byte value of range [0..255] to a float value of range [0..1].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float b2f(byte b)
        {
            return b * 1f / byte.MaxValue;
        }

        /// <summary>Converts a byte2 values of range [0..255] to a float2 values of range [0..1].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 b2f(byte2 b)
        {
            return mathx.mul(b, 1f) / byte.MaxValue;
        }

        /// <summary>Converts a byte3 values of range [0..255] to a float3 values of range [0..1].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 b2f(byte3 b)
        {
            return mathx.mul(b, 1f) / byte.MaxValue;
        }

        /// <summary>Converts a byte4 values of range [0..255] to a float4 values of range [0..1].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 b2f(byte4 b)
        {
            return mathx.mul(b, 1f) / byte.MaxValue;
        }

        /// <summary>Converts a float value of range [0..1] to a byte value of range [0..255].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte f2b(float f)
        {
            unchecked { return (byte)(f * byte.MaxValue); }
        }

        /// <summary>Converts a float2 values of range [0..1] to a byte2 values of range [0..255].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 f2b(float2 f)
        {
            unchecked { return (byte2)(f * byte.MaxValue); }
        }

        /// <summary>Converts a float3 values of range [0..1] to a byte3 values of range [0..255].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 f2b(float3 f)
        {
            unchecked { return (byte3)(f * byte.MaxValue); }
        }

        /// <summary>Converts a float4 values of range [0..1] to a byte4 values of range [0..255].</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 f2b(float4 f)
        {
            unchecked { return (byte4)(f * byte.MaxValue); }
        }

        /// <summary>Converts texture normal vector to unity normal vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 normal(Color c)
        {
            return (rgb(c) * 2 - 1).xzy;
        }

        /// <summary>Converts texture normal vector to unity normal vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 normal(Color32 c)
        {
            return (b2f(rgb(c)) * 2 - 1).xzy;
        }

        /// <summary>Converts unity normal vector to texture normal vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color normal(float3 v)
        {
            return color((v.xzy + 1) * 0.5f);
        }

        /// <summary>Converts unity normal vector to texture normal vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Color32 normal32(float3 v)
        {
            return color(f2b((v.xzy + 1) * 0.5f));
        }
    }
}