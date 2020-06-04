using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Buffers
{
	public struct MeshUVsBuffer : IBufferElementData
	{
		public float2 uv;
	}
}
