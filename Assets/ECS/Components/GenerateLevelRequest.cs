using Unity.Entities;
using Unity.Mathematics;

namespace Common.ECS.Components
{
    public struct GenerateLevelRequest : IComponentData
    {
        public int2 position;
        public int radius;
    }
}