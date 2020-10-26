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
			float2 dm = float2.zero;
			if (Input.GetKey(KeyCode.W))
				dm.y += 1.0f;
			if (Input.GetKey(KeyCode.S))
				dm.y -= 1.0f;
			if (Input.GetKey(KeyCode.D))
				dm.x += 1.0f;
			if (Input.GetKey(KeyCode.A))
				dm.x -= 1.0f;

			var moves = math.lengthsq(dm) > 0.0f;
			if (moves)
				dm = math.normalize(dm);

			var fires = Input.GetKey(KeyCode.Space);

			Entities
				.WithAll<PlayerTag>()
				.ForEach((ref Translate translate, ref RotateToRotation rotate, ref ParticlesOnInvokeEffect particlesEffect, in Rotation rotation) =>
				{
					var direction = new float3(dm.x, 0.0f, dm.y);
					translate.direction = direction;
					rotate.rotation = moves ? quaternion.LookRotation(direction, math.up()) : rotation.Value;
					particlesEffect.invoke = fires;
				})
				.Schedule();
		}
	}
}