using Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public partial class ParticlesEffectsSystem : SystemBase
    {
        private EntityCommandBufferSystem m_CommandBuffer;
        private NativeArray<Random> m_RandomArray;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_CommandBuffer = World.GetOrCreateSystemManaged<BeginInitializationEntityCommandBufferSystem>();
            m_RandomArray = new NativeArray<Random>(1, Allocator.Persistent);
            m_RandomArray[0] = new Random(1);
        }

        protected override void OnUpdate()
        {
            var commands = m_CommandBuffer.CreateCommandBuffer().AsParallelWriter();

            Entities
                .ForEach((int entityInQueryIndex, Entity entity, in ParticlePrefab prefab, in ParticleRandomLifetime randomLifetime, in ParticleRandomSize randomSize, in LocalTransform transform) =>
                {
                    var random = new Random((uint)entity.Index);

                    var hasEmissionBox = SystemAPI.HasComponent<ParticleEmissionBox>(entity);
                    var hasEmissionSphere = SystemAPI.HasComponent<ParticleEmissionSphere>(entity);
                    var hasRandomRotation = SystemAPI.HasComponent<ParticleRandomRotation>(entity);
                    var hasRandomDirection = SystemAPI.HasComponent<ParticleRandomDirection>(entity);
                    var hasRandomSpeed = SystemAPI.HasComponent<ParticleRandomSpeed>(entity);
                    var hasSizeOverLifetime = SystemAPI.HasComponent<ParticleSizeOverLifetime>(entity);
                    var hasColorOverLifetime = SystemAPI.HasComponent<ParticleColorOverLifetime>(entity);

                    var newParticle = commands.Instantiate(entityInQueryIndex, prefab.value);
                    var particleTransform = LocalTransform.FromPosition(transform.Position);

                    var lifetimeValue = random.NextFloat(randomLifetime.min, randomLifetime.max);
                    commands.AddComponent(entityInQueryIndex, newParticle, new Lifetime { value = lifetimeValue });
                    commands.AddComponent(entityInQueryIndex, newParticle, new Livetime());

                    var sizeValue = random.NextFloat(randomSize.min, randomSize.max);
                    commands.AddComponent(entityInQueryIndex, newParticle, new SizeReference { value = sizeValue });
                    particleTransform.Scale = sizeValue;

                    if (hasEmissionBox)
                    {
                        var particleEmissionBox = SystemAPI.GetComponent<ParticleEmissionBox>(entity);
                        var randomOffset = random.NextFloat3(particleEmissionBox.min, particleEmissionBox.max);
                        particleTransform.Position += randomOffset;
                    }

                    if (hasEmissionSphere)
                    {
                        var particleEmissionSphere = SystemAPI.GetComponent<ParticleEmissionSphere>(entity);
                        var randomOffset = random.NextFloat(particleEmissionSphere.min, particleEmissionSphere.max) * random.NextFloat3Direction();
                        particleTransform.Position += randomOffset;
                    }

                    if (hasRandomRotation)
                    {
                        var particleRandomRotation = SystemAPI.GetComponent<ParticleRandomRotation>(entity);
                        var randomRotation = quaternion.EulerXYZ(random.NextFloat3(particleRandomRotation.min, particleRandomRotation.max));
                        particleTransform.Rotation = math.mul(transform.Rotation, randomRotation);
                    }

                    if (hasRandomDirection)
                    {
                        var particleRandomDirection = SystemAPI.GetComponent<ParticleRandomDirection>(entity);
                        var randomDirection = math.normalizesafe(random.NextFloat3(particleRandomDirection.min, particleRandomDirection.max));
                        randomDirection = math.mul(transform.Rotation, randomDirection);
                        commands.AddComponent(entityInQueryIndex, newParticle, new TranslateDirection { value = randomDirection });
                    }

                    if (hasRandomSpeed)
                    {
                        var particleRandomSpeed = SystemAPI.GetComponent<ParticleRandomSpeed>(entity);
                        var randomSpeed = random.NextFloat(particleRandomSpeed.min, particleRandomSpeed.max);
                        commands.AddComponent(entityInQueryIndex, newParticle, new TranslateSpeed { value = randomSpeed });
                    }

                    if (hasSizeOverLifetime)
                    {
                        var particleSizeOverLifetime = SystemAPI.GetComponent<ParticleSizeOverLifetime>(entity);
                        var curveRef = particleSizeOverLifetime.curveRef;
                        commands.AddComponent(entityInQueryIndex, newParticle, new SizeOverLifetime { curveRef = curveRef });
                        particleTransform.Scale = curveRef.Value.Evaluate(0.0f) * sizeValue;
                    }

                    if (hasColorOverLifetime)
                    {
                        var particleColorOverLifetime = SystemAPI.GetComponent<ParticleColorOverLifetime>(entity);
                        var gradientsRef = particleColorOverLifetime.gradientsRef;
                        commands.AddComponent(entityInQueryIndex, newParticle, new ColorOverLifetime { gradientsRef = gradientsRef });
                        commands.AddComponent(entityInQueryIndex, newParticle, new MaterialBaseColor { value = gradientsRef.Value.Evaluate(0.0f) });
                    }

                    commands.SetComponent(entityInQueryIndex, newParticle, particleTransform);

                    commands.DestroyEntity(entityInQueryIndex, entity);
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