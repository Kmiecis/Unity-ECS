using Unity.Entities;

namespace CommonECS.Systems
{
	public abstract class CommandsSystemBase : SystemBase
	{
		protected EndSimulationEntityCommandBufferSystem m_CommandBufferSystem;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_CommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
		}

		protected EntityCommandBuffer CreateCommandBuffer()
		{
			return m_CommandBufferSystem.CreateCommandBuffer();
		}
	}
}