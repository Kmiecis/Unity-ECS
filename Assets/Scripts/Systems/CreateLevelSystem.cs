using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public partial class CreateLevelSystem : SystemBase
    {
        private BeginInitializationEntityCommandBufferSystem m_CommandBufferSystem;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_CommandBufferSystem = World.GetOrCreateSystemManaged<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            if (SystemAPI.TryGetSingleton<PlatformPrefab>(out var data))
            {
                var commands = m_CommandBufferSystem.CreateCommandBuffer().AsParallelWriter();

                var transform = SystemAPI.GetComponent<LocalTransform>(data.value);

                Entities
                    .ForEach((Entity requestEntity, in CreateLevelRequest request) =>
                    {
                        var requestPosition = request.position;
                        var requestSize = request.size;

                        for (int y = 0; y < requestSize.y; y++)
                        {
                            for (int x = 0; x < requestSize.x; x++)
                            {
                                var entity = commands.Instantiate(requestEntity.Index, data.value);
                                commands.SetComponent(requestEntity.Index, entity, transform.WithPosition(new float3(x, 0.0f, y)));
                            }
                        }

                        commands.DestroyEntity(requestEntity.Index, requestEntity);
                    })
                    .ScheduleParallel();

                m_CommandBufferSystem.AddJobHandleForProducer(this.Dependency);
            }
        }
    }
}
