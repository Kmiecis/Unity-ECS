using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class ApproachCheckAuthoring : AuthoringBehaviour<ApproachCheck>
    {
        public bool value;

        public override ApproachCheck AsComponent(IBaker baker)
        {
            return new ApproachCheck
            {
                value = value
            };
        }
    }

    public class ApproachCheckBaker : Baker<ApproachCheckAuthoring>
    {
        public override void Bake(ApproachCheckAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}