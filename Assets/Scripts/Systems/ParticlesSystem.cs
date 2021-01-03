using CommonECS.Components;
using Unity.Entities;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class ParticlesSystem : SystemBase
	{
		private EntityCommandBufferSystem m_CommandBuffer;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_CommandBuffer = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			var commandBuffer = m_CommandBuffer.CreateCommandBuffer().AsParallelWriter();

			Entities
				.WithAll<ParticlesOnCreationTag>()
				.ForEach((int entityInQueryIndex, Entity entity, in ParticleEffectCount count, in ParticleEffectPrefab prefab, in Translation translation, in Rotation rotation) =>
				{
					for (int i = 0; i < count.value; ++i)
					{
						var newEffect = commandBuffer.Instantiate(entityInQueryIndex, prefab.value);
						commandBuffer.SetComponent(entityInQueryIndex, newEffect, translation);
						commandBuffer.SetComponent(entityInQueryIndex, newEffect, rotation);
					}
					
					commandBuffer.RemoveComponent<ParticlesOnCreationTag>(entityInQueryIndex, entity);
					commandBuffer.RemoveComponent<ParticleEffectPrefab>(entityInQueryIndex, entity);
					commandBuffer.RemoveComponent<ParticleEffectCount>(entityInQueryIndex, entity);
				})
				.ScheduleParallel();

			Entities
				.WithAll<ParticlesOnDestructionTag, DestroyTag>()
				.ForEach((int entityInQueryIndex, Entity entity, in ParticleEffectCount count, in ParticleEffectPrefab prefab, in Translation translation, in Rotation rotation) =>
				{
					for (int i = 0; i < count.value; ++i)
					{
						var newEffect = commandBuffer.Instantiate(entityInQueryIndex, prefab.value);
						commandBuffer.SetComponent(entityInQueryIndex, newEffect, translation);
						commandBuffer.SetComponent(entityInQueryIndex, newEffect, rotation);
					}
				})
				.ScheduleParallel();

			Entities
				.ForEach((int entityInQueryIndex, Entity entity, in ParticlesPlay play, in ParticleEffectCount count, in ParticleEffectPrefab prefab, in Translation translation, in Rotation rotation) =>
				{
					if (play.value)
					{
						for (int i = 0; i < count.value; ++i)
						{
							var newEffect = commandBuffer.Instantiate(entityInQueryIndex, prefab.value);
							commandBuffer.SetComponent(entityInQueryIndex, newEffect, translation);
							commandBuffer.SetComponent(entityInQueryIndex, newEffect, rotation);
						}
					}
				})
				.ScheduleParallel();

			var deltaTime = Time.DeltaTime;

			Entities
				.ForEach((int entityInQueryIndex, Entity entity, ref ParticleEffectCooldown cooldown, in ParticlesPlay play, in ParticleEffectInterval interval, in ParticleEffectPrefab prefab, in Translation translation, in Rotation rotation) =>
				{
					if (play.value)
					{
						cooldown.value -= deltaTime;

						while (cooldown.value <= 0.0f)
						{
							var newEffect = commandBuffer.Instantiate(entityInQueryIndex, prefab.value);
							commandBuffer.SetComponent(entityInQueryIndex, newEffect, translation);
							commandBuffer.SetComponent(entityInQueryIndex, newEffect, rotation);

							cooldown.value += interval.value;
						}
					}
				})
				.ScheduleParallel();
			
			m_CommandBuffer.AddJobHandleForProducer(this.Dependency);
		}
	}
}