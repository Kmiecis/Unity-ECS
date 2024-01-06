using CommonECS;
using Unity.Entities;
using Unity.Mathematics;

namespace Components.Authoring
{
    public class RotateAuthoring : AuthoringBehaviour<Rotate>
    {
        public quaternion value;

        public override Rotate AsComponent(IBaker baker)
        {
            return new Rotate
            {
                value = value
            };
        }
    }

    public class RotateBaker : Baker<RotateAuthoring>
    {
        public override void Bake(RotateAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}