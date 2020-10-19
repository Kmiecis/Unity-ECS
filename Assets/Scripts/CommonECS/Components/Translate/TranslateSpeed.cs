using Unity.Entities;

namespace CommonECS.Components
{
	[GenerateAuthoringComponent]
	public struct TranslateSpeed : IComponentData
	{
		public float value;
	}
}
