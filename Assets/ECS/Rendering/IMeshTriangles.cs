using Unity.Mathematics;

namespace Common.ECS.Rendering
{
    public interface IMeshTriangles
    {
        void AddTriangle(float3 v0, float3 v1, float3 v2);
    }
}