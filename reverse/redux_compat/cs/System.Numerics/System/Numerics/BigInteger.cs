/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 44: System.Numerics.dll - Assembly: System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 15302-15314

namespace System.Numerics
{
	[Serializable]
	[IsReadOnly]
	public struct BigInteger : IFormattable, IComparable, IComparable<BigInteger>, IEquatable<BigInteger> // TypeDefIndex: 15304
	{
		// Fields
		internal readonly int _sign; // 0x00
		internal readonly uint[] _bits; // 0x08
		private static readonly BigInteger s_bnMinInt; // 0x00
		private static readonly BigInteger s_bnOneInt; // 0x10
		private static readonly BigInteger s_bnZeroInt; // 0x20
		private static readonly BigInteger s_bnMinusOneInt; // 0x30
		private static readonly byte[] s_success; // 0x40
	
		// Properties
		public static BigInteger Zero { get; } // 0x0000000181933810-0x0000000181933870 
		public static BigInteger MinusOne { get; } // 0x00000001819337B0-0x0000000181933810 
		public bool IsZero { get; } // 0x00000001819337A0-0x00000001819337B0 
	
		// Nested types
		private enum GetBytesMode // TypeDefIndex: 15305
		{
			AllocateArray = 0,
			Count = 1,
			Span = 2
		}
	
		// Constructors
		public BigInteger(int value); // 0x0000000181933720-0x00000001819337A0
		[CLSCompliant(false)]
		public BigInteger(uint value); // 0x0000000181932FC0-0x0000000181933080
		public BigInteger(long value); // 0x0000000181932E20-0x0000000181932FC0
		[CLSCompliant(false)]
		public BigInteger(ulong value); // 0x0000000181932710-0x0000000181932830
		public BigInteger(float value); // 0x0000000181932DC0-0x0000000181932E20
		public BigInteger(double value); // 0x0000000181932830-0x0000000181932BD0
		public BigInteger(decimal value); // 0x0000000181932BD0-0x0000000181932DC0
		[CLSCompliant(false)]
		public BigInteger(byte[] value); // 0x0000000181932630-0x0000000181932710
		public BigInteger(ReadOnlySpan<byte> value, bool isUnsigned = false /* Metadata: 0x006A9F64 */, bool isBigEndian = false /* Metadata: 0x006A9F65 */); // 0x0000000181933080-0x0000000181933720
		internal BigInteger(int n, uint[] rgu); // 0x0000000180F37790-0x0000000180F377B0
		internal BigInteger(uint[] value, bool negative); // 0x0000000181932450-0x0000000181932630
		static BigInteger(); // 0x00000001819321D0-0x0000000181932450
	
