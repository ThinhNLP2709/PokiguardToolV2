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
using System.Text;

// Image 44: System.Numerics.dll - Assembly: System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 15302-15314

namespace System.Numerics
{
	internal static class BigNumber // TypeDefIndex: 15307
	{
		// Nested types
		private struct BigNumberBuffer // TypeDefIndex: 15308
		{
			// Fields
			public StringBuilder digits; // 0x00
			public int precision; // 0x08
			public int scale; // 0x0C
			public bool sign; // 0x10
	
			// Methods
			public static BigNumberBuffer Create(); // 0x00000001819362A0-0x00000001819362F0
		}
	
		// Methods
		internal static bool TryValidateParseStyleInteger(NumberStyles style, out ArgumentException e); // 0x0000000181938500-0x0000000181938650
		internal static bool TryParseBigInteger(ReadOnlySpan<char> value, NumberStyles style, NumberFormatInfo info, out BigInteger result); // 0x0000000181938210-0x0000000181938500
		internal static BigInteger ParseBigInteger(string value, NumberStyles style, NumberFormatInfo info); // 0x0000000181937D90-0x0000000181937F80
		internal static BigInteger ParseBigInteger(ReadOnlySpan<char> value, NumberStyles style, NumberFormatInfo info); // 0x0000000181937F80-0x00000001819380F0
		private static bool HexNumberToBigInteger(ref BigNumberBuffer number, ref BigInteger value); // 0x0000000181937890-0x0000000181937B10
		private static bool NumberToBigInteger(ref BigNumberBuffer number, ref BigInteger value); // 0x0000000181937B10-0x0000000181937D90
		internal static char ParseFormatSpecifier(ReadOnlySpan<char> format, out int digits); // 0x00000001819380F0-0x0000000181938210
		private static string FormatBigIntegerToHex(bool targetSpan, BigInteger value, char format, int digits, NumberFormatInfo info, Span<char> destination, out int charsWritten, out bool spanSuccess); // 0x00000001819362F0-0x00000001819369D0
		internal static string FormatBigInteger(BigInteger value, string format, NumberFormatInfo info); // 0x00000001819369D0-0x0000000181936AA0
		private static string FormatBigInteger(bool targetSpan, BigInteger value, string formatString, ReadOnlySpan<char> formatSpan, NumberFormatInfo info, Span<char> destination, out int charsWritten, out bool spanSuccess); // 0x0000000181936AA0-0x0000000181937890
	}
}
