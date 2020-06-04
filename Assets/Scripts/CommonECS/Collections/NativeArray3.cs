using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace CommonECS.Collections
{
	[NativeContainer]
	[NativeContainerSupportsDeallocateOnJobCompletion]
	public struct NativeArray3<T> : IDisposable
		where T : struct
	{
		private int3 m_Extents;
		private NativeArray<T> m_Array;

		public int3 Extents
			=> m_Extents;

		public NativeArray<T> Array
			=> m_Array;

		public int Width
			=> Extents.x;

		public int Height
			=> Extents.y;

		public int Depth
			=> Extents.z;

		public int Length
			=> Width * Height * Depth;

		public NativeArray3(int3 extents, Allocator allocator)
		{
			m_Extents = extents;
			m_Array = new NativeArray<T>(extents.x * extents.y * extents.z, allocator);
		}

		public NativeArray3(int width, int height, int depth, Allocator allocator) :
			this(new int3(width, height, depth), allocator)
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

		public void Dispose()
		{
			m_Array.Dispose();
		}
	}
}
