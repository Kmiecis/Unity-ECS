using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ApproachCheck : IComponentData
	{
		public bool value;
	}
}