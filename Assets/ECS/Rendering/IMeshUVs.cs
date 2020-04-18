using Unity.Mathematics;

namespace Common.ECS.Rendering
{
    public interface IMeshUVs
    {
        void AddUVs(float2 uv0, float2 uv1, float2 uv2);
    }
}