using CommonECS;
using Unity.Entities;
using UnityEngine;

namespace Components.Authoring
{
    public class ParticleEffectPrefabAuthoring : AuthoringBehaviour<ParticleEffectPrefab>
    {
        public GameObject value;

        public override bool MarkDependencies(IBaker baker)
        {
            baker.DependsOn(value);

            return value != null;
        }

        public override ParticleEffectPrefab AsComponent(IBaker baker)
        {
            return new ParticleEffectPrefab
            {
                value = baker.GetEntity(value, TransformUsageFlags.Dynamic)
            };
        }
    }

    public class ParticleEffectPrefabBaker : Baker<ParticleEffectPrefabAuthoring>
    {
        public override void Bake(ParticleEffectPrefabAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}