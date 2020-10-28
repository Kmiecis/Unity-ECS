using CommonECS.Structs;
using Unity.Entities;

namespace CommonECS.Components
{
	public struct ColorOverLifetime : IComponentData
	{
		public BlobAssetReference<Gradients> gradientsRef;
	}
}