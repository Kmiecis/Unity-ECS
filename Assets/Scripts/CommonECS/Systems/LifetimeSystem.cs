﻿using CommonECS.Components;
using Unity.Entities;

namespace CommonECS.Systems
{
	public class LifetimeSystem : SystemBase
	{
		private BeginInitializationEntityCommandBufferSystem m_CommandBuffer;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_CommandBuffer = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			var commandBuffer = m_CommandBuffer.CreateCommandBuffer().AsParallelWriter();

			var deltaTime = Time.DeltaTime;

			Entities
				.ForEach((int entityInQueryIndex, Entity entity, ref Lifetime lifetime) =>
				{
					var lifetimeValue = lifetime.value;
					lifetime.value -= deltaTime;

					if (lifetime.value <= 0.0f && lifetimeValue > 0.0f)
					{
						commandBuffer.AddComponent(entityInQueryIndex, entity, new DestroyTag());
					}
				})
				.ScheduleParallel();

			m_CommandBuffer.AddJobHandleForProducer(this.Dependency);
		}
	}
}