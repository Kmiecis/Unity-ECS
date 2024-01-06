using CommonECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ParticleTagAuthoring : AuthoringBehaviour<ParticleTag>
    {
    }

    public class ParticleTagBaker : Baker<ParticleTagAuthoring>
    {
        public override void Bake(ParticleTagAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}