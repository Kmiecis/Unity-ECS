using Structs;
using Unity.Entities;

namespace Components
{
    public struct ColorOverLifetime : IComponentData
    {
        public BlobAssetReference<SampledGradient> gradientsRef;
    }
}