using Common.Mathematics;
using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public partial class RotateToRotationSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = World.Time.DeltaTime;

            Entities
                .ForEach((ref LocalTransform transform, in RotateToRotation rotate, in RotateSpeed speed) =>
                {
                    var currentRotation = transform.Rotation;
                    var targetRotation = rotate.rotation;

                    var radians = math.radians(speed.value);
                    var newRotation = mathu.rotate_towards(currentRotation, targetRotation, radians * deltaTime);

                    transform.Rotation = newRotation;
                })
                .ScheduleParallel();
        }
    }
}