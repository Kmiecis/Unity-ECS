using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ApproachPosition : IComponentData
	{
		public float3 value;
	}
}