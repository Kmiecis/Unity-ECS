using Unity.Entities;

namespace Components
{
    public struct ParticleRandomLifetime : IComponentData
    {
        public float min;
        public float max;
    }
}