using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct PlatformPrefab : IComponentData
	{
		public Entity value;
	}
}
