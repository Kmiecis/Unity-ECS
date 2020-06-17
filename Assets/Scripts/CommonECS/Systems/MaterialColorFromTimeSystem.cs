using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;

namespace CommonECS.Systems
{
	public class MaterialColorFromTimeSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			var elapsedTime = (float)Time.ElapsedTime;
			Entities.ForEach((ref MaterialColor materialColor ) =>
			{
				materialColor.Value = new float4(
					elapsedTime % 10.0f / 10.0f,
					elapsedTime % 20.0f / 20.0f,
					elapsedTime % 30.0f / 30.0f,
					1f
				);
			}).ScheduleParallel();
		}
	}
}
