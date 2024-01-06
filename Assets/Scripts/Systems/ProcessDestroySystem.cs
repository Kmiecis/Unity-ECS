using Components;
using Unity.Entities;
using Unity.Jobs;

namespace Systems
{
    public partial class ProcessDestroySystem : SystemBase
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

            Entities
                .WithAll<DestroyTag>()
                .ForEach((int entityInQueryIndex, Entity entity) =>
                {
                    commands.DestroyEntity(entityInQueryIndex, entity);
                })
                .ScheduleParallel();

            m_CommandBuffer.AddJobHandleForProducer(this.Dependency);
        }
    }
}
