using CommonECS;
using Unity.Entities;
using Unity.Mathematics;

namespace Components.Authoring
{
    public class ProjectileSpawnAuthoring : AuthoringBehaviour<ProjectileSpawn>
    {
        public float3 offset;
        public quaternion rotation;

        public override ProjectileSpawn AsComponent(IBaker baker)
        {
            return new ProjectileSpawn
            {
                offset = offset,
                rotation = rotation
            };
        }
    }

    public class ProjectileSpawnBaker : Baker<ProjectileSpawnAuthoring>
    {
        public override void Bake(ProjectileSpawnAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}