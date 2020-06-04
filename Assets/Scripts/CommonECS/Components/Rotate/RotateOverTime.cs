using CommonECS.Mathematics;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct RotateOverTime : IComponentData
	{
		public quaternion fromRotation;
		public quaternion toRotation;
		public float timeRotation;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetFromDirection(float3 direction, Rotation rotation)
		{
			fromRotation = rotation.Value;
			toRotation = math.mul(fromRotation, quaternion.LookRotation(direction, axis.UP));
			timeRotation = 0f;
		}
	}
}
