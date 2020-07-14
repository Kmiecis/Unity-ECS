using Unity.Entities;

namespace CommonECS.Components
{
	public struct RotateToTarget : IComponentData
	{
		public Entity value;
		public float speed;
	}
}
