using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct SizeReference : IComponentData
	{
		public float value;
	}
}