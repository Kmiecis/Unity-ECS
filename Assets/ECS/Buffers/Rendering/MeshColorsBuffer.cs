using Common.Mathematics;
using Unity.Entities;

namespace Common.ECS.Buffers
{
    public struct MeshColorsBuffer : IBufferElementData
    {
        public byte4 color;
    }
}