using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffect : IComponentData
	{
		public Entity particle;
		public int count;
	}
}