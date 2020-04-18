using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Mathematics
{
    public struct Edge2
    {
        public float2 v0, v1;

        public float Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return math.distance(v1, v0); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Distance(float2 v)
        {
            var v0v1 = v1 - v0;
            var v0p = v - v0;
            var pv1 = v1 - v;
            var r = math.dot(v0v1, v0p) / math.length(v0v1);
            if (r < 0)
                return math.length(v0p);
            else if (r > 0)
                return math.length(pv1);
            var lv0p = math.length(v0p);
            var lv0v1 = math.length(v0v1);
            return math.sqrt(lv0p * lv0p - r * lv0v1 * lv0v1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(float2 v)
        {
            return mathx.equals(Length, math.distance(v1, v) + math.distance(v, v0));
        }

        public bool Equals(Edge2 v)
        {
            return v0.Equals(v.v0) && v1.Equals(v.v1);
        }

        public override bool Equals(object obj)
        {
            if (obj is Edge2)
                return Equals((Edge2)obj);
            return false;
        }

        public override int GetHashCode()
        {
            return v0.GetHashCode() ^ v1.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[v0: {0}, v1: {1}]", v0, v1);
        }
    }
}