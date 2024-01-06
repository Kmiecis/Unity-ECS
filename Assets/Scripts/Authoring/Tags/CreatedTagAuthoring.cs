using CommonECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class CreatedTagAuthoring : AuthoringBehaviour<CreatedTag>
    {
    }

    public class CreatedTagBaker : Baker<CreatedTagAuthoring>
    {
        public override void Bake(CreatedTagAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}