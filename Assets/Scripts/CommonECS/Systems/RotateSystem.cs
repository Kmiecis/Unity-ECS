using CommonECS.Components;
using CommonECS.Mathematics;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class RotateSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			Entities.ForEach((ref Rotation rotation, in Rotate rotate) =>
			{
				rotation.Value = math.normalizesafe(math.mul(rotation.Value, rotate.value));
			}
			).ScheduleParallel();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion GetRotationFromPositions(float3 currentPosition, float3 targetPosition)
		{
			var heading = targetPosition - currentPosition;
			heading.y = 0f;

			return quaternion.LookRotation(heading, axis.UP);
		}
	}
}
