using CommonECS.Components;
using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Systems
{
	public class ColorOverLifetimeSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			Entities
				.ForEach((ref MaterialBaseColor materialColor, in ColorOverLifetime colorOverLifetime, in Lifetime lifetime, in Livetime livetime) =>
				{
					var lifetimeNormalized = math.min((livetime.value) / (livetime.value + lifetime.value), 1.0f);
					ref var colorOverLifetimeGradients = ref colorOverLifetime.gradientsRef.Value;
					ref var newColor = ref colorOverLifetimeGradients.Evaluate(lifetimeNormalized);
					materialColor.value = newColor;
				})
				.ScheduleParallel();
		}
	}
}