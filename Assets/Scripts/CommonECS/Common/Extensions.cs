using Unity.Collections;
using Unity.Entities;

namespace CommonECS
{
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


	public static class ResourcePathExtensions
	{
		public static string ToPathString(this ResourcePath path)
		{
			return path.ToString().Replace('_', '/');
		}
	}
}
