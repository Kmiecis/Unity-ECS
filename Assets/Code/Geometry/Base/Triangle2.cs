using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Mathematics
{
    public struct Triangle2
    {
        public float2 v0, v1, v2;

        public float Area
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return 0.5f * (-v1.y * v0.x + v2.y * (v0.x - v1.x) + v2.x * (v1.y - v0.y) + v1.x * v0.y); }
        }

        public float Perimeter
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return math.distance(v1, v0) + math.distance(v2, v1) + math.distance(v0, v2); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(float2 p)
        {
            var s = v0.y * v2.x - v0.x * v2.y + (v2.y - v0.y) * p.x + (v0.x - v2.x) * p.y;
            var t = v0.x * v1.y - v0.y * v1.x + (v0.y - v1.y) * p.x + (v1.x - v0.x) * p.y;

            if ((s < 0) != (t < 0))
                return false;

            var A = -v1.y * v2.x + v0.y * (v2.x - v1.x) + v0.x * (v1.y - v2.y) + v1.x * v2.y;

            return A < 0 ?
                    (s <= 0 && s + t >= A) :
                    (s >= 0 && s + t <= A);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 Weights(float2 v)
        {
            var ta = new Triangle2 { v0 = v1, v1 = v2, v2 = v };
            var tb = new Triangle2 { v0 = v2, v1 = v0, v2 = v };
            var tc = new Triangle2 { v0 = v0, v1 = v1, v2 = v };

            var f = this.Area;
            var fa = ta.Area;
            var fb = tb.Area;
            var fc = tc.Area;

            return new float3(fa / f, fb / f, fc / f);
        }

        public bool Equals(Triangle2 v)
        {
            return v0.Equals(v.v0) && v1.Equals(v.v1) && v2.Equals(v.v2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Triangle2)
                return Equals((Triangle2)obj);
            return false;
        }

        public override string ToString()
        {
            return string.Format("[v0: {0}, v1: {1}, v2: {2}]", v0, v1, v2);
        }

        public override int GetHashCode()
        {
            return v0.GetHashCode() ^ v1.GetHashCode() ^ v2.GetHashCode();
        }
    }
}