using CommonECS.Structs;
using Unity.Entities;
using UnityEngine;

namespace CommonECS.Components
{
	public class ColorOverLifetimeAuthoring : MonoBehaviour, IConvertGameObjectToEntity
	{
		public int samples = 255;
		public Gradient gradient;

		public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
		{
			var colorOverLifetime = new ColorOverLifetime { gradientsRef = Gradients.ConstructBlobAssetReference(gradient, samples) };

			var materialBaseColor = new MaterialBaseColor { value = colorOverLifetime.gradientsRef.Value.Evaluate(0.0f) };
			dstManager.AddComponentData(entity, materialBaseColor);
			dstManager.AddComponentData(entity, colorOverLifetime);
		}
	}
}