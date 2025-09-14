using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ParticleRandomSizeAuthoring : AuthoringBehaviour<ParticleRandomSize>
    {
        public float min;
        public float max;

        public override ParticleRandomSize AsComponent(IBaker baker)
        {
            return new ParticleRandomSize
            {
                min = min,
                max = max
            };
        }
    }

    public class ParticleRandomSizeBaker : Baker<ParticleRandomSizeAuthoring>
    {
        public override void Bake(ParticleRandomSizeAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}