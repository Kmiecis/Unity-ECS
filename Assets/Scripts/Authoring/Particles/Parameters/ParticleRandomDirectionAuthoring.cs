using CommonECS;
using Unity.Entities;
using Unity.Mathematics;

namespace Components.Authoring
{
    public class ParticleRandomDirectionAuthoring : AuthoringBehaviour<ParticleRandomDirection>
    {
        public float3 min;
        public float3 max;

        public override ParticleRandomDirection AsComponent(IBaker baker)
        {
            return new ParticleRandomDirection
            {
                min = min,
                max = max
            };
        }
    }

    public class ParticleRandomDirectionBaker : Baker<ParticleRandomDirectionAuthoring>
    {
        public override void Bake(ParticleRandomDirectionAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}