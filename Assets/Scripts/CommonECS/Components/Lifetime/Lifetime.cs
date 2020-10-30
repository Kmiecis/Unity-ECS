using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct Lifetime : IComponentData
	{
		public float value;
	}
}