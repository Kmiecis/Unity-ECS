using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffectRandomSpeed : IComponentData
	{
		public float min;
		public float max;
	}
}