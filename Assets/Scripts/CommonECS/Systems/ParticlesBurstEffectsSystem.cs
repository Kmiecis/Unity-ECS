using CommonECS.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class ParticlesBurstEffectsSystem : SystemBase
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
				.ForEach((int entityInQueryIndex, Entity entity, in ParticleBurstEffect burstEffect, in Translation translation, in Rotation rotation) =>
				{
					var random = randomArray[0];

					for (int i = 0; i < burstEffect.count; ++i)
					{
						var newParticleEntity = commandBuffer.Instantiate(entityInQueryIndex, burstEffect.particle);
						commandBuffer.SetComponent(entityInQueryIndex, newParticleEntity, translation);

						var hasBoxEmission = HasComponent<ParticleEffectBoxEmission>(entity);
						var hasSphereEmission = HasComponent<ParticleEffectSphereEmission>(entity);
						var hasRandomLifetime = HasComponent<ParticleEffectRandomLifetime>(entity);
						var hasRandomSize = HasComponent<ParticleEffectRandomSize>(entity);
						var hasRandomRotation = HasComponent<ParticleEffectRandomRotation>(entity);
						var hasRandomDirection = HasComponent<ParticleEffectRandomDirection>(entity);
						var hasRandomSpeed = HasComponent<ParticleEffectRandomSpeed>(entity);
						var hasSizeOverLifetime = HasComponent<ParticleEffectSizeOverLifetime>(entity);
						var hasColorOverLifetime = HasComponent<ParticleEffectColorOverLifetime>(entity);

						if (hasBoxEmission)
						{
							var particleEffectBoxEmission = GetComponent<ParticleEffectBoxEmission>(entity);
							var randomOffset = random.NextFloat3(particleEffectBoxEmission.min, particleEffectBoxEmission.max);
							randomOffset += translation.Value;
							commandBuffer.SetComponent(entityInQueryIndex, newParticleEntity, new Translation { Value = randomOffset });
						}

						if (hasSphereEmission)
						{
							var particleEffectSphereEmission = GetComponent<ParticleEffectSphereEmission>(entity);
							var randomOffset = random.NextFloat(particleEffectSphereEmission.min, particleEffectSphereEmission.max) * random.NextFloat3Direction();
							randomOffset += translation.Value;
							commandBuffer.SetComponent(entityInQueryIndex, newParticleEntity, new Translation { Value = randomOffset });
						}

						if (hasRandomLifetime)
						{
							var particleEffectRandomLifetime = GetComponent<ParticleEffectRandomLifetime>(entity);
							var randomLifetime = random.NextFloat(particleEffectRandomLifetime.min, particleEffectRandomLifetime.max);
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new Lifetime { value = randomLifetime });
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new Livetime());
						}

						if (hasRandomSize)
						{
							var particleEffectRandomSize = GetComponent<ParticleEffectRandomSize>(entity);
							var randomSize = random.NextFloat(particleEffectRandomSize.min, particleEffectRandomSize.max);
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new SizeReference { value = randomSize });
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new NonUniformScale { Value = randomSize });
						}

						if (hasRandomRotation)
						{
							var particleEffectRandomRotation = GetComponent<ParticleEffectRandomRotation>(entity);
							var randomRotation = quaternion.EulerXYZ(random.NextFloat3(particleEffectRandomRotation.min, particleEffectRandomRotation.max));
							randomRotation = math.mul(rotation.Value, randomRotation);
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new Rotation { Value = randomRotation });
						}
						
						if (hasRandomDirection)
						{
							var particleEffectRandomDirection = GetComponent<ParticleEffectRandomDirection>(entity);
							var randomDirection = math.normalizesafe(random.NextFloat3(particleEffectRandomDirection.min, particleEffectRandomDirection.max));
							randomDirection = math.mul(rotation.Value, randomDirection);
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new TranslateDirection { value = randomDirection });
						}

						if (hasRandomSpeed)
						{
							var particleEffectRandomSpeed = GetComponent<ParticleEffectRandomSpeed>(entity);
							var randomSpeed = random.NextFloat(particleEffectRandomSpeed.min, particleEffectRandomSpeed.max);
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new TranslateSpeed { value = randomSpeed });
						}

						if (hasSizeOverLifetime)
						{
							var particleEffectSizeOverLifetime = GetComponent<ParticleEffectSizeOverLifetime>(entity);
							var curveRef = particleEffectSizeOverLifetime.curveRef;
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new SizeOverLifetime { curveRef = curveRef });
						}

						if (hasColorOverLifetime)
						{
							var particleEffectColorOverLifetime = GetComponent<ParticleEffectColorOverLifetime>(entity);
							var gradientsRef = particleEffectColorOverLifetime.gradientsRef;
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new ColorOverLifetime { gradientsRef = gradientsRef });
							commandBuffer.AddComponent(entityInQueryIndex, newParticleEntity, new MaterialBaseColor { value = gradientsRef.Value.Evaluate(0.0f) });
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