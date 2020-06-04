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
			var moves = false;
			var direction = float3.zero;
			if (Input.GetKey(KeyCode.W))
			{
				moves = true;
				direction.z += 1;
			}
			if (Input.GetKey(KeyCode.S))
			{
				moves = true;
				direction.z -= 1;
			}
			if (Input.GetKey(KeyCode.D))
			{
				moves = true;
				direction.x += 1;
			}
			if (Input.GetKey(KeyCode.A))
			{
				moves = true;
				direction.x -= 1;
			}

			if (math.lengthsq(direction) > 1)
				direction = math.normalize(direction);

			Entities.ForEach((ref PlayerInput playerInput) => {
				playerInput.moves = moves;
				playerInput.direction = direction;
			}).ScheduleParallel();
		}
	}
}
