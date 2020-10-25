using CommonECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class TranslateToPositionSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			var deltaTime = Time.DeltaTime;

			Entities
				.ForEach((ref Translation translation, in TranslateToPosition translate, in TranslateSpeed speed) =>
				{
					var currentPosition = translation.Value;
					var targetPosition = translate.value;

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
				}
				).ScheduleParallel();
		}
	}
}