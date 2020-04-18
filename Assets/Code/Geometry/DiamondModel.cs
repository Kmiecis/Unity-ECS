using Unity.Mathematics;

namespace Common.Mathematics
{
    public static class DiamondModel
    {
        public const int VCOUNT = 6;
        public const float CENTER_TO_VERTEX = 2 * mathx.ROOT_2;

        public static readonly float3[] V3 = new float3[]
        {
            new float3(0, -CENTER_TO_VERTEX, 0),
            new float3(-CENTER_TO_VERTEX, 0, 0),
            new float3(0, 0, +CENTER_TO_VERTEX),
            new float3(+CENTER_TO_VERTEX, 0, 0),
            new float3(0, 0, -CENTER_TO_VERTEX),
            new float3(0, +CENTER_TO_VERTEX, 0)
        };
    }
}