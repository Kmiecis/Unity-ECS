using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	public struct Rotate : IComponentData
	{
		public quaternion value;
	}
}
