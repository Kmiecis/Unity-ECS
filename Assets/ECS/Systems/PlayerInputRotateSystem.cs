using Common.ECS.Components;
using Common.Mathematics;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    public class PlayerInputRotateSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref RotateOverTime rotate, in PlayerInput playerInput, in Rotation rotation) =>
            {
                if (playerInput.moves)
                {
                    rotate.fromRotation = rotation.Value;
                    rotate.toRotation = quaternion.LookRotation(playerInput.direction, axis.UP);
                    rotate.timeRotation = 0f;
                }
            }).ScheduleParallel(); 
        }
    }
}