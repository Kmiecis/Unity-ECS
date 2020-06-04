using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	[Serializable]
	public struct byte2
	{
		public byte x;
		public byte y;

		/// <summary>byte2 zero value.</summary>
		public static readonly byte2 zero;

		/// <summary>Constructs a byte2 vector from two byte values.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(byte x, byte y)
		{
			this.x = x;
			this.y = y;
		}

		/// <summary>Constructs a byte2 vector from a byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(byte2 v)
		{
			this.x = v.x;
			this.y = v.y;
		}

		/// <summary>Constructs a byte2 vector from a single byte value by assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(byte v)
		{
			this.x = v;
			this.y = v;
		}

		/// <summary>Constructs a byte2 vector from a single short value by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(short v)
		{
			this.x = (byte)v;
			this.y = (byte)v;
		}

		/// <summary>Constructs a byte2 vector from a single int value by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(int v)
		{
			this.x = (byte)v;
			this.y = (byte)v;
		}

		/// <summary>Constructs a byte2 vector from a int2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(int2 v)
		{
			this.x = (byte)v.x;
			this.y = (byte)v.y;
		}

		/// <summary>Constructs a byte2 vector from a single ushort value by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(ushort v)
		{
			this.x = (byte)v;
			this.y = (byte)v;
		}

		/// <summary>Constructs a byte2 vector from a single uint value by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(uint v)
		{
			this.x = (byte)v;
			this.y = (byte)v;
		}

		/// <summary>Constructs a byte2 vector from a uint2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(uint2 v)
		{
			this.x = (byte)v.x;
			this.y = (byte)v.y;
		}

		/// <summary>Constructs a byte2 vector from a single float value by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(float v)
		{
			this.x = (byte)v;
			this.y = (byte)v;
		}

		/// <summary>Constructs a byte2 vector from a float2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(float2 v)
		{
			this.x = (byte)v.x;
			this.y = (byte)v.y;
		}

		/// <summary>Constructs a byte2 vector from a single double value by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(double v)
		{
			this.x = (byte)v;
			this.y = (byte)v;
		}

		/// <summary>Constructs a byte2 vector from a double2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte2(double2 v)
		{
			this.x = (byte)v.x;
			this.y = (byte)v.y;
		}


		/// <summary>Implicitly converts a single byte value to a byte2 vector by assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator byte2(byte v) { return new byte2(v); }

		/// <summary>Explicitly converts a single short value to a byte2 vector by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte2(short v) { return new byte2(v); }

		/// <summary>Explicitly converts a single int value to a byte2 vector by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte2(int v) { return new byte2(v); }

		/// <summary>Explicitly converts a int2 vector to a byte2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte2(int2 v) { return new byte2(v); }

		/// <summary>Explicitly converts a single ushort value to a byte2 vector by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte2(ushort v) { return new byte2(v); }

		/// <summary>Explicitly converts a single uint value to a byte2 vector by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte2(uint v) { return new byte2(v); }

		/// <summary>Explicitly converts a uint2 vector to a byte2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte2(uint2 v) { return new byte2(v); }

		/// <summary>Explicitly converts a single float value to a byte2 vector by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte2(float v) { return new byte2(v); }

		/// <summary>Explicitly converts a float2 vector to a byte2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte2(float2 v) { return new byte2(v); }

		/// <summary>Explicitly converts a single double value to a byte2 vector by converting it to byte and assigning it to every component.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte2(double v) { return new byte2(v); }

		/// <summary>Explicitly converts a double2 vector to a byte2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte2(double2 v) { return new byte2(v); }


		/// <summary>Implicitly converts a byte2 vector to a int2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator int2(byte2 v) { return new int2(v.x, v.y); }

		/// <summary>Implicitly converts a byte2 vector to a uint2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator uint2(byte2 v) { return new uint2(v.x, v.y); }

		/// <summary>Implicitly converts a byte2 vector to a float2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float2(byte2 v) { return new float2(v.x, v.y); }

		/// <summary>Implicitly converts a byte2 vector to a double2 vector by componentwise conversion.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double2(byte2 v) { return new double2(v.x, v.y); }


		/// <summary>Returns the result of a componentwise multiplication operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator *(byte2 lhs, byte2 rhs) { return new int2(lhs.x * rhs.x, lhs.y * rhs.y); }

		/// <summary>Returns the result of a componentwise multiplication operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator *(byte2 lhs, byte rhs) { return new int2(lhs.x * rhs, lhs.y * rhs); }

		/// <summary>Returns the result of a componentwise multiplication operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator *(byte lhs, byte2 rhs) { return new int2(lhs * rhs.x, lhs * rhs.y); }


		/// <summary>Returns the result of a componentwise addition operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator +(byte2 lhs, byte2 rhs) { return new int2(lhs.x + rhs.x, lhs.y + rhs.y); }

		/// <summary>Returns the result of a componentwise addition operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator +(byte2 lhs, byte rhs) { return new int2(lhs.x + rhs, lhs.y + rhs); }

		/// <summary>Returns the result of a componentwise addition operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator +(byte lhs, byte2 rhs) { return new int2(lhs + rhs.x, lhs + rhs.y); }


		/// <summary>Returns the result of a componentwise subtraction operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator -(byte2 lhs, byte2 rhs) { return new int2(lhs.x - rhs.x, lhs.y - rhs.y); }

		/// <summary>Returns the result of a componentwise subtraction operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator -(byte2 lhs, byte rhs) { return new int2(lhs.x - rhs, lhs.y - rhs); }

		/// <summary>Returns the result of a componentwise subtraction operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator -(byte lhs, byte2 rhs) { return new int2(lhs - rhs.x, lhs - rhs.y); }


		/// <summary>Returns the result of a componentwise division operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator /(byte2 lhs, byte2 rhs) { return new int2(lhs.x / rhs.x, lhs.y / rhs.y); }

		/// <summary>Returns the result of a componentwise division operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator /(byte2 lhs, byte rhs) { return new int2(lhs.x / rhs, lhs.y / rhs); }

		/// <summary>Returns the result of a componentwise division operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator /(byte lhs, byte2 rhs) { return new int2(lhs / rhs.x, lhs / rhs.y); }


		/// <summary>Returns the result of a componentwise modulus operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator %(byte2 lhs, byte2 rhs) { return new int2(lhs.x % rhs.x, lhs.y % rhs.y); }

		/// <summary>Returns the result of a componentwise modulus operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator %(byte2 lhs, byte rhs) { return new int2(lhs.x % rhs, lhs.y % rhs); }

		/// <summary>Returns the result of a componentwise modulus operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator %(byte lhs, byte2 rhs) { return new int2(lhs % rhs.x, lhs % rhs.y); }


		/// <summary>Returns the result of a componentwise increment operation on an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 operator ++(byte2 v) { return new byte2(++v.x, ++v.y); }


		/// <summary>Returns the result of a componentwise decrement operation on an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 operator --(byte2 v) { return new byte2(--v.x, --v.y); }


		/// <summary>Returns the result of a componentwise less than operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(byte2 lhs, byte2 rhs) { return new bool2(lhs.x < rhs.x, lhs.y < rhs.y); }

		/// <summary>Returns the result of a componentwise less than operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(byte2 lhs, byte rhs) { return new bool2(lhs.x < rhs, lhs.y < rhs); }

		/// <summary>Returns the result of a componentwise less than operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <(byte lhs, byte2 rhs) { return new bool2(lhs < rhs.x, lhs < rhs.y); }


		/// <summary>Returns the result of a componentwise less or equal operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(byte2 lhs, byte2 rhs) { return new bool2(lhs.x <= rhs.x, lhs.y <= rhs.y); }

		/// <summary>Returns the result of a componentwise less or equal operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(byte2 lhs, byte rhs) { return new bool2(lhs.x <= rhs, lhs.y <= rhs); }

		/// <summary>Returns the result of a componentwise less or equal operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator <=(byte lhs, byte2 rhs) { return new bool2(lhs <= rhs.x, lhs <= rhs.y); }


		/// <summary>Returns the result of a componentwise greater than operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(byte2 lhs, byte2 rhs) { return new bool2(lhs.x > rhs.x, lhs.y > rhs.y); }

		/// <summary>Returns the result of a componentwise greater than operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(byte2 lhs, byte rhs) { return new bool2(lhs.x > rhs, lhs.y > rhs); }

		/// <summary>Returns the result of a componentwise greater than operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >(byte lhs, byte2 rhs) { return new bool2(lhs > rhs.x, lhs > rhs.y); }


		/// <summary>Returns the result of a componentwise greater or equal operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(byte2 lhs, byte2 rhs) { return new bool2(lhs.x >= rhs.x, lhs.y >= rhs.y); }

		/// <summary>Returns the result of a componentwise greater or equal operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(byte2 lhs, byte rhs) { return new bool2(lhs.x >= rhs, lhs.y >= rhs); }

		/// <summary>Returns the result of a componentwise greater or equal operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator >=(byte lhs, byte2 rhs) { return new bool2(lhs >= rhs.x, lhs >= rhs.y); }


		/// <summary>Returns the result of a componentwise unary minus operation on an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator -(byte2 v) { return new int2(-v.x, -v.y); }


		/// <summary>Returns the result of a componentwise unary plus operation on an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator +(byte2 v) { return new int2(+v.x, +v.y); }


		/// <summary>Returns the result of a componentwise left shift operation on an byte2 vector by a number of bits specified by a single int.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator <<(byte2 x, int n) { return new int2(x.x << n, x.y << n); }

		/// <summary>Returns the result of a componentwise right shift operation on an byte2 vector by a number of bits specified by a single int.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator >>(byte2 x, int n) { return new int2(x.x >> n, x.y >> n); }


		/// <summary>Returns the result of a componentwise equality operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(byte2 lhs, byte2 rhs) { return new bool2(lhs.x == rhs.x, lhs.y == rhs.y); }

		/// <summary>Returns the result of a componentwise equality operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(byte2 lhs, byte rhs) { return new bool2(lhs.x == rhs, lhs.y == rhs); }

		/// <summary>Returns the result of a componentwise equality operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator ==(byte lhs, byte2 rhs) { return new bool2(lhs == rhs.x, lhs == rhs.y); }


		/// <summary>Returns the result of a componentwise not equal operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(byte2 lhs, byte2 rhs) { return new bool2(lhs.x != rhs.x, lhs.y != rhs.y); }

		/// <summary>Returns the result of a componentwise not equal operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(byte2 lhs, byte rhs) { return new bool2(lhs.x != rhs, lhs.y != rhs); }

		/// <summary>Returns the result of a componentwise not equal operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool2 operator !=(byte lhs, byte2 rhs) { return new bool2(lhs != rhs.x, lhs != rhs.y); }


		/// <summary>Returns the result of a componentwise bitwise not operation on an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator ~(byte2 v) { return new int2(~v.x, ~v.y); }


		/// <summary>Returns the result of a componentwise bitwise and operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator &(byte2 lhs, byte2 rhs) { return new int2(lhs.x & rhs.x, lhs.y & rhs.y); }

		/// <summary>Returns the result of a componentwise bitwise and operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator &(byte2 lhs, byte rhs) { return new int2(lhs.x & rhs, lhs.y & rhs); }

		/// <summary>Returns the result of a componentwise bitwise and operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator &(byte lhs, byte2 rhs) { return new int2(lhs & rhs.x, lhs & rhs.y); }


		/// <summary>Returns the result of a componentwise bitwise or operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator |(byte2 lhs, byte2 rhs) { return new int2(lhs.x | rhs.x, lhs.y | rhs.y); }

		/// <summary>Returns the result of a componentwise bitwise or operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator |(byte2 lhs, byte rhs) { return new int2(lhs.x | rhs, lhs.y | rhs); }

		/// <summary>Returns the result of a componentwise bitwise or operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator |(byte lhs, byte2 rhs) { return new int2(lhs | rhs.x, lhs | rhs.y); }


		/// <summary>Returns the result of a componentwise bitwise exclusive or operation on two byte2 vectors.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator ^(byte2 lhs, byte2 rhs) { return new int2(lhs.x ^ rhs.x, lhs.y ^ rhs.y); }

		/// <summary>Returns the result of a componentwise bitwise exclusive or operation on an byte2 vector and an byte value.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator ^(byte2 lhs, byte rhs) { return new int2(lhs.x ^ rhs, lhs.y ^ rhs); }

		/// <summary>Returns the result of a componentwise bitwise exclusive or operation on an byte value and an byte2 vector.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 operator ^(byte lhs, byte2 rhs) { return new int2(lhs ^ rhs.x, lhs ^ rhs.y); }

#if UNITY_UNSAFE
        /// <summary>Returns the byte element at a specified index.</summary>
        unsafe public byte this[int index]
        {
            get { fixed (byte2* array = &this) { return ((byte*)array)[index]; } }
            set { fixed (byte* array = &x) { array[index] = value; } }
        }
#endif

		/// <summary>Returns true if the byte2 is equal to a given byte2, false otherwise.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(byte2 v)
		{
			return x == v.x && y == v.y;
		}

		/// <summary>Returns true if the byte2 is equal to a given byte2, false otherwise.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override bool Equals(object obj)
		{
			return obj is byte2 && Equals((byte2)obj);
		}

		/// <summary>Returns a hash code for the byte2.</summary>
		public override int GetHashCode()
		{
			return (int)math.hash(new uint2(x, y));
		}

		/// <summary>Returns a string representation of the byte2.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return string.Format("byte2({0}, {1})", x, y);
		}

		/// <summary>Returns a string representation of the half2 using a specified format and culture-specific format information.</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return string.Format("byte2({0}, {1})", x.ToString(format, formatProvider), y.ToString(format, formatProvider));
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
	}
}
