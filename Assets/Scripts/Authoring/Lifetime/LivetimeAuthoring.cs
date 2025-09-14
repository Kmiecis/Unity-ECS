using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class LivetimeAuthoring : AuthoringBehaviour<Livetime>
    {
        public float value;

        public override Livetime AsComponent(IBaker baker)
        {
            return new Livetime
            {
                value = value
            };
        }
    }

    public class LivetimeBaker : Baker<LivetimeAuthoring>
    {
        public override void Bake(LivetimeAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}