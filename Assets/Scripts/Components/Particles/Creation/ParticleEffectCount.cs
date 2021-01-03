using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffectCount : IComponentData
	{
		public int value;
	}
}