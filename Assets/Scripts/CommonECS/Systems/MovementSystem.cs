using CommonECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class MovementSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			Entities
				.ForEach((ref Translate translate, ref RotateSmoothly rotate, in MovementInput movementInput, in Rotation rotation) =>
				{
					translate.value = movementInput.direction;
					if (movementInput.moves)
					{
						rotate.fromRotation = rotation.Value;
						rotate.toRotation = quaternion.LookRotation(movementInput.direction, math.up());
						rotate.timeRotation = 0.0f;
					}
				})
				.ScheduleParallel();
		}
	}
}