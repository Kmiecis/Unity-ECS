using Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public partial class RotateSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .ForEach((ref LocalTransform transform, in Rotate rotate) =>
                {
                    transform.Rotation = math.normalizesafe(math.mul(transform.Rotation, rotate.value));
                }
                ).ScheduleParallel();
        }
    }
}