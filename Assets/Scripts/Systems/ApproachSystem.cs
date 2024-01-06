using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public partial class ApproachSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .ForEach((ref ApproachPosition position, in ApproachTarget target) =>
                {
                    var entity = target.value;

                    if (SystemAPI.HasComponent<LocalTransform>(entity))
                    {
                        var transform = SystemAPI.GetComponent<LocalTransform>(entity);

                        position.value = transform.Position;
                    }
                })
                .ScheduleParallel();

            var deltaTime = World.Time.DeltaTime;

            Entities
                .ForEach((ref LocalTransform transform, ref ApproachCheck check, in ApproachPosition position, in ApproachSpeed speed, in ApproachDistance distance) =>
                {
                    var currentPosition = transform.Position;
                    var targetPosition = position.value;

                    var direction = targetPosition - currentPosition;

                    if (math.lengthsq(direction) > 0)
                        direction = math.normalize(direction);

                    var movement = direction * speed.value * deltaTime;

                    var newPosition = currentPosition + movement;

                    var da = newPosition - currentPosition;
                    var db = targetPosition - newPosition;

                    var hasReached = math.dot(da, db) < 0;
                    if (hasReached)
                        movement = targetPosition - currentPosition;

                    transform.Position += movement;
                    check.value = hasReached;
                })
                .ScheduleParallel();
        }
    }
}