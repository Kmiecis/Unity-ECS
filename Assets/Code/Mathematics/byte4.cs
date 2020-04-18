using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Mathematics
{
    [Serializable]
    public struct byte4
    {
        public byte x;
        public byte y;
        public byte z;
        public byte w;

        /// <summary>byte4 zero value.</summary>
        public static readonly byte4 zero;

        /// <summary>Constructs a byte4 vector from two byte values.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte y, byte z, byte w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>Constructs a byte4 vector from two byte values and an byte2 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte y, byte2 zw)
        {
            this.x = x;
            this.y = y;
            this.z = zw.x;
            this.w = zw.y;
        }

        /// <summary>Constructs a byte4 vector from an byte value, an byte2 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte2 yz, byte w)
        {
            this.x = x;
            this.y = yz.x;
            this.z = yz.y;
            this.w = w;
        }

        /// <summary>Constructs a byte4 vector from an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte3 yzw)
        {
            this.x = x;
            this.y = yzw.x;
            this.z = yzw.y;
            this.w = yzw.z;
        }

        /// <summary>Constructs a byte4 vector from an byte2 vector and two byte values.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte2 xy, byte z, byte w)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
            this.w = w;
        }

        /// <summary>Constructs a byte4 vector from two byte2 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte2 xy, byte2 zw)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = zw.x;
            this.w = zw.y;
        }

        /// <summary>Constructs a byte4 vector from an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte3 xyz, byte w)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            this.w = w;
        }

        /// <summary>Constructs a byte4 vector from a byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
            this.w = v.w;
        }

        /// <summary>Constructs a byte4 vector from a single byte value by assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
            this.w = v;
        }

        /// <summary>Constructs a byte4 vector from a single short value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(short v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
            this.w = (byte)v;
        }

        /// <summary>Constructs a byte4 vector from a single int value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(int v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
            this.w = (byte)v;
        }

        /// <summary>Constructs a byte4 vector from a int4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(int4 v)
        {
            this.x = (byte)v.x;
            this.y = (byte)v.y;
            this.z = (byte)v.z;
            this.w = (byte)v.w;
        }

        /// <summary>Constructs a byte4 vector from a single ushort value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(ushort v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
            this.w = (byte)v;
        }

        /// <summary>Constructs a byte4 vector from a single uint value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(uint v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
            this.w = (byte)v;
        }

        /// <summary>Constructs a byte4 vector from a uint4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(uint4 v)
        {
            this.x = (byte)v.x;
            this.y = (byte)v.y;
            this.z = (byte)v.z;
            this.w = (byte)v.w;
        }

        /// <summary>Constructs a byte4 vector from a single float value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(float v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
            this.w = (byte)v;
        }

        /// <summary>Constructs a byte4 vector from a float4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(float4 v)
        {
            this.x = (byte)v.x;
            this.y = (byte)v.y;
            this.z = (byte)v.z;
            this.w = (byte)v.w;
        }

        /// <summary>Constructs a byte4 vector from a single double value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(double v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
            this.w = (byte)v;
        }

        /// <summary>Constructs a byte4 vector from a double4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(double4 v)
        {
            this.x = (byte)v.x;
            this.y = (byte)v.y;
            this.z = (byte)v.z;
            this.w = (byte)v.w;
        }


        /// <summary>Implicitly converts a single byte value to a byte4 vector by assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte4(byte v) { return new byte4(v); }

        /// <summary>Explicitly converts a single short value to a byte4 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(short v) { return new byte4(v); }

        /// <summary>Explicitly converts a single int value to a byte4 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(int v) { return new byte4(v); }

        /// <summary>Explicitly converts a int4 vector to a byte4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(int4 v) { return new byte4(v); }

        /// <summary>Explicitly converts a single ushort value to a byte4 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(ushort v) { return new byte4(v); }

        /// <summary>Explicitly converts a single uint value to a byte4 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(uint v) { return new byte4(v); }

        /// <summary>Explicitly converts a uint4 vector to a byte4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(uint4 v) { return new byte4(v); }

        /// <summary>Explicitly converts a single float value to a byte4 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(float v) { return new byte4(v); }

        /// <summary>Explicitly converts a float4 vector to a byte4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(float4 v) { return new byte4(v); }

        /// <summary>Explicitly converts a single double value to a byte4 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(double v) { return new byte4(v); }

        /// <summary>Explicitly converts a double4 vector to a byte4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(double4 v) { return new byte4(v); }


        /// <summary>Implicitly converts a byte4 vector to a int4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(byte4 v) { return new int4(v.x, v.y, v.z, v.w); }

        /// <summary>Implicitly converts a byte4 vector to a uint4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4(byte4 v) { return new uint4(v.x, v.y, v.z, v.w); }

        /// <summary>Implicitly converts a byte4 vector to a float4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(byte4 v) { return new float4(v.x, v.y, v.z, v.w); }

        /// <summary>Implicitly converts a byte4 vector to a double4 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(byte4 v) { return new double4(v.x, v.y, v.z, v.w); }


        /// <summary>Returns the result of a componentwise multiplication operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator *(byte4 lhs, byte4 rhs) { return new int4(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z, lhs.w * rhs.w); }

        /// <summary>Returns the result of a componentwise multiplication operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator *(byte4 lhs, byte rhs) { return new int4(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs, lhs.w * rhs); }

        /// <summary>Returns the result of a componentwise multiplication operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator *(byte lhs, byte4 rhs) { return new int4(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z, lhs * rhs.w); }


        /// <summary>Returns the result of a componentwise addition operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator +(byte4 lhs, byte4 rhs) { return new int4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w); }

        /// <summary>Returns the result of a componentwise addition operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator +(byte4 lhs, byte rhs) { return new int4(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs, lhs.w + rhs); }

        /// <summary>Returns the result of a componentwise addition operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator +(byte lhs, byte4 rhs) { return new int4(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z, lhs + rhs.w); }


        /// <summary>Returns the result of a componentwise subtraction operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator -(byte4 lhs, byte4 rhs) { return new int4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w); }

        /// <summary>Returns the result of a componentwise subtraction operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator -(byte4 lhs, byte rhs) { return new int4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs); }

        /// <summary>Returns the result of a componentwise subtraction operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator -(byte lhs, byte4 rhs) { return new int4(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z, lhs - rhs.w); }


        /// <summary>Returns the result of a componentwise division operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator /(byte4 lhs, byte4 rhs) { return new int4(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z, lhs.w / rhs.w); }

        /// <summary>Returns the result of a componentwise division operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator /(byte4 lhs, byte rhs) { return new int4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs); }

        /// <summary>Returns the result of a componentwise division operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator /(byte lhs, byte4 rhs) { return new int4(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z, lhs / rhs.w); }


        /// <summary>Returns the result of a componentwise modulus operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator %(byte4 lhs, byte4 rhs) { return new int4(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z, lhs.w % rhs.w); }

        /// <summary>Returns the result of a componentwise modulus operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator %(byte4 lhs, byte rhs) { return new int4(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs, lhs.w % rhs); }

        /// <summary>Returns the result of a componentwise modulus operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator %(byte lhs, byte4 rhs) { return new int4(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z, lhs % rhs.w); }


        /// <summary>Returns the result of a componentwise increment operation on an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ++(byte4 v) { return new byte4(++v.x, ++v.y, ++v.z, ++v.w); }


        /// <summary>Returns the result of a componentwise decrement operation on an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator --(byte4 v) { return new byte4(--v.x, --v.y, --v.z, --v.w); }


        /// <summary>Returns the result of a componentwise less than operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <(byte4 lhs, byte4 rhs) { return new bool4(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z, lhs.w < rhs.w); }

        /// <summary>Returns the result of a componentwise less than operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <(byte4 lhs, byte rhs) { return new bool4(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs, lhs.w < rhs); }

        /// <summary>Returns the result of a componentwise less than operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <(byte lhs, byte4 rhs) { return new bool4(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z, lhs < rhs.w); }


        /// <summary>Returns the result of a componentwise less or equal operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <=(byte4 lhs, byte4 rhs) { return new bool4(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z, lhs.w <= rhs.w); }

        /// <summary>Returns the result of a componentwise less or equal operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <=(byte4 lhs, byte rhs) { return new bool4(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs, lhs.w <= rhs); }

        /// <summary>Returns the result of a componentwise less or equal operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <=(byte lhs, byte4 rhs) { return new bool4(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z, lhs <= rhs.w); }


        /// <summary>Returns the result of a componentwise greater than operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >(byte4 lhs, byte4 rhs) { return new bool4(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z, lhs.w > rhs.w); }

        /// <summary>Returns the result of a componentwise greater than operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >(byte4 lhs, byte rhs) { return new bool4(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs, lhs.w > rhs); }

        /// <summary>Returns the result of a componentwise greater than operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >(byte lhs, byte4 rhs) { return new bool4(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z, lhs > rhs.w); }


        /// <summary>Returns the result of a componentwise greater or equal operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >=(byte4 lhs, byte4 rhs) { return new bool4(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z, lhs.w >= rhs.w); }

        /// <summary>Returns the result of a componentwise greater or equal operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >=(byte4 lhs, byte rhs) { return new bool4(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs, lhs.w >= rhs); }

        /// <summary>Returns the result of a componentwise greater or equal operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >=(byte lhs, byte4 rhs) { return new bool4(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z, lhs >= rhs.w); }


        /// <summary>Returns the result of a componentwise unary minus operation on an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator -(byte4 v) { return new int4(-v.x, -v.y, -v.z, -v.w); }


        /// <summary>Returns the result of a componentwise unary plus operation on an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator +(byte4 v) { return new int4(+v.x, +v.y, +v.z, +v.w); }


        /// <summary>Returns the result of a componentwise left shift operation on an byte4 vector by a number of bits specified by a single int.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator <<(byte4 x, int n) { return new int4(x.x << n, x.y << n, x.z << n, x.w << n); }

        /// <summary>Returns the result of a componentwise right shift operation on an byte4 vector by a number of bits specified by a single int.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator >>(byte4 x, int n) { return new int4(x.x >> n, x.y >> n, x.z >> n, x.w >> n); }


        /// <summary>Returns the result of a componentwise equality operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator ==(byte4 lhs, byte4 rhs) { return new bool4(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z, lhs.w == rhs.w); }

        /// <summary>Returns the result of a componentwise equality operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator ==(byte4 lhs, byte rhs) { return new bool4(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs, lhs.w == rhs); }

        /// <summary>Returns the result of a componentwise equality operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator ==(byte lhs, byte4 rhs) { return new bool4(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z, lhs == rhs.w); }


        /// <summary>Returns the result of a componentwise not equal operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator !=(byte4 lhs, byte4 rhs) { return new bool4(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z, lhs.w != rhs.w); }

        /// <summary>Returns the result of a componentwise not equal operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator !=(byte4 lhs, byte rhs) { return new bool4(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs, lhs.w != rhs); }

        /// <summary>Returns the result of a componentwise not equal operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator !=(byte lhs, byte4 rhs) { return new bool4(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z, lhs != rhs.w); }


        /// <summary>Returns the result of a componentwise bitwise not operation on an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator ~(byte4 v) { return new int4(~v.x, ~v.y, ~v.z, ~v.w); }


        /// <summary>Returns the result of a componentwise bitwise and operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator &(byte4 lhs, byte4 rhs) { return new int4(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z, lhs.w & rhs.w); }

        /// <summary>Returns the result of a componentwise bitwise and operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator &(byte4 lhs, byte rhs) { return new int4(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs, lhs.w & rhs); }

        /// <summary>Returns the result of a componentwise bitwise and operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator &(byte lhs, byte4 rhs) { return new int4(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z, lhs & rhs.w); }


        /// <summary>Returns the result of a componentwise bitwise or operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator |(byte4 lhs, byte4 rhs) { return new int4(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z, lhs.w | rhs.w); }

        /// <summary>Returns the result of a componentwise bitwise or operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator |(byte4 lhs, byte rhs) { return new int4(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs, lhs.w | rhs); }

        /// <summary>Returns the result of a componentwise bitwise or operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator |(byte lhs, byte4 rhs) { return new int4(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z, lhs | rhs.w); }


        /// <summary>Returns the result of a componentwise bitwise exclusive or operation on two byte4 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator ^(byte4 lhs, byte4 rhs) { return new int4(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z, lhs.w ^ rhs.w); }

        /// <summary>Returns the result of a componentwise bitwise exclusive or operation on an byte4 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator ^(byte4 lhs, byte rhs) { return new int4(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs, lhs.w ^ rhs); }

        /// <summary>Returns the result of a componentwise bitwise exclusive or operation on an byte value and an byte4 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator ^(byte lhs, byte4 rhs) { return new int4(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z, lhs ^ rhs.w); }


        /// <summary>Returns the int element at a specified index.</summary>
        unsafe public byte this[int index]
        {
            get { fixed (byte4* array = &this) { return ((byte*)array)[index]; } }
            set { fixed (byte* array = &x) { array[index] = value; } }
        }


        /// <summary>Returns true if the byte4 is equal to a given byte4, false otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte4 v)
        {
            return x == v.x && y == v.y && z == v.z && w == v.w;
        }

        /// <summary>Returns true if the byte4 is equal to a given byte4, false otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            return Equals((byte4)obj);
        }

        /// <summary>Returns a hash code for the byte4.</summary>
        public override int GetHashCode()
        {
            return (int)math.hash(new uint4(x, y, z, w));
        }

        /// <summary>Returns a string representation of the byte4.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("byte4({0}, {1}, {2}, {3})", x, y, z, w);
        }

        /// <summary>Returns a string representation of the half2 using a specified format and culture-specific format information.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("byte4({0}, {1}, {2}, {3})",
                x.ToString(format, formatProvider),
                y.ToString(format, formatProvider),
                z.ToString(format, formatProvider),
                w.ToString(format, formatProvider)
            );
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, x, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, z, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; y = value.y; z = value.z; w = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, w, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; y = value.y; w = value.z; z = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, y, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, y, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; z = value.y; y = value.z; w = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, w, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; z = value.y; w = value.z; y = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, z, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, y, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; w = value.y; y = value.z; z = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, z, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; w = value.y; z = value.z; y = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 xwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(x, w, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, z, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; x = value.y; z = value.z; w = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, w, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; x = value.y; w = value.z; z = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, x, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, y, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, x, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; z = value.y; x = value.z; w = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, w, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; z = value.y; w = value.z; x = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 yzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, z, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, x, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; w = value.y; x = value.z; z = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, z, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; w = value.y; z = value.z; x = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 ywww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(y, w, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, y, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; x = value.y; y = value.z; w = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, w, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; x = value.y; w = value.z; y = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, x, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, x, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; y = value.y; x = value.z; w = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, w, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; y = value.y; w = value.z; x = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, y, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, z, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, x, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; w = value.y; x = value.z; y = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, y, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; w = value.y; y = value.z; x = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 zwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(z, w, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, y, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; x = value.y; y = value.z; z = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, z, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; x = value.y; z = value.z; y = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, x, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, x, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; y = value.y; x = value.z; z = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, z, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; y = value.y; z = value.z; x = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, y, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, x, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; z = value.y; x = value.z; y = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, y, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; z = value.y; y = value.z; x = value.w; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, z, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte4 wwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte4(w, w, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, y, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; y = value.y; z = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, y, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; y = value.y; w = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, z, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; z = value.y; y = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, z, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; z = value.y; w = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, w, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; w = value.y; y = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, w, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; w = value.y; z = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 xww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(x, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, x, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, x, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; x = value.y; z = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, x, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; x = value.y; w = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, y, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, z, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; z = value.y; x = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, z, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; z = value.y; w = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 ywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, w, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; w = value.y; x = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 ywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 ywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, w, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; w = value.y; z = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 yww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(y, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, x, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; x = value.y; y = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, x, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, x, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; x = value.y; w = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, y, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; y = value.y; x = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, y, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, y, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; y = value.y; w = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, z, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, z, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, w, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; w = value.y; x = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, w, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; w = value.y; y = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 zww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(z, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, x, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; x = value.y; y = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, x, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; x = value.y; z = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, x, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, y, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; y = value.y; x = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, y, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; y = value.y; z = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, y, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, z, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; z = value.y; x = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, z, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; z = value.y; y = value.z; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, z, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, w, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, w, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 wwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, w, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte3 www
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte3(w, w, w); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(x, x); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(x, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; y = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(x, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; z = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 xw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(x, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { x = value.x; w = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(y, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; x = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(y, y); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(y, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; z = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 yw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(y, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { y = value.x; w = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(z, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; x = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(z, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; y = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(z, z); }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 zw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(z, w); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { z = value.x; w = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 wx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(w, x); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; x = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 wy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(w, y); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; y = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 wz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(w, z); }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { w = value.x; z = value.y; }
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte2 ww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return new byte2(w, w); }
        }
    }
}