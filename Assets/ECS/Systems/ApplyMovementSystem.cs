using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    public class ApplyMovementSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            var jobHandle2D = Entities.ForEach((ref Translation translation, in Movement2D movement) =>
            {
                translation.Value += movement.value.x_z() * deltaTime;
            }
            ).Schedule(inputDeps);
            var jobHandle3D = Entities.ForEach((ref Translation translation, in Movement3D movement) =>
            {
                translation.Value += movement.value * deltaTime;
            }
            ).Schedule(jobHandle2D);
            return jobHandle3D;
        }
    }
}