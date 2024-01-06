using CommonECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ParticleEffectCountAuthoring : AuthoringBehaviour<ParticleEffectCount>
    {
        public int value;

        public override ParticleEffectCount AsComponent(IBaker baker)
        {
            return new ParticleEffectCount
            {
                value = value
            };
        }
    }

    public class ParticleEffectCountBaker : Baker<ParticleEffectCountAuthoring>
    {
        public override void Bake(ParticleEffectCountAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}