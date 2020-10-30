using CommonECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class ApproachSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			Entities
				.ForEach((ref ApproachPosition position, ref ApproachTarget target) =>
				{
					var entity = target.value;
					if (HasComponent<Translation>(entity))
					{
						var translation = GetComponent<Translation>(entity);

						position.value = translation.Value;
					}
				})
				.ScheduleParallel();

			var deltaTime = Time.DeltaTime;

			Entities
				.ForEach((ref Translation translation, ref ApproachCheck check, in ApproachPosition position, in ApproachSpeed speed, in ApproachDistance distance) =>
				{
					var currentPosition = translation.Value;
					var targetPosition = position.value;

					var direction = targetPosition - currentPosition;

					if (math.lengthsq(direction) > 0)
						direction = math.normalize(direction);

					var movement = direction * speed.value * deltaTime;

					var newPosition = currentPosition + movement;

					var da = newPosition - currentPosition;
					var db = targetPosition - newPosition;

					var hasReached = math.dot(da, db) < 0;
					if (hasReached)
						movement = targetPosition - currentPosition;

					translation.Value += movement;
					check.value = hasReached;
				})
				.ScheduleParallel();
		}
	}
}