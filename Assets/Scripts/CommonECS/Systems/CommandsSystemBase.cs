using Unity.Entities;

namespace CommonECS.Systems
{
	public abstract class CommandsSystemBase : SystemBase
	{
		protected BeginInitializationEntityCommandBufferSystem m_CommandBufferSystem;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_CommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
		}

		protected EntityCommandBuffer CreateCommandBuffer()
		{
			return m_CommandBufferSystem.CreateCommandBuffer();
		}

		protected EntityCommandBuffer.ParallelWriter CreateParallelWriter()
		{
			return m_CommandBufferSystem.CreateCommandBuffer().AsParallelWriter();
		}

		protected void FinalizeDependency()
		{
			m_CommandBufferSystem.AddJobHandleForProducer(this.Dependency);
		}
	}
}