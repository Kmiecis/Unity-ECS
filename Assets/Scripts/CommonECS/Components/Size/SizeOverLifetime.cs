using CommonECS.Structs;
using Unity.Entities;

namespace CommonECS.Components
{
	// Has manually generated authoring
	public struct SizeOverLifetime : IComponentData
	{
		public BlobAssetReference<AnimationsCurve> curveRef;
	}
}