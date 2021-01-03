using CommonECS.Components;
using CommonECS.Mathematics;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class RotateToRotationSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			var deltaTime = Time.DeltaTime;

			Entities
				.ForEach((ref Rotation rotation, in RotateToRotation rotate, in RotateSpeed speed) =>
				{
					var currentRotation = rotation.Value;
					var targetRotation = rotate.rotation;

					var radians = math.radians(speed.value);
					var newRotation = mathx.rotate_towards(currentRotation, targetRotation, radians * deltaTime);

					rotation.Value = newRotation;
				})
				.ScheduleParallel();
		}
	}
}