using CommonECS;
using Unity.Entities;
using Unity.Mathematics;

namespace Components.Authoring
{
    public class ParticleRandomRotationAuthoring : AuthoringBehaviour<ParticleRandomRotation>
    {
        public float3 min;
        public float3 max;

        public override ParticleRandomRotation AsComponent(IBaker baker)
        {
            return new ParticleRandomRotation
            {
                min = min,
                max = max
            };
        }
    }

    public class ParticleRandomRotationBaker : Baker<ParticleRandomRotationAuthoring>
    {
        public override void Bake(ParticleRandomRotationAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}