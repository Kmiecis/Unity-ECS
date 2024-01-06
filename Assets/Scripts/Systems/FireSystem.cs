using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public partial class FireSystem : SystemBase
    {
        private BeginInitializationEntityCommandBufferSystem m_CommandBufferSystem;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_CommandBufferSystem = World.GetOrCreateSystemManaged<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commands = m_CommandBufferSystem.CreateCommandBuffer().AsParallelWriter();
            var deltaTime = World.Time.DeltaTime;

            Entities
                .ForEach((int entityInQueryIndex, ref FireCooldown fireCooldown, in FireInput fireInput, in FireInterval fireInterval, in FireSpeed fireSpeed, in ProjectilePrefab projectilePrefab, in ProjectileSpawn projectileSpawn, in LocalToWorld localToWorld) =>
                {
                    fireCooldown.value -= deltaTime;

                    if (fireInput.fire &&
                        fireCooldown.value <= 0.0f)
                    {
                        var firedProjectile = commands.Instantiate(entityInQueryIndex, projectilePrefab.value);

                        var firedTranslateDirection = new TranslateDirection { value = localToWorld.Forward };
                        var firedTranslateSpeed = new TranslateSpeed { value = fireSpeed.value };
                        var firedTransform = new LocalTransform
                        {
                            Position = math.transform(localToWorld.Value, projectileSpawn.offset),
                            Rotation = quaternion.LookRotation(localToWorld.Forward, math.up())
                        };

                        commands.SetComponent(entityInQueryIndex, firedProjectile, firedTranslateDirection);
                        commands.SetComponent(entityInQueryIndex, firedProjectile, firedTranslateSpeed);
                        commands.SetComponent(entityInQueryIndex, firedProjectile, firedTransform);

                        fireCooldown.value = fireInterval.value;
                    }
                })
                .ScheduleParallel();

            m_CommandBufferSystem.AddJobHandleForProducer(this.Dependency);
        }
    }
}