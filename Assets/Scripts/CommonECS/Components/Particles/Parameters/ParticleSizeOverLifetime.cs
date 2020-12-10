using CommonECS.Structs;
using Unity.Entities;

namespace CommonECS.Components
{
	public struct ParticleSizeOverLifetime : IComponentData
	{
		public BlobAssetReference<SampledAnimationCurve> curveRef;
	}
}