using CommonECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class PlayerTagAuthoring : AuthoringBehaviour<PlayerTag>
    {
    }

    public class PlayerTagBaker : Baker<PlayerTagAuthoring>
    {
        public override void Bake(PlayerTagAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}