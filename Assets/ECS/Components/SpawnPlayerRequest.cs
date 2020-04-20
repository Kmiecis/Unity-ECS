using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    public struct SpawnPlayerRequest : IComponentData
    {
        public float2 position;
    }
}