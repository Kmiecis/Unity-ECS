using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    [GenerateAuthoringComponent]
    public struct Move : IComponentData
    {
        public float3 value;
    }
}