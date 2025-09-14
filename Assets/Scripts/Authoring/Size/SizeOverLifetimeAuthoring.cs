using Common.ECS;
using Structs;
using Unity.Entities;
using UnityEngine;

namespace Components.Authoring
{
    [RequireComponent(typeof(SizeReferenceAuthoring))]
    public class SizeOverLifetimeAuthoring : AuthoringBehaviour<SizeOverLifetime>
    {
        public int samples = byte.MaxValue;
        public AnimationCurve curve;

        public override SizeOverLifetime AsComponent(IBaker baker)
        {
            return new SizeOverLifetime
            {
                curveRef = SampledAnimationCurve.ConstructBlobAssetReference(curve, samples)
            };
        }
    }

    public class SizeOverLifetimeBaker : Baker<SizeOverLifetimeAuthoring>
    {
        public override void Bake(SizeOverLifetimeAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}