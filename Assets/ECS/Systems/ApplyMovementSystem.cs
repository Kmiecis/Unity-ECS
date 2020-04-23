using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    [AlwaysSynchronizeSystem]
    public class ApplyMovementSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            Entities.ForEach((ref Translation translation, in Movement movement) =>
            {
                translation.Value += movement.value;
            }
            ).Run();
            return default;
        }
    }
}