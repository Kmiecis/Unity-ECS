using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;

namespace Common.ECS.Systems
{
    [UpdateBefore(typeof(ApplyMovementSystem))]
    public class ApplySpeedSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var jobHandle2D = Entities.ForEach((ref Movement2D movement, in Speed speed) =>
            {
                movement.value *= speed.value;
            }
            ).Schedule(inputDeps);
            var jobHandle3D = Entities.ForEach((ref Movement3D movement, in Speed speed) =>
            {
                movement.value *= speed.value;
            }
            ).Schedule(jobHandle2D);
            return jobHandle3D;
        }
    }
}