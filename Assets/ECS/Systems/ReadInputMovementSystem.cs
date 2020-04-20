using Common.ECS.Components;
using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Systems
{
    public class ReadInputMovementSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.WithAll<InputHorizontal, InputVertical>().ForEach((ref Movement2D movement) => {
                var dh = CrossPlatformInput.GetAxisHorizontal();
                var dv = CrossPlatformInput.GetAxisVertical();
                var delta = (dh > 0 && dv > 0) ? math.normalize(new float2(dh, dv)) : new float2(dh, dv);
                movement.value = delta;
            });
        }
    }
}