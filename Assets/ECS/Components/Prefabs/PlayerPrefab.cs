using Unity.Entities;

namespace Common.ECS.Components
{
    [GenerateAuthoringComponent]
    public struct PlayerPrefab : IComponentData
    {
        public Entity value;
    }
}