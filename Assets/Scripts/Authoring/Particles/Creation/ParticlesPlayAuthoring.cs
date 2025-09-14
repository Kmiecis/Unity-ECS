using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ParticlesPlayAuthoring : AuthoringBehaviour<ParticlesPlay>
    {
        public bool value;

        public override ParticlesPlay AsComponent(IBaker baker)
        {
            return new ParticlesPlay
            {
                value = value
            };
        }
    }

    public class ParticlesPlayBaker : Baker<ParticlesPlayAuthoring>
    {
        public override void Bake(ParticlesPlayAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}