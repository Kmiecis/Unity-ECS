using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleRandomSpeed : IComponentData
	{
		public float min;
		public float max;
	}
}