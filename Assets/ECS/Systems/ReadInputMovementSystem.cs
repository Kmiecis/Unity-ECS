using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

namespace Common.ECS.Systems
{
    [UpdateBefore(typeof(ApplySpeedSystem))]
    public class ReadInputMovementSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            var dh = CrossPlatformInput.GetAxisHorizontal();
            var dv = CrossPlatformInput.GetAxisVertical();

            var jobHandle = Entities.WithAll<InputHorizontal, InputVertical>().ForEach((ref Movement movement) =>
            {
                var delta = (dh > 0 && dv > 0) ? math.normalize(new float2(dh, dv)) : new float2(dh, dv);
                delta *= deltaTime;
                movement.value = delta.x_z();
            }
            ).Schedule(inputDeps);
            return jobHandle;
        }
    }
}