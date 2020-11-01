using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	public struct DestroyScale : IComponentData
	{
		public float3 value;
	}
}