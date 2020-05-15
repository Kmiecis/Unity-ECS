using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    public struct InstantiatePlatformRequest : IComponentData
    {
        public float3 position;
    }
}