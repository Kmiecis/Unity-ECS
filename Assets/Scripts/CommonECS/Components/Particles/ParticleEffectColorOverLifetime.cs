using CommonECS.Structs;
using Unity.Entities;

namespace CommonECS.Components
{
	public struct ParticleEffectColorOverLifetime : IComponentData
	{
		public BlobAssetReference<Gradients> gradientsRef;
	}
}