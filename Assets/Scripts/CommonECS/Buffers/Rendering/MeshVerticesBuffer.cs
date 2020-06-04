using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Buffers
{
	public struct MeshVerticesBuffer : IBufferElementData
	{
		public float3 vertex;
	}
}
