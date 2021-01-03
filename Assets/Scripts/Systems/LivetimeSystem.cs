using CommonECS.Components;
using Unity.Entities;

namespace CommonECS.Systems
{
	public class LivetimeSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			var deltaTime = Time.DeltaTime;

			Entities
				.ForEach((ref Livetime livetime) =>
				{
					livetime.value += deltaTime;
				})
				.ScheduleParallel();
		}
	}
}