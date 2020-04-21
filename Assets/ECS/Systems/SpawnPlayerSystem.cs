using Common.ECS.Buffers;
using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

namespace Common.ECS.Systems
{
    public class SpawnPlayerSystem : JobComponentSystem
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
            var jobHandle = Entities.ForEach((Entity entity, in SpawnPlayerRequest request) =>
            {
                commandBuffer.RemoveComponent<SpawnPlayerRequest>(JOB_INDEX, entity);
                var requestDatas = commandBuffer.AddBuffer<InstantiatePrefabData>(JOB_INDEX, entity);
                var requestPath = new InstantiatePrefabPath { value = ResourcePath.Prefabs_Player };
                commandBuffer.AddComponent(JOB_INDEX, entity, requestPath);

                var requestData = new InstantiatePrefabData
                {
                    translation = request.position.x_z(),
                    rotation = quaternion.identity
                };
                requestDatas.Add(requestData);
            }
            ).Schedule(inputDeps);
            m_CommandBufferSystem.AddJobHandleForProducer(inputDeps);
            return jobHandle;
        }

        private const int JOB_INDEX = 0;
    }
}