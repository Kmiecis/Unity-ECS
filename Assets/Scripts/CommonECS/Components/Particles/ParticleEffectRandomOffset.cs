using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffectRandomOffset : IComponentData
	{
		public float3 min;
		public float3 max;
	}
}