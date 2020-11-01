using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	public struct DestroyTranslation : IComponentData
	{
		public float3 value;
	}
}