using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    [GenerateAuthoringComponent]
    public struct Movement2D : IComponentData
    {
        public float2 value;
    }
}