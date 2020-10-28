using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;

namespace CommonECS.Components
{
	[MaterialProperty("_BaseColor", MaterialPropertyFormat.Float4)]
	public struct MaterialBaseColor : IComponentData
	{
		public float4 value;
	}
}