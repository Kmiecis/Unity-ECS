using Common.ECS;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Components.Authoring
{
    public class MaterialBaseColorAuthoring : AuthoringBehaviour<MaterialBaseColor>
    {
        public Color value;

        public override MaterialBaseColor AsComponent(IBaker baker)
        {
            return new MaterialBaseColor { value = new float4(value.r, value.g, value.b, value.a) };
        }

        private void Reset()
        {
            if (TryGetComponent<ColorOverLifetimeAuthoring>(out var component))
            {
                value = component.gradient.Evaluate(0.0f);
            }
        }
    }

    public class MaterialBaseColorBaker : Baker<MaterialBaseColorAuthoring>
    {
        public override void Bake(MaterialBaseColorAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}