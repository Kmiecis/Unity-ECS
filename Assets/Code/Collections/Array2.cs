using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Collections
{
    public class Array2<T>
    {
        private int2 m_Extents;
        private T[] m_Array;

        public int2 Extents
            => m_Extents;

        public T[] Array
            => m_Array;

        public int Width
            => Extents.x;

        public int Height
            => Extents.y;

        public int Count
            => Width * Height;

        public Array2(int2 extents)
        {
            m_Extents = extents;
            m_Array = new T[extents.x * extents.y];
        }

        public Array2(int width, int height)
            : this(new int2(width, height))
        {
        }

        public T this[int x, int y]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return m_Array[y * m_Extents.x + x]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { m_Array[y * m_Extents.x + x] = value; }
        }

        public T this[int2 xy]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this[xy.x, xy.y]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { this[xy.x, xy.y] = value; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool InBounds(int x, int y)
        {
            return x > -1 && x < m_Extents.x && y > -1 && y < m_Extents.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool InBounds(int2 xy)
        {
            return InBounds(xy.x, xy.y);
        }
    }
}