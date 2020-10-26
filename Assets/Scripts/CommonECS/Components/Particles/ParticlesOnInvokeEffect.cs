using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticlesOnInvokeEffect : IComponentData
	{
		public bool invoke;
		public Entity effect;
	}
}