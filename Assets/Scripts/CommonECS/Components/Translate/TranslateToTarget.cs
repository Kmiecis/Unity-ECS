using Unity.Entities;

namespace CommonECS.Components
{
	public struct TranslateToTarget : IComponentData
	{
		public Entity value;
		public float speed;
	}
}
