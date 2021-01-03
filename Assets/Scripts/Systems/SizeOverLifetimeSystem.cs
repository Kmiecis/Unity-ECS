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
				.ForEach((ref NonUniformScale scale, in SizeReference sizeReference, in SizeOverLifetime sizeOverLifetime, in Lifetime lifetime, in Livetime livetime) =>
				{
					var lifetimeNormalized = math.min((livetime.value) / (livetime.value + lifetime.value), 1.0f);
					ref var sizeOverLifetimeCurve = ref sizeOverLifetime.curveRef.Value;
					var sizeEvaluated = sizeOverLifetimeCurve.Evaluate(lifetimeNormalized);
					scale.Value = sizeEvaluated * sizeReference.value;
				})
				.ScheduleParallel();
		}
	}
}