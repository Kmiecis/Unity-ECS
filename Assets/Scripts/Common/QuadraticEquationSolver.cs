using CommonECS.Mathematics;
using Unity.Mathematics;
using UnityEngine;

namespace Common
{
	public class QuadraticEquationSolver : MonoBehaviour
	{
		[Header("Input")]
		public float2 A;
		public float2 B;
		public float2 C;
		[Header("Output")]
		public string result;

		void Solve()
		{
			result = QuadraticEquation.FromPoints(A, B, C).ToString();
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			Solve();
		}
#endif
	}
}
