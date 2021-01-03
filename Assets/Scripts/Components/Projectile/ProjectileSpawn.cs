using Unity.Entities;
using Unity.Mathematics;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ProjectileSpawn : IComponentData
	{
		public float3 offset;
		public quaternion rotation;
	}
}