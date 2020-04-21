using Common.ECS.Components;
using Common.Mathematics;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

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
                m_Created = true;

                var levelRequest = m_EntityManager.CreateEntity();
                m_EntityManager.AddComponentData(levelRequest, new CreateLevelRequest
                {
                    position = new int2(0, 0),
                    size = new int2(width, height)
                });

                var playerRequest = m_EntityManager.CreateEntity();
                m_EntityManager.AddComponentData(playerRequest, new SpawnPlayerRequest
                {
                    position = new float2(0, 0)
                });
            }

            if (CrossPlatformInput.GetKeyDown(KeyCode.R))
            {
                Entities.WithAll<Player>().ForEach((Entity entity) =>
                {
                    var hexPosition = new int2 { x = Random.Range(0, width), y = Random.Range(0, height) };
                    var goToPosition = new GoToPosition { value = HexModel.Convert(hexPosition) };
                    m_EntityManager.EnsureComponentData(entity, goToPosition);
                });
            }
        }
    }
}