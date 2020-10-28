using CommonECS.Mathematics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace CommonECS.Structs
{
	public struct AnimationsCurve
	{
		public int samples;
		public BlobArray<float> keys;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ref float Evaluate(float value)
		{
			var index = mathx.round(value * (samples - 1));
			return ref keys[index];
		}
		
		public static BlobAssetReference<AnimationsCurve> ConstructBlobAssetReference(AnimationCurve curve, int samples = 255)
		{
			using (var blobBuilder = new BlobBuilder(Allocator.Temp))
			{
				ref var root = ref blobBuilder.ConstructRoot<AnimationsCurve>();
				var keys = blobBuilder.Allocate(ref root.keys, samples);
				var step = 1.0f / (samples - 1);
				for (int i = 0; i < samples; ++i)
					keys[i] = curve.Evaluate(i * step);
				root.samples = samples;
				return blobBuilder.CreateBlobAssetReference<AnimationsCurve>(Allocator.Persistent);
			}
		}
	}
}