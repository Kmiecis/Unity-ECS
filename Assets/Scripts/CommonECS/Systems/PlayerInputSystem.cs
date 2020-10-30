using CommonECS.Components;
using CommonECS.Mathematics;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace CommonECS.Systems
{
	public class PlayerInputSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			float2 inputMovement = float2.zero;
			if (Input.GetKey(KeyCode.W))
				inputMovement.y += 1.0f;
			if (Input.GetKey(KeyCode.S))
				inputMovement.y -= 1.0f;
			if (Input.GetKey(KeyCode.D))
				inputMovement.x += 1.0f;
			if (Input.GetKey(KeyCode.A))
				inputMovement.x -= 1.0f;

			var moves = math.lengthsq(inputMovement) > 0.0f;
			if (moves)
				inputMovement = math.normalize(inputMovement);

			var fires = Input.GetKey(KeyCode.Space);

			Entities
				.WithAll<PlayerTag>()
				.ForEach((ref TranslateDirection direction, ref RotateToRotation rotate, ref ParticlesOnInvokeEffect particlesEffect, in Rotation rotation) =>
				{
					var inputDirection = new float3(inputMovement.x, 0.0f, inputMovement.y);
					direction.value = inputDirection;
					rotate.rotation = moves ? quaternion.LookRotation(inputDirection, math.up()) : rotation.Value;
					particlesEffect.invoke = fires;
				})
				.Schedule();
		}
	}
}