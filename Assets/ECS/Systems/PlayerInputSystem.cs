using Common.ECS.Components;
using Common.Mathematics;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Common.ECS.Systems
{
    public class PlayerInputSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var moves = false;
            var direction = float3.zero;
            if (CrossPlatformInput.GetKey(KeyCode.W))
            {
                moves = true;
                direction.z += 1;
            }
            if (CrossPlatformInput.GetKey(KeyCode.S))
            {
                moves = true;
                direction.z -= 1;
            }
            if (CrossPlatformInput.GetKey(KeyCode.D))
            {
                moves = true;
                direction.x += 1;
            }
            if (CrossPlatformInput.GetKey(KeyCode.A))
            {
                moves = true;
                direction.x -= 1;
            }

            if (math.lengthsq(direction) > 1)
                direction = math.normalize(direction);

            Entities.ForEach((ref PlayerInput playerInput) => {
                playerInput.moves = moves;
                playerInput.direction = direction;
            }).ScheduleParallel();
        }
    }
}