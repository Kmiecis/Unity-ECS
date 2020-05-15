using Common.ECS.Components;
using Common.ECS.Systems;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Common.ECS
{
    public class GameManagerSystem : ComponentSystem
    {
        public int width = 10;
        public int height = 10;
        
        private EntityManager m_EntityManager;
        private bool m_Created = false;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_EntityManager = World.EntityManager;
        }

        protected override void OnUpdate()
        {
            if (CrossPlatformInput.GetKeyDown(KeyCode.Space) && !m_Created)
            {
                InstantiatePrefabSystem.EnsurePrefabExistence(World, ResourcePath.Prefabs_Platform);
                InstantiatePrefabSystem.EnsurePrefabExistence(World, ResourcePath.Prefabs_Player);
                m_Created = true;

                var levelRequest = m_EntityManager.CreateEntity();
                m_EntityManager.AddComponentData(levelRequest, new CreateLevelRequest
                {
                    position = new int2(0, 0),
                    size = new int2(width, height)
                });

                var playerRequest = m_EntityManager.CreateEntity();
                m_EntityManager.AddComponentData(playerRequest, new InstantiateRequest
                {
                    path = ResourcePath.Prefabs_Player,
                    count = 1
                });
                m_EntityManager.AddComponentData(playerRequest, new InstantiatePlayerRequest
                {
                    position = float3.zero
                });
            }
        }
    }
}