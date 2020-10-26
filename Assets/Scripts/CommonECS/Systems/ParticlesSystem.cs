using CommonECS.Components;
using Unity.Entities;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class ParticlesSystem : SystemBase
	{
		private EntityCommandBufferSystem m_CommandBuffer;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_CommandBuffer = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			var commandBuffer = m_CommandBuffer.CreateCommandBuffer().AsParallelWriter();
			
			Entities
				.ForEach((int entityInQueryIndex, Entity entity, in ParticlesOnCreationEffect particlesEffect, in Translation translation) =>
				{
					var newEffectEntity = commandBuffer.Instantiate(entityInQueryIndex, particlesEffect.effect);
					commandBuffer.SetComponent(entityInQueryIndex, newEffectEntity, translation);
					commandBuffer.RemoveComponent<ParticlesOnCreationEffect>(entityInQueryIndex, entity);
				})
				.ScheduleParallel();

			Entities
				.WithAll<DestroyTag>()
				.ForEach((int entityInQueryIndex, Entity entity, in ParticlesOnDestructionEffect particlesEffect, in Translation translation) =>
				{
					var newEffectEntity = commandBuffer.Instantiate(entityInQueryIndex, particlesEffect.effect);
					commandBuffer.SetComponent(entityInQueryIndex, newEffectEntity, translation);
				})
				.ScheduleParallel();

			Entities
				.ForEach((int entityInQueryIndex, Entity entity, in ParticlesOnInvokeEffect particlesEffect, in Translation translation) =>
				{
					if (particlesEffect.invoke)
					{
						var newEffectEntity = commandBuffer.Instantiate(entityInQueryIndex, particlesEffect.effect);
						commandBuffer.SetComponent(entityInQueryIndex, newEffectEntity, translation);
					}
				})
				.ScheduleParallel();

			m_CommandBuffer.AddJobHandleForProducer(this.Dependency);
		}
	}
}