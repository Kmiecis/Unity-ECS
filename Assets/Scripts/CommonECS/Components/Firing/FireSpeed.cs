using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct FireSpeed : IComponentData
	{
		public float value;
	}
}