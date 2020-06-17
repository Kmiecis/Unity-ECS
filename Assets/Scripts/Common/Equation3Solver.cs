using CommonECS.Mathematics;
using UnityEngine;

namespace Common
{
	public class Equation3Solver : MonoBehaviour
	{
		[Header("Input")]
		public Equation3 e1;
		public Equation3 e2;
		public Equation3 e3;
		[Header("Result")]
		public float a;
		public float b;
		public float c;

		void Solve()
		{

		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			Solve();
		}
#endif
	}
}