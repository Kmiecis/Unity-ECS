using Unity.Entities;
using Unity.Rendering;

namespace Components
{
    [MaterialProperty("_Alpha")]
    public struct MaterialAlpha : IComponentData
    {
        public float value;
    }
}