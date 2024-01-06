using Components;
using Unity.Entities;

namespace Systems
{
    public partial class LifetimeSystem : SystemBase
    {
        private BeginInitializationEntityCommandBufferSystem m_CommandBuffer;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_CommandBuffer = World.GetOrCreateSystemManaged<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commands = m_CommandBuffer.CreateCommandBuffer().AsParallelWriter();

            var deltaTime = World.Time.DeltaTime;

            Entities
                .ForEach((int entityInQueryIndex, Entity entity, ref Lifetime lifetime) =>
                {
                    var lifetimeValue = lifetime.value;
                    lifetime.value -= deltaTime;

                    if (lifetime.value <= 0.0f && lifetimeValue > 0.0f)
                    {
                        commands.AddComponent(entityInQueryIndex, entity, new DestroyTag());
                    }
                })
                .ScheduleParallel();

            m_CommandBuffer.AddJobHandleForProducer(this.Dependency);
        }
    }
}