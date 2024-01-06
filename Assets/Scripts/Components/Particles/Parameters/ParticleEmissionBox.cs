﻿using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct ParticleEmissionBox : IComponentData
    {
        public float3 min;
        public float3 max;
    }
}