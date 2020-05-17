using Unity.Entities;

namespace Common.ECS.Components
{
    [GenerateAuthoringComponent]
    public struct RotateSpeed : IComponentData
    {
        public float value;
    }
}