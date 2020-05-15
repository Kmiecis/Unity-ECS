using Unity.Entities;

namespace Common.ECS.Components
{
    public struct RotateToTarget : IComponentData
    {
        public Entity value;
    }
}