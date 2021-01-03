using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ApproachTarget : IComponentData
	{
		public Entity value;
	}
}