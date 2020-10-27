using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffect : IComponentData
	{
		public Entity particle;
		public int count;
	}
}