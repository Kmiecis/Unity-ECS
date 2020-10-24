using Unity.Entities;
using UnityEngine.Rendering;

namespace CommonECS.Components
{
	public struct MeshRequest : IComponentData
	{
		public ResourcePath materialPath;
		public ShadowCastingMode castShadows;
		public bool receiveShadows;
	}
}
