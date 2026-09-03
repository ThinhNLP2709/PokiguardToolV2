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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	internal static class Number // TypeDefIndex: 2314
	{
		// Fields
		private static readonly string[] s_posCurrencyFormats; // 0x00
		private static readonly string[] s_negCurrencyFormats; // 0x08
		private static readonly string[] s_posPercentFormats; // 0x10
		private static readonly string[] s_negPercentFormats; // 0x18
		private static readonly string[] s_negNumberFormats; // 0x20
		private static readonly int[] s_charToHexLookup; // 0x28
		private static readonly ulong[] s_rgval64Power10; // 0x30
		private static readonly sbyte[] s_rgexp64Power10; // 0x38
		private static readonly ulong[] s_rgval64Power10By16; // 0x40
		private static readonly short[] s_rgexp64Power10By16; // 0x48
	
		// Nested types
		[IsByRefLike]
		[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
		internal struct NumberBuffer // TypeDefIndex: 2315
		{
			// Fields
			public int precision; // 0x00
			public int scale; // 0x04
			private int _sign; // 0x08
			private DigitsAndNullTerminator _digits; // 0x0C
			private unsafe char* _allDigits; // 0x72
	
			// Properties
			public bool sign { get; set; } // 0x0000000181616660-0x0000000181616670 0x0000000181616670-0x0000000181616680
			public unsafe char* digits { get; } // 0x0000000181616650-0x0000000181616660 
	
			// Nested types
			private struct DigitsAndNullTerminator // TypeDefIndex: 2316
			{
			}
		}
	
		// Constructors
		static Number(); // 0x000000018160DBB0-0x000000018160E7A0
	
		// Methods
		public static string FormatDecimal(decimal value, ReadOnlySpan<char> format, NumberFormatInfo info); // 0x0000000181601DF0-0x0000000181601FC0
		public static bool TryFormatDecimal(decimal value, ReadOnlySpan<char> format, NumberFormatInfo info, Span<char> destination, out int charsWritten); // 0x0000000181608D70-0x0000000181608F50
		private static void DecimalToNumber(decimal value, ref NumberBuffer number); // 0x00000001816017A0-0x0000000181601980
		public static string FormatDouble(double value, string format, NumberFormatInfo info); // 0x0000000181601FC0-0x00000001816020E0
		public static bool TryFormatDouble(double value, ReadOnlySpan<char> format, NumberFormatInfo info, Span<char> destination, out int charsWritten); // 0x0000000181608F50-0x00000001816090C0
		private static string FormatDouble(ref ValueStringBuilder sb, double value, ReadOnlySpan<char> format, NumberFormatInfo info); // 0x00000001816020E0-0x0000000181602350
		public static string FormatSingle(float value, string format, NumberFormatInfo info); // 0x00000001816036B0-0x00000001816037D0
		public static bool TryFormatSingle(float value, ReadOnlySpan<char> format, NumberFormatInfo info, Span<char> destination, out int charsWritten); // 0x00000001816096B0-0x0000000181609820
		private static string FormatSingle(ref ValueStringBuilder sb, float value, ReadOnlySpan<char> format, NumberFormatInfo info); // 0x00000001816037D0-0x0000000181603A60
		private static bool TryCopyTo(string source, Span<char> destination, out int charsWritten); // 0x0000000181608CC0-0x0000000181608D70
		public static string FormatInt32(int value, ReadOnlySpan<char> format, IFormatProvider provider); // 0x0000000181602C10-0x0000000181602E90
		public static bool TryFormatInt32(int value, ReadOnlySpan<char> format, IFormatProvider provider, Span<char> destination, out int charsWritten); // 0x00000001816090C0-0x00000001816093B0
		public static string FormatUInt32(uint value, ReadOnlySpan<char> format, IFormatProvider provider); // 0x0000000181603A60-0x0000000181603CA0
		public static bool TryFormatUInt32(uint value, ReadOnlySpan<char> format, IFormatProvider provider, Span<char> destination, out int charsWritten); // 0x0000000181609820-0x0000000181609AB0
		public static string FormatInt64(long value, ReadOnlySpan<char> format, IFormatProvider provider); // 0x0000000181602E90-0x0000000181603110
		public static bool TryFormatInt64(long value, ReadOnlySpan<char> format, IFormatProvider provider, Span<char> destination, out int charsWritten); // 0x00000001816093B0-0x00000001816096B0
		public static string FormatUInt64(ulong value, ReadOnlySpan<char> format, IFormatProvider provider); // 0x0000000181603CA0-0x0000000181603EE0
		public static bool TryFormatUInt64(ulong value, ReadOnlySpan<char> format, IFormatProvider provider, Span<char> destination, out int charsWritten); // 0x0000000181609AB0-0x0000000181609D40
		private static void Int32ToNumber(int value, ref NumberBuffer number); // 0x0000000181604060-0x0000000181604170
		private static string NegativeInt32ToDecStr(int value, int digits, string sNegative); // 0x00000001816046E0-0x0000000181604880
		private static bool TryNegativeInt32ToDecStr(int value, int digits, string sNegative, Span<char> destination, out int charsWritten); // 0x000000018160A060-0x000000018160A200
		private static string Int32ToHexStr(int value, char hexBase, int digits); // 0x0000000181603F30-0x0000000181604060
		private static bool TryInt32ToHexStr(int value, char hexBase, int digits, Span<char> destination, out int charsWritten); // 0x0000000181609D40-0x0000000181609E80
		private static unsafe char* Int32ToHexChars(char* buffer, uint value, int hexBase, int digits); // 0x0000000181603EF0-0x0000000181603F30
		private static void UInt32ToNumber(uint value, ref NumberBuffer number); // 0x000000018160D720-0x000000018160D820
		internal static unsafe char* UInt32ToDecChars(char* bufferEnd, uint value, int digits); // 0x000000018160D560-0x000000018160D5A0
		private static string UInt32ToDecStr(uint value, int digits); // 0x000000018160D5A0-0x000000018160D720
		private static bool TryUInt32ToDecStr(uint value, int digits, Span<char> destination, out int charsWritten); // 0x000000018160D210-0x000000018160D390
		private static void Int64ToNumber(long input, ref NumberBuffer number); // 0x0000000181604380-0x0000000181604560
		private static string NegativeInt64ToDecStr(long input, int digits, string sNegative); // 0x0000000181604880-0x0000000181604A80
		private static bool TryNegativeInt64ToDecStr(long input, int digits, string sNegative, Span<char> destination, out int charsWritten); // 0x000000018160A200-0x000000018160A420
		private static string Int64ToHexStr(long value, char hexBase, int digits); // 0x00000001816041B0-0x0000000181604380
		private static bool TryInt64ToHexStr(long value, char hexBase, int digits, Span<char> destination, out int charsWritten); // 0x0000000181609E80-0x000000018160A060
		private static void UInt64ToNumber(ulong value, ref NumberBuffer number); // 0x000000018160D9E0-0x000000018160DBB0
		private static string UInt64ToDecStr(ulong value, int digits); // 0x000000018160D820-0x000000018160D9E0
		private static bool TryUInt64ToDecStr(ulong value, int digits, Span<char> destination, out int charsWritten); // 0x000000018160D390-0x000000018160D560
		internal static char ParseFormatSpecifier(ReadOnlySpan<char> format, out int digits); // 0x0000000181607090-0x0000000181607210
		internal static void NumberToString(ref ValueStringBuilder sb, ref NumberBuffer number, char format, int nMaxDigits, NumberFormatInfo info, bool isDecimal); // 0x0000000181606200-0x0000000181606B70
		internal static void NumberToStringFormat(ref ValueStringBuilder sb, ref NumberBuffer number, ReadOnlySpan<char> format, NumberFormatInfo info); // 0x00000001816054E0-0x0000000181606200
		private static void FormatCurrency(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info); // 0x0000000181601BF0-0x0000000181601DF0
		private static void FormatFixed(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info, int[] groupDigits, string sDecimal, string sGroup); // 0x0000000181602530-0x0000000181602990
		private static void FormatNumber(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info); // 0x0000000181603110-0x0000000181603300
		private static void FormatScientific(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info, char expChar); // 0x0000000181603500-0x00000001816036B0
		private static void FormatExponent(ref ValueStringBuilder sb, NumberFormatInfo info, int value, char expChar, int minDigits, bool positiveSign); // 0x0000000181602350-0x0000000181602530
		private static void FormatGeneral(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info, char expChar, bool bSuppressScientific); // 0x0000000181602990-0x0000000181602C10
		private static void FormatPercent(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info); // 0x0000000181603300-0x0000000181603500
		private static void RoundNumber(ref NumberBuffer number, int pos); // 0x00000001816089B0-0x0000000181608AA0
		private static int FindSection(ReadOnlySpan<char> format, int section); // 0x0000000181601B00-0x0000000181601BF0
		private static uint Low32(ulong value); // 0x0000000180815D70-0x0000000180815D80
		private static uint High32(ulong value); // 0x0000000181603EE0-0x0000000181603EF0
		private static uint Int64DivMod1E9(ref ulong value); // 0x0000000181604170-0x00000001816041B0
		private static bool NumberToInt32(ref NumberBuffer number, ref int value); // 0x0000000181605390-0x0000000181605430
		private static bool NumberToInt64(ref NumberBuffer number, ref long value); // 0x0000000181605430-0x00000001816054E0
		private static bool NumberToUInt32(ref NumberBuffer number, ref uint value); // 0x0000000181606B70-0x0000000181606C10
		private static bool NumberToUInt64(ref NumberBuffer number, ref ulong value); // 0x0000000181606C10-0x0000000181606CC0
		internal static int ParseInt32(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info); // 0x0000000181607210-0x0000000181607430
		internal static long ParseInt64(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info); // 0x0000000181607430-0x0000000181607660
		internal static uint ParseUInt32(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info); // 0x0000000181608580-0x0000000181608790
		internal static ulong ParseUInt64(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info); // 0x0000000181608790-0x00000001816089B0
		private static unsafe bool ParseNumber(ref char* str, char* strEnd, NumberStyles styles, ref NumberBuffer number, NumberFormatInfo info, bool parseDecimal); // 0x0000000181607660-0x00000001816082A0
		internal static bool TryParseInt32(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out int result); // 0x000000018160AD70-0x000000018160AF20
		private static bool TryParseInt32IntegerStyle(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out int result, ref bool failureIsOverflow); // 0x000000018160A680-0x000000018160AD70
		private static bool TryParseInt64IntegerStyle(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out long result, ref bool failureIsOverflow); // 0x000000018160AF20-0x000000018160B620
		internal static bool TryParseInt64(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out long result); // 0x000000018160B620-0x000000018160B7D0
		internal static bool TryParseUInt32(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out uint result); // 0x000000018160C350-0x000000018160C500
		private static bool TryParseUInt32IntegerStyle(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out uint result, ref bool failureIsOverflow); // 0x000000018160BCC0-0x000000018160C350
		private static bool TryParseUInt32HexNumberStyle(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out uint result, ref bool failureIsOverflow); // 0x000000018160B940-0x000000018160BCC0
		internal static bool TryParseUInt64(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out ulong result); // 0x000000018160CF30-0x000000018160D0E0
		private static bool TryParseUInt64IntegerStyle(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out ulong result, ref bool failureIsOverflow); // 0x000000018160C880-0x000000018160CF30
		private static bool TryParseUInt64HexNumberStyle(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out ulong result, ref bool failureIsOverflow); // 0x000000018160C500-0x000000018160C880
		internal static decimal ParseDecimal(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info); // 0x0000000181606CC0-0x0000000181606DD0
		private static bool NumberBufferToDecimal(ref NumberBuffer number, ref decimal value); // 0x0000000181604A80-0x0000000181604D40
		internal static double ParseDouble(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info); // 0x0000000181606DD0-0x0000000181607090
		internal static float ParseSingle(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info); // 0x00000001816082A0-0x0000000181608580
		internal static bool TryParseDecimal(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out decimal result); // 0x000000018160A420-0x000000018160A520
		internal static bool TryParseDouble(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out double result); // 0x000000018160A520-0x000000018160A680
		internal static bool TryParseSingle(ReadOnlySpan<char> value, NumberStyles styles, NumberFormatInfo info, out float result); // 0x000000018160B7D0-0x000000018160B940
		private static void StringToNumber(ReadOnlySpan<char> value, NumberStyles styles, ref NumberBuffer number, NumberFormatInfo info, bool parseDecimal); // 0x0000000181608AA0-0x0000000181608BD0
		internal static bool TryStringToNumber(ReadOnlySpan<char> value, NumberStyles styles, ref NumberBuffer number, NumberFormatInfo info, bool parseDecimal); // 0x000000018160D0E0-0x000000018160D210
		private static bool TrailingZeros(ReadOnlySpan<char> value, int index); // 0x0000000181608C70-0x0000000181608CC0
		private static unsafe char* MatchChars(char* p, char* pEnd, string value); // 0x0000000181604590-0x0000000181604620
		private static bool IsWhite(int ch); // 0x0000000181604570-0x0000000181604590
		private static bool IsDigit(int ch); // 0x0000000181604560-0x0000000181604570
		private static void ThrowOverflowOrFormatException(bool overflow, string overflowResourceKey); // 0x0000000181608BD0-0x0000000181608C70
		private static bool NumberBufferToDouble(ref NumberBuffer number, ref double value); // 0x0000000181604D40-0x0000000181604DE0
		private static unsafe uint DigitsToInt(char* p, int count); // 0x0000000181601980-0x00000001816019C0
		private static ulong Mul32x32To64(uint a, uint b); // 0x0000000181604620-0x0000000181604630
		private static ulong Mul64Lossy(ulong a, ulong b, ref int pexp); // 0x0000000181604630-0x00000001816046E0
		private static int abs(int value); // 0x000000018160E7A0-0x000000018160E7B0
		private static double NumberToDouble(ref NumberBuffer number); // 0x0000000181604DE0-0x0000000181605390
		private static void DoubleToNumber(double value, int precision, ref NumberBuffer number); // 0x00000001816019C0-0x0000000181601B00
	}
}
