using Components;
using Unity.Entities;
using Unity.Transforms;

namespace Systems
{
    public partial class ParticlesSystem : SystemBase
    {
        private EntityCommandBufferSystem m_CommandBuffer;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_CommandBuffer = World.GetOrCreateSystemManaged<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commands = m_CommandBuffer.CreateCommandBuffer().AsParallelWriter();

            Entities
                .WithAll<ParticlesOnCreationTag>()
                .ForEach((int entityInQueryIndex, Entity entity, in ParticleEffectCount count, in ParticleEffectPrefab prefab, in LocalTransform transform) =>
                {
                    for (int i = 0; i < count.value; ++i)
                    {
                        var newEffect = commands.Instantiate(entityInQueryIndex, prefab.value);
                        commands.SetComponent(entityInQueryIndex, newEffect, transform);
                    }

                    commands.RemoveComponent<ParticlesOnCreationTag>(entityInQueryIndex, entity);
                    commands.RemoveComponent<ParticleEffectPrefab>(entityInQueryIndex, entity);
                    commands.RemoveComponent<ParticleEffectCount>(entityInQueryIndex, entity);
                })
                .ScheduleParallel();

            Entities
                .WithAll<ParticlesOnDestructionTag, DestroyTag>()
                .ForEach((int entityInQueryIndex, Entity entity, in ParticleEffectCount count, in ParticleEffectPrefab prefab, in LocalTransform transform) =>
                {
                    for (int i = 0; i < count.value; ++i)
                    {
                        var newEffect = commands.Instantiate(entityInQueryIndex, prefab.value);
                        commands.SetComponent(entityInQueryIndex, newEffect, transform);
                    }
                })
                .ScheduleParallel();

            Entities
                .ForEach((int entityInQueryIndex, Entity entity, in ParticlesPlay play, in ParticleEffectCount count, in ParticleEffectPrefab prefab, in LocalTransform transform) =>
                {
                    if (play.value)
                    {
                        for (int i = 0; i < count.value; ++i)
                        {
                            var newEffect = commands.Instantiate(entityInQueryIndex, prefab.value);
                            commands.SetComponent(entityInQueryIndex, newEffect, transform);
                        }
                    }
                })
                .ScheduleParallel();

            var deltaTime = World.Time.DeltaTime;

            Entities
                .ForEach((int entityInQueryIndex, Entity entity, ref ParticleEffectCooldown cooldown, in ParticlesPlay play, in ParticleEffectInterval interval, in ParticleEffectPrefab prefab, in LocalTransform transform) =>
                {
                    if (play.value)
                    {
                        cooldown.value -= deltaTime;

                        if (interval.value > 0.0f)
                        {
                            while (cooldown.value <= 0.0f)
                            {
                                var newEffect = commands.Instantiate(entityInQueryIndex, prefab.value);
                                commands.SetComponent(entityInQueryIndex, newEffect, transform);

                                cooldown.value += interval.value;
                            }
                        }
                    }
                })
                .ScheduleParallel();

            m_CommandBuffer.AddJobHandleForProducer(this.Dependency);
        }
    }
}