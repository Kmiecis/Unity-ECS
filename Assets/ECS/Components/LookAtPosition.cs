using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    public struct LookAtPosition : IComponentData
    {
        public float3 position;
    }
}