using Common.ECS.Components;
using Unity.Entities;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    public class MoveToPositionSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;

            Entities.ForEach((ref Translation translation, in MoveToPosition moveTo, in MoveSpeed speed) => {
                var currentPosition = translation.Value;
                var targetPosition = moveTo.value;

                var movement = MoveSystem.GetMovementFromPositions(currentPosition, targetPosition, speed.value, deltaTime);

                translation.Value += movement;
            }).ScheduleParallel();
        }
    }
}