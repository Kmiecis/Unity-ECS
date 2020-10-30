using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleBurstEffect : IComponentData
	{
		public Entity particle;
		public int count;
	}
}