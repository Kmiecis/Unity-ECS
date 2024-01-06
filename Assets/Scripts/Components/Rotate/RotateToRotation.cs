using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct RotateToRotation : IComponentData
    {
        public quaternion rotation;
    }
}