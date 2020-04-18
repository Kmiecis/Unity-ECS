using Common.ECS.Buffers;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Rendering
{
    public struct FlatMeshDataUVs : IMeshTriangles, IMeshUVs
    {
        private DynamicBuffer<float3> m_Vertices;
        private DynamicBuffer<int> m_Triangles;
        private DynamicBuffer<float3> m_Normals;
        private DynamicBuffer<float2> m_UVs;

        public FlatMeshDataUVs(DynamicBuffer<MeshVerticesBuffer> vs,
            DynamicBuffer<MeshTrianglesBuffer> ts,
            DynamicBuffer<MeshNormalsBuffer> ns,
            DynamicBuffer<MeshUVsBuffer> uvs)
        {
            m_Vertices = vs.Reinterpret<float3>();
            m_Triangles = ts.Reinterpret<int>();
            m_Normals = ns.Reinterpret<float3>();
            m_UVs = uvs.Reinterpret<float2>();
        }

        public FlatMeshDataUVs(EntityManager entityManager, Entity entity) :
            this(entityManager.GetBuffer<MeshVerticesBuffer>(entity),
                entityManager.GetBuffer<MeshTrianglesBuffer>(entity),
                entityManager.GetBuffer<MeshNormalsBuffer>(entity),
                entityManager.GetBuffer<MeshUVsBuffer>(entity))
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddTriangle(float3 v0, float3 v1, float3 v2)
        {
            var n = math.cross(v1 - v0, v2 - v1);
            AddVertex(v0, n);
            AddVertex(v1, n);
            AddVertex(v2, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddVertex(float3 v, float3 n)
        {
            m_Vertices.Add(v);
            m_Triangles.Add(m_Triangles.Length);
            m_Normals.Add(n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddUVs(float2 uv0, float2 uv1, float2 uv2)
        {
            AddUV(uv0);
            AddUV(uv1);
            AddUV(uv2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddUV(float2 uv)
        {
            m_UVs.Add(uv);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
            m_Vertices.Clear();
            m_Triangles.Clear();
            m_Normals.Clear();
            m_UVs.Clear();
        }
    }
}