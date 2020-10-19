using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct RotateSmoothly : IComponentData
	{
		public quaternion fromRotation;
		public quaternion toRotation;
		public float timeRotation;
	}
}
