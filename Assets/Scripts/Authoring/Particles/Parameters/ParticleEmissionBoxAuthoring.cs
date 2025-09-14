using Common.ECS;
using Unity.Entities;
using Unity.Mathematics;

namespace Components.Authoring
{
    public class ParticleEmissionBoxAuthoring : AuthoringBehaviour<ParticleEmissionBox>
    {
        public float3 min;
        public float3 max;

        public override ParticleEmissionBox AsComponent(IBaker baker)
        {
            return new ParticleEmissionBox
            {
                min = min,
                max = max
            };
        }
    }

    public class ParticleEmissionBoxBaker : Baker<ParticleEmissionBoxAuthoring>
    {
        public override void Bake(ParticleEmissionBoxAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}