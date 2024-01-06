using Unity.Entities;

namespace Components
{
    public struct ParticleEmissionSphere : IComponentData
    {
        public float min;
        public float max;
    }
}