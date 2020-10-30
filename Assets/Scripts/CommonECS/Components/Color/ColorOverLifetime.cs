using CommonECS.Structs;
using Unity.Entities;

namespace CommonECS.Components
{
	// Has manually generated authoring
	public struct ColorOverLifetime : IComponentData
	{
		public BlobAssetReference<Gradients> gradientsRef;
	}
}