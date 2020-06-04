using CommonECS.Buffers;
using CommonECS.Mathematics;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Rendering
{
	public struct FlatMeshDataColors : IMeshTriangles, IMeshColors
	{
		private DynamicBuffer<float3> m_Vertices;
		private DynamicBuffer<int> m_Triangles;
		private DynamicBuffer<float3> m_Normals;
		private DynamicBuffer<byte4> m_Colors;

		public FlatMeshDataColors(DynamicBuffer<MeshVerticesBuffer> vs,
			DynamicBuffer<MeshTrianglesBuffer> ts,
			DynamicBuffer<MeshNormalsBuffer> ns,
			DynamicBuffer<MeshColorsBuffer> cs)
		{
			m_Vertices = vs.Reinterpret<float3>();
			m_Triangles = ts.Reinterpret<int>();
			m_Normals = ns.Reinterpret<float3>();
			m_Colors = cs.Reinterpret<byte4>();
		}

		public FlatMeshDataColors(EntityManager entityManager, Entity entity) :
			this(entityManager.GetBuffer<MeshVerticesBuffer>(entity),
				entityManager.GetBuffer<MeshTrianglesBuffer>(entity),
				entityManager.GetBuffer<MeshNormalsBuffer>(entity),
				entityManager.GetBuffer<MeshColorsBuffer>(entity))
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
		public void AddColors(byte4 c0, byte4 c1, byte4 c2)
		{
			AddColor(c0);
			AddColor(c1);
			AddColor(c2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AddColor(byte4 c)
		{
			m_Colors.Add(c);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
			m_Vertices.Clear();
			m_Triangles.Clear();
			m_Normals.Clear();
			m_Colors.Clear();
		}
	}
}
