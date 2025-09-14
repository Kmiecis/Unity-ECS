using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ParticleEmissionSphereAuthoring : AuthoringBehaviour<ParticleEmissionSphere>
    {
        public float min;
        public float max;

        public override ParticleEmissionSphere AsComponent(IBaker baker)
        {
            return new ParticleEmissionSphere
            {
                min = min,
                max = max
            };
        }
    }

    public class ParticleEmissionSphereBaker : Baker<ParticleEmissionSphereAuthoring>
    {
        public override void Bake(ParticleEmissionSphereAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}