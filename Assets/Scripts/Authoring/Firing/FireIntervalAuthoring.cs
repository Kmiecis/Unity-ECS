using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class FireIntervalAuthoring : AuthoringBehaviour<FireInterval>
    {
        public float value;

        public override FireInterval AsComponent(IBaker baker)
        {
            return new FireInterval
            {
                value = value
            };
        }
    }

    public class FireIntervalBaker : Baker<FireIntervalAuthoring>
    {
        public override void Bake(FireIntervalAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}