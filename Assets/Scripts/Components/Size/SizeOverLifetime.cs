using Structs;
using Unity.Entities;

namespace Components
{
    public struct SizeOverLifetime : IComponentData
    {
        public BlobAssetReference<SampledAnimationCurve> curveRef;
    }
}