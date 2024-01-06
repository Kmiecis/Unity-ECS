using Components;
using Unity.Entities;
using Unity.Transforms;

namespace Systems
{
    public partial class TranslateSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = World.Time.DeltaTime;

            Entities
                .ForEach((ref LocalTransform transform, in TranslateDirection direction, in TranslateSpeed speed) =>
                {
                    transform.Position += direction.value * speed.value * deltaTime;
                }
                ).ScheduleParallel();
        }
    }
}
