using Unity.Mathematics;

namespace Common.Mathematics
{
    public static class RhombusModel
    {
        public const int VCOUNT = 4;
        public const float CENTER_TO_VERTEX = mathx.ROOT_2;

        public static readonly float2[] V2 = new float2[]
        {
            new float2(-CENTER_TO_VERTEX, 0),
            new float2(0, +CENTER_TO_VERTEX),
            new float2(+CENTER_TO_VERTEX, 0),
            new float2(0, -CENTER_TO_VERTEX)
        };

        public static readonly float3[] V3 = new float3[]
        {
            new float3(-CENTER_TO_VERTEX, 0, 0),
            new float3(0, 0, +CENTER_TO_VERTEX),
            new float3(+CENTER_TO_VERTEX, 0, 0),
            new float3(0, 0, -CENTER_TO_VERTEX),
        };
    }
}