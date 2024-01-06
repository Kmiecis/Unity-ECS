using CommonECS;
using Structs;
using Unity.Entities;
using UnityEngine;

namespace Components.Authoring
{
    public class ParticleColorOverLifetimeAuthoring : AuthoringBehaviour<ParticleColorOverLifetime>
    {
        public int samples = byte.MaxValue;
        public Gradient gradient;

        public override ParticleColorOverLifetime AsComponent(IBaker baker)
        {
            return new ParticleColorOverLifetime
            {
                gradientsRef = SampledGradient.CreateBlobAssetReference(gradient, samples)
            };
        }
    }

    public class ParticleColorOverLifetimeBaker : Baker<ParticleColorOverLifetimeAuthoring>
    {
        public override void Bake(ParticleColorOverLifetimeAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}