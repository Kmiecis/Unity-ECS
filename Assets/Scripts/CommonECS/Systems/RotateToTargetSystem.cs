using CommonECS.Components;
using Unity.Entities;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class RotateToTargetSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			var translationComponents = GetComponentDataFromEntity<Translation>(true);

			Entities.ForEach((ref Rotation rotation, in Translation translation, in RotateToTarget target) =>
			{
				if (translationComponents.Exists(target.value))
				{
					var currentPosition = translation.Value;
					var targetPosition = translationComponents[target.value].Value;

					var rotationValue = RotateSystem.GetRotationFromPositions(currentPosition, targetPosition);

					rotation.Value = rotationValue;
				}
			}
			).ScheduleParallel();
		}
	}
}
