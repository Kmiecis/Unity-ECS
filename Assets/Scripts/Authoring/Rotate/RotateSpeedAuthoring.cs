using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class RotateSpeedAuthoring : AuthoringBehaviour<RotateSpeed>
    {
        public float value;

        public override RotateSpeed AsComponent(IBaker baker)
        {
            return new RotateSpeed
            {
                value = value
            };
        }
    }

    public class RotateSpeedBaker : Baker<RotateSpeedAuthoring>
    {
        public override void Bake(RotateSpeedAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}