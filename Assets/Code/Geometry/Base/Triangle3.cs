using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Mathematics
{
    public struct Triangle3
    {
        public float3 v0, v1, v2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 Weights(float3 v)
        {
            var va = v0 - v;
            var vb = v1 - v;
            var vc = v2 - v;

            var fsq = math.lengthsq(math.cross(v1 - v0, v2 - v1));
            var fsqa = math.lengthsq(math.cross(vb, vc));
            var fsqb = math.lengthsq(math.cross(vc, va));
            var fsqc = math.lengthsq(math.cross(va, vb));

            return new float3(fsqa, fsqb, fsqc);
        }
    }
}