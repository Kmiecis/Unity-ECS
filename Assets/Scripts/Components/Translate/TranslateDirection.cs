using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct TranslateDirection : IComponentData
	{
		public float3 value;
	}
}
