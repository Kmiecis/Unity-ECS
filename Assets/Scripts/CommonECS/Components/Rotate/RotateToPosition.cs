using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct RotateToPosition : IComponentData
	{
		public float3 value;
	}
}
