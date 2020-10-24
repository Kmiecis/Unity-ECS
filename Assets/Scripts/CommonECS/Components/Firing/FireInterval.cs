using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct FireInterval : IComponentData
	{
		public float value;
	}
}