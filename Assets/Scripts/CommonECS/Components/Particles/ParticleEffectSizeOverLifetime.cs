using CommonECS.Structs;
using Unity.Entities;

namespace CommonECS.Components
{
	public struct ParticleEffectSizeOverLifetime : IComponentData
	{
		public BlobAssetReference<AnimationsCurve> curveRef;
	}
}