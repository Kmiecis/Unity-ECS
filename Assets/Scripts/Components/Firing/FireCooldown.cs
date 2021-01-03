using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct FireCooldown : IComponentData
	{
		public float value;
	}
}