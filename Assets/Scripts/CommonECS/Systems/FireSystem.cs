using CommonECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace CommonECS.Systems
{
	public class FireSystem : SystemBase
	{
		private BeginInitializationEntityCommandBufferSystem m_CommandBufferSystem;

		protected override void OnCreate()
		{
			base.OnCreate();
			m_CommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			var commandBuffer = m_CommandBufferSystem.CreateCommandBuffer().AsParallelWriter();
			var deltaTime = Time.DeltaTime;

			Entities
				.ForEach((int entityInQueryIndex, ref FireCooldown fireCooldown, in FireInput fireInput, in FireInterval fireInterval, in FireSpeed fireSpeed, in ProjectilePrefab projectilePrefab, in ProjectileSpawn projectileSpawn, in LocalToWorld localToWorld) =>
				{
					if (fireCooldown.value > 0.0f)
					{
						fireCooldown.value -= deltaTime;
					}

					if (
						fireInput.fire &&
						fireCooldown.value <= 0.0f
					)
					{
						var firedProjectile = commandBuffer.Instantiate(entityInQueryIndex, projectilePrefab.value);

						var firedTranslateComponent = new Translate { value = localToWorld.Forward };
						var firedTranslateSpeedComponent = new TranslateSpeed { value = fireSpeed.value };
						var firedTranslationComponent = new Translation { Value = math.transform(localToWorld.Value, projectileSpawn.offset) };
						var firedRotationComponent = new Rotation { Value = quaternion.LookRotation(localToWorld.Forward, math.up()) };

						commandBuffer.SetComponent(entityInQueryIndex, firedProjectile, firedTranslateComponent);
						commandBuffer.SetComponent(entityInQueryIndex, firedProjectile, firedTranslateSpeedComponent);
						commandBuffer.SetComponent(entityInQueryIndex, firedProjectile, firedTranslationComponent);
						commandBuffer.SetComponent(entityInQueryIndex, firedProjectile, firedRotationComponent);

						fireCooldown.value = fireInterval.value;
					}
				})
				.ScheduleParallel();

			m_CommandBufferSystem.AddJobHandleForProducer(this.Dependency);
		}
	}
}