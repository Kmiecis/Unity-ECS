using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    public struct MoveToPosition : IComponentData
    {
        public float3 value;
    }
}