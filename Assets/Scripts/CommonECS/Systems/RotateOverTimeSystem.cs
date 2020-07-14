using CommonECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class RotateOverTimeSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			var deltaTime = Time.DeltaTime;

			Entities.ForEach((ref Rotation rotation, ref RotateOverTime rotate) =>
			{
				if (rotate.timeRotation < 1f)
				{
					rotate.timeRotation = math.min(rotate.timeRotation + rotate.speed * deltaTime, 1f);
					rotation.Value = math.slerp(rotate.fromRotation, rotate.toRotation, rotate.timeRotation);
				}
			}
			).ScheduleParallel();
		}
	}
}
