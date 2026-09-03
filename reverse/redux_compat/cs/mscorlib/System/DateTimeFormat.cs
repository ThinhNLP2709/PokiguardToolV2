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
	internal static class DateTimeFormat // TypeDefIndex: 2248
	{
		// Fields
		internal static readonly TimeSpan NullOffset; // 0x00
		internal static char[] allStandardFormats; // 0x08
		internal static readonly DateTimeFormatInfo InvariantFormatInfo; // 0x10
		internal static readonly string[] InvariantAbbreviatedMonthNames; // 0x18
		internal static readonly string[] InvariantAbbreviatedDayNames; // 0x20
		internal static string[] fixedNumberFormats; // 0x28
	
		// Constructors
		static DateTimeFormat(); // 0x00000001815E11F0-0x00000001815E1570
	
		// Methods
		internal static void FormatDigits(StringBuilder outputBuffer, int value, int len); // 0x00000001815DF190-0x00000001815DF210
		internal static void FormatDigits(StringBuilder outputBuffer, int value, int len, bool overrideLengthLimit); // 0x00000001815DF210-0x00000001815DF310
		private static void HebrewFormatDigits(StringBuilder outputBuffer, int digits); // 0x00000001815DFDE0-0x00000001815DFE50
		internal static int ParseRepeatPattern(ReadOnlySpan<char> format, int pos, char patternChar); // 0x00000001815E0170-0x00000001815E01C0
		private static string FormatDayOfWeek(int dayOfWeek, int repeat, DateTimeFormatInfo dtfi); // 0x00000001815DF150-0x00000001815DF190
		private static string FormatMonth(int month, int repeatCount, DateTimeFormatInfo dtfi); // 0x00000001815DF3E0-0x00000001815DF420
		private static string FormatHebrewMonthName(DateTime time, int month, int repeatCount, DateTimeFormatInfo dtfi); // 0x00000001815DF310-0x00000001815DF3E0
		internal static int ParseQuoteString(ReadOnlySpan<char> format, int pos, StringBuilder result); // 0x00000001815DFFA0-0x00000001815E0170
		internal static int ParseNextChar(ReadOnlySpan<char> format, int pos); // 0x00000001815DFF60-0x00000001815DFFA0
		private static bool IsUseGenitiveForm(ReadOnlySpan<char> format, int index, int tokenLen, char patternToMatch); // 0x00000001815DFE50-0x00000001815DFF60
		private static StringBuilder FormatCustomized(DateTime dateTime, ReadOnlySpan<char> format, DateTimeFormatInfo dtfi, TimeSpan offset, StringBuilder result); // 0x00000001815DDB40-0x00000001815DF150
		private static void FormatCustomizedTimeZone(DateTime dateTime, TimeSpan offset, ReadOnlySpan<char> format, int tokenLen, bool timeOnly, StringBuilder result); // 0x00000001815DD780-0x00000001815DDB40
		private static void FormatCustomizedRoundripTimeZone(DateTime dateTime, TimeSpan offset, StringBuilder result); // 0x00000001815DD4B0-0x00000001815DD780
		private static void Append2DigitNumber(StringBuilder result, int val); // 0x00000001815DCD30-0x00000001815DCDB0
		internal static string GetRealFormat(ReadOnlySpan<char> format, DateTimeFormatInfo dtfi); // 0x00000001815DFAA0-0x00000001815DFDE0
		private static string ExpandPredefinedFormat(ReadOnlySpan<char> format, ref DateTime dateTime, ref DateTimeFormatInfo dtfi, ref TimeSpan offset); // 0x00000001815DCDB0-0x00000001815DD4B0
		internal static string Format(DateTime dateTime, string format, IFormatProvider provider); // 0x00000001815DF790-0x00000001815DF820
		internal static string Format(DateTime dateTime, string format, IFormatProvider provider, TimeSpan offset); // 0x00000001815DF820-0x00000001815DFAA0
		internal static bool TryFormat(DateTime dateTime, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider); // 0x00000001815E0E10-0x00000001815E0ED0
		internal static bool TryFormat(DateTime dateTime, Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider, TimeSpan offset); // 0x00000001815E0ED0-0x00000001815E1100
		private static StringBuilder FormatStringBuilder(DateTime dateTime, ReadOnlySpan<char> format, DateTimeFormatInfo dtfi, TimeSpan offset); // 0x00000001815DF420-0x00000001815DF790
		private static bool TryFormatO(DateTime dateTime, TimeSpan offset, Span<char> destination, out int charsWritten); // 0x00000001815E01C0-0x00000001815E08D0
		private static bool TryFormatR(DateTime dateTime, TimeSpan offset, Span<char> destination, out int charsWritten); // 0x00000001815E08D0-0x00000001815E0E10
		private static void WriteTwoDecimalDigits(uint value, Span<char> destination, int offset); // 0x00000001815E1190-0x00000001815E11F0
		private static void WriteFourDecimalDigits(uint value, Span<char> buffer, int startingIndex = 0 /* Metadata: 0x0064E3D7 */); // 0x00000001815DC520-0x00000001815DC7A0
		private static void WriteDigits(ulong value, Span<char> buffer); // 0x00000001815E1100-0x00000001815E1190
		internal static void InvalidFormatForLocal(ReadOnlySpan<char> format, DateTime dateTime); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
