using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	public struct axis
	{
		public static readonly float3 UP = new float3(0f, 1f, 0f);
		public static readonly float3 RIGHT = new float3(1f, 0f, 0f);
		public static readonly float3 FORWARD = new float3(0f, 0f, 1f);
	}
}
