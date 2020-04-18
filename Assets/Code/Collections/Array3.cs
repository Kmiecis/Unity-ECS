using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Collections
{
    public class Array3<T>
    {
        private int3 m_Extents;
        private T[] m_Array;

        public int3 Length
            => m_Extents;

        public T[] Array
            => m_Array;

        public int Width
            => Length.x;

        public int Height
            => Length.y;

        public int Count
            => Width * Height;

        public Array3(int3 length)
        {
            m_Extents = length;
            m_Array = new T[length.x * length.y];
        }

        public Array3(int width, int height, int depth)
            : this(new int3(width, height, depth))
        {
        }

        public T this[int x, int y, int z]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return m_Array[z * m_Extents.y * m_Extents.x + y * m_Extents.x + x]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { m_Array[z * m_Extents.y * m_Extents.x + y * m_Extents.x + x] = value; }
        }

        public T this[int3 xyz]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this[xyz.x, xyz.y, xyz.z]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { this[xyz.x, xyz.y, xyz.z] = value; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool InBounds(int x, int y, int z)
        {
            return x > -1 && x < m_Extents.x && y > -1 && y < m_Extents.y && z > -1 && z < m_Extents.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool InBounds(int3 xyz)
        {
            return InBounds(xyz.x, xyz.y, xyz.z);
        }
    }
}