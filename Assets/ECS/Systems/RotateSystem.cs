using Common.ECS.Components;
using Common.Mathematics;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    public class TurnSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;

            Entities.ForEach((ref Rotation rotation, in Rotate rotate) => {
                rotation.Value = math.mul(rotation.Value, rotate.value);
            }).ScheduleParallel();

            Entities.ForEach((ref Rotation rotation, ref RotateOverTime rotate, in RotateSpeed speed) => {
                if (rotate.timeRotation < 1f)
                {
                    rotate.timeRotation = math.min(rotate.timeRotation + speed.value * deltaTime, 1f);
                    rotation.Value = math.slerp(rotate.fromRotation, rotate.toRotation, rotate.timeRotation);
                }
            }).ScheduleParallel();

            Entities.ForEach((ref Rotation rotation, in Translation translation, in RotateToPosition position) => {
                var currentPosition = translation.Value;
                var targetPosition = position.value;

                var rotationValue = GetRotationFromPositions(currentPosition, targetPosition);

                rotation.Value = rotationValue;
            }).ScheduleParallel();

            var translationComponents = GetComponentDataFromEntity<Translation>(true);

            Entities.ForEach((ref Rotation rotation, in Translation translation, in RotateToTarget target) => {
                if (translationComponents.Exists(target.value))
                {
                    var currentPosition = translation.Value;
                    var targetPosition = translationComponents[target.value].Value;

                    var rotationValue = GetRotationFromPositions(currentPosition, targetPosition);

                    rotation.Value = rotationValue;
                }
            }).ScheduleParallel();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quaternion GetRotationFromPositions(float3 currentPosition, float3 targetPosition)
        {
            var heading = targetPosition - currentPosition;
            heading.y = 0f;

            return quaternion.LookRotation(heading, axis.UP);
        }
    }
}