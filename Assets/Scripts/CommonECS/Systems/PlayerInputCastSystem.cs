using CommonECS.Components;
using CommonECS.Mathematics;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class PlayerInputCastSystem : SystemBase
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

			Entities.ForEach((in Translation translation, in Rotation rotation, in LocalToWorld localToWorld, in Castable castable, in PlayerInput player) =>
			{
				if (player.casts)
				{
					var castedTranslate = new Translate { value = localToWorld.Forward };
					var castedRotation = new Rotation { Value = quaternion.LookRotation(localToWorld.Forward, axis.UP) };
					var castedTranslation = new Translation { Value = localToWorld.Position + math.mul(castedRotation.Value, castable.offset) };
					var casted = commandBuffer.Instantiate(0, castable.prefab);
					commandBuffer.SetComponent(0, casted, castedTranslation);
					commandBuffer.SetComponent(0, casted, castedRotation);
					commandBuffer.SetComponent(0, casted, castedTranslate);
				}
			}
			).ScheduleParallel();

			m_CommandBufferSystem.AddJobHandleForProducer(this.Dependency);
		}
	}
}