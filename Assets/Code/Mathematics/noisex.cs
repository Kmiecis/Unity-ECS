using Common.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Common.Mathematics
{
    public static class noisex
    {
        /// <summary> Noise Map generator </summary>
        public static Array2<float> map(
            int2 extents = default, int2 offset = default,
            int octaves = 1, float persistance = 0.5f, float lacunarity = 2f,
            float2 scale = default, int seed = 0
        )
        {
            var result = new Array2<float>(extents.x, extents.y);

            Random.InitState(seed);
            float2 randomOffset = new float2(Random.Range(-99999, 99999), Random.Range(-99999, 99999));
            float2 middleOffset = new float2(extents.x * 0.5f, extents.y * 0.5f);
            float2 revertedExtents = new float2(1f / extents.x, 1f / extents.y);
            float2 revertedScale = new float2(1f / math.min(scale.x, 1e-5f), 1f / math.min(scale.y, 1e-5f));

            for (int y = 0; y < extents.y; ++y)
            {
                for (int x = 0; x < extents.x; ++x)
                {
                    float amplitude = 1f;
                    float frequency = 1f;
                    float value = 0f;

                    for (int i = 0; i < octaves; ++i)
                    {
                        float sampleX = ((x - middleOffset.x + offset.x) * revertedScale.x * revertedExtents.x) * frequency + randomOffset.x;
                        float sampleY = ((y - middleOffset.y + offset.y) * revertedScale.y * revertedExtents.y) * frequency + randomOffset.y;

                        float perlin = Mathf.PerlinNoise(sampleX, sampleY);
                        value += perlin * amplitude;

                        amplitude *= persistance;
                        frequency *= lacunarity;
                    }

                    result[x, y] = value;
                }
            }

            return result;
        }

        /// <summary> Noise Map generator smoothed to [0 .. 1] values </summary>
        public static Array2<float> smoothmap(
            int2 extents = default, int2 offset = default,
            int octaves = 1, float persistance = 0.5f, float lacunarity = 2f,
            float2 scale = default, int seed = 0
        )
        {
            var result = new Array2<float>(extents.x, extents.y);

            float2 noiseHeightMinMax = new float2(0f, 1f);
            for (int i = 1; i < octaves; ++i)
            {
                float persistanceAffection = math.pow(persistance, i);
                noiseHeightMinMax.x += persistanceAffection * 0.25f;
                noiseHeightMinMax.y += persistanceAffection * 0.75f;
            }

            Random.InitState(seed);
            float2 randomOffset = new float2(Random.Range(-99999, 99999), Random.Range(-99999, 99999));
            float2 middleOffset = new float2(extents.x * 0.5f, extents.y * 0.5f);
            float2 revertedExtents = new float2(1f / extents.x, 1f / extents.y);
            float2 revertedScale = new float2(1f / math.max(scale.x, 1e-4f), 1f / math.max(scale.y, 1e-4f));

            for (int y = 0; y < extents.y; ++y)
            {
                for (int x = 0; x < extents.x; ++x)
                {
                    float amplitude = 1f;
                    float frequency = 1f;
                    float value = 0f;

                    for (int i = 0; i < octaves; ++i)
                    {
                        float sampleX = ((x - middleOffset.x + offset.x) * revertedScale.x * revertedExtents.x) * frequency + randomOffset.x;
                        float sampleY = ((y - middleOffset.y + offset.y) * revertedScale.y * revertedExtents.y) * frequency + randomOffset.y;

                        float perlin = Mathf.PerlinNoise(sampleX, sampleY);
                        value += perlin * amplitude;

                        amplitude *= persistance;
                        frequency *= lacunarity;
                    }

                    result[x, y] = math.smoothstep(noiseHeightMinMax.x, noiseHeightMinMax.y, value);
                }
            }

            return result;
        }

        /// <summary> Noise Map generator smoothed to [0 .. 1] values </summary>
        public static int[,] randommap(int2 extents = default, float fill = 0.5f, int smooths = 5, int seed = 0)
        {
            Random.InitState(seed);

            int[,] result = new int[extents.x, extents.y];
            for (int y = 0; y < extents.y; ++y)
            {
                for (int x = 0; x < extents.x; ++x)
                {
                    var random = Random.Range(0f, 1f);
                    var value = random < fill ? 1 : 0;
                    result[x, y] = value;
                }
            }
            for (int i = 0; i < smooths; ++i)
            {
                for (int y = 0; y < extents.y; ++y)
                {
                    for (int x = 0; x < extents.x; ++x)
                    {
                        int counter = 0;
                        for (int dy = y - 1; dy <= y + 1; ++dy)
                        {
                            for (int dx = x - 1; dx <= x + 1; ++dx)
                            {
                                if (dx == x && dy == y)
                                    continue;
                                if (mathx.inrange(0, extents.x, dx) && mathx.inrange(0, extents.y, dy))
                                    counter += result[dx, dy];
                            }
                        }
                        if (counter > 4)
                            result[x, y] = 1;
                        else if (counter < 4)
                            result[x, y] = 0;
                    }
                }
            }
            return result;
        }
    }
}