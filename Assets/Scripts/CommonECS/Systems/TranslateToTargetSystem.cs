using CommonECS.Components;
using Unity.Entities;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class TranslateToTargetSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			var deltaTime = Time.DeltaTime;
			var translationComponents = GetComponentDataFromEntity<Translation>(true);

			Entities.ForEach((ref Translation translation, in TranslateToTarget translate, in TranslateSpeed speed) =>
			{
				if (translationComponents.HasComponent(translate.value))
				{
					var currentPosition = translation.Value;
					var targetPosition = translationComponents[translate.value].Value;

					var movement = TranslateTools.GetTranslationFromPositions(
						currentPosition, targetPosition, speed.value, deltaTime
					);

					translation.Value += movement;
				}
			}
			).ScheduleParallel();
		}
	}
}
