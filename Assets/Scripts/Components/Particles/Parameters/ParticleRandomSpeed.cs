using Unity.Entities;

namespace Components
{
    public struct ParticleRandomSpeed : IComponentData
    {
        public float min;
        public float max;
    }
}