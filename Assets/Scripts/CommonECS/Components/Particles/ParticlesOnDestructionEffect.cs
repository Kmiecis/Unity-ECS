using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticlesOnDestructionEffect : IComponentData
	{
		public Entity effect;
	}
}