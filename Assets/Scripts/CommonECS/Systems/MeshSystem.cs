using CommonECS.Buffers;
using CommonECS.Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;

namespace CommonECS.Systems
{
	public class MeshSystem : ComponentSystem
	{
		private EntityQuery m_EntityQuery;
		private EntityManager m_EntityManager;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_EntityManager = World.EntityManager;
			var entityQueryDesc = new EntityQueryDesc()
			{
				All = new ComponentType[]
				{
					ComponentType.ReadWrite<RenderMesh>(),
					ComponentType.ReadOnly<MeshVerticesBuffer>(),
					ComponentType.ReadOnly<MeshTrianglesBuffer>(),
					ComponentType.ReadOnly<MeshRequest>()
				},
				Any = new ComponentType[]
				{
					ComponentType.ReadOnly<MeshNormalsBuffer>(),
					ComponentType.ReadOnly<MeshColorsBuffer>(),
					ComponentType.ReadOnly<MeshUVsBuffer>()
				}
			};
			m_EntityQuery = GetEntityQuery(entityQueryDesc);
		}

		protected override void OnUpdate()
		{
			var entities = m_EntityQuery.ToEntityArray(Allocator.TempJob);

			for (int i = 0; i < entities.Length; ++i)
			{
				var mesh = new Mesh();
				var entity = entities[i];

				var vertices = m_EntityManager.GetBuffer<MeshVerticesBuffer>(entity);
				var triangles = m_EntityManager.GetBuffer<MeshTrianglesBuffer>(entity);
				var normals = m_EntityManager.GetBuffer<MeshNormalsBuffer>(entity);
				ApplyMeshBase(mesh, in vertices, in triangles, in normals);

				if (m_EntityManager.HasComponent<MeshColorsBuffer>(entity))
				{
					var colors = m_EntityManager.GetBuffer<MeshColorsBuffer>(entity);
					ApplyMeshColors(mesh, in colors);
				}
				if (m_EntityManager.HasComponent<MeshUVsBuffer>(entity))
				{
					var uvs = m_EntityManager.GetBuffer<MeshUVsBuffer>(entity);
					ApplyMeshUVs(mesh, in uvs);
				}

				var meshRequest = m_EntityManager.GetComponentData<MeshRequest>(entity);
				var renderMesh = m_EntityManager.GetSharedComponentData<RenderMesh>(entity);
				renderMesh.mesh = mesh;
				renderMesh.material = ResourceManager.Load<Material>(meshRequest.materialPath);
				renderMesh.castShadows = meshRequest.castShadows;
				renderMesh.receiveShadows = meshRequest.receiveShadows;
				m_EntityManager.SetSharedComponentData(entity, renderMesh);

				m_EntityManager.RemoveComponent<MeshRequest>(entity);
			}

			entities.Dispose();
		}

		private void ApplyMeshBase(Mesh mesh,
			in DynamicBuffer<MeshVerticesBuffer> vs,
			in DynamicBuffer<MeshTrianglesBuffer> ts,
			in DynamicBuffer<MeshNormalsBuffer> ns)
		{
			var vsArray = vs.Reinterpret<float3>().AsNativeArray();
			var tsArray = ts.Reinterpret<int>().AsNativeArray();
			var nsArray = ns.Reinterpret<float3>().AsNativeArray();

			mesh.SetVertices(vsArray);
			mesh.SetTriangles(tsArray.ToArray(), 0);
			mesh.SetNormals(nsArray);
		}

		private void ApplyMeshColors(Mesh mesh, in DynamicBuffer<MeshColorsBuffer> cs)
		{
			var csArray = cs.Reinterpret<Color>().AsNativeArray();

			mesh.SetColors(csArray);
		}

		private void ApplyMeshUVs(Mesh mesh, in DynamicBuffer<MeshUVsBuffer> uvs)
		{
			var uvsArray = uvs.Reinterpret<float2>().AsNativeArray();

			mesh.SetUVs(0, uvsArray);
		}
	}
}
