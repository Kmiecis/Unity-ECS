using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace CommonECS.Collections
{
	[NativeContainer]
	[NativeContainerSupportsDeallocateOnJobCompletion]
	public struct NativeArray2<T> : IDisposable
		where T : struct
	{
		private int2 m_Extents;
		private NativeArray<T> m_Array;

		public int2 Extents
			=> m_Extents;

		public NativeArray<T> Array
			=> m_Array;

		public int Width
			=> Extents.x;

		public int Height
			=> Extents.y;

		public int Length
			=> Width * Height;

		public NativeArray2(int2 extents, Allocator allocator)
		{
			m_Extents = extents;
			m_Array = new NativeArray<T>(extents.x * extents.y, allocator);
		}

		public NativeArray2(int width, int height, Allocator allocator)
			: this(new int2(width, height), allocator)
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

		public void Dispose()
		{
			m_Array.Dispose();
		}
	}
}
