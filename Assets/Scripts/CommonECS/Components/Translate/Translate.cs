using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct Translate : IComponentData
	{
		public float3 value;
	}
}
