using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS
{
    public static class Float2Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 x_(this float2 v)
        {
            return new float2(v.x, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 _y(this float2 v)
        {
            return new float2(0, v.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 xy_(this float2 v)
        {
            return new float3(v.x, v.y, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 x_z(this float2 v)
        {
            return new float3(v.x, 0, v.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 _yz(this float2 v)
        {
            return new float3(0, v.x, v.y);
        }
    }


    public static class EntityManagerExtensions
    {
        public static void EnsureComponentData<T>(this EntityManager entityManager, Entity entity, T componentData)
            where T : struct, IComponentData
        {
            if (entityManager.HasComponent<T>(entity))
                entityManager.SetComponentData(entity, componentData);
            else
                entityManager.AddComponentData(entity, componentData);
        }
    }


    public static class NativeArrayExtensions
    {
        public static NativeArray<T> Populate<T>(this NativeArray<T> arr, T value) where T : struct
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = value;
            }
            return arr;
        }
    }
}