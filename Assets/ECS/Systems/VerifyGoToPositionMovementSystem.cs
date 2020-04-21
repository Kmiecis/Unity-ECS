using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    [UpdateAfter(typeof(ApplySpeedSystem))]
    [UpdateBefore(typeof(ApplyMovementSystem))]
    public class VerifyGoToPositionMovementSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var jobHandle = Entities.ForEach((ref Movement movement, in Translation translation, in GoToPosition position) =>
            {
                var currentPosition = translation.Value;
                var targetPosition = position.value;
                var newPosition = currentPosition + movement.value;

                var da = newPosition - currentPosition;
                var db = targetPosition - newPosition;
                var hasReached = math.dot(da, db) < 0;

                if (hasReached)
                {
                    movement.value = targetPosition - currentPosition;
                }
            }
            ).Schedule(inputDeps);
            return jobHandle;
        }
    }
}