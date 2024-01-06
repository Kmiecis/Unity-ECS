using CommonECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class LifetimeAuthoring : AuthoringBehaviour<Lifetime>
    {
        public float value;

        public override Lifetime AsComponent(IBaker baker)
        {
            return new Lifetime
            {
                value = value
            };
        }
    }

    public class LifetimeBaker : Baker<LifetimeAuthoring>
    {
        public override void Bake(LifetimeAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}