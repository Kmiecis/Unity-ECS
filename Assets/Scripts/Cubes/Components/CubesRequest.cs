using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    [Serializable]
    public struct CubesRequest : IComponentData
    {
        public int3 size;
        public float fill;
        public float scale;
        public float3 offset;
    }
}