using Unity.Collections;
using System;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Common.ECS.Collections
{
    [NativeContainer]
    [NativeContainerSupportsDeallocateOnJobCompletion]
    public struct NativeArray2<T> : IDisposable
        where T : struct
    {
        private int2 m_Length;
        private NativeArray<T> m_Array;

        public int2 Length
            => m_Length;

        public NativeArray<T> Array
            => m_Array;

        public int Width
            => Length.x;

        public int Height
            => Length.y;

        public int Count
            => Width * Height;

        public NativeArray2(int2 length, Allocator allocator)
        {
            m_Length = length;
            m_Array = new NativeArray<T>(length.x * length.y, allocator);
        }

        public NativeArray2(int width, int height, Allocator allocator)
            : this(new int2(width, height), allocator)
        {
        }

        public T this[int x, int y]
        {
            get { return m_Array[y * m_Length.x + x]; }
            set { m_Array[y * m_Length.x + x] = value; }
        }

        public void Dispose()
        {
            m_Array.Dispose();
        }
    }
}