using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    [GenerateAuthoringComponent]
    public struct Movement3D : IComponentData
    {
        public float3 value;
    }
}