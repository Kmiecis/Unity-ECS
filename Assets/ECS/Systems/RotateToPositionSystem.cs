using Common.ECS.Components;
using Unity.Entities;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    public class RotateToPositionSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref Rotation rotation, in Translation translation, in RotateToPosition position) => {
                var currentPosition = translation.Value;
                var targetPosition = position.value;

                var rotationValue = RotateSystem.GetRotationFromPositions(currentPosition, targetPosition);

                rotation.Value = rotationValue;
            }).ScheduleParallel();
        }
    }
}