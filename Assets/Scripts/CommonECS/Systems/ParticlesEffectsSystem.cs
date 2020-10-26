using CommonECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class ParticlesEffectsSystem : SystemBase
	{
		private EntityCommandBufferSystem m_CommandBuffer;
		private Random m_Random;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_CommandBuffer = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
			m_Random = new Random(1);
		}

		protected override void OnUpdate()
		{
			var commandBuffer = m_CommandBuffer.CreateCommandBuffer().AsParallelWriter();
			var random = m_Random;
			
			Entities
				.ForEach((int entityInQueryIndex, Entity entity, in ParticleEffect particleEffect, in Translation translation) =>
				{
					for (int i = 0; i < particleEffect.count; ++i)
					{
						var newParticleEntity = commandBuffer.Instantiate(entityInQueryIndex, particleEffect.particle);
						commandBuffer.SetComponent(entityInQueryIndex, newParticleEntity, translation);
						
						if (HasComponent<ParticleEffectRandomDirection>(entity))
						{
							var particleEffectRandomDirection = GetComponent<ParticleEffectRandomDirection>(entity);
							var randomDirection = new Translate { direction = random.NextFloat3(particleEffectRandomDirection.min, particleEffectRandomDirection.max) };
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, randomDirection);
						}

						if (HasComponent<ParticleEffectRandomSpeed>(entity))
						{
							var particleEffectRandomSpeed = GetComponent<ParticleEffectRandomSpeed>(entity);
							var randomSpeed = new TranslateSpeed { value = random.NextFloat(particleEffectRandomSpeed.min, particleEffectRandomSpeed.max) };
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, randomSpeed);
						}

						if (HasComponent<ParticleEffectRandomLifetime>(entity))
						{
							var particleEffectRandomLifetime = GetComponent<ParticleEffectRandomLifetime>(entity);
							var randomLifetime = new Lifetime { value = random.NextFloat(particleEffectRandomLifetime.min, particleEffectRandomLifetime.max) };
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, randomLifetime);
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new Livetime());
						}
					}

					commandBuffer.DestroyEntity(entityInQueryIndex, entity);
				})
				.ScheduleParallel();

			m_Random.state = random.state;
			m_CommandBuffer.AddJobHandleForProducer(this.Dependency);
		}
	}
}