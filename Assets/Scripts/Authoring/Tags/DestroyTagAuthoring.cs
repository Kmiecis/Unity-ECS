using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class DestroyTagAuthoring : AuthoringBehaviour<DestroyTag>
    {
    }

    public class DestroyTagBaker : Baker<DestroyTagAuthoring>
    {
        public override void Bake(DestroyTagAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}