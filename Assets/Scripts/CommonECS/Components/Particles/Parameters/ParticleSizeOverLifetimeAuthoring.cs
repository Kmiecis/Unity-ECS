using UnityEngine;
using Unity.Entities;
using CommonECS.Structs;

namespace CommonECS.Components
{
	public class ParticleSizeOverLifetimeAuthoring : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int samples = 255;
		public AnimationCurve curve;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var particleEffectSizeOverLifetime = new ParticleSizeOverLifetime { curveRef = SampledAnimationCurve.ConstructBlobAssetReference(curve, samples) };

			dstManager.AddComponentData(entity, particleEffectSizeOverLifetime);
		}
	}
}