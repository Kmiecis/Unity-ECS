using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Components
{
	public static class RotateTools
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion GetRotationFromPositions(float3 currentPosition, float3 targetPosition)
		{
			var heading = targetPosition - currentPosition;
			heading.y = 0f;

			return quaternion.LookRotation(heading, math.up());
		}
	}
}
