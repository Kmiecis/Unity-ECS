using CommonECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ParticleRandomLifetimeAuthoring : AuthoringBehaviour<ParticleRandomLifetime>
    {
        public float min;
        public float max;

        public override ParticleRandomLifetime AsComponent(IBaker baker)
        {
            return new ParticleRandomLifetime
            {
                min = min,
                max = max
            };
        }
    }

    public class ParticleRandomLifetimeBaker : Baker<ParticleRandomLifetimeAuthoring>
    {
        public override void Bake(ParticleRandomLifetimeAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}