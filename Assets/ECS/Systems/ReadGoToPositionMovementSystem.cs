using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    [AlwaysSynchronizeSystem]
    [UpdateBefore(typeof(ApplySpeedSystem))]
    public class ReadGoToPositionMovementSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            Entities.ForEach((ref Movement movement, in Translation translation, in GoToPosition position) =>
            {
                var entityPosition = translation.Value;
                var targetPosition = position.value;
                var deltaPosition = targetPosition - entityPosition;

                if (math.lengthsq(deltaPosition) > 0)
                {
                    deltaPosition = math.normalize(deltaPosition);
                }

                movement.value = deltaPosition * deltaTime;
            }
            ).Run();
            return default;
        }
    }
}