using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	public struct minmax
	{
		public float2 min;
		public float2 max;

		public float Width
			=> max.x - min.x;

		public float Height
			=> max.y - min.y;

		public float2 Size
			=> max - min;

		public float2 Center
			=> (min + max) * 0.5f;

		public void Contain(float2 v)
		{
			if (min.x > v.x)
				min.x = v.x;
			if (max.x < v.x)
				max.x = v.x;

			if (min.y > v.y)
				min.y = v.y;
			if (max.y < v.y)
				max.y = v.y;
		}

		public bool Equals(minmax v)
		{
			return min.Equals(v.min) && max.Equals(v.max);
		}

		public override bool Equals(object obj)
		{
			return obj is minmax && Equals((minmax)obj);
		}

		public override string ToString()
		{
			return string.Format("[min: {0}, max: {1}]", min, max);
		}

		public override int GetHashCode()
		{
			return min.GetHashCode() ^ max.GetHashCode();
		}
	}
}
