using CommonECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ApproachDistanceAuthoring : AuthoringBehaviour<ApproachDistance>
    {
        public float value;

        public override ApproachDistance AsComponent(IBaker baker)
        {
            return new ApproachDistance
            {
                value = value
            };
        }
    }

    public class ApproachDistanceBaker : Baker<ApproachDistanceAuthoring>
    {
        public override void Bake(ApproachDistanceAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}