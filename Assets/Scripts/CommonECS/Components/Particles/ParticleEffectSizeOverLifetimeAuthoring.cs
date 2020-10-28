using UnityEngine;
using Unity.Entities;
using CommonECS.Structs;

namespace CommonECS.Components
{
	public class ParticleEffectSizeOverLifetimeAuthoring : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int samples = 255;
		public AnimationCurve curve;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var particleEffectSizeOverLifetime = new ParticleEffectSizeOverLifetime { curveRef = AnimationsCurve.ConstructBlobAssetReference(curve, samples) };

			dstManager.AddComponentData(entity, particleEffectSizeOverLifetime);
		}
	}
}