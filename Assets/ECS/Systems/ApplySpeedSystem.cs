using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;

namespace Common.ECS.Systems
{
    [AlwaysSynchronizeSystem]
    [UpdateBefore(typeof(ApplyMovementSystem))]
    public class ApplySpeedSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            Entities.ForEach((ref Movement movement, in Speed speed) =>
            {
                movement.value *= speed.value;
            }
            ).Run();
            return default;
        }
    }
}