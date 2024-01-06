using Components;
using Unity.Entities;

namespace Systems
{
    public partial class LivetimeSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = World.Time.DeltaTime;

            Entities
                .ForEach((ref Livetime livetime) =>
                {
                    livetime.value += deltaTime;
                })
                .ScheduleParallel();
        }
    }
}