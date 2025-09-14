using Common.ECS;
using Unity.Entities;
using Unity.Mathematics;

namespace Components.Authoring
{
    public class ApproachPositionAuthoring : AuthoringBehaviour<ApproachPosition>
    {
        public float3 value;

        public override ApproachPosition AsComponent(IBaker baker)
        {
            return new ApproachPosition
            {
                value = value
            };
        }
    }

    public class ApproachPositionBaker : Baker<ApproachPositionAuthoring>
    {
        public override void Bake(ApproachPositionAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}