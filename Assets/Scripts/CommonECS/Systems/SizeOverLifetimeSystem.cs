using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Components
{
	public class SizeOverLifetimeSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			Entities
				.WithoutBurst()
				.ForEach((ref NonUniformScale scale, in SizeOverLifetime sizeOverLifetime, in Lifetime lifetime, in Livetime livetime) =>
				{
					var lifetimeNormalized = math.min((livetime.value) / (livetime.value + lifetime.value), 1.0f);
					ref var sizeOverLifetimeCurve = ref sizeOverLifetime.curveRef.Value;
					ref var newScale = ref sizeOverLifetimeCurve.Evaluate(lifetimeNormalized);
					scale.Value = newScale;
				})
				.ScheduleParallel();
		}
	}
}