using CommonECS.Structs;
using Unity.Entities;
using Unity.Transforms;
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

			var localScale = transform.localScale;
			var sizeValue = (localScale.x + localScale.y + localScale.z) * (1.0f / 3.0f);
			dstManager.AddComponentData(entity, new SizeReference { value = sizeValue });
			dstManager.AddComponentData(entity, new NonUniformScale { Value = sizeOverLifetime.curveRef.Value.Evaluate(0.0f) * sizeValue });
			dstManager.AddComponentData(entity, sizeOverLifetime);
		}
	}
}