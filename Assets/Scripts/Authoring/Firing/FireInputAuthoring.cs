using CommonECS;
using Unity.Entities;

namespace Components.Authoring
{
    public class FireInputAuthoring : AuthoringBehaviour<FireInput>
    {
        public bool fire;

        public override FireInput AsComponent(IBaker baker)
        {
            return new FireInput
            {
                fire = fire
            };
        }
    }

    public class FireInputBaker : Baker<FireInputAuthoring>
    {
        public override void Bake(FireInputAuthoring authoring)
        {
            authoring.Bake(this);
        }
    }
}