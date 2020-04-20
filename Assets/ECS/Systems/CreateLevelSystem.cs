using Common.ECS.Buffers;
using Common.ECS.Components;
using Common.Mathematics;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

namespace Common.ECS.Systems
{
    public class CreateLevelSystem : JobComponentSystem
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

            var jobHandle = Entities.ForEach((Entity entity, in CreateLevelRequest request) => {
                commandBuffer.RemoveComponent<CreateLevelRequest>(JOB_INDEX, entity);
                var requestDatas = commandBuffer.AddBuffer<InstantiatePrefabData>(JOB_INDEX, entity);
                var requestPath = new InstantiatePrefabPath { value = ResourcePath.Prefabs_Platform };
                commandBuffer.AddComponent(JOB_INDEX, entity, requestPath);

                var requestPosition = request.position;
                var requestSize = request.size;
                for (int y = 0; y < requestSize.y; y++)
                {
                    for (int x = 0; x < requestSize.x; x++)
                    {
                        var hexPosition = new int2(x, y);
                        var position = HexModel.Convert(hexPosition);

                        var requestData = new InstantiatePrefabData
                        {
                            translation = position,
                            rotation = quaternion.identity
                        };

                        requestDatas.Add(requestData);
                    }
                }
            }).Schedule(inputDeps);

            m_CommandBufferSystem.AddJobHandleForProducer(jobHandle);
            return jobHandle;
        }

        private const int JOB_INDEX = 0;
    }
}