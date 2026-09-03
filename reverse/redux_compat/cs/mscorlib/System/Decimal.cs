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
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[IsReadOnly]
	public struct Decimal : IFormattable, IComparable, IConvertible, IComparable<decimal>, IEquatable<decimal>, IDeserializationCallback, ISpanFormattable // TypeDefIndex: 2516
	{
		// Fields
		[DecimalConstant(0, 0, 0, 0, 0)]
		public static readonly decimal Zero; // 0x00
		[DecimalConstant(0, 0, 0, 0, 1)]
		public static readonly decimal One; // 0x10
		[DecimalConstant(0, 128, 0, 0, 1)]
		public static readonly decimal MinusOne; // 0x20
		[DecimalConstant(0, 0, 4294967295, 4294967295, 4294967295)]
		public static readonly decimal MaxValue; // 0x30
		[DecimalConstant(0, 128, 4294967295, 4294967295, 4294967295)]
		public static readonly decimal MinValue; // 0x40
		private readonly int flags; // 0x00
		private readonly int hi; // 0x04
		private readonly int lo; // 0x08
		private readonly int mid; // 0x0C
		[NonSerialized]
		private readonly ulong ulomidLE; // 0x08
	
		// Properties
		internal uint High { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
		internal uint Low { get; } // 0x0000000180732D20-0x0000000180732D30 
		internal uint Mid { get; } // 0x0000000180732D30-0x0000000180732D40 
		internal bool IsNegative { get; } // 0x0000000181669EC0-0x0000000181669ED0 
		internal int Scale { get; } // 0x000000018166C8F0-0x000000018166C900 
		private ulong Low64 { get; } // 0x000000018166C8B0-0x000000018166C8F0 
	
		// Nested types
		private struct DecCalc // TypeDefIndex: 2517
		{
			// Fields
			private uint uflags; // 0x00
			private uint uhi; // 0x04
			private uint ulo; // 0x08
			private uint umid; // 0x0C
			private ulong ulomidLE; // 0x08
			private static readonly uint[] s_powers10; // 0x00
			private static readonly ulong[] s_ulongPowers10; // 0x08
			private static readonly double[] s_doublePowers10; // 0x10
			private static readonly PowerOvfl[] PowerOvflValues; // 0x18
	
			// Properties
			private uint High { get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
			private uint Low { get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
			private uint Mid { get; set; } // 0x0000000180732D30-0x0000000180732D40 0x0000000180732D70-0x0000000180732D80
			private bool IsNegative { get; } // 0x0000000181669EC0-0x0000000181669ED0 
			private ulong Low64 { get; set; } // 0x0000000181663EF0-0x0000000181663F00 0x0000000181663F00-0x0000000181663F10
	
			// Nested types
			internal enum RoundingMode // TypeDefIndex: 2518
			{
				ToEven = 0,
				AwayFromZero = 1,
				Truncate = 2,
				Floor = 3,
				Ceiling = 4
			}
	
			private struct PowerOvfl // TypeDefIndex: 2519
			{
				// Fields
				public readonly uint Hi; // 0x00
				public readonly ulong MidLo; // 0x08
	
				// Constructors
				public PowerOvfl(uint hi, uint mid, uint lo); // 0x00000001816727D0-0x00000001816727F0
			}
	
			private struct Buf12 // TypeDefIndex: 2520
			{
				// Fields
				public uint U0; // 0x00
				public uint U1; // 0x04
				public uint U2; // 0x08
				private ulong ulo64LE; // 0x00
				private ulong uhigh64LE; // 0x04
	
				// Properties
				public ulong Low64 { get; set; } // 0x0000000180A45A40-0x0000000180A45A50 0x0000000180CBE820-0x0000000180CBE830
				public ulong High64 { get; set; } // 0x0000000181663ED0-0x0000000181663EE0 0x0000000181663EE0-0x0000000181663EF0
			}
	
			private struct Buf16 // TypeDefIndex: 2521
			{
				// Fields
				public uint U0; // 0x00
				public uint U1; // 0x04
				public uint U2; // 0x08
				public uint U3; // 0x0C
				private ulong ulo64LE; // 0x00
				private ulong uhigh64LE; // 0x08
	
				// Properties
				public ulong Low64 { get; set; } // 0x0000000180A45A40-0x0000000180A45A50 0x0000000180CBE820-0x0000000180CBE830
				public ulong High64 { get; set; } // 0x0000000181663EF0-0x0000000181663F00 0x0000000181663F00-0x0000000181663F10
			}
	
			private struct Buf24 // TypeDefIndex: 2522
			{
				// Fields
				public uint U0; // 0x00
				public uint U1; // 0x04
				public uint U2; // 0x08
				public uint U3; // 0x0C
				public uint U4; // 0x10
				public uint U5; // 0x14
				private ulong ulo64LE; // 0x00
				private ulong umid64LE; // 0x08
				private ulong uhigh64LE; // 0x10
	
				// Properties
				public ulong Low64 { get; set; } // 0x0000000180A45A40-0x0000000180A45A50 0x0000000180CBE820-0x0000000180CBE830
				public ulong Mid64 { set; } // 0x0000000181663F00-0x0000000181663F10
				public ulong High64 { set; } // 0x0000000180719060-0x0000000180719070
			}
	
			// Constructors
			static DecCalc(); // 0x0000000181669B00-0x0000000181669EC0
	
			// Methods
			private static uint GetExponent(float f); // 0x0000000181666F50-0x0000000181666F60
			private static uint GetExponent(double d); // 0x0000000181666F40-0x0000000181666F50
			private static ulong UInt32x32To64(uint a, uint b); // 0x0000000181604620-0x0000000181604630
			private static void UInt64x64To128(ulong a, ulong b, ref DecCalc result); // 0x0000000181668070-0x0000000181668190
			private static uint Div96By32(ref Buf12 bufNum, uint den); // 0x0000000181666CA0-0x0000000181666D10
			private static bool Div96ByConst(ref ulong high64, ref uint low, uint pow); // 0x0000000181666E60-0x0000000181666EC0
			private static void Unscale(ref uint low, ref ulong high64, ref int scale); // 0x0000000181668190-0x00000001816683C0
			private static uint Div96By64(ref Buf12 bufNum, ulong den); // 0x0000000181666D10-0x0000000181666E60
			private static uint Div128By96(ref Buf16 bufNum, ref Buf12 bufDen); // 0x0000000181666B80-0x0000000181666CA0
			private static uint IncreaseScale(ref Buf12 bufNum, uint power); // 0x00000001816670F0-0x0000000181667180
			private static void IncreaseScale64(ref Buf12 bufNum, uint power); // 0x0000000181667070-0x00000001816670F0
			private static unsafe int ScaleResult(Buf24* bufRes, uint hiRes, int scale); // 0x00000001816675E0-0x0000000181667E90
			private static unsafe uint DivByConst(uint* result, uint hiRes, out uint quotient, out uint remainder, uint power); // 0x0000000181666EC0-0x0000000181666F40
			private static int LeadingZeroCount(uint value); // 0x0000000181663520-0x0000000181663840
			private static int OverflowUnscale(ref Buf12 bufQuo, int scale, bool sticky); // 0x00000001816674C0-0x00000001816675E0
			private static int SearchScale(ref Buf12 bufQuo, int scale); // 0x0000000181667E90-0x0000000181668070
			private static bool Add32To96(ref Buf12 bufNum, uint value); // 0x0000000181666510-0x0000000181666530
			internal static void DecAddSub(ref DecCalc d1, ref DecCalc d2, bool sign); // 0x0000000181666530-0x0000000181666B00
			internal static int VarDecCmp([IsReadOnly] in decimal d1, [IsReadOnly] in decimal d2); // 0x00000001816685D0-0x00000001816686C0
			private static int VarDecCmpSub([IsReadOnly] in decimal d1, [IsReadOnly] in decimal d2); // 0x00000001816683C0-0x00000001816685D0
			internal static void VarDecMul(ref DecCalc d1, ref DecCalc d2); // 0x0000000181669630-0x0000000181669990
			internal static void VarDecFromR4(float input, out DecCalc result); // 0x0000000181668F60-0x00000001816692C0
			internal static void VarDecFromR8(double input, out DecCalc result); // 0x00000001816692C0-0x0000000181669630
			internal static float VarR4FromDec([IsReadOnly] in decimal value); // 0x0000000181669990-0x00000001816699E0
			internal static double VarR8FromDec([IsReadOnly] in decimal value); // 0x00000001816699E0-0x0000000181669B00
			internal static int GetHashCode([IsReadOnly] in decimal d); // 0x0000000181666F60-0x0000000181667070
			internal static void VarDecDiv(ref DecCalc d1, ref DecCalc d2); // 0x00000001816686C0-0x0000000181668F60
			internal static void InternalRound(ref DecCalc d, uint scale, RoundingMode mode); // 0x0000000181667180-0x00000001816674C0
			internal static uint DecDivMod1E9(ref DecCalc value); // 0x0000000181666B00-0x0000000181666B80
		}
	
		// Constructors
		public Decimal(int value); // 0x000000018166C5C0-0x000000018166C5F0
		[CLSCompliant(false)]
		public Decimal(uint value); // 0x000000018166C530-0x000000018166C540
		public Decimal(long value); // 0x000000018166C6B0-0x000000018166C6E0
		[CLSCompliant(false)]
		public Decimal(ulong value); // 0x000000018166C5F0-0x000000018166C600
		public Decimal(float value); // 0x000000018166C830-0x000000018166C8B0
		public Decimal(double value); // 0x000000018166C540-0x000000018166C5C0
		public Decimal(int[] bits); // 0x000000018166C6E0-0x000000018166C830
		public Decimal(int lo, int mid, int hi, bool isNegative, byte scale); // 0x000000018166C610-0x000000018166C6B0
		private Decimal([IsReadOnly] in decimal d, int flags); // 0x000000018166C600-0x000000018166C610
		static Decimal(); // 0x000000018166C440-0x000000018166C530
	
		// Methods
		private static ref DecCalc AsMutable(ref decimal d); // 0x0000000180370C60-0x0000000180370C70
		internal static uint DecDivMod1E9(ref decimal value); // 0x000000018166A150-0x000000018166A230
		private static bool IsValid(int flags); // 0x000000018166A5E0-0x000000018166A600
		void IDeserializationCallback.OnDeserialization(object sender); // 0x000000018166B240-0x000000018166B2F0
		internal static decimal Abs(ref decimal d); // 0x0000000181669ED0-0x0000000181669EF0
		public static decimal Add(decimal d1, decimal d2); // 0x0000000181669EF0-0x0000000181669F90
		public static int Compare(decimal d1, decimal d2); // 0x000000018166A0F0-0x000000018166A150
		public int CompareTo(object value); // 0x0000000181669F90-0x000000018166A090
		public int CompareTo(decimal value); // 0x000000018166A090-0x000000018166A0F0
		public static decimal Divide(decimal d1, decimal d2); // 0x000000018166A230-0x000000018166A2D0
		public override bool Equals(object value); // 0x000000018166A330-0x000000018166A3F0
		public bool Equals(decimal value); // 0x000000018166A2D0-0x000000018166A330
		public override int GetHashCode(); // 0x000000018166A480-0x000000018166A5D0
		public override string ToString(); // 0x000000018166BD70-0x000000018166BE00
		public string ToString(IFormatProvider provider); // 0x000000018166BC00-0x000000018166BCA0
		public string ToString(string format, IFormatProvider provider); // 0x000000018166BCA0-0x000000018166BD70
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x000000018166C2A0-0x000000018166C370
		public static decimal Parse(string s, IFormatProvider provider); // 0x000000018166A890-0x000000018166A970
		public static decimal Parse(string s, NumberStyles style, IFormatProvider provider); // 0x000000018166A7A0-0x000000018166A890
		public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out decimal result); // 0x000000018166C370-0x000000018166C440
		public static int[] GetBits(decimal d); // 0x000000018166A3F0-0x000000018166A480
		internal static ref decimal Max(ref decimal d1, ref decimal d2); // 0x000000018166A600-0x000000018166A670
		internal static ref decimal Min(ref decimal d1, ref decimal d2); // 0x000000018166A670-0x000000018166A6E0
		public static decimal Multiply(decimal d1, decimal d2); // 0x000000018166A6E0-0x000000018166A780
		public static decimal Negate(decimal d); // 0x000000018166A780-0x000000018166A7A0
		public static decimal Round(decimal d, int decimals); // 0x000000018166A970-0x000000018166AAB0
		private static decimal Round(ref decimal d, int decimals, MidpointRounding mode); // 0x000000018166AAB0-0x000000018166AC60
		public static byte ToByte(decimal value); // 0x000000018166B2F0-0x000000018166B520
		[CLSCompliant(false)]
		public static sbyte ToSByte(decimal value); // 0x000000018166B930-0x000000018166BB70
		public static short ToInt16(decimal value); // 0x000000018166B570-0x000000018166B7B0
		public static double ToDouble(decimal d); // 0x000000018166B520-0x000000018166B570
		public static int ToInt32(decimal d); // 0x000000018166B7B0-0x000000018166B860
		public static long ToInt64(decimal d); // 0x000000018166B860-0x000000018166B930
		[CLSCompliant(false)]
		public static ushort ToUInt16(decimal value); // 0x000000018166BE00-0x000000018166C030
		[CLSCompliant(false)]
		public static uint ToUInt32(decimal d); // 0x000000018166C030-0x000000018166C0E0
		[CLSCompliant(false)]
		public static ulong ToUInt64(decimal d); // 0x000000018166C0E0-0x000000018166C1B0
		public static float ToSingle(decimal d); // 0x000000018166BB70-0x000000018166BC00
		public static decimal Truncate(decimal d); // 0x000000018166C240-0x000000018166C2A0
		private static void Truncate(ref decimal d); // 0x000000018166C1B0-0x000000018166C240
		public static implicit operator decimal(byte value); // 0x000000018166D390-0x000000018166D3B0
		[CLSCompliant(false)]
		public static implicit operator decimal(sbyte value); // 0x000000018166D300-0x000000018166D330
		public static implicit operator decimal(short value); // 0x000000018166D360-0x000000018166D390
		[CLSCompliant(false)]
		public static implicit operator decimal(ushort value); // 0x000000018166D270-0x000000018166D290
		public static implicit operator decimal(char value); // 0x000000018166D270-0x000000018166D290
		public static implicit operator decimal(int value); // 0x000000018166D330-0x000000018166D360
		[CLSCompliant(false)]
		public static implicit operator decimal(uint value); // 0x000000018166D2F0-0x000000018166D300
		public static implicit operator decimal(long value); // 0x000000018166D290-0x000000018166D2D0
		[CLSCompliant(false)]
		public static implicit operator decimal(ulong value); // 0x000000018166D2D0-0x000000018166D2F0
		public static explicit operator decimal(float value); // 0x000000018166CC30-0x000000018166CCC0
		public static explicit operator decimal(double value); // 0x000000018166CED0-0x000000018166CF60
		public static explicit operator int(decimal value); // 0x000000018166CF60-0x000000018166D0E0
		public static explicit operator long(decimal value); // 0x000000018166CAA0-0x000000018166CC30
		[CLSCompliant(false)]
		public static explicit operator ulong(decimal value); // 0x000000018166CCC0-0x000000018166CE40
		public static explicit operator float(decimal value); // 0x000000018166D0E0-0x000000018166D1B0
		public static explicit operator double(decimal value); // 0x000000018166CE40-0x000000018166CED0
		public static decimal operator -(decimal d); // 0x000000018166A780-0x000000018166A7A0
		public static decimal operator ++(decimal d); // 0x000000018166D3B0-0x000000018166D490
		public static decimal operator +(decimal d1, decimal d2); // 0x000000018166C900-0x000000018166C9A0
		public static decimal operator -(decimal d1, decimal d2); // 0x000000018166D650-0x000000018166D6F0
		public static decimal operator *(decimal d1, decimal d2); // 0x000000018166D5B0-0x000000018166D650
		public static decimal operator /(decimal d1, decimal d2); // 0x000000018166C9A0-0x000000018166CA40
		public static bool operator ==(decimal d1, decimal d2); // 0x000000018166CA40-0x000000018166CAA0
		public static bool operator !=(decimal d1, decimal d2); // 0x000000018166D490-0x000000018166D4F0
		public static bool operator <(decimal d1, decimal d2); // 0x000000018166D550-0x000000018166D5B0
		public static bool operator <=(decimal d1, decimal d2); // 0x000000018166D4F0-0x000000018166D550
		public static bool operator >(decimal d1, decimal d2); // 0x000000018166D210-0x000000018166D270
		public static bool operator >=(decimal d1, decimal d2); // 0x000000018166D1B0-0x000000018166D210
		public TypeCode GetTypeCode(); // 0x000000018166A5D0-0x000000018166A5E0
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x000000018166AC60-0x000000018166ACC0
		char IConvertible.ToChar(IFormatProvider provider); // 0x000000018166AD20-0x000000018166ADB0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x000000018166AFC0-0x000000018166B020
		byte IConvertible.ToByte(IFormatProvider provider); // 0x000000018166ACC0-0x000000018166AD20
		short IConvertible.ToInt16(IFormatProvider provider); // 0x000000018166AEA0-0x000000018166AF00
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x000000018166B120-0x000000018166B180
		int IConvertible.ToInt32(IFormatProvider provider); // 0x000000018166AF00-0x000000018166AF60
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x000000018166B180-0x000000018166B1E0
		long IConvertible.ToInt64(IFormatProvider provider); // 0x000000018166AF60-0x000000018166AFC0
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x000000018166B1E0-0x000000018166B240
		float IConvertible.ToSingle(IFormatProvider provider); // 0x000000018166B020-0x000000018166B080
		double IConvertible.ToDouble(IFormatProvider provider); // 0x000000018166AE40-0x000000018166AEA0
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x000000018092E600-0x000000018092E610
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x000000018166ADB0-0x000000018166AE40
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x000000018166B080-0x000000018166B120
	}
}
