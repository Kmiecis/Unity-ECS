using CommonECS;
using Unity.Entities;
using UnityEngine;

namespace Components.Authoring
{
    public class CubeDataAuthoring : AuthoringBehaviour<CubeData>
    {
        public GameObject prefab;

        public override bool MarkDependencies(IBaker baker)
        {
            baker.DependsOn(prefab);

            return prefab != null;
        }

        public override CubeData AsComponent(IBaker baker)
        {
            return new CubeData
            {
                prefab = baker.GetEntity(prefab, TransformUsageFlags.Dynamic)
            };
        }

        public class Baker : Baker<CubeDataAuthoring>
        {
            public override void Bake(CubeDataAuthoring authoring)
            {
                authoring.Bake(this);
            }
        }
    }
}