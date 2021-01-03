using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleRandomSize : IComponentData
	{
		public float min;
		public float max;
	}
}