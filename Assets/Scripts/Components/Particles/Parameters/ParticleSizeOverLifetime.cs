using Structs;
using Unity.Entities;

namespace Components
{
    public struct ParticleSizeOverLifetime : IComponentData
    {
        public BlobAssetReference<SampledAnimationCurve> curveRef;
    }
}