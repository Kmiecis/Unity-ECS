using Unity.Mathematics;

namespace Common.Mathematics
{
    public static class CubeModel
    {
        public const int VCOUNT = 8;
        public const float CENTER_TO_VERTEX = 0.5f * mathx.ROOT_3;

        public static readonly float3[] V3 = new float3[]
        {
            new float3(-1, -1, -1),
            new float3(-1, -1, +1),
            new float3(+1, -1, +1),
            new float3(+1, -1, -1),
            new float3(-1, +1, -1),
            new float3(-1, +1, +1),
            new float3(+1, +1, +1),
            new float3(+1, +1, -1),
        };
    }
}