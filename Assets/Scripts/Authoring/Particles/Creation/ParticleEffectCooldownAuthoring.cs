using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ParticleEffectCooldownAuthoring : AuthoringBehaviour<ParticleEffectCooldown>
    {
        public float value;

        public override ParticleEffectCooldown AsComponent(IBaker baker)
        {
            return new ParticleEffectCooldown
            {
                value = value
            };
        }
    }

    public class ParticleEffectCooldownBaker : Baker<ParticleEffectCooldownAuthoring>
    {
        public override void Bake(ParticleEffectCooldownAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}