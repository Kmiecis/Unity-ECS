using CommonECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace CommonECS.Systems
{
	public class PlayerInputSystem : SystemBase
	{
		protected override void OnUpdate()
		{
			float2 dm = float2.zero;
			if (Input.GetKey(KeyCode.W)) dm.y += 1.0f;
			if (Input.GetKey(KeyCode.S)) dm.y -= 1.0f;
			if (Input.GetKey(KeyCode.D)) dm.x += 1.0f;
			if (Input.GetKey(KeyCode.A)) dm.x -= 1.0f;

			var moves = math.lengthsq(dm) > 0.0f;
			if (moves)
			{
				dm = math.normalize(dm);
			}

			Entities.ForEach((ref PlayerInput playerInput) =>
			{
				playerInput.moves = moves;
				playerInput.direction = new float3(dm.x, 0.0f, dm.y);
			}
			).ScheduleParallel();
		}
	}
}
