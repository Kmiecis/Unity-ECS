using Unity.Entities;

namespace CommonECS.Components
{
	public struct RotateToTarget : IComponentData
	{
		public Entity value;
	}
}
