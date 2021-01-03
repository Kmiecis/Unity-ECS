using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEmissionSphere : IComponentData
	{
		public float min;
		public float max;
	}
}