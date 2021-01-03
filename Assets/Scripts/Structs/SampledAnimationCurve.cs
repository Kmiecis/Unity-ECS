using CommonECS.Mathematics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace CommonECS.Structs
{
	public struct SampledAnimationCurve
	{
		public BlobArray<float> keys;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float Evaluate(float value)
		{
			var sampled = value * (keys.Length - 1);

			var index = mathx.round(sampled);
			if (index < sampled) {
				var prevValue = keys[index];
				var nextValue = keys[index + 1];
				return math.lerp(prevValue, nextValue, sampled - index);
			} else if (index > sampled) {
				var prevValue = keys[index - 1];
				var nextValue = keys[index];
				return math.lerp(prevValue, nextValue, sampled - (index - 1));
			} else {
				return keys[index];
			}
		}
		
		public static BlobAssetReference<SampledAnimationCurve> ConstructBlobAssetReference(AnimationCurve curve, int samples = 255, float time = 1.0f)
		{
			using (var blobBuilder = new BlobBuilder(Allocator.Temp))
			{
				ref var root = ref blobBuilder.ConstructRoot<SampledAnimationCurve>();
				var keys = blobBuilder.Allocate(ref root.keys, samples);
				var step = time / (samples - 1);
				for (int i = 0; i < samples; ++i)
					keys[i] = curve.Evaluate(i * step);
				return blobBuilder.CreateBlobAssetReference<SampledAnimationCurve>(Allocator.Persistent);
			}
		}
	}
}