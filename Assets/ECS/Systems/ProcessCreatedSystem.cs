using Common.ECS.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

namespace Common.ECS.Systems
{
    public class ProcessCreatedSystem : JobComponentSystem
    {
        private BeginInitializationEntityCommandBufferSystem m_CommandBufferSystem;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_CommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var commandBuffer = m_CommandBufferSystem.CreateCommandBuffer().ToConcurrent();
            var jobHandle = Entities.WithAll<CreatedTag>().ForEach((Entity entity) => {
                commandBuffer.RemoveComponent<CreatedTag>(entity.Index, entity);
            }).Schedule(inputDeps);
            m_CommandBufferSystem.AddJobHandleForProducer(jobHandle);
            return jobHandle;
        }
    }
}