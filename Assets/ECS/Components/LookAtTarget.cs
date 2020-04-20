using Unity.Entities;

namespace Common.ECS.Components
{
    public struct LookAtTarget : IComponentData
    {
        public Entity target;
    }
}