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
            var jobHandle = Entities.ForEach((ref Rotation rotation, in Translation translation, in LookAtTarget lookAt) =>
            {
                if (translationComponents.Exists(lookAt.target))
                {
                    var position = translation.Value;
                    var targetPosition = translationComponents[lookAt.target].Value;

                    var heading = targetPosition - position;
                    heading.y = 0f;

                    rotation.Value = quaternion.LookRotation(heading, math.up());
                }
            }
            ).Schedule(inputDeps);
            return jobHandle;
        }
    }
}