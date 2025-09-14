using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class MaterialAlphaAuthoring : AuthoringBehaviour<MaterialAlpha>
    {
        public float value;

        public override MaterialAlpha AsComponent(IBaker baker)
        {
            return new MaterialAlpha
            {
                value = value
            };
        }
    }

    public class MaterialAlphaBaker : Baker<MaterialAlphaAuthoring>
    {
        public override void Bake(MaterialAlphaAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}