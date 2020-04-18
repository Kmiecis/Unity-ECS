using Unity.Entities;
using Unity.Transforms;

namespace Common.ECS.Components
{
    public struct InstantiatePrefabRequest : IComponentData
    {
        public ResourcePath path;
        public Translation translation;
        public Rotation rotation;
    }
}