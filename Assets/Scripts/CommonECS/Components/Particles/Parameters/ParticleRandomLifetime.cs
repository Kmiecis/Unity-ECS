using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleRandomLifetime : IComponentData
	{
		public float min;
		public float max;
	}
}