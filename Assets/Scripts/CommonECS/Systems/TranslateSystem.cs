using CommonECS.Components;
using Unity.Entities;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class TranslateSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			var deltaTime = Time.DeltaTime;

			Entities.ForEach((ref Translation translation, in Translate translate) =>
			{
				translation.Value += translate.value * translate.speed * deltaTime;
			}
			).ScheduleParallel();
		}
	}
}
