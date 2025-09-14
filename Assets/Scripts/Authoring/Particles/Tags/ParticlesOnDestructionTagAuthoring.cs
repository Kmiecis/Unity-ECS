using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ParticlesOnDestructionTagAuthoring : AuthoringBehaviour<ParticlesOnDestructionTag>
    {
    }

    public class ParticlesOnDestructionTagBaker : Baker<ParticlesOnDestructionTagAuthoring>
    {
        public override void Bake(ParticlesOnDestructionTagAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}