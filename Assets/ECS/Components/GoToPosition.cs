using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    public struct GoToPosition : IComponentData
    {
        public float3 value;
    }
}