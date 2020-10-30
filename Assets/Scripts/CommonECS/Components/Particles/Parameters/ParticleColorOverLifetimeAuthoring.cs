using CommonECS.Structs;
using Unity.Entities;
using UnityEngine;

namespace CommonECS.Components
{
	public class ParticleColorOverLifetimeAuthoring : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int samples = 255;
		public Gradient gradient;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var particleEffectColorOverLifetime = new ParticleColorOverLifetime { gradientsRef = Gradients.ConstructBlobAssetReference(gradient, samples) };

			dstManager.AddComponentData(entity, particleEffectColorOverLifetime);
		}
	}
}