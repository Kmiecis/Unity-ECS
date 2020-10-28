using CommonECS.Structs;
using Unity.Entities;

namespace CommonECS.Components
{
	public struct SizeOverLifetime : IComponentData
	{
		public BlobAssetReference<AnimationsCurve> curveRef;
	}
}