using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct RotateToRotation : IComponentData
	{
		public quaternion rotation;
	}
}