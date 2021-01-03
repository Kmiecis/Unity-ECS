using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct RotateSpeed : IComponentData
	{
		public float value;
	}
}