		// Methods
		public static BigInteger Parse(string value, IFormatProvider provider); // 0x0000000181931190-0x00000001819313E0
		public static BigInteger Parse(string value, NumberStyles style, IFormatProvider provider); // 0x00000001819313E0-0x00000001819315E0
		public override int GetHashCode(); // 0x0000000181931060-0x00000001819310C0
		public override bool Equals(object obj); // 0x0000000181930F40-0x0000000181930FF0
		public bool Equals(long other); // 0x0000000181930EB0-0x0000000181930F40
		public bool Equals(BigInteger other); // 0x0000000181930D90-0x0000000181930EB0
		public int CompareTo(long other); // 0x0000000181930BD0-0x0000000181930C80
		public int CompareTo(BigInteger other); // 0x0000000181930A10-0x0000000181930BD0
		public int CompareTo(object obj); // 0x0000000181930C80-0x0000000181930D90
		public byte[] ToByteArray(); // 0x0000000181931870-0x0000000181931940
		public byte[] ToByteArray(bool isUnsigned = false /* Metadata: 0x006A9F66 */, bool isBigEndian = false /* Metadata: 0x006A9F67 */); // 0x00000001819317C0-0x0000000181931870
		public bool TryWriteBytes(Span<byte> destination, out int bytesWritten, bool isUnsigned = false /* Metadata: 0x006A9F68 */, bool isBigEndian = false /* Metadata: 0x006A9F69 */); // 0x0000000181932060-0x0000000181932120
		internal bool TryWriteOrCountBytes(Span<byte> destination, out int bytesWritten, bool isUnsigned = false /* Metadata: 0x006A9F6A */, bool isBigEndian = false /* Metadata: 0x006A9F6B */); // 0x0000000181932120-0x00000001819321D0
		private byte[] TryGetBytes(GetBytesMode mode, Span<byte> destination, bool isUnsigned, bool isBigEndian, ref int bytesWritten); // 0x0000000181931B60-0x0000000181932060
		public override string ToString(); // 0x0000000181931940-0x00000001819319E0
		public string ToString(IFormatProvider provider); // 0x00000001819319E0-0x0000000181931A80
		public string ToString(string format, IFormatProvider provider); // 0x0000000181931A80-0x0000000181931B60
		private static BigInteger Add(uint[] leftBits, int leftSign, uint[] rightBits, int rightSign); // 0x0000000181930860-0x0000000181930A10
		public static BigInteger operator -(BigInteger left, BigInteger right); // 0x0000000181935F10-0x0000000181936270
		private static BigInteger Subtract(uint[] leftBits, int leftSign, uint[] rightBits, int rightSign); // 0x00000001819315E0-0x00000001819317C0
		public static implicit operator BigInteger(byte value); // 0x0000000181934BE0-0x0000000181934C10
		[CLSCompliant(false)]
		public static implicit operator BigInteger(sbyte value); // 0x00000001819349B0-0x00000001819349E0
		public static implicit operator BigInteger(short value); // 0x0000000181934BB0-0x0000000181934BE0
		[CLSCompliant(false)]
		public static implicit operator BigInteger(ushort value); // 0x0000000181934DB0-0x0000000181934DE0
		public static implicit operator BigInteger(int value); // 0x0000000181934990-0x00000001819349B0
		[CLSCompliant(false)]
		public static implicit operator BigInteger(uint value); // 0x0000000181934B00-0x0000000181934BB0
		public static implicit operator BigInteger(long value); // 0x0000000181934C10-0x0000000181934DB0
		[CLSCompliant(false)]
		public static implicit operator BigInteger(ulong value); // 0x00000001819349E0-0x0000000181934B00
		public static explicit operator byte(BigInteger value); // 0x00000001819347E0-0x0000000181934860
		[CLSCompliant(false)]
		public static explicit operator sbyte(BigInteger value); // 0x0000000181934330-0x00000001819343B0
		public static explicit operator short(BigInteger value); // 0x0000000181934040-0x00000001819340C0
		[CLSCompliant(false)]
		public static explicit operator ushort(BigInteger value); // 0x0000000181934760-0x00000001819347E0
		public static explicit operator int(BigInteger value); // 0x0000000181934210-0x0000000181934330
		[CLSCompliant(false)]
		public static explicit operator uint(BigInteger value); // 0x0000000181934410-0x00000001819344C0
		public static explicit operator long(BigInteger value); // 0x0000000181934860-0x0000000181934990
		[CLSCompliant(false)]
		public static explicit operator ulong(BigInteger value); // 0x0000000181934690-0x0000000181934760
		public static explicit operator float(BigInteger value); // 0x00000001819343B0-0x0000000181934410
		public static explicit operator double(BigInteger value); // 0x00000001819344C0-0x0000000181934690
		public static explicit operator decimal(BigInteger value); // 0x00000001819340C0-0x0000000181934210
		public static BigInteger operator <<(BigInteger value, int shift); // 0x0000000181934EB0-0x00000001819351F0
		public static BigInteger operator >>(BigInteger value, int shift); // 0x0000000181935A10-0x0000000181935F10
		public static BigInteger operator -(BigInteger value); // 0x0000000181936270-0x00000001819362A0
		public static BigInteger operator +(BigInteger left, BigInteger right); // 0x0000000181933870-0x0000000181933BE0
		public static BigInteger operator *(BigInteger left, BigInteger right); // 0x00000001819356E0-0x0000000181935A10
		public static BigInteger operator /(BigInteger dividend, BigInteger divisor); // 0x0000000181933BE0-0x0000000181933FE0
		public static BigInteger operator %(BigInteger dividend, BigInteger divisor); // 0x00000001819353E0-0x00000001819356E0
		public static bool operator <=(BigInteger left, BigInteger right); // 0x00000001819351F0-0x0000000181935260
		public static bool operator !=(BigInteger left, BigInteger right); // 0x0000000181934E40-0x0000000181934EB0
		public static bool operator <(BigInteger left, long right); // 0x0000000181935380-0x00000001819353E0
		public static bool operator <=(BigInteger left, long right); // 0x0000000181935260-0x00000001819352C0
		public static bool operator ==(BigInteger left, long right); // 0x0000000181933FE0-0x0000000181934040
		public static bool operator !=(BigInteger left, long right); // 0x0000000181934DE0-0x0000000181934E40
		public static bool operator <(long left, BigInteger right); // 0x0000000181935320-0x0000000181935380
		public static bool operator <=(long left, BigInteger right); // 0x00000001819352C0-0x0000000181935320
		private static bool GetPartsForBitManipulation(ref BigInteger x, out uint[] xd, out int xl); // 0x00000001819310C0-0x0000000181931190
		internal static int GetDiffLength(uint[] rgu1, uint[] rgu2, int cu); // 0x0000000181930FF0-0x0000000181931060
	}
}
