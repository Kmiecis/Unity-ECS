using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ApproachSpeedAuthoring : AuthoringBehaviour<ApproachSpeed>
    {
        public float value;

        public override ApproachSpeed AsComponent(IBaker baker)
        {
            return new ApproachSpeed
            {
                value = value
            };
        }
    }

    public class ApproachSpeedBaker : Baker<ApproachSpeedAuthoring>
    {
        public override void Bake(ApproachSpeedAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}