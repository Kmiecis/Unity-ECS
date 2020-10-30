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
				.ForEach((int entityInQueryIndex, Entity entity, in ParticlePrefab prefab, in Translation translation, in Rotation rotation) =>
				{
					var random = randomArray[0];

					var hasEmissionBox = HasComponent<ParticleEmissionBox>(entity);
					var hasEmissionSphere = HasComponent<ParticleEmissionSphere>(entity);
					var hasRandomLifetime = HasComponent<ParticleRandomLifetime>(entity);
					var hasRandomSize = HasComponent<ParticleRandomSize>(entity);
					var hasRandomRotation = HasComponent<ParticleRandomRotation>(entity);
					var hasRandomDirection = HasComponent<ParticleRandomDirection>(entity);
					var hasRandomSpeed = HasComponent<ParticleRandomSpeed>(entity);
					var hasSizeOverLifetime = HasComponent<ParticleSizeOverLifetime>(entity);
					var hasColorOverLifetime = HasComponent<ParticleColorOverLifetime>(entity);

					var newParticle = commandBuffer.Instantiate(entityInQueryIndex, prefab.value);
					commandBuffer.SetComponent(entityInQueryIndex, newParticle, translation);

					if (hasEmissionBox)
					{
						var particleEmissionBox = GetComponent<ParticleEmissionBox>(entity);
						var randomOffset = random.NextFloat3(particleEmissionBox.min, particleEmissionBox.max);
						randomOffset += translation.Value;
						commandBuffer.SetComponent(entityInQueryIndex, newParticle, new Translation { Value = randomOffset });
					}

					if (hasEmissionSphere)
					{
						var particleEmissionSphere = GetComponent<ParticleEmissionSphere>(entity);
						var randomOffset = random.NextFloat(particleEmissionSphere.min, particleEmissionSphere.max) * random.NextFloat3Direction();
						randomOffset += translation.Value;
						commandBuffer.SetComponent(entityInQueryIndex, newParticle, new Translation { Value = randomOffset });
					}

					if (hasRandomLifetime)
					{
						var particleRandomLifetime = GetComponent<ParticleRandomLifetime>(entity);
						var randomLifetime = random.NextFloat(particleRandomLifetime.min, particleRandomLifetime.max);
						commandBuffer.AddComponent(entityInQueryIndex, newParticle, new Lifetime { value = randomLifetime });
						commandBuffer.AddComponent(entityInQueryIndex, newParticle, new Livetime());
					}

					if (hasRandomSize)
					{
						var particleRandomSize = GetComponent<ParticleRandomSize>(entity);
						var randomSize = random.NextFloat(particleRandomSize.min, particleRandomSize.max);
						commandBuffer.AddComponent(entityInQueryIndex, newParticle, new SizeReference { value = randomSize });
						commandBuffer.AddComponent(entityInQueryIndex, newParticle, new NonUniformScale { Value = randomSize });
					}

					if (hasRandomRotation)
					{
						var particleRandomRotation = GetComponent<ParticleRandomRotation>(entity);
						var randomRotation = quaternion.EulerXYZ(random.NextFloat3(particleRandomRotation.min, particleRandomRotation.max));
						randomRotation = math.mul(rotation.Value, randomRotation);
						commandBuffer.AddComponent(entityInQueryIndex, newParticle, new Rotation { Value = randomRotation });
					}

					if (hasRandomDirection)
					{
						var particleRandomDirection = GetComponent<ParticleRandomDirection>(entity);
						var randomDirection = math.normalizesafe(random.NextFloat3(particleRandomDirection.min, particleRandomDirection.max));
						randomDirection = math.mul(rotation.Value, randomDirection);
						commandBuffer.AddComponent(entityInQueryIndex, newParticle, new TranslateDirection { value = randomDirection });
					}

					if (hasRandomSpeed)
					{
						var particleRandomSpeed = GetComponent<ParticleRandomSpeed>(entity);
						var randomSpeed = random.NextFloat(particleRandomSpeed.min, particleRandomSpeed.max);
						commandBuffer.AddComponent(entityInQueryIndex, newParticle, new TranslateSpeed { value = randomSpeed });
					}

					if (hasSizeOverLifetime)
					{
						var particleSizeOverLifetime = GetComponent<ParticleSizeOverLifetime>(entity);
						var curveRef = particleSizeOverLifetime.curveRef;
						commandBuffer.AddComponent(entityInQueryIndex, newParticle, new SizeOverLifetime { curveRef = curveRef });
						commandBuffer.AddComponent(entityInQueryIndex, newParticle, new NonUniformScale { Value = curveRef.Value.Evaluate(0.0f) });
					}

					if (hasColorOverLifetime)
					{
						var particleColorOverLifetime = GetComponent<ParticleColorOverLifetime>(entity);
						var gradientsRef = particleColorOverLifetime.gradientsRef;
						commandBuffer.AddComponent(entityInQueryIndex, newParticle, new ColorOverLifetime { gradientsRef = gradientsRef });
						commandBuffer.AddComponent(entityInQueryIndex, newParticle, new MaterialBaseColor { value = gradientsRef.Value.Evaluate(0.0f) });
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