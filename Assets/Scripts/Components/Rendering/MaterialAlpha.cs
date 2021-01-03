using Unity.Entities;
using Unity.Rendering;

namespace CommonECS.Components
{
	[MaterialProperty("_Alpha", MaterialPropertyFormat.Float)]
	public struct MaterialAlpha : IComponentData
	{
		public float value;
	}
}