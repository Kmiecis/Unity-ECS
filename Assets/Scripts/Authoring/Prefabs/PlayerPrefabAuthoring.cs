using Common.ECS;
using Unity.Entities;
using UnityEngine;

namespace Components.Authoring
{
    public class PlayerPrefabAuthoring : AuthoringBehaviour<PlayerPrefab>
    {
        public GameObject value;

        public override bool MarkDependencies(IBaker baker)
        {
            baker.DependsOn(value);

            return value != null;
        }

        public override PlayerPrefab AsComponent(IBaker baker)
        {
            return new PlayerPrefab
            {
                value = baker.GetEntity(value, TransformUsageFlags.Dynamic)
            };
        }
    }

    public class PlayerPrefabBaker : Baker<PlayerPrefabAuthoring>
    {
        public override void Bake(PlayerPrefabAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}