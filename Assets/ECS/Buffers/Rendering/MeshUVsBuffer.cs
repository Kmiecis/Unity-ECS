using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Buffers
{
    public struct MeshUVsBuffer : IBufferElementData
    {
        public float2 uv;
    }
}