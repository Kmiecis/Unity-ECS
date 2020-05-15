using Unity.Entities;

namespace Common.ECS.Components
{
    [GenerateAuthoringComponent]
    public struct MoveSpeed : IComponentData
    {
        public float value;
    }
}