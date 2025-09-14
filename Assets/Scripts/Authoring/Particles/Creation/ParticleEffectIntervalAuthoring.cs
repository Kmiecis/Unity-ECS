using Common.ECS;
using Unity.Entities;
using UnityEngine;

namespace Components.Authoring
{
    public class ParticleEffectIntervalAuthoring : AuthoringBehaviour<ParticleEffectInterval>
    {
        [Min(1e-5f)]
        public float value;

        public override ParticleEffectInterval AsComponent(IBaker baker)
        {
            return new ParticleEffectInterval
            {
                value = value
            };
        }
    }

    public class ParticleEffectIntervalBaker : Baker<ParticleEffectIntervalAuthoring>
    {
        public override void Bake(ParticleEffectIntervalAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}