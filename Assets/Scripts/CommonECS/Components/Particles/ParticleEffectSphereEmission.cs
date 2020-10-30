using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffectSphereEmission : IComponentData
	{
		public float min;
		public float max;
	}
}