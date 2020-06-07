using CommonECS.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace CommonECS.Mathematics
{
	public static class noisex
	{
		/// <summary> Noise Map generator </summary>
		public static void map(ref NativeArray2<float> map,
			int2 offset = default,
			int octaves = 1, float persistance = 0.5f, float lacunarity = 2.0f,
			float2 scale = default, uint seed = 1
		)
		{
			var extents = map.Extents;

			var random = new Random(seed);
			float2 randomOffset = new float2(random.NextFloat(-99999.0f, +99999.0f), random.NextFloat(-99999.0f, +99999.0f));
			float2 middleOffset = new float2(extents.x * 0.5f, extents.y * 0.5f);
			float2 revertedExtents = new float2(1.0f / extents.x, 1.0f / extents.y);
			float2 revertedScale = new float2(1.0f / math.max(scale.x, 1e-5f), 1.0f / math.max(scale.y, 1e-5f));

			for (int y = 0; y < extents.y; ++y)
			{
				for (int x = 0; x < extents.x; ++x)
				{
					float amplitude = 1.0f;
					float frequency = 1.0f;
					float value = 0.0f;

					for (int i = 0; i < octaves; ++i)
					{
						float sampleX = ((x - middleOffset.x + offset.x) * revertedScale.x * revertedExtents.x) * frequency + randomOffset.x;
						float sampleY = ((y - middleOffset.y + offset.y) * revertedScale.y * revertedExtents.y) * frequency + randomOffset.y;

						float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
						value += perlinValue * amplitude;

						amplitude *= persistance;
						frequency *= lacunarity;
					}

					map[x, y] = value;
				}
			}
		}

		/// <summary> Noise Map generator smoothed to [0 .. 1] values </summary>
		public static void smoothmap(ref NativeArray2<float> map,
			int2 offset = default,
			int octaves = 1, float persistance = 0.5f, float lacunarity = 2.0f,
			float2 scale = default, uint seed = 1
		)
		{
			var extents = map.Extents;

			float2 noiseHeightMinMax = new float2(0.0f, 1.0f);
			for (int i = 1; i < octaves; ++i)
			{
				float persistanceAffection = math.pow(persistance, i);
				noiseHeightMinMax.x += persistanceAffection * 0.25f;
				noiseHeightMinMax.y += persistanceAffection * 0.75f;
			}

			var random = new Random(seed);
			float2 randomOffset = new float2(random.NextFloat(-99999.0f, +99999.0f), random.NextFloat(-99999.0f, +99999.0f));
			float2 middleOffset = new float2(extents.x * 0.5f, extents.y * 0.5f);
			float2 revertedExtents = new float2(1.0f / extents.x, 1.0f / extents.y);
			float2 revertedScale = new float2(1.0f / math.max(scale.x, 1e-4f), 1.0f / math.max(scale.y, 1e-4f));

			for (int y = 0; y < extents.y; ++y)
			{
				for (int x = 0; x < extents.x; ++x)
				{
					float amplitude = 1.0f;
					float frequency = 1.0f;
					float value = 0.0f;

					for (int i = 0; i < octaves; ++i)
					{
						float sampleX = ((x - middleOffset.x + offset.x) * revertedScale.x * revertedExtents.x) * frequency + randomOffset.x;
						float sampleY = ((y - middleOffset.y + offset.y) * revertedScale.y * revertedExtents.y) * frequency + randomOffset.y;

						float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
						value += perlinValue * amplitude;

						amplitude *= persistance;
						frequency *= lacunarity;
					}

					map[x, y] = math.smoothstep(noiseHeightMinMax.x, noiseHeightMinMax.y, value);
				}
			}
		}

		/// <summary> Noise Map generator smoothed to [0 .. 1] values </summary>
		public static void randommap(ref NativeArray2<int> map, float fill = 0.5f, int smooths = 5, uint seed = 1)
		{
			var extents = map.Extents;
			var random = new Random(seed);

			for (int y = 0; y < extents.y; ++y)
			{
				for (int x = 0; x < extents.x; ++x)
				{
					var randomValue = random.NextFloat(0.0f, 1.0f);
					var value = randomValue < fill ? 1 : 0;
					map[x, y] = value;
				}
			}

			for (int i = 0; i < smooths; ++i)
			{
				for (int y = 0; y < extents.y; ++y)
				{
					for (int x = 0; x < extents.x; ++x)
					{
						int counter = 0;

						int dyMin = math.max(y - 1, 0);
						int dyMax = math.min(y + 1, extents.y - 1);
						for (int dy = dyMin; dy <= dyMax; ++dy)
						{
							int dxMin = math.max(x - 1, 0);
							int dxMax = math.min(x + 1, extents.x - 1);
							for (int dx = dxMin; dx <= dxMax; ++dx)
							{
								if (dx == x && dy == y)
								{
									continue;
								}

								counter += map[dx, dy];
							}
						}

						if (counter > 4)
						{
							map[x, y] = 1;
						}
						else if (counter < 4)
						{
							map[x, y] = 0;
						}
					}
				}
			}
		}
	}
}
