using Unity.Entities;

namespace Common.ECS.Components
{
    public struct MoveToTarget : IComponentData
    {
        public Entity value;
    }
}