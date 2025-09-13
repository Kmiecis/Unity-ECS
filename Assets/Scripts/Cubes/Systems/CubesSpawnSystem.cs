using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    [BurstCompile]
    [RequireMatchingQueriesForUpdate]
    public partial struct CubesSpawnSystem : ISystem
    {
        private EntityQuery _cubeQuery;
        private EntityQuery _requestQuery;
        private EntityArchetype _cubeArchetype;

        private EntityQuery CreateCubeQuery(ref SystemState state)
        {
            return state.GetEntityQuery(
                ComponentType.ReadOnly<CubeTag>()
            );
        }

        private EntityQuery CreateRequestQuery(ref SystemState state)
        {
            return state.GetEntityQuery(
                ComponentType.ReadOnly<CubesRequest>()
            );
        }

        private EntityArchetype CreateCubeArchetype(ref SystemState state)
        {
            return state.EntityManager.CreateArchetype(
                typeof(LocalTransform),
                typeof(CubeTag)//,
                               //typeof(MaterialBaseColor)
            );
        }

        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<CubeData>();

            _cubeQuery = CreateCubeQuery(ref state);
            _requestQuery = CreateRequestQuery(ref state);
            _cubeArchetype = CreateCubeArchetype(ref state);

            state.RequireForUpdate(_requestQuery);
        }

        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.TempJob);

            var data = SystemAPI.GetSingleton<CubeData>();

            state.EntityManager.DestroyEntity(_cubeQuery);

            foreach (var (request, entity) in SystemAPI.Query<CubesRequest>()
                .WithEntityAccess())
            {
                var size = request.size;

                var cubes = new NativeArray<Cube>(size.x * size.y * size.z, Allocator.TempJob);

                var waveJob = new CubeWaveJob
                {
                    cubes = cubes,
                    size = request.size,
                    fill = request.fill,
                    scale = request.scale,
                    offset = request.offset
                };
                state.Dependency = waveJob.Schedule(size.x, 64, state.Dependency);

                var spawnJob = new CubeSpawnJob
                {
                    cubes = cubes,
                    ecb = ecb.AsParallelWriter(),
                    size = request.size,
                    prefab = data.prefab,
                    archetype = _cubeArchetype
                };
                state.Dependency = spawnJob.Schedule(size.x, 64, state.Dependency);

                state.Dependency.Complete();

                ecb.DestroyEntity(entity);

                cubes.Dispose();
            }

            ecb.Playback(state.EntityManager);
        }

        private struct Cube
        {
            public bool exists;
            public float3 color;
        }

        [BurstCompile]
        private struct CubeWaveJob : IJobParallelFor
        {
            [NativeDisableParallelForRestriction]
            public NativeArray<Cube> cubes;

            public int3 size;
            public float fill;
            public float scale;
            public float3 offset;

            public void Execute(int x)
            {
                for (int z = 0; z < size.z; ++z)
                {
                    for (int y = 0; y < size.y; ++y)
                    {
                        int i = x + (y + z * size.y) * size.x;

                        var xyz = new float3(x, y, z);
                        var sample = xyz * scale + offset;
                        var vnoise = (noise.cnoise(sample) + 1.0f) * 0.5f;

                        var data = new Cube
                        {
                            exists = vnoise < fill,
                            color = new float3(1, 1, 1)// xyz / size
                        };
                        cubes[i] = data;
                    }
                }
            }
        }

        [BurstCompile]
        private struct CubeSpawnJob : IJobParallelFor
        {
            [ReadOnly]
            [NativeDisableParallelForRestriction]
            public NativeArray<Cube> cubes;

            public EntityCommandBuffer.ParallelWriter ecb;

            public int3 size;
            public Entity prefab;
            public EntityArchetype archetype;

            public void Execute(int x)
            {
                var hsize = (float3)size * 0.5f;

                for (int z = 0; z < size.z; ++z)
                {
                    for (int y = 0; y < size.y; ++y)
                    {
                        int i = x + (y + z * size.y) * size.x;

                        var data = cubes[i];
                        if (data.exists)
                        {
                            var entity = CreateEntity(x, y, z);
                            var position = new float3(x, y, z) - hsize;
                            ecb.SetComponent(i, entity, LocalTransform.FromPosition(position));
                            //var color = new float4(data.color, 1.0f);
                            //ecb.SetComponent(i, entity, new MaterialBaseColor { value = color });
                        }
                    }
                }
            }

            private Entity CreateEntity(int x, int y, int z)
            {
                int i = x + (y + z * size.y) * size.x;
                if (IsInside(x, y, z))
                {
                    return ecb.CreateEntity(i, archetype);
                }
                return ecb.Instantiate(i, prefab);
            }

            private bool IsInside(int x, int y, int z)
            {
                return (
                    x > 0 && Exists(x - 1, y, z) &&
                    x < size.x - 1 && Exists(x + 1, y, z) &&
                    y > 0 && Exists(x, y - 1, z) &&
                    y < size.y - 1 && Exists(x, y + 1, z) &&
                    z > 0 && Exists(x, y, z - 1) &&
                    z < size.z - 1 && Exists(x, y, z + 1)
                );
            }

            private bool Exists(int x, int y, int z)
            {
                int i = x + (y + z * size.y) * size.x;
                return cubes[i].exists;
            }
        }
    }
}