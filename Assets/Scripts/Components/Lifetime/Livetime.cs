using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct Livetime : IComponentData
	{
		public float value;
	}
}