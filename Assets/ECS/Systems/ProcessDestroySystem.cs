using Common.ECS.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

namespace Common.ECS.Systems
{
    public class ProcessDestroySystem : JobComponentSystem
    {
        private BeginInitializationEntityCommandBufferSystem m_CommandBuffer;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_CommandBuffer = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var commandBuffer = m_CommandBuffer.CreateCommandBuffer().ToConcurrent();
            var jobHandle = Entities.WithAll<DestroyTag>().ForEach((Entity entity) =>
            {
                commandBuffer.RemoveComponent<DestroyTag>(entity.Index, entity);
            }
            ).Schedule(inputDeps);
            m_CommandBuffer.AddJobHandleForProducer(jobHandle);
            return jobHandle;
        }
    }
}