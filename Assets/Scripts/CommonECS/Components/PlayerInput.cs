using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct PlayerInput : IComponentData
	{
		public bool moves;
		public float3 direction;
	}
}
