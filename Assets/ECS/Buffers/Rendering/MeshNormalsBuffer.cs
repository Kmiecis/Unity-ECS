using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Buffers
{
    public struct MeshNormalsBuffer : IBufferElementData
    {
        public float3 normal;
    }
}