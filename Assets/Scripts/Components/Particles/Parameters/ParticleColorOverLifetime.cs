using Structs;
using Unity.Entities;

namespace Components
{
    public struct ParticleColorOverLifetime : IComponentData
    {
        public BlobAssetReference<SampledGradient> gradientsRef;
    }
}