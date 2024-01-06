using Components;
using Unity.Entities;
using Unity.Jobs;

namespace Systems
{
    public partial class ProcessCreatedSystem : SystemBase
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

            Entities
                .WithAll<CreatedTag>()
                .ForEach((Entity entity) =>
                {
                    commands.RemoveComponent<CreatedTag>(entity.Index, entity);
                }
                ).ScheduleParallel();

            m_CommandBufferSystem.AddJobHandleForProducer(this.Dependency);
        }
    }
}
