using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffectRandomSize : IComponentData
	{
		public float min;
		public float max;
	}
}