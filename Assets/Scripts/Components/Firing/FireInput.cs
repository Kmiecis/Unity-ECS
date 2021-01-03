using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct FireInput : IComponentData
	{
		public bool fire;
	}
}