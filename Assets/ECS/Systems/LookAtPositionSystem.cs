using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    public class LookAtPositionSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var jobHandle = Entities.ForEach((ref Rotation rotation, in Translation translation, in LookAtPosition target) =>
            {
                var entityPosition = translation.Value;
                var targetPosition = target.position;

                var heading = targetPosition - entityPosition;
                heading.y = 0f;

                rotation.Value = quaternion.LookRotation(heading, math.up());
            }
            ).Schedule(inputDeps);
            return jobHandle;
        }
    }
}