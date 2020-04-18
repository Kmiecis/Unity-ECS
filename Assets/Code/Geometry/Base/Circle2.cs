using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Mathematics
{
    public struct Circle2
    {
        public float2 position;
        public float radius;

        public float Diameter
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return radius * 2f; }
        }

        public float Area
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return math.PI * radius * radius; }
        }

        public float Circumference
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return 2 * math.PI * radius; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Distance(float2 v)
        {
            return math.distance(position, v) - radius;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float DistanceSq(float2 v)
        {
            return math.distancesq(position, v) - radius * radius;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(float2 v)
        {
            var dx = position.x - v.x;
            var dy = position.y - v.y;
            return dx * dx + dy * dy < radius * radius;
        }

        public static Circle2 Create(float2 v0, float2 v1, float2 v2)
        {
            var m1c = new float3(v0.x * v0.x + v0.y * v0.y, v1.x * v1.x + v1.y * v1.y, v2.x * v2.x + v2.y * v2.y);
            var m2c = new float3(v0.x, v1.x, v2.x);
            var m3c = new float3(v0.y, v1.y, v2.y);
            var m4c = new float3(1, 1, 1);

            var M11 = new float3x3(m2c, m3c, m4c);
            var M12 = new float3x3(m1c, m3c, m4c);
            var M13 = new float3x3(m1c, m2c, m4c);
            var M14 = new float3x3(m1c, m2c, m3c);

            var detM11 = math.determinant(M11);
            var detM12 = math.determinant(M12);
            var detM13 = math.determinant(M13);
            var detM14 = math.determinant(M14);

            if (detM11 == 0)
                return new Circle2 { position = float2.zero, radius = float.MaxValue };

            var x = 0.5f * detM12 / detM11;
            var y = -0.5f * detM13 / detM11;
            var r = math.sqrt(x * x + y * y + detM14 / detM11);

            return new Circle2 { position = new float2(x, y), radius = r };
        }
        
        public bool Equals(Circle2 v)
        {
            return radius.Equals(v.radius) && position.Equals(v.position);
        }

        public override bool Equals(object obj)
        {
            if (obj is Circle2)
                return Equals((Circle2)obj);
            return false;
        }

        public override string ToString()
        {
            return string.Format("[position: {0}, radius: {1}]", position, radius);
        }

        public override int GetHashCode()
        {
            return position.GetHashCode() ^ radius.GetHashCode();
        }
    }
}