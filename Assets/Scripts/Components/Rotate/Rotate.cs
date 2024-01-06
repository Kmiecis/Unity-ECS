using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct Rotate : IComponentData
    {
        public quaternion value;
    }
}