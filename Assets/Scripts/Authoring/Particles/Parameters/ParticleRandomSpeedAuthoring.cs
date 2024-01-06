using CommonECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ParticleRandomSpeedAuthoring : AuthoringBehaviour<ParticleRandomSpeed>
    {
        public float min;
        public float max;

        public override ParticleRandomSpeed AsComponent(IBaker baker)
        {
            return new ParticleRandomSpeed
            {
                min = min,
                max = max
            };
        }
    }

    public class ParticleRandomSpeedBaker : Baker<ParticleRandomSpeedAuthoring>
    {
        public override void Bake(ParticleRandomSpeedAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}