using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	public struct TranslateToPosition : IComponentData
	{
		public float3 value;
		public float speed;
	}
}
