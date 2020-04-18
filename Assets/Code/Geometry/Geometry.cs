using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Mathematics
{
    public static class Geometry
    {
        /// <summary> Calculates vertex at 'index' of regular polygon with 'count' vertices  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 Vertex(int index, int count)
        {
            var angleStep = 2 * math.PI / count;
            var angle = index * angleStep;
            return new float3(math.cos(angle), 0f, math.sin(angle));
        }

        /// <summary> Calculates offset vertex at 'index' of regular polygon with 'count' vertices </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 Vertex(int index, int count, float offset)
        {
            var angleStep = 2 * math.PI / count;
            var angleOffset = offset * angleStep;
            var angle = index * angleStep + angleOffset;
            return new float3(math.cos(angle), 0f, math.sin(angle));
        }

        /// <summary> Projects point 'v' to plane defined by two axes 'ax' and 'ay' </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 Project(float3 v, float3 ax, float3 ay)
        {
            float x = math.dot(ax, v);
            float y = math.dot(ay, v);
            return new float2(x, y);
        }

        /// <summary> Projects point 'v' to plane y </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 ProjectY(float3 v)
        {
            return Project(v, new float3(1, 0, 0), new float3(0, 0, 1));
        }

        /// <summary> Projects point 'v' to plane z </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 ProjectZ(float3 v)
        {
            return Project(v, new float3(1, 0, 0), new float3(0, 1, 0));
        }

        /// <summary> Projects point 'v' to plane x </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 ProjectX(float3 v)
        {
            return Project(v, new float3(0, 0, -1), new float3(0, 1, 0));
        }
    }
}