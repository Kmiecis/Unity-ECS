using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffectRandomLifetime : IComponentData
	{
		public float min;
		public float max;
	}
}