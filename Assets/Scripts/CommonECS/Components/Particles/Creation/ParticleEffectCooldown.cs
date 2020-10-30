using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffectCooldown : IComponentData
	{
		public float value;
	}
}