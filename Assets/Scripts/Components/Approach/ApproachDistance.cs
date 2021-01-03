using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ApproachDistance : IComponentData
	{
		public float value;
	}
}