using CommonECS.Components;
using Unity.Entities;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class TranslateToPositionSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			var deltaTime = Time.DeltaTime;

			Entities.ForEach((ref Translation translation, in TranslateToPosition translate) =>
			{
				var currentPosition = translation.Value;
				var targetPosition = translate.value;

				var movement = TranslateTools.GetTranslationFromPositions(
					currentPosition, targetPosition, translate.speed, deltaTime
				);

				translation.Value += movement;
			}
			).ScheduleParallel();
		}
	}
}
