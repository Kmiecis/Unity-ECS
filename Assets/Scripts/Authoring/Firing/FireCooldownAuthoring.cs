using CommonECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class FireCooldownAuthoring : AuthoringBehaviour<FireCooldown>
    {
        public float value;

        public override FireCooldown AsComponent(IBaker baker)
        {
            return new FireCooldown
            {
                value = value
            };
        }
    }

    public class FireCooldownBaker : Baker<FireCooldownAuthoring>
    {
        public override void Bake(FireCooldownAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}