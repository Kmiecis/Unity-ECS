using Common.ECS.Buffers;
using Common.ECS.Components;
using Common.Mathematics;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Common.ECS.Systems
{
    public class CreateLevelSystem : SystemBase
    {
        private BeginInitializationEntityCommandBufferSystem m_CommandBufferSystem;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_CommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commandBuffer = m_CommandBufferSystem.CreateCommandBuffer().ToConcurrent();

            var prefab = GetSingleton<PlatformPrefab>();

            Entities.ForEach((Entity requestEntity, in CreateLevelRequest request) => {
                var requestPosition = request.position;
                var requestSize = request.size;
                for (int y = 0; y < requestSize.y; y++)
                {
                    for (int x = 0; x < requestSize.x; x++)
                    {
                        var hexPosition = new int2(x, y);
                        var position = HexModel.Convert(hexPosition);
                        
                        var entity = commandBuffer.Instantiate(requestEntity.Index, prefab.value);
                        commandBuffer.SetComponent(requestEntity.Index, entity, new Translation { Value = position });
                    }
                }

                commandBuffer.DestroyEntity(requestEntity.Index, requestEntity);
            }).ScheduleParallel();

            m_CommandBufferSystem.AddJobHandleForProducer(this.Dependency);
        }
    }
}