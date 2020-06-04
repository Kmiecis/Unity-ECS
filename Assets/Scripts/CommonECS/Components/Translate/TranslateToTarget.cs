using Unity.Entities;

namespace CommonECS.Components
{
	public struct TranslateToTarget : IComponentData
	{
		public Entity value;
	}
}
