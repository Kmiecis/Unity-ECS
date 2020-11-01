using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	public struct DestroyRotation : IComponentData
	{
		public quaternion value;
	}
}