using Common.ECS;
using Structs;
using Unity.Entities;
using UnityEngine;

namespace Components
{
    public class ParticleSizeOverLifetimeAuthoring : AuthoringBehaviour<ParticleSizeOverLifetime>
    {
        public int samples = byte.MaxValue;
        public AnimationCurve curve;

        public override ParticleSizeOverLifetime AsComponent(IBaker baker)
        {
            return new ParticleSizeOverLifetime
            {
                curveRef = SampledAnimationCurve.ConstructBlobAssetReference(curve, samples)
            };
        }
    }

    public class ParticleSizeOverLifetimeBaker : Baker<ParticleSizeOverLifetimeAuthoring>
    {
        public override void Bake(ParticleSizeOverLifetimeAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}