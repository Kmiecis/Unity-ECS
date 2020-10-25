using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct TranslateToPosition : IComponentData
	{
		public float3 value;
	}
}
