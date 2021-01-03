using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct PlayerPrefab : IComponentData
	{
		public Entity value;
	}
}
