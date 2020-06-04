using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	public struct TranslateToPosition : IComponentData
	{
		public float3 value;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 GetTranslationFromPositions(float3 currentPosition, float3 targetPosition, float speed, float deltaTime)
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
