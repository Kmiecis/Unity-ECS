using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Mathematics
{
    public class Polygon2
    {
        public float2[] vs;

        public Polygon2(int vertices = 5)
        {
            vs = new float2[vertices];
        }
        
        public float Distance(float2 p)
        {
            float min = float.MaxValue;
            float max = float.MinValue;

            for (int i0 = 0; i0 < vs.Length; ++i0)
            {
                int i1 = (i0 + 1) % vs.Length;
                var v0 = vs[i0];
                var v1 = vs[i1];

                var n = math.normalize(new float2(v1.y - v0.y, v0.x - v1.x));

                float A = math.dot(n, p);

                float minB = float.MaxValue;
                float maxB = float.MinValue;

                for (int i = 0; i < vs.Length; ++i)
                {
                    float B = math.dot(n, vs[i]);

                    minB = math.min(minB, B);
                    maxB = math.max(maxB, B);
                }

                min = math.min(min, A - maxB);
                max = math.max(max, minB - A);
            }

            return mathx.absmin(min, max);
        }

        public float2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return vs[index]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { vs[index] = value; }
        }
    }
}