using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class SizeReferenceAuthoring : AuthoringBehaviour<SizeReference>
    {
        public override SizeReference AsComponent(IBaker baker)
        {
            var scale = transform.localScale;

            return new SizeReference
            {
                value = (scale.x + scale.y + scale.z) * (1.0f / 3.0f)
            };
        }
    }

    public class SizeReferenceBaker : Baker<SizeReferenceAuthoring>
    {
        public override void Bake(SizeReferenceAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}