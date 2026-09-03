/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 37: UnityEngine.BurstModule.dll - Assembly: UnityEngine.BurstModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14997-15049

namespace Unity.Burst
{
	internal static class BurstString // TypeDefIndex: 15012
	{
		// Fields
		private static readonly char[] SplitByColon; // 0x00
		private static readonly byte[] logTable; // 0x08
		private static readonly uint[] g_PowerOf10_U32; // 0x10
		private static readonly byte[] InfinityString; // 0x18
		private static readonly byte[] NanString; // 0x20
	
		// Nested types
		private enum NumberBufferKind // TypeDefIndex: 15013
		{
			Integer = 0,
			Float = 1
		}
	
		private struct NumberBuffer // TypeDefIndex: 15014
		{
			// Fields
			private readonly unsafe byte* _buffer; // 0x00
			public NumberBufferKind Kind; // 0x08
			public int DigitsCount; // 0x0C
			public int Scale; // 0x10
			public readonly bool IsNegative; // 0x14
	
			// Constructors
			public unsafe NumberBuffer(NumberBufferKind kind, byte* buffer, int digitsCount, int scale, bool isNegative); // 0x0000000182174820-0x0000000182174840
	
			// Methods
			public unsafe byte* GetDigitsPointer(); // 0x00000001808BADD0-0x00000001808BADE0
		}
	
		public enum NumberFormatKind : byte // TypeDefIndex: 15015
		{
			General = 0,
			Decimal = 1,
			DecimalForceSigned = 2,
			Hexadecimal = 3
		}
	
		public struct FormatOptions // TypeDefIndex: 15016
		{
			// Fields
			public NumberFormatKind Kind; // 0x00
			public sbyte AlignAndSize; // 0x01
			public byte Specifier; // 0x02
			public bool Lowercase; // 0x03
	
			// Properties
			public bool Uppercase { get; } // 0x0000000181942190-0x00000001819421A0 
	
			// Constructors
			public FormatOptions(NumberFormatKind kind, sbyte alignAndSize, byte specifier, bool lowercase); // 0x0000000180F4CB10-0x0000000180F4CB30
	
			// Methods
			public int GetBase(); // 0x0000000182174450-0x0000000182174470
			public override string ToString(); // 0x0000000182174470-0x0000000182174820
		}
	
		public struct tBigInt // TypeDefIndex: 15017
		{
			// Fields
			public int m_length; // 0x00
			public unsafe fixed /* 0x00000000-0x00000000 */ uint m_blocks[0]; // 0x04
	
			// Nested types
			[CompilerGenerated]
			[UnsafeValueType]
			public struct _m_blocks_e__FixedBuffer // TypeDefIndex: 15018
			{
				// Fields
				public uint FixedElementField; // 0x00
			}
	
			// Methods
			public int GetLength(); // 0x0000000180732D10-0x0000000180732D20
			public uint GetBlock(int idx); // 0x0000000182174AD0-0x0000000182174AE0
			public bool IsZero(); // 0x00000001819337A0-0x00000001819337B0
			public void SetU64(ulong val); // 0x0000000182174B00-0x0000000182174B30
			public void SetU32(uint val); // 0x0000000182174AE0-0x0000000182174B00
		}
	
		public enum CutoffMode // TypeDefIndex: 15019
		{
			Unique = 0,
			TotalLength = 1,
			FractionLength = 2
		}
	
		public struct tFloatUnion32 // TypeDefIndex: 15020
		{
			// Fields
			public float m_floatingPoint; // 0x00
			public uint m_integer; // 0x00
	
			// Methods
			public bool IsNegative(); // 0x0000000181669EC0-0x0000000181669ED0
			public uint GetExponent(); // 0x0000000182174B30-0x0000000182174B40
			public uint GetMantissa(); // 0x0000000182174B40-0x0000000182174B50
		}
	
		public struct tFloatUnion64 // TypeDefIndex: 15021
		{
			// Fields
			public double m_floatingPoint; // 0x00
			public ulong m_integer; // 0x00
	
			// Methods
			public bool IsNegative(); // 0x0000000182174B80-0x0000000182174BA0
			public uint GetExponent(); // 0x0000000182174B50-0x0000000182174B60
			public ulong GetMantissa(); // 0x0000000182174B60-0x0000000182174B80
		}
	
		// Constructors
		static BurstString(); // 0x0000000182173F80-0x00000001821741F0
	
