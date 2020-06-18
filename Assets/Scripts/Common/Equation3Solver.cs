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
			if (!e1.IsValid() || !e2.IsValid() || !e3.IsValid())
			{
				return;
			}

			var ne1 = e1.WithNormalizedC();
			var ne2 = e2.WithNormalizedC();
			var ne3 = e3.WithNormalizedC();

			var ne21 = (ne1 - ne2).WithZeroC();
			var ne32 = (ne2 - ne3).WithZeroC();

			if (!ne21.IsValid() || !ne32.IsValid())
			{
				return;
			}

			ne21.NormalizeB();
			a = ne32.EvaluateA(ne21);
			b = ne32.EvaluateB(a);
			c = ne3.EvaluateC(a, b);
		}

#if UNITY_EDITOR
		private void OnValidate()
		{
			Solve();
		}
#endif
	}
}