using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct MovementInput : IComponentData
	{
		public bool moves;
		public float3 direction;
	}
}