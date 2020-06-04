using CommonECS.Components;
using Unity.Entities;
using Unity.Jobs;

namespace CommonECS.Systems
{
	public class ProcessCreatedSystem : SystemBase
	{
		private BeginInitializationEntityCommandBufferSystem m_CommandBufferSystem;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_CommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			var commandBuffer = m_CommandBufferSystem.CreateCommandBuffer().ToConcurrent();

			Entities.WithAll<CreatedTag>().ForEach((Entity entity) => {
				commandBuffer.RemoveComponent<CreatedTag>(entity.Index, entity);
			}).ScheduleParallel();

			m_CommandBufferSystem.AddJobHandleForProducer(this.Dependency);
		}
	}
}
