﻿using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Mathematics
{
    public struct AABB2
    {
        public float2 position;
        public float2 size;

        public float Width
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return size.x; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { size.x = value; }
        }

        public float Height
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return size.y; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { size.y = value; }
        }

        public float2 Min
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return position; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { size += position - value; position = value; }
        }

        public float2 Max
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return position + size; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { size += (value - this.Max); }
        }

        public float2 Center
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return position + size * 0.5f; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { position += (value - this.Center); }
        }

        public float Area
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return size.x * size.y; }
        }

        public float Perimeter
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return 2 * size.x + 2 * size.y; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(float2 p)
        {
            var min = this.Min;
            var max = this.Max;
            return p.x > min.x && p.x < max.x && p.y > min.y && p.y < max.y;
        }

        public bool Equals(AABB2 v)
        {
            return position.Equals(v.position) && size.Equals(v.size);
        }

        public override bool Equals(object obj)
        {
            if (obj is AABB2)
                return Equals((AABB2)obj);
            return false;
        }

        public override string ToString()
        {
            return string.Format("[position: {0}, size: {1}]", position, size);
        }

        public override int GetHashCode()
        {
            return position.GetHashCode() ^ size.GetHashCode();
        }
    }
}