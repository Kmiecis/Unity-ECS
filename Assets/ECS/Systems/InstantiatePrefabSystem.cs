using Common.ECS.Components;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Common.ECS.Systems
{
    public class InstantiatePrefabSystem : ComponentSystem
    {
        private static NativeArray<Entity> m_Prefabs;

        private EntityManager m_EntityManager;
        private EntityQuery m_EntityQuery;
        private GameObjectConversionSettings m_ConversionSettings;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_Prefabs = new NativeArray<Entity>((int)ResourcePath.Count, Allocator.Persistent).Populate(Entity.Null);
            m_EntityManager = World.EntityManager;
            m_EntityQuery = GetEntityQuery(
                ComponentType.ReadOnly<InstantiatePrefabRequest>()
            );
            m_ConversionSettings = GameObjectConversionSettings.FromWorld(World, null);
        }

        protected override void OnDestroy()
        {
            m_Prefabs.Dispose();
            base.OnDestroy();
        }

        protected override void OnUpdate()
        {
            var requests = m_EntityQuery.ToComponentDataArray<InstantiatePrefabRequest>(Allocator.TempJob);
            for (int i = 0; i < requests.Length; ++i)
            {
                var request = requests[i];
                int requestPathIndex = (int)request.path;
                if (m_Prefabs[requestPathIndex] == Entity.Null)
                {
                    var path = request.path.ToPathString();
                    var objectPrefab = Resources.Load<GameObject>(path);
                    
                    var entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(objectPrefab, m_ConversionSettings);
                    m_Prefabs[requestPathIndex] = entityPrefab;
                }
                var entity = m_EntityManager.Instantiate(m_Prefabs[requestPathIndex]);
                m_EntityManager.SetComponentData(entity, request.translation);
                m_EntityManager.SetComponentData(entity, request.rotation);
            }
            requests.Dispose();
            m_EntityManager.DestroyEntity(m_EntityQuery);
        }
    }
}