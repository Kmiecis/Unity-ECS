using Unity.Mathematics;

namespace Common.Mathematics
{
    public static class RectModel
    {
        public const int VCOUNT = 4;
        public const float CENTER_TO_VERTEX = mathx.ROOT_2;

        public static readonly float2[] V2 = new float2[]
        {
            new float2(-1, -1),
            new float2(-1, +1),
            new float2(+1, +1),
            new float2(+1, -1)
        };

        public static readonly float3[] V3 = new float3[]
        {
            new float3(-1, 0, -1),
            new float3(-1, 0, +1),
            new float3(+1, 0, +1),
            new float3(+1, 0, -1)
        };
    }
}