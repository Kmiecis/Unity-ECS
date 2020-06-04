using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Buffers
{
	public struct MeshNormalsBuffer : IBufferElementData
	{
		public float3 normal;
	}
}
