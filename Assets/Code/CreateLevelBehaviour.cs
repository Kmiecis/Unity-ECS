using Common.ECS.Buffers;
using Common.ECS.Components;
using Common.Mathematics;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Common
{
    public class CreateLevelBehaviour : MonoBehaviour
    {
        public int width = 10;
        public int height = 10;

        private bool m_Created;
        private EntityManager m_EntityManager;

        private void Start()
        {
            m_EntityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        private void Update()
        {
            if (CrossPlatformInput.GetKeyDown(KeyCode.Space) && !m_Created)
            {
                m_Created = true;
                var entity = m_EntityManager.CreateEntity();
                var componentPath = new InstantiatePrefabPath { value = ResourcePath.Prefabs_Platform };
                m_EntityManager.AddComponentData(entity, componentPath);

                var bufferData = m_EntityManager.AddBuffer<InstantiatePrefabData>(entity);
                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        var hexPosition = new int2(x, y);
                        var position = HexModel.Convert(hexPosition);
                        
                        var data = new InstantiatePrefabData
                        {
                            translation = position,
                            rotation = quaternion.identity
                        };

                        bufferData.Add(data);
                    }
                }
            }
        }
    }
}