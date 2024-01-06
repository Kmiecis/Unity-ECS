using CommonECS;
using Unity.Entities;
using Unity.Mathematics;

namespace Components.Authoring
{
    public class RotateToRotationAuthoring : AuthoringBehaviour<RotateToRotation>
    {
        public float3 rotation;

        public override RotateToRotation AsComponent(IBaker baker)
        {
            return new RotateToRotation
            {
                rotation = quaternion.Euler(rotation)
            };
        }
    }

    public class RotateToRotationBaker : Baker<RotateToRotationAuthoring>
    {
        public override void Bake(RotateToRotationAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}