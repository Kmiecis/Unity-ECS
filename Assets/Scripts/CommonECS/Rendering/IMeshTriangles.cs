using Unity.Mathematics;

namespace CommonECS.Rendering
{
	public interface IMeshTriangles
	{
		void AddTriangle(float3 v0, float3 v1, float3 v2);
	}
}
