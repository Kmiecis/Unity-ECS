using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    public struct InstantiatePlayerRequest : IComponentData
    {
        public float3 position;
    }
}