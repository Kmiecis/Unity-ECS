using CommonECS;
using Unity.Entities;
using Unity.Mathematics;

namespace Components.Authoring
{
    public class TranslateDirectionAuthoring : AuthoringBehaviour<TranslateDirection>
    {
        public float3 value;

        public override TranslateDirection AsComponent(IBaker baker)
        {
            return new TranslateDirection
            {
                value = value
            };
        }
    }

    public class TranslateDirectionBaker : Baker<TranslateDirectionAuthoring>
    {
        public override void Bake(TranslateDirectionAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}