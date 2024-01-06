using CommonECS;
using Unity.Entities;
using UnityEngine;

namespace Components.Authoring
{
    public class PlatformPrefabAuthoring : AuthoringBehaviour<PlatformPrefab>
    {
        public GameObject value;

        public override bool MarkDependencies(IBaker baker)
        {
            baker.DependsOn(value);

            return value != null;
        }

        public override PlatformPrefab AsComponent(IBaker baker)
        {
            return new PlatformPrefab
            {
                value = baker.GetEntity(value, TransformUsageFlags.Dynamic)
            };
        }
    }

    public class PlatformPrefabBaker : Baker<PlatformPrefabAuthoring>
    {
        public override void Bake(PlatformPrefabAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}