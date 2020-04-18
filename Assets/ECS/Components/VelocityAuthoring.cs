using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Common.ECS.Components
{
    public class VelocityAuthoring : MonoBehaviour, IConvertGameObjectToEntity
    {
        public float3 value;

        public void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem)
        {
            entityManager.AddComponentData(entity, new Velocity() { value = value });
        }
    }

    public struct Velocity : IComponentData
    {
        public float3 value;
    }
}