﻿using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct ParticleEffectPrefab : IComponentData
	{
		public Entity value;
	}
}