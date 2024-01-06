using Components;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public partial class PlayerSpawnSystem : SystemBase
    {
        public int width = 10;
        public int height = 10;

        private BeginInitializationEntityCommandBufferSystem m_CommandBufferSystem;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_CommandBufferSystem = World.GetOrCreateSystemManaged<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space) &&
                !SystemAPI.HasSingleton<PlayerTag>())
            {
                var commands = m_CommandBufferSystem.CreateCommandBuffer().AsParallelWriter();

                this.Dependency = new CreateJob()
                {
                    width = width,
                    height = height,
                    playerPrefab = SystemAPI.GetSingleton<PlayerPrefab>(),
                    commands = commands
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
            public EntityCommandBuffer.ParallelWriter commands;

            public void Execute()
            {
                var levelRequest = commands.CreateEntity(0);
                commands.AddComponent(0, levelRequest, new CreateLevelRequest
                {
                    position = new int2(0, 0),
                    size = new int2(width, height)
                });

                var player = commands.Instantiate(0, playerPrefab.value);
                commands.SetComponent(0, player, new LocalTransform());
            }
        }
    }
}
