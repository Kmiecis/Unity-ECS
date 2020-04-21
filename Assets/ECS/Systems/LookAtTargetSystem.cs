using Common.ECS.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    public class LookAtTargetSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var translationComponents = GetComponentDataFromEntity<Translation>(true);
            var jobHandle = Entities.ForEach((ref Rotation rotation, in Translation translation, in LookAtTarget target) =>
            {
                if (translationComponents.Exists(target.value))
                {
                    var entityPosition = translation.Value;
                    var targetPosition = translationComponents[target.value].Value;

                    var heading = targetPosition - entityPosition;
                    heading.y = 0f;

                    rotation.Value = quaternion.LookRotation(heading, math.up());
                }
            }
            ).Schedule(inputDeps);
            return jobHandle;
        }
    }
}