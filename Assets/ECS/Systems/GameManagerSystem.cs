using Common.ECS.Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Common.ECS
{
    public class GameManagerSystem : SystemBase
    {
        public int width = 10;
        public int height = 10;
        
        private BeginInitializationEntityCommandBufferSystem m_CommandBufferSystem;

        private bool m_Created = false;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_CommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            if (CrossPlatformInput.GetKeyDown(KeyCode.Space) && !m_Created)
            {
                m_Created = true;

                var commandBuffer = m_CommandBufferSystem.CreateCommandBuffer().ToConcurrent();

                this.Dependency = new CreateJob()
                {
                    width = width,
                    height = height,
                    playerPrefab = GetSingleton<PlayerPrefab>(),
                    commandBuffer = commandBuffer
                }
                .Schedule(this.Dependency);
                
                m_CommandBufferSystem.AddJobHandleForProducer(this.Dependency);
            }
        }

        private struct CreateJob : IJob
        {
            public int width;
            public int height;
            public PlayerPrefab playerPrefab;
            public EntityCommandBuffer.Concurrent commandBuffer;

            public void Execute()
            {
                var levelRequest = commandBuffer.CreateEntity(0);
                commandBuffer.AddComponent(0, levelRequest, new CreateLevelRequest
                {
                    position = new int2(0, 0),
                    size = new int2(width, height)
                });

                var player = commandBuffer.Instantiate(0, playerPrefab.value);
                commandBuffer.SetComponent(0, player, new Translation { Value = float3.zero });
            }
        }
    }
}