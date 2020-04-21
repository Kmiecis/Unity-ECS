using Unity.Entities;

namespace Common.ECS.Components
{
    public struct FollowTarget : IComponentData
    {
        public Entity value;
    }
}