using Common.ECS.Components;
using Unity.Entities;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    public class MoveToTargetSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;
            var translationComponents = GetComponentDataFromEntity<Translation>(true);

            Entities.ForEach((ref Translation translation, in MoveToTarget moveTo, in MoveSpeed speed) => {
                if (translationComponents.Exists(moveTo.value))
                {
                    var currentPosition = translation.Value;
                    var targetPosition = translationComponents[moveTo.value].Value;

                    var movement = MoveSystem.GetMovementFromPositions(currentPosition, targetPosition, speed.value, deltaTime);

                    translation.Value += movement;
                }
            }).ScheduleParallel();
        }
    }
}