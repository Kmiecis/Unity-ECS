using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;

namespace Common.ECS.Systems
{
    public class ProcessDestroySystem : SystemBase
    {
        private BeginInitializationEntityCommandBufferSystem m_CommandBuffer;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_CommandBuffer = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commandBuffer = m_CommandBuffer.CreateCommandBuffer().ToConcurrent();

            Entities.WithAll<DestroyTag>().ForEach((Entity entity) => {
                commandBuffer.RemoveComponent<DestroyTag>(entity.Index, entity);
            }).ScheduleParallel();

            m_CommandBuffer.AddJobHandleForProducer(this.Dependency);
        }
    }
}