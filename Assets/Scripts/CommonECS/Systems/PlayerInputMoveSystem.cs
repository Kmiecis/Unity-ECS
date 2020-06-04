using CommonECS.Components;
using Unity.Entities;

namespace CommonECS.Systems
{
	public class PlayerInputMoveSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			Entities.ForEach((ref Translate translate, in PlayerInput player) => {
				translate.value = player.direction;
			}).ScheduleParallel();
		}
	}
}
