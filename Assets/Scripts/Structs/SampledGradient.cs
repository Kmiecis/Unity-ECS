using Common.Mathematics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Structs
{
    public struct SampledGradient
    {
        public int samples;
        public BlobArray<float4> keys;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref float4 Evaluate(float value)
        {
            var index = mathx.round_to_int(value * (samples - 1));
            return ref keys[index];
        }

        public static BlobAssetReference<SampledGradient> CreateBlobAssetReference(Gradient gradient, int samples = 255)
        {
            using (var blobBuilder = new BlobBuilder(Allocator.Temp))
            {
                ref var root = ref blobBuilder.ConstructRoot<SampledGradient>();
                var keys = blobBuilder.Allocate(ref root.keys, samples);
                var step = 1.0f / (samples - 1);
                for (int i = 0; i < samples; ++i)
                    keys[i] = gradient.Evaluate(i * step).rgba();
                root.samples = samples;
                return blobBuilder.CreateBlobAssetReference<SampledGradient>(Allocator.Persistent);
            }
        }
    }
}