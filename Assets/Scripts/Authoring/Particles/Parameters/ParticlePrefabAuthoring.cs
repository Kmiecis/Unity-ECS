using CommonECS;
using Unity.Entities;
using UnityEngine;

namespace Components.Authoring
{
    public class ParticlePrefabAuthoring : AuthoringBehaviour<ParticlePrefab>
    {
        public GameObject value;

        public override bool MarkDependencies(IBaker baker)
        {
            baker.DependsOn(value);

            return value != null;
        }

        public override ParticlePrefab AsComponent(IBaker baker)
        {
            return new ParticlePrefab
            {
                value = baker.GetEntity(value, TransformUsageFlags.Dynamic)
            };
        }
    }

    public class ParticlePrefabBaker : Baker<ParticlePrefabAuthoring>
    {
        public override void Bake(ParticlePrefabAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}