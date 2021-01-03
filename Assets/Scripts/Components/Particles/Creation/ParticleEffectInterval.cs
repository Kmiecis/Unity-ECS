using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffectInterval : IComponentData
	{
		public float value;
	}
}