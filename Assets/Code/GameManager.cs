using Common.ECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Common
{
    public class GameManager : MonoBehaviour
    {
        public int width = 10;
        public int height = 10;
        
        private EntityManager m_EntityManager;

        private void Start()
        {
            m_EntityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        private void Update()
        {
            if (CrossPlatformInput.GetKeyDown(KeyCode.Space))
            {
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
        }
    }
}