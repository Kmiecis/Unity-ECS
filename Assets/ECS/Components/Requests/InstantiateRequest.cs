using Unity.Entities;

namespace Common.ECS.Components
{
    public struct InstantiateRequest : IComponentData
    {
        public ResourcePath path;
        public int count;
    }
}