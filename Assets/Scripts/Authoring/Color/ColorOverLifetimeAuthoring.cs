using CommonECS;
using Structs;
using Unity.Entities;
using UnityEngine;

namespace Components.Authoring
{
    [RequireComponent(typeof(MaterialBaseColorAuthoring))]
    public class ColorOverLifetimeAuthoring : AuthoringBehaviour<ColorOverLifetime>
    {
        public int samples = byte.MaxValue;
        public Gradient gradient;

        public override ColorOverLifetime AsComponent(IBaker baker)
        {
            return new ColorOverLifetime
            {
                gradientsRef = SampledGradient.CreateBlobAssetReference(gradient, samples)
            };
        }

        private void OnValidate()
        {
            if (TryGetComponent<MaterialBaseColorAuthoring>(out var component))
            {
                component.value = gradient.Evaluate(0.0f);
            }
        }
    }

    public class ColorOverLifetimeBaker : Baker<ColorOverLifetimeAuthoring>
    {
        public override void Bake(ColorOverLifetimeAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}