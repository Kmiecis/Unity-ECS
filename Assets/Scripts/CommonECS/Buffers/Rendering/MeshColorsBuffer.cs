using CommonECS.Mathematics;
using Unity.Entities;

namespace CommonECS.Buffers
{
	public struct MeshColorsBuffer : IBufferElementData
	{
		public byte4 color;
	}
}
