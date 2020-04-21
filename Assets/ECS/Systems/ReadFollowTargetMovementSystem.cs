using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    [UpdateBefore(typeof(ApplySpeedSystem))]
    public class ReadFollowTargetMovementSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            var translationComponents = GetComponentDataFromEntity<Translation>(true);
            var jobHandle = Entities.ForEach((ref Movement movement, in Translation translation, in FollowTarget target) =>
            {
                if (translationComponents.Exists(target.value))
                {
                    var entityPosition = translation.Value;
                    var targetPosition = translationComponents[target.value].Value;
                    var deltaPosition = targetPosition - entityPosition;

                    if (math.lengthsq(deltaPosition) > 0)
                    {
                        deltaPosition = math.normalize(deltaPosition);
                    }

                    movement.value = deltaPosition * deltaTime;
                }
                else
                {
                    movement.value = 0f;
                }
            }
            ).Schedule(inputDeps);
            return jobHandle;
        }
    }
}