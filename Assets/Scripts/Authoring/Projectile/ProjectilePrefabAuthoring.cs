using Common.ECS;
using Unity.Entities;
using UnityEngine;

namespace Components.Authoring
{
    public class ProjectilePrefabAuthoring : AuthoringBehaviour<ProjectilePrefab>
    {
        public GameObject value;

        public override bool MarkDependencies(IBaker baker)
        {
            baker.DependsOn(value);

            return value != null;
        }

        public override ProjectilePrefab AsComponent(IBaker baker)
        {
            return new ProjectilePrefab
            {
                value = baker.GetEntity(value, TransformUsageFlags.Dynamic)
            };
        }
    }

    public class ProjectilePrefabBaker : Baker<ProjectilePrefabAuthoring>
    {
        public override void Bake(ProjectilePrefabAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}