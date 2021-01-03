using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticlesPlay : IComponentData
	{
		public bool value;
	}
}