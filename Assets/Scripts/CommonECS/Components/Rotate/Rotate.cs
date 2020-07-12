using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct Rotate : IComponentData
	{
		public quaternion value;
	}
}