		// Methods
		public static unsafe void CopyFixedString(byte* dest, int destLength, byte* src, int srcLength); // 0x0000000182171A50-0x0000000182171A90
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, byte* src, int srcLength, int formatOptionsRaw); // 0x0000000182173210-0x0000000182173320
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, float value, int formatOptionsRaw); // 0x00000001821734B0-0x0000000182173530
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, double value, int formatOptionsRaw); // 0x0000000182173810-0x0000000182173890
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, bool value, int formatOptionsRaw); // 0x00000001821730B0-0x0000000182173210
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, char value, int formatOptionsRaw); // 0x0000000182173960-0x0000000182173B20
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, byte value, int formatOptionsRaw); // 0x00000001821733F0-0x00000001821734B0
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, ushort value, int formatOptionsRaw); // 0x0000000182173680-0x0000000182173740
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, uint value, int formatOptionsRaw); // 0x0000000182173600-0x0000000182173680
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, ulong value, int formatOptionsRaw); // 0x0000000182173030-0x00000001821730B0
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, sbyte value, int formatOptionsRaw); // 0x0000000182173320-0x00000001821733F0
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, short value, int formatOptionsRaw); // 0x0000000182173890-0x0000000182173960
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, int value, int formatOptionsRaw); // 0x0000000182173530-0x0000000182173600
		public static unsafe void Format(byte* dest, ref int destIndex, int destLength, long value, int formatOptionsRaw); // 0x0000000182173740-0x0000000182173810
		private static unsafe void ConvertUnsignedIntegerToString(byte* dest, ref int destIndex, int destLength, ulong value, FormatOptions options); // 0x0000000182171860-0x0000000182171A50
		private static int GetLengthIntegerToString(long value, int basis, int zeroPadding); // 0x0000000182173C60-0x0000000182173C90
		private static unsafe void ConvertIntegerToString(byte* dest, ref int destIndex, int destLength, long value, FormatOptions options); // 0x0000000182171660-0x0000000182171860
		private static unsafe void FormatNumber(byte* dest, ref int destIndex, int destLength, ref NumberBuffer number, int nMaxDigits, FormatOptions options); // 0x0000000182172CB0-0x0000000182173030
		private static unsafe void FormatDecimalOrHexadecimal(byte* dest, ref int destIndex, int destLength, ref NumberBuffer number, int zeroPadding, bool outputPositiveSign); // 0x00000001821728B0-0x0000000182172960
		private static byte ValueToIntegerChar(int value, bool uppercase); // 0x0000000182173F50-0x0000000182173F80
		private static unsafe bool AlignRight(byte* dest, ref int destIndex, int destLength, int align, int length); // 0x00000001821701D0-0x0000000182170270
		private static unsafe bool AlignLeft(byte* dest, ref int destIndex, int destLength, int align, int length); // 0x0000000182170190-0x00000001821701D0
		private static int GetLengthForFormatGeneral(ref NumberBuffer number, int nMaxDigits); // 0x0000000182173B20-0x0000000182173C60
		private static unsafe void FormatGeneral(byte* dest, ref int destIndex, int destLength, ref NumberBuffer number, int nMaxDigits, byte expChar); // 0x0000000182172960-0x0000000182172B10
		private static void RoundNumber(ref NumberBuffer number, int pos, bool isCorrectlyRounded); // 0x0000000182173E00-0x0000000182173F20
		private static unsafe bool ShouldRoundUp(byte* dig, int i, bool isCorrectlyRounded); // 0x0000000182173F20-0x0000000182173F50
		private static uint LogBase2(uint val); // 0x0000000182173C90-0x0000000182173E00
		private static int BigInt_Compare([IsReadOnly] in tBigInt lhs, [IsReadOnly] in tBigInt rhs); // 0x00000001821703D0-0x0000000182170430
		private static void BigInt_Add(out tBigInt pResult, [IsReadOnly] in tBigInt lhs, [IsReadOnly] in tBigInt rhs); // 0x0000000182170340-0x00000001821703D0
		private static void BigInt_Add_internal(out tBigInt pResult, [IsReadOnly] in tBigInt pLarge, [IsReadOnly] in tBigInt pSmall); // 0x0000000182170270-0x0000000182170340
		private static void BigInt_Multiply(out tBigInt pResult, [IsReadOnly] in tBigInt lhs, [IsReadOnly] in tBigInt rhs); // 0x0000000182170B50-0x0000000182170BE0
		private static void BigInt_Multiply_internal(out tBigInt pResult, [IsReadOnly] in tBigInt pLarge, [IsReadOnly] in tBigInt pSmall); // 0x0000000182170A50-0x0000000182170B50
		private static void BigInt_Multiply(out tBigInt pResult, [IsReadOnly] in tBigInt lhs, uint rhs); // 0x0000000182170BE0-0x0000000182170C60
		private static void BigInt_Multiply2(out tBigInt pResult, [IsReadOnly] in tBigInt input); // 0x00000001821706A0-0x0000000182170710
		private static void BigInt_Multiply2(ref tBigInt pResult); // 0x0000000182170650-0x00000001821706A0
		private static void BigInt_Multiply10(ref tBigInt pResult); // 0x0000000182170610-0x0000000182170650
		private static tBigInt g_PowerOf10_Big(int i); // 0x00000001821741F0-0x00000001821743C0
		private static void BigInt_Pow10(out tBigInt pResult, uint exponent); // 0x0000000182170C60-0x0000000182170EC0
		private static void BigInt_MultiplyPow10(out tBigInt pResult, [IsReadOnly] in tBigInt input, uint exponent); // 0x0000000182170710-0x0000000182170A50
		private static void BigInt_Pow2(out tBigInt pResult, uint exponent); // 0x0000000182170EC0-0x0000000182170F20
		private static uint BigInt_DivideWithRemainder_MaxQuotient9(ref tBigInt pDividend, [IsReadOnly] in tBigInt divisor); // 0x0000000182170430-0x0000000182170610
		private static void BigInt_ShiftLeft(ref tBigInt pResult, uint shift); // 0x0000000182170F20-0x00000001821710C0
		private static unsafe uint Dragon4(ulong mantissa, int exponent, uint mantissaHighBitIdx, bool hasUnequalMargins, CutoffMode cutoffMode, int cutoffNumber, byte* pOutBuffer, uint bufferSize, out int pOutExponent); // 0x0000000182171A90-0x00000001821728B0
		private static unsafe void FormatInfinityNaN(byte* dest, ref int destIndex, int destLength, ulong mantissa, bool isNegative, FormatOptions formatOptions); // 0x0000000182172B10-0x0000000182172CB0
		private static unsafe void ConvertFloatToString(byte* dest, ref int destIndex, int destLength, float value, FormatOptions formatOptions); // 0x00000001821713A0-0x0000000182171660
		private static unsafe void ConvertDoubleToString(byte* dest, ref int destIndex, int destLength, double value, FormatOptions formatOptions); // 0x00000001821710C0-0x00000001821713A0
	}
}
