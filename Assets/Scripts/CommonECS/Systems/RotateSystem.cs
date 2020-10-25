using CommonECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class RotateSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			Entities.ForEach((ref Rotation rotation, in Rotate rotate) =>
			{
				rotation.Value = math.normalizesafe(math.mul(rotation.Value, rotate.value));
			}
			).ScheduleParallel();
		}
	}
}