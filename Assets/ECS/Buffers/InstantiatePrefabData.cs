using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Buffers
{
    public struct InstantiatePrefabData : IBufferElementData
    {
        public float3 translation;
        public quaternion rotation;
    }
}
