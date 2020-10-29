using Unity.Entities;
using UnityEngine;

namespace CommonECS
{
	public abstract class AuthoringBehaviour : MonoBehaviour, IConvertGameObjectToEntity
	{
		public abstract void Convert(Entity entity, EntityManager entityManager, GameObjectConversionSystem conversionSystem);
	}
}