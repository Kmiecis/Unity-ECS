using CommonECS.Mathematics;
using Unity.Mathematics;
using UnityEngine;

namespace Common
{
	public class LinearEquationSolver : MonoBehaviour
	{
		[Header("Input")]
		public float2 A;
		public float2 B;
		[Header("Output")]
		public string result;

		void Solve()
		{
			result = LinearEquation.FromPoints(A, B).ToString();
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			Solve();
		}
#endif
	}
}
