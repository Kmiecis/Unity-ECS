using CommonECS.Components;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;
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
