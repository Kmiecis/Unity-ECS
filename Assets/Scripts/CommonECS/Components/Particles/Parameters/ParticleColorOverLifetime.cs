using CommonECS.Structs;
using Unity.Entities;

namespace CommonECS.Components
{
	public struct ParticleColorOverLifetime : IComponentData
	{
		public BlobAssetReference<Gradients> gradientsRef;
	}
}