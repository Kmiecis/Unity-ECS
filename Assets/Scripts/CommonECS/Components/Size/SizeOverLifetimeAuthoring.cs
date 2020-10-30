using CommonECS.Structs;
using Unity.Entities;
using UnityEngine;

namespace CommonECS.Components
{
	public class SizeOverLifetimeAuthoring : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int samples = 255;
		public AnimationCurve curve;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var sizeOverLifetime = new SizeOverLifetime { curveRef = AnimationsCurve.ConstructBlobAssetReference(curve, samples) };

			dstManager.AddComponentData(entity, sizeOverLifetime);
		}
	}
}