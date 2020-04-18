using Unity.Entities;

namespace Common.ECS.Components
{
    public struct LookAt : IComponentData
    {
        public Entity target; // Target has to have Translation component
    }
}