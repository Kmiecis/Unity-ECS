using Common.ECS.Buffers;
using Common.ECS.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Common.ECS.Systems
{
    public class InstantiatePrefabSystem : ComponentSystem
    {
        private static NativeArray<Entity> m_Prefabs;

        private EntityManager m_EntityManager;
        private GameObjectConversionSettings m_ConversionSettings;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_Prefabs = new NativeArray<Entity>((int)ResourcePath.Count, Allocator.Persistent).Populate(Entity.Null);
            m_EntityManager = World.EntityManager;
            m_ConversionSettings = GameObjectConversionSettings.FromWorld(World, null);
        }

        protected override void OnDestroy()
        {
            m_Prefabs.Dispose();
            base.OnDestroy();
        }

        protected override void OnUpdate()
        {
            var query = Entities.WithAll<InstantiatePrefabPath>();
            query.ForEach((ref InstantiatePrefabPath path, DynamicBuffer<InstantiatePrefabData> dataLookup) => {
                // Need to create copy, because EntityManager operations invalidate DynamicBuffer<T>
                var dataLookupCopy = dataLookup.ToNativeArray(Allocator.Temp);

                int pathIndex = (int)path.value;

                if (m_Prefabs[pathIndex] == Entity.Null)
                {
                    var pathString = path.value.ToPathString();
                    var objectPrefab = Resources.Load<GameObject>(pathString);

                    var entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(objectPrefab, m_ConversionSettings);
                    m_Prefabs[pathIndex] = entityPrefab;
                }

                var entitiesCount = dataLookupCopy.Length;
                var entities = new NativeArray<Entity>(entitiesCount, Allocator.Temp);
                m_EntityManager.Instantiate(m_Prefabs[pathIndex], entities);

                for (int i = 0; i < entitiesCount; ++i)
                {
                    var entity = entities[i];
                    var data = dataLookupCopy[i];

                    var entityTranslation = new Translation { Value = data.translation };
                    var entityRotation = new Rotation { Value = data.rotation };

                    m_EntityManager.SetComponentData(entity, entityTranslation);
                    m_EntityManager.SetComponentData(entity, entityRotation);
                }
                
                entities.Dispose();
                dataLookupCopy.Dispose();
            });
            m_EntityManager.DestroyEntity(query.ToEntityQuery());
        }
    }
}