using Common.ECS.Components;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    public class MoveSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;

            Entities.ForEach((ref Translation translation, in Move move, in MoveSpeed speed) => {
                translation.Value += move.value * speed.value * deltaTime;
            }).ScheduleParallel();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 GetMovementFromPositions(float3 currentPosition, float3 targetPosition, float speed, float deltaTime)
        {
            var direction = targetPosition - currentPosition;

            if (math.lengthsq(direction) > 0)
                direction = math.normalize(direction);

            var movement = direction * speed * deltaTime;

            var newPosition = currentPosition + movement;

            var da = newPosition - currentPosition;
            var db = targetPosition - newPosition;
            var hasReached = math.dot(da, db) < 0;
            if (hasReached)
                movement = targetPosition - currentPosition;

            return movement;
        }
    }
}