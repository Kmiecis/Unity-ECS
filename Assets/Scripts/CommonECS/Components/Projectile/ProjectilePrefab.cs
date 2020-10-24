using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ProjectilePrefab : IComponentData
	{
		public Entity value;
	}
}