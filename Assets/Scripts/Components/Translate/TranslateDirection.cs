using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct TranslateDirection : IComponentData
    {
        public float3 value;
    }
}