/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 44: System.Numerics.dll - Assembly: System.Numerics, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 15302-15314

namespace System.Globalization
{
	internal class FormatProvider // TypeDefIndex: 15311
	{
		// Nested types
		private class Number // TypeDefIndex: 15312
		{
			// Fields
			private static string[] s_posCurrencyFormats; // 0x00
			private static string[] s_negCurrencyFormats; // 0x08
			private static string[] s_posPercentFormats; // 0x10
			private static string[] s_negPercentFormats; // 0x18
			private static string[] s_negNumberFormats; // 0x20
			private static string s_posNumberFormat; // 0x28
	
			// Nested types
			internal struct NumberBuffer // TypeDefIndex: 15313
			{
				// Fields
				public int precision; // 0x00
				public int scale; // 0x04
				public bool sign; // 0x08
				public unsafe char* overrideDigits; // 0x10
	
				// Properties
				public unsafe char* digits { get; } // 0x0000000180377550-0x0000000180377560 
			}
	
			// Constructors
			static Number(); // 0x000000018193BE60-0x000000018193C720
	
			// Methods
			private static bool IsWhite(char ch); // 0x0000000181939950-0x0000000181939970
			private static unsafe char* MatchChars(char* p, char* pEnd, string str); // 0x00000001819399C0-0x0000000181939A80
			private static unsafe char* MatchChars(char* p, char* pEnd, char* str); // 0x0000000181939970-0x00000001819399C0
			private static unsafe bool ParseNumber(ref char* str, char* strEnd, NumberStyles options, ref NumberBuffer number, StringBuilder sb, NumberFormatInfo numfmt, bool parseDecimal); // 0x000000018193B080-0x000000018193BC40
			private static bool TrailingZeros(ReadOnlySpan<char> s, int index); // 0x0000000181608C70-0x0000000181608CC0
			internal static bool TryStringToNumber(ReadOnlySpan<char> str, NumberStyles options, ref NumberBuffer number, StringBuilder sb, NumberFormatInfo numfmt, bool parseDecimal); // 0x000000018193BD30-0x000000018193BE60
			internal static unsafe void Int32ToDecChars(char* buffer, ref int index, uint value, int digits); // 0x00000001819398E0-0x0000000181939950
			internal static char ParseFormatSpecifier(ReadOnlySpan<char> format, out int digits); // 0x0000000181607090-0x0000000181607210
			internal static void NumberToString(ref ValueStringBuilder sb, ref NumberBuffer number, char format, int nMaxDigits, NumberFormatInfo info, bool isDecimal); // 0x000000018193A750-0x000000018193B080
			private static void FormatCurrency(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info); // 0x0000000181938970-0x0000000181938B70
			private static unsafe int wcslen(char* s); // 0x000000018193C720-0x000000018193C740
			private static void FormatFixed(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info, int[] groupDigits, string sDecimal, string sGroup); // 0x0000000181938D10-0x00000001819391A0
			private static void FormatNumber(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info); // 0x00000001819393C0-0x0000000181939580
			private static void FormatScientific(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info, char expChar); // 0x0000000181939780-0x00000001819398E0
			private static void FormatExponent(ref ValueStringBuilder sb, NumberFormatInfo info, int value, char expChar, int minDigits, bool positiveSign); // 0x0000000181938B70-0x0000000181938D10
			private static void FormatGeneral(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info, char expChar, bool bSuppressScientific); // 0x00000001819391A0-0x00000001819393C0
			private static void FormatPercent(ref ValueStringBuilder sb, ref NumberBuffer number, int nMinDigits, int nMaxDigits, NumberFormatInfo info); // 0x0000000181939580-0x0000000181939780
			private static void RoundNumber(ref NumberBuffer number, int pos); // 0x000000018193BC40-0x000000018193BD30
			private static int FindSection(ReadOnlySpan<char> format, int section); // 0x0000000181601B00-0x0000000181601BF0
			internal static void NumberToStringFormat(ref ValueStringBuilder sb, ref NumberBuffer number, ReadOnlySpan<char> format, NumberFormatInfo info); // 0x0000000181939A80-0x000000018193A750
		}
	
		// Methods
		internal static void FormatBigInteger(ref ValueStringBuilder sb, int precision, int scale, bool sign, ReadOnlySpan<char> format, NumberFormatInfo numberFormatInfo, char[] digits, int startIndex); // 0x0000000181938650-0x0000000181938790
		internal static bool TryStringToBigInteger(ReadOnlySpan<char> s, NumberStyles styles, NumberFormatInfo numberFormatInfo, StringBuilder receiver, out int precision, out int scale, out bool sign); // 0x0000000181938790-0x0000000181938970
	}
}
