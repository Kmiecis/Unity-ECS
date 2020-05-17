using Unity.Entities;

namespace Common.ECS.Components
{
    [GenerateAuthoringComponent]
    public struct PlatformPrefab : IComponentData
    {
        public Entity value;
    }
}