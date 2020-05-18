using Common.ECS.Components;
using Unity.Entities;

namespace Common.ECS.Systems
{
    public class PlayerInputMoveSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref Move move, in PlayerInput player) => {
                move.value = player.direction;
            }).ScheduleParallel();
        }
    }
}