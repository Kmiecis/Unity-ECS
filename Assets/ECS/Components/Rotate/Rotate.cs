using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    public struct Rotate : IComponentData
    {
        public quaternion value;
    }
}