using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common.Mathematics
{
    [Serializable]
    public struct byte3
    {
        public byte x;
        public byte y;
        public byte z;

        /// <summary>byte3 zero value.</summary>
        public static readonly byte3 zero;

        /// <summary>Constructs a byte3 vector from two byte values.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte x, byte y, byte z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>Constructs a byte3 vector from an byte value and an byte2 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte x, byte2 yz)
        {
            this.x = x;
            this.y = yz.x;
            this.z = yz.y;
        }

        /// <summary>Constructs a byte3 vector from an byte2 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte2 xy, byte z)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }

        /// <summary>Constructs a byte3 vector from a byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte3 xyz)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
        }

        /// <summary>Constructs a byte3 vector from a single byte value by assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte v)
        {
            this.x = v;
            this.y = v;
            this.z = v;
        }

        /// <summary>Constructs a byte3 vector from a single short value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(short v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
        }

        /// <summary>Constructs a byte3 vector from a single int value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(int v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
        }

        /// <summary>Constructs a byte3 vector from a int3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(int3 v)
        {
            this.x = (byte)v.x;
            this.y = (byte)v.y;
            this.z = (byte)v.z;
        }

        /// <summary>Constructs a byte3 vector from a single ushort value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(ushort v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
        }

        /// <summary>Constructs a byte3 vector from a single uint value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(uint v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
        }

        /// <summary>Constructs a byte3 vector from a uint3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(uint3 v)
        {
            this.x = (byte)v.x;
            this.y = (byte)v.y;
            this.z = (byte)v.z;
        }

        /// <summary>Constructs a byte3 vector from a single float value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(float v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
        }

        /// <summary>Constructs a byte3 vector from a float3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(float3 v)
        {
            this.x = (byte)v.x;
            this.y = (byte)v.y;
            this.z = (byte)v.z;
        }

        /// <summary>Constructs a byte3 vector from a single double value by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(double v)
        {
            this.x = (byte)v;
            this.y = (byte)v;
            this.z = (byte)v;
        }

        /// <summary>Constructs a byte3 vector from a double3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(double3 v)
        {
            this.x = (byte)v.x;
            this.y = (byte)v.y;
            this.z = (byte)v.z;
        }


        /// <summary>Implicitly converts a single byte value to a byte3 vector by assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte3(byte v) { return new byte3(v); }

        /// <summary>Explicitly converts a single short value to a byte3 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(short v) { return new byte3(v); }

        /// <summary>Explicitly converts a single int value to a byte3 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(int v) { return new byte3(v); }

        /// <summary>Explicitly converts a int3 vector to a byte3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(int3 v) { return new byte3(v); }

        /// <summary>Explicitly converts a single ushort value to a byte3 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(ushort v) { return new byte3(v); }

        /// <summary>Explicitly converts a single uint value to a byte3 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(uint v) { return new byte3(v); }

        /// <summary>Explicitly converts a uint3 vector to a byte3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(uint3 v) { return new byte3(v); }

        /// <summary>Explicitly converts a single float value to a byte3 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(float v) { return new byte3(v); }

        /// <summary>Explicitly converts a float3 vector to a byte3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(float3 v) { return new byte3(v); }

        /// <summary>Explicitly converts a single double value to a byte3 vector by converting it to byte and assigning it to every component.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(double v) { return new byte3(v); }

        /// <summary>Explicitly converts a double3 vector to a byte3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(double3 v) { return new byte3(v); }


        /// <summary>Implicitly converts a byte3 vector to a int3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(byte3 v) { return new int3(v.x, v.y, v.z); }

        /// <summary>Implicitly converts a byte3 vector to a uint3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(byte3 v) { return new uint3(v.x, v.y, v.z); }

        /// <summary>Implicitly converts a byte3 vector to a float3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(byte3 v) { return new float3(v.x, v.y, v.z); }

        /// <summary>Implicitly converts a byte3 vector to a double3 vector by componentwise conversion.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(byte3 v) { return new double3(v.x, v.y, v.z); }


        /// <summary>Returns the result of a componentwise multiplication operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator *(byte3 lhs, byte3 rhs) { return new int3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z); }

        /// <summary>Returns the result of a componentwise multiplication operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator *(byte3 lhs, byte rhs) { return new int3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs); }

        /// <summary>Returns the result of a componentwise multiplication operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator *(byte lhs, byte3 rhs) { return new int3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z); }


        /// <summary>Returns the result of a componentwise addition operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator +(byte3 lhs, byte3 rhs) { return new int3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z); }

        /// <summary>Returns the result of a componentwise addition operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator +(byte3 lhs, byte rhs) { return new int3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs); }

        /// <summary>Returns the result of a componentwise addition operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator +(byte lhs, byte3 rhs) { return new int3(lhs + rhs.x, lhs + rhs.y, lhs + rhs.z); }


        /// <summary>Returns the result of a componentwise subtraction operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator -(byte3 lhs, byte3 rhs) { return new int3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z); }

        /// <summary>Returns the result of a componentwise subtraction operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator -(byte3 lhs, byte rhs) { return new int3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs); }

        /// <summary>Returns the result of a componentwise subtraction operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator -(byte lhs, byte3 rhs) { return new int3(lhs - rhs.x, lhs - rhs.y, lhs - rhs.z); }


        /// <summary>Returns the result of a componentwise division operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator /(byte3 lhs, byte3 rhs) { return new int3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z); }

        /// <summary>Returns the result of a componentwise division operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator /(byte3 lhs, byte rhs) { return new int3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs); }

        /// <summary>Returns the result of a componentwise division operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator /(byte lhs, byte3 rhs) { return new int3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z); }


        /// <summary>Returns the result of a componentwise modulus operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator %(byte3 lhs, byte3 rhs) { return new int3(lhs.x % rhs.x, lhs.y % rhs.y, lhs.z % rhs.z); }

        /// <summary>Returns the result of a componentwise modulus operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator %(byte3 lhs, byte rhs) { return new int3(lhs.x % rhs, lhs.y % rhs, lhs.z % rhs); }

        /// <summary>Returns the result of a componentwise modulus operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator %(byte lhs, byte3 rhs) { return new int3(lhs % rhs.x, lhs % rhs.y, lhs % rhs.z); }


        /// <summary>Returns the result of a componentwise increment operation on an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ++(byte3 v) { return new byte3(++v.x, ++v.y, ++v.z); }


        /// <summary>Returns the result of a componentwise decrement operation on an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator --(byte3 v) { return new byte3(--v.x, --v.y, --v.z); }


        /// <summary>Returns the result of a componentwise less than operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <(byte3 lhs, byte3 rhs) { return new bool3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z); }

        /// <summary>Returns the result of a componentwise less than operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <(byte3 lhs, byte rhs) { return new bool3(lhs.x < rhs, lhs.y < rhs, lhs.z < rhs); }

        /// <summary>Returns the result of a componentwise less than operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <(byte lhs, byte3 rhs) { return new bool3(lhs < rhs.x, lhs < rhs.y, lhs < rhs.z); }


        /// <summary>Returns the result of a componentwise less or equal operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <=(byte3 lhs, byte3 rhs) { return new bool3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z); }

        /// <summary>Returns the result of a componentwise less or equal operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <=(byte3 lhs, byte rhs) { return new bool3(lhs.x <= rhs, lhs.y <= rhs, lhs.z <= rhs); }

        /// <summary>Returns the result of a componentwise less or equal operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <=(byte lhs, byte3 rhs) { return new bool3(lhs <= rhs.x, lhs <= rhs.y, lhs <= rhs.z); }


        /// <summary>Returns the result of a componentwise greater than operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >(byte3 lhs, byte3 rhs) { return new bool3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z); }

        /// <summary>Returns the result of a componentwise greater than operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >(byte3 lhs, byte rhs) { return new bool3(lhs.x > rhs, lhs.y > rhs, lhs.z > rhs); }

        /// <summary>Returns the result of a componentwise greater than operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >(byte lhs, byte3 rhs) { return new bool3(lhs > rhs.x, lhs > rhs.y, lhs > rhs.z); }


        /// <summary>Returns the result of a componentwise greater or equal operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >=(byte3 lhs, byte3 rhs) { return new bool3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z); }

        /// <summary>Returns the result of a componentwise greater or equal operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >=(byte3 lhs, byte rhs) { return new bool3(lhs.x >= rhs, lhs.y >= rhs, lhs.z >= rhs); }

        /// <summary>Returns the result of a componentwise greater or equal operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >=(byte lhs, byte3 rhs) { return new bool3(lhs >= rhs.x, lhs >= rhs.y, lhs >= rhs.z); }


        /// <summary>Returns the result of a componentwise unary minus operation on an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator -(byte3 v) { return new int3(-v.x, -v.y, -v.z); }


        /// <summary>Returns the result of a componentwise unary plus operation on an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator +(byte3 v) { return new int3(+v.x, +v.y, +v.z); }


        /// <summary>Returns the result of a componentwise left shift operation on an byte3 vector by a number of bits specified by a single int.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator <<(byte3 x, int n) { return new int3(x.x << n, x.y << n, x.z << n); }

        /// <summary>Returns the result of a componentwise right shift operation on an byte3 vector by a number of bits specified by a single int.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator >>(byte3 x, int n) { return new int3(x.x >> n, x.y >> n, x.z >> n); }


        /// <summary>Returns the result of a componentwise equality operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator ==(byte3 lhs, byte3 rhs) { return new bool3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z); }

        /// <summary>Returns the result of a componentwise equality operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator ==(byte3 lhs, byte rhs) { return new bool3(lhs.x == rhs, lhs.y == rhs, lhs.z == rhs); }

        /// <summary>Returns the result of a componentwise equality operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator ==(byte lhs, byte3 rhs) { return new bool3(lhs == rhs.x, lhs == rhs.y, lhs == rhs.z); }


        /// <summary>Returns the result of a componentwise not equal operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator !=(byte3 lhs, byte3 rhs) { return new bool3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z); }

        /// <summary>Returns the result of a componentwise not equal operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator !=(byte3 lhs, byte rhs) { return new bool3(lhs.x != rhs, lhs.y != rhs, lhs.z != rhs); }

        /// <summary>Returns the result of a componentwise not equal operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator !=(byte lhs, byte3 rhs) { return new bool3(lhs != rhs.x, lhs != rhs.y, lhs != rhs.z); }


        /// <summary>Returns the result of a componentwise bitwise not operation on an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ~(byte3 v) { return new int3(~v.x, ~v.y, ~v.z); }


        /// <summary>Returns the result of a componentwise bitwise and operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator &(byte3 lhs, byte3 rhs) { return new int3(lhs.x & rhs.x, lhs.y & rhs.y, lhs.z & rhs.z); }

        /// <summary>Returns the result of a componentwise bitwise and operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator &(byte3 lhs, byte rhs) { return new int3(lhs.x & rhs, lhs.y & rhs, lhs.z & rhs); }

        /// <summary>Returns the result of a componentwise bitwise and operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator &(byte lhs, byte3 rhs) { return new int3(lhs & rhs.x, lhs & rhs.y, lhs & rhs.z); }


        /// <summary>Returns the result of a componentwise bitwise or operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator |(byte3 lhs, byte3 rhs) { return new int3(lhs.x | rhs.x, lhs.y | rhs.y, lhs.z | rhs.z); }

        /// <summary>Returns the result of a componentwise bitwise or operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator |(byte3 lhs, byte rhs) { return new int3(lhs.x | rhs, lhs.y | rhs, lhs.z | rhs); }

        /// <summary>Returns the result of a componentwise bitwise or operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator |(byte lhs, byte3 rhs) { return new int3(lhs | rhs.x, lhs | rhs.y, lhs | rhs.z); }


        /// <summary>Returns the result of a componentwise bitwise exclusive or operation on two byte3 vectors.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^(byte3 lhs, byte3 rhs) { return new int3(lhs.x ^ rhs.x, lhs.y ^ rhs.y, lhs.z ^ rhs.z); }

        /// <summary>Returns the result of a componentwise bitwise exclusive or operation on an byte3 vector and an byte value.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^(byte3 lhs, byte rhs) { return new int3(lhs.x ^ rhs, lhs.y ^ rhs, lhs.z ^ rhs); }

        /// <summary>Returns the result of a componentwise bitwise exclusive or operation on an byte value and an byte3 vector.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^(byte lhs, byte3 rhs) { return new int3(lhs ^ rhs.x, lhs ^ rhs.y, lhs ^ rhs.z); }


        /// <summary>Returns the int element at a specified index.</summary>
        unsafe public byte this[int index]
        {
            get { fixed (byte3* array = &this) { return ((byte*)array)[index]; } }
            set { fixed (byte* array = &x) { array[index] = value; } }
        }


        /// <summary>Returns true if the byte3 is equal to a given byte3, false otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte3 xyz)
        {
            return x == xyz.x && y == xyz.y && z == xyz.z;
        }

        /// <summary>Returns true if the byte3 is equal to a given byte3, false otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            return Equals((byte3)obj);
        }

        /// <summary>Returns a hash code for the byte3.</summary>
        public override int GetHashCode()
        {
            return (int)math.hash(new uint3(x, y, z));
        }

        /// <summary>Returns a string representation of the byte3.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("byte3({0}, {1}, {2})", x, y, z);
        }

        /// <summary>Returns a string representation of the half2 using a specified format and culture-specific format information.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("byte3({0}, {1}, {2})",
                x.ToString(format, formatProvider),
                y.ToString(format, formatProvider),
                z.ToString(format, formatProvider)
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
    }
}