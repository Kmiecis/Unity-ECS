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
            var jobHandle = Entities.ForEach((ref Translation translation, in Movement movement) =>
            {
                translation.Value += movement.value;
            }
            ).Schedule(inputDeps);
            return jobHandle;
        }
    }
}