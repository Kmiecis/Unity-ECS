using Common.ECS.Components;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Common.ECS.Systems
{
    public class InstantiatePrefabSystem : SystemBase
    {
        private static readonly Entity[] m_Prefabs = new Entity[(int)ResourcePath.Count].Populate(Entity.Null);
        private BeginInitializationEntityCommandBufferSystem m_CommandBufferSystem;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_CommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commandBuffer = m_CommandBufferSystem.CreateCommandBuffer().ToConcurrent();

            Entities.WithoutBurst().ForEach((Entity requestEntity, in InstantiateRequest request, in InstantiatePlayerRequest playerRequest) => {
                int prefabIndex = (int)request.path;
                var prefab = m_Prefabs[prefabIndex];
                for (int i = 0; i < request.count; ++i)
                {
                    var entity = commandBuffer.Instantiate(requestEntity.Index, prefab);
                    commandBuffer.SetComponent(requestEntity.Index, entity, new Translation { Value = playerRequest.position });
                }
                commandBuffer.DestroyEntity(requestEntity.Index, requestEntity);
            }).ScheduleParallel();

            Entities.WithoutBurst().ForEach((Entity requestEntity, in InstantiateRequest request, in InstantiatePlatformRequest platformRequest) => {
                int prefabIndex = (int)request.path;
                var prefab = m_Prefabs[prefabIndex];
                for (int i = 0; i < request.count; ++i)
                {
                    var entity = commandBuffer.Instantiate(requestEntity.Index, prefab);
                    commandBuffer.SetComponent(requestEntity.Index, entity, new Translation { Value = platformRequest.position });
                }
                commandBuffer.DestroyEntity(requestEntity.Index, requestEntity);
            }).ScheduleParallel();

            m_CommandBufferSystem.AddJobHandleForProducer(this.Dependency);
        }

        public static void EnsurePrefabExistence(World world, ResourcePath path)
        {
            var system = world.GetOrCreateSystem<InstantiatePrefabSystem>();
            var conversionSettings = GameObjectConversionSettings.FromWorld(world, null);
            var prefabs = m_Prefabs;
            var pathIndex = (int)path;

            if (prefabs[pathIndex] == Entity.Null)
            {
                var pathString = path.ToPathString();
                var objectPrefab = Resources.Load<GameObject>(pathString);
                var entityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(objectPrefab, conversionSettings);
                prefabs[pathIndex] = entityPrefab;
            }
        }
    }
}