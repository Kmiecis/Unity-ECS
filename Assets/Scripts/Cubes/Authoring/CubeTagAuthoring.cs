using Common.ECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class CubeTagAuthoring : AuthoringBehaviour<CubeTag>
    {
        public override CubeTag AsComponent(IBaker baker)
        {
            return new CubeTag();
        }

        public class Baker : Baker<CubeTagAuthoring>
        {
            public override void Bake(CubeTagAuthoring authoring)
            {
                authoring.Bake(this);
            }
        }
    }
}