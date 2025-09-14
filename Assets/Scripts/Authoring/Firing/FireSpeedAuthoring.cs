using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class FireSpeedAuthoring : AuthoringBehaviour<FireSpeed>
    {
        public float value;

        public override FireSpeed AsComponent(IBaker baker)
        {
            return new FireSpeed
            {
                value = value
            };
        }
    }

    public class FireSpeedBaker : Baker<FireSpeedAuthoring>
    {
        public override void Bake(FireSpeedAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}