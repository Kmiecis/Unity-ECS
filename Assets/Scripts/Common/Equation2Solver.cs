using CommonECS.Mathematics;
using UnityEngine;

namespace Common
{
	public class Equation2Solver : MonoBehaviour
	{
		[Header("Input")]
		public Equation2 e1;
		public Equation2 e2;
		[Header("Output")]
		public float a;
		public float b;

		public void Solve()
		{
			if (!e1.IsValid() || !e2.IsValid())
			{
				return;
			}

			var ne1 = e1.WithNormalizedA();
			b = e2.EvaluateB(ne1);
			a = e1.EvaluateA(b);
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			Solve();
		}
#endif
	}
}
