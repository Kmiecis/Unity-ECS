using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    [AlwaysSynchronizeSystem]
    [UpdateAfter(typeof(ApplySpeedSystem))]
    [UpdateBefore(typeof(ApplyMovementSystem))]
    public class VerifyFollowTargetMovementSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var translationComponents = GetComponentDataFromEntity<Translation>(true);
            Entities.ForEach((ref Movement movement, in Translation translation, in FollowTarget target) =>
            {
                if (translationComponents.Exists(target.value))
                {
                    var currentPosition = translation.Value;
                    var targetPosition = translationComponents[target.value].Value;
                    var newPosition = currentPosition + movement.value;

                    var da = newPosition - currentPosition;
                    var db = targetPosition - newPosition;
                    var hasReached = math.dot(da, db) < 0;
                    
                    if (hasReached)
                    {
                        movement.value = targetPosition - currentPosition;
                    }
                }
            }
            ).Run();
            return default;
        }
    }
}