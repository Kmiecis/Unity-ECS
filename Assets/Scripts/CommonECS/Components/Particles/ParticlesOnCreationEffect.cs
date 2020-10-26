using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticlesOnCreationEffect : IComponentData
	{
		public Entity effect;
	}
}