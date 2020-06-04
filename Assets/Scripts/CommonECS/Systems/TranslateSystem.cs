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

			Entities.ForEach((ref Translation translation, in Translate translate, in TranslateSpeed speed) => {
				translation.Value += translate.value * speed.value * deltaTime;
			}).ScheduleParallel();
		}
	}
}
