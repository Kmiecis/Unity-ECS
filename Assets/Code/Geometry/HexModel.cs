using Unity.Mathematics;

namespace Common.Mathematics
{
    public static class HexModel
    {
        public const int VCOUNT = 6;
        public const float CENTER_TO_SIDE = 1f;
        public const float CENTER_TO_VERTEX = CENTER_TO_SIDE * (2.0f / mathx.ROOT_3);

        public static readonly float2[] V2 = new float2[]
        {
            new float2(0, +CENTER_TO_VERTEX),
            new float2(+CENTER_TO_SIDE, +CENTER_TO_VERTEX * 0.5f),
            new float2(+CENTER_TO_SIDE, -CENTER_TO_VERTEX * 0.5f),
            new float2(0, -CENTER_TO_VERTEX),
            new float2(-CENTER_TO_SIDE, -CENTER_TO_VERTEX * 0.5f),
            new float2(-CENTER_TO_SIDE, +CENTER_TO_VERTEX * 0.5f),
        };

        public static readonly float3[] V3 = new float3[]
        {
            new float3(0, 0, +CENTER_TO_VERTEX),
            new float3(+CENTER_TO_SIDE, 0, +CENTER_TO_VERTEX * 0.5f),
            new float3(+CENTER_TO_SIDE, 0, -CENTER_TO_VERTEX * 0.5f),
            new float3(0, 0, -CENTER_TO_VERTEX),
            new float3(-CENTER_TO_SIDE, 0, -CENTER_TO_VERTEX * 0.5f),
            new float3(-CENTER_TO_SIDE, 0, +CENTER_TO_VERTEX * 0.5f),
        };

        public static readonly int2[] T = new int2[]
        {
            new int2() { x = +0, y = +1 },
            new int2() { x = +1, y = +0 },
            new int2() { x = +0, y = -1 },
            new int2() { x = -1, y = -1 },
            new int2() { x = -1, y = +0 },
            new int2() { x = -1, y = +1 }
        };

        /// <summary>
        /// Convers position defined in hex coordinates to world position
        /// </summary>
        public static float3 Convert(int2 v)
        {
            float x = (v.x + v.y * 0.5f - v.y / 2)* CENTER_TO_SIDE * 2f;
            float z = v.y * CENTER_TO_VERTEX * 1.5f;

            return new float3(x, 0f, z);
        }

        /// <summary>
        /// Converts position defined as world position to hex coordinates
        /// </summary>
        public static int2 Convert(float3 v)
        {
            float x = v.x / (CENTER_TO_SIDE * 2f);
            float y = -x;

            float offset = v.z / (CENTER_TO_VERTEX * 3f);
            x -= offset;
            y -= offset;

            int ix = mathx.round(x);
            int iy = mathx.round(y);
            int iz = mathx.round(-x - y);

            if (ix + iy + iz != 0)
            {
                float dx = math.abs(x - ix);
                float dy = math.abs(y - iy);
                float dz = math.abs(-x - y - iz);

                if (dx > dy && dx > dz)
                    ix = -iy - iz;
                else if (dz > dy)
                    iz = -ix - iy;
            }

            return new int2(ix, iz);
        }

        public enum Direction
        {
            NE, E, SE, SW, W, NW, Count
        }
    }
}