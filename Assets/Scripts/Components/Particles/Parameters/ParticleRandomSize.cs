using Unity.Entities;

namespace Components
{
    public struct ParticleRandomSize : IComponentData
    {
        public float min;
        public float max;
    }
}