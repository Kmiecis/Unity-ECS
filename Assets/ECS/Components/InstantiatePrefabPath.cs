using Unity.Entities;

namespace Common.ECS.Components
{
    public struct InstantiatePrefabPath : IComponentData
    {
        public ResourcePath value;
    }
}
