using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;

namespace Components
{
    [MaterialProperty("_BaseColor")]
    public struct MaterialBaseColor : IComponentData
    {
        public float4 value;
    }
}