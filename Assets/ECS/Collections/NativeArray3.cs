using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Common.ECS.Collections
{
    [NativeContainer]
    [NativeContainerSupportsDeallocateOnJobCompletion]
    public struct NativeArray3<T> : IDisposable
        where T : struct
    {
        private int3 m_Length;
        private NativeArray<T> m_Array;

        public int3 Length
            => m_Length;

        public NativeArray<T> Array
            => m_Array;

        public int Count
            => Width * Height * Depth;

        public int Width
            => Length.x;

        public int Height
            => Length.y;

        public int Depth
            => Length.z;

        public NativeArray3(int3 length, Allocator allocator)
        {
            m_Length = length;
            m_Array = new NativeArray<T>(length.x * length.y * length.z, allocator);
        }

        public NativeArray3(int width, int height, int depth, Allocator allocator) :
            this(new int3(width, height, depth), allocator)
        {
        }

        public T this[int x, int y, int z]
        {
            get { return m_Array[z * Height * Width + y * Width + x]; }
            set { m_Array[z * Height * Width + y * Width + x] = value; }
        }

        public void Dispose()
        {
            m_Array.Dispose();
        }
    }
}