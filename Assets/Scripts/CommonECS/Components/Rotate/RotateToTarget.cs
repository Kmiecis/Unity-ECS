using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct RotateToTarget : IComponentData
	{
		public Entity value;
	}
}
