using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffectRandomScale : IComponentData
	{
		public float min;
		public float max;
	}
}