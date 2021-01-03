using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ApproachSpeed : IComponentData
	{
		public float value;
	}
}