using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct Castable : IComponentData
	{
		public Entity prefab;
		public float3 offset;
	}
}