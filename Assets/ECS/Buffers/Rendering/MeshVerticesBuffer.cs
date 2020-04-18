using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Buffers
{
    public struct MeshVerticesBuffer : IBufferElementData
    {
        public float3 vertex;
    }
}