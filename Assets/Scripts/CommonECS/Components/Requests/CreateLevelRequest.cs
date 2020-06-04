using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	public struct CreateLevelRequest : IComponentData
	{
		public int2 position;
		public int2 size;
	}
}
