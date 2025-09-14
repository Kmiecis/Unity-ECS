using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class TranslateSpeedAuthoring : AuthoringBehaviour<TranslateSpeed>
    {
        public float value;

        public override TranslateSpeed AsComponent(IBaker baker)
        {
            return new TranslateSpeed
            {
                value = value
            };
        }
    }

    public class TranslateSpeedBaker : Baker<TranslateSpeedAuthoring>
    {
        public override void Bake(TranslateSpeedAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}