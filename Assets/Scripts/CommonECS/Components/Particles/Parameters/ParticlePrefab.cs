using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticlePrefab : IComponentData
	{
		public Entity value;
	}
}