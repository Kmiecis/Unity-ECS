using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct ProjectileSpawn : IComponentData
    {
        public float3 offset;
        public quaternion rotation;
    }
}