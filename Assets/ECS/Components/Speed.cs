using Unity.Entities;

namespace Common.ECS.Components
{
    [GenerateAuthoringComponent]
    public struct Speed : IComponentData
    {
        public float value;
    }
}