using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ParticlesOnCreationTagAuthoring : AuthoringBehaviour<ParticlesOnCreationTag>
    {
    }

    public class ParticlesOnCreationTagBaker : Baker<ParticlesOnCreationTagAuthoring>
    {
        public override void Bake(ParticlesOnCreationTagAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}