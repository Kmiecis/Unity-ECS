using CommonECS.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class ParticlesEffectsSystem : SystemBase
	{
		private EntityCommandBufferSystem m_CommandBuffer;
		private NativeArray<Random> m_RandomArray;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_CommandBuffer = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
			m_RandomArray = new NativeArray<Random>(1, Allocator.Persistent);
			m_RandomArray[0] = new Random(1);
		}

		protected override void OnUpdate()
		{
			var commandBuffer = m_CommandBuffer.CreateCommandBuffer().AsParallelWriter();
			var randomArray = m_RandomArray;

			Entities
				.ForEach((int entityInQueryIndex, Entity entity, in ParticleEffect particleEffect, in Translation translation, in Rotation rotation) =>
				{
					var random = randomArray[0];

					for (int i = 0; i < particleEffect.count; ++i)
					{
						var newParticleEntity = commandBuffer.Instantiate(entityInQueryIndex, particleEffect.particle);
						commandBuffer.SetComponent(entityInQueryIndex, newParticleEntity, translation);

						var hasRandomOffset = HasComponent<ParticleEffectRandomOffset>(entity);
						var hasRandomRotation = HasComponent<ParticleEffectRandomRotation>(entity);
						var hasRandomScale = HasComponent<ParticleEffectRandomScale>(entity);
						var hasRandomDirection = HasComponent<ParticleEffectRandomDirection>(entity);
						var hasRandomSpeed = HasComponent<ParticleEffectRandomSpeed>(entity);
						var hasRandomLifetime = HasComponent<ParticleEffectRandomLifetime>(entity);

						if (hasRandomOffset)
						{
							var particleEffectRandomOffset = GetComponent<ParticleEffectRandomOffset>(entity);
							var randomOffset = random.NextFloat3(particleEffectRandomOffset.min, particleEffectRandomOffset.max);
							randomOffset += translation.Value;
							commandBuffer.SetComponent(entityInQueryIndex, newParticleEntity, new Translation { Value = randomOffset });
						}

						if (hasRandomRotation)
						{
							var particleEffectRandomRotation = GetComponent<ParticleEffectRandomRotation>(entity);
							var randomRotation = quaternion.EulerXYZ(random.NextFloat3(particleEffectRandomRotation.min, particleEffectRandomRotation.max));
							randomRotation = math.mul(rotation.Value, randomRotation);
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new Rotation { Value = randomRotation });
						}

						if (hasRandomScale)
						{
							var particleEffectRandomScale = GetComponent<ParticleEffectRandomScale>(entity);
							var randomScale = random.NextFloat(particleEffectRandomScale.min, particleEffectRandomScale.max);
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new Scale { Value = randomScale });
							commandBuffer.RemoveComponent<NonUniformScale>(entityInQueryIndex, newParticleEntity);
						}

						if (hasRandomDirection)
						{
							var particleEffectRandomDirection = GetComponent<ParticleEffectRandomDirection>(entity);
							var randomDirection = random.NextFloat3(particleEffectRandomDirection.min, particleEffectRandomDirection.max);
							randomDirection = math.mul(rotation.Value, randomDirection);
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new Translate { direction = randomDirection });
						}

						if (hasRandomSpeed)
						{
							var particleEffectRandomSpeed = GetComponent<ParticleEffectRandomSpeed>(entity);
							var randomSpeed = random.NextFloat(particleEffectRandomSpeed.min, particleEffectRandomSpeed.max);
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new TranslateSpeed { value = randomSpeed });
						}

						if (hasRandomLifetime)
						{
							var particleEffectRandomLifetime = GetComponent<ParticleEffectRandomLifetime>(entity);
							var randomLifetime = random.NextFloat(particleEffectRandomLifetime.min, particleEffectRandomLifetime.max);
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new Lifetime { value = randomLifetime });
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new Livetime());
						}
					}
					randomArray[0] = random;

					commandBuffer.DestroyEntity(entityInQueryIndex, entity);
				})
				.ScheduleParallel();
			
			m_CommandBuffer.AddJobHandleForProducer(this.Dependency);
		}

		protected override void OnDestroy()
		{
			m_RandomArray.Dispose();
			base.OnDestroy();
		}
	}
}