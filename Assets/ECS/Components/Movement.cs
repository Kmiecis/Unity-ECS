using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    [GenerateAuthoringComponent]
    public struct Movement : IComponentData
    {
        public float3 value;
    }
}