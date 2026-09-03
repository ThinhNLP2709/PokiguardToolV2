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
	internal static class DateTimeParse // TypeDefIndex: 2249
	{
		// Fields
		internal static MatchNumberDelegate m_hebrewNumberParser; // 0x00
		private static DS[][] dateParsingStates; // 0x08
	
		// Nested types
		internal delegate bool MatchNumberDelegate(ref __DTString str, int digitLen, out int result); // TypeDefIndex: 2250; 0x0000000180A72B30-0x0000000180A72B50
	
		internal enum DTT // TypeDefIndex: 2251
		{
			End = 0,
			NumEnd = 1,
			NumAmpm = 2,
			NumSpace = 3,
			NumDatesep = 4,
			NumTimesep = 5,
			MonthEnd = 6,
			MonthSpace = 7,
			MonthDatesep = 8,
			NumDatesuff = 9,
			NumTimesuff = 10,
			DayOfWeek = 11,
			YearSpace = 12,
			YearDateSep = 13,
			YearEnd = 14,
			TimeZone = 15,
			Era = 16,
			NumUTCTimeMark = 17,
			Unk = 18,
			NumLocalTimeMark = 19,
			Max = 20
		}
	
		internal enum TM // TypeDefIndex: 2252
		{
			NotSet = -1,
			AM = 0,
			PM = 1
		}
	
		internal enum DS // TypeDefIndex: 2253
		{
			BEGIN = 0,
			N = 1,
			NN = 2,
			D_Nd = 3,
			D_NN = 4,
			D_NNd = 5,
			D_M = 6,
			D_MN = 7,
			D_NM = 8,
			D_MNd = 9,
			D_NDS = 10,
			D_Y = 11,
			D_YN = 12,
			D_YNd = 13,
			D_YM = 14,
			D_YMd = 15,
			D_S = 16,
			T_S = 17,
			T_Nt = 18,
			T_NNt = 19,
			ERROR = 20,
			DX_NN = 21,
			DX_NNN = 22,
			DX_MN = 23,
			DX_NM = 24,
			DX_MNN = 25,
			DX_DS = 26,
			DX_DSN = 27,
			DX_NDS = 28,
			DX_NNDS = 29,
			DX_YNN = 30,
			DX_YMN = 31,
			DX_YN = 32,
			DX_YM = 33,
			TX_N = 34,
			TX_NN = 35,
			TX_NNN = 36,
			TX_TS = 37,
			DX_NNY = 38
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2254
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<MatchNumberDelegate> __9__98_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018160E8B0-0x000000018160E920
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal MatchNumberDelegate _DoStrictParse_b__98_0(); // 0x000000018160E7C0-0x000000018160E8B0
		}
	
		// Constructors
		static DateTimeParse(); // 0x00000001815F0250-0x00000001815F0B20
	
		// Methods
		internal static DateTime ParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, DateTimeFormatInfo dtfi, DateTimeStyles style); // 0x00000001815EC650-0x00000001815EC830
		internal static DateTime ParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, DateTimeFormatInfo dtfi, DateTimeStyles style, out TimeSpan offset); // 0x00000001815EC410-0x00000001815EC650
		internal static bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, DateTimeFormatInfo dtfi, DateTimeStyles style, out DateTime result); // 0x00000001815EEE90-0x00000001815EF090
		internal static bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, DateTimeFormatInfo dtfi, DateTimeStyles style, out DateTime result, out TimeSpan offset); // 0x00000001815EF090-0x00000001815EF2E0
		internal static bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, DateTimeFormatInfo dtfi, DateTimeStyles style, ref DateTimeResult result); // 0x00000001815EEDA0-0x00000001815EEE90
		internal static DateTime ParseExactMultiple(ReadOnlySpan<char> s, string[] formats, DateTimeFormatInfo dtfi, DateTimeStyles style); // 0x00000001815EC2E0-0x00000001815EC410
		internal static bool TryParseExactMultiple(ReadOnlySpan<char> s, string[] formats, DateTimeFormatInfo dtfi, DateTimeStyles style, out DateTime result); // 0x00000001815EE870-0x00000001815EE9F0
		internal static bool TryParseExactMultiple(ReadOnlySpan<char> s, string[] formats, DateTimeFormatInfo dtfi, DateTimeStyles style, ref DateTimeResult result); // 0x00000001815EE9F0-0x00000001815EEDA0
		private static bool MatchWord(ref __DTString str, string target); // 0x00000001815EA8F0-0x00000001815EAA50
		private static bool GetTimeZoneName(ref __DTString str); // 0x00000001815E8910-0x00000001815E89A0
		internal static bool IsDigit(char ch); // 0x00000001815E8E80-0x00000001815E8E90
		private static bool ParseFraction(ref __DTString str, out double result); // 0x00000001815EC960-0x00000001815ECA70
		private static bool ParseTimeZone(ref __DTString str, ref TimeSpan result); // 0x00000001815ED460-0x00000001815ED780
		private static bool HandleTimeZone(ref __DTString str, ref DateTimeResult result); // 0x00000001815E8D10-0x00000001815E8E80
		private static bool Lex(DS dps, ref __DTString str, ref DateTimeToken dtok, ref DateTimeRawInfo raw, ref DateTimeResult result, ref DateTimeFormatInfo dtfi, DateTimeStyles styles); // 0x00000001815E8E90-0x00000001815E9E70
		private static Calendar GetJapaneseCalendarDefaultInstance(); // 0x00000001815E8450-0x00000001815E8550
		internal static Calendar GetTaiwanCalendarDefaultInstance(); // 0x00000001815E86E0-0x00000001815E87E0
		private static bool VerifyValidPunctuation(ref __DTString str); // 0x00000001815F0040-0x00000001815F0250
		private static bool GetYearMonthDayOrder(string datePattern, DateTimeFormatInfo dtfi, out int order); // 0x00000001815E89A0-0x00000001815E8BC0
		private static bool GetYearMonthOrder(string pattern, DateTimeFormatInfo dtfi, out int order); // 0x00000001815E8BC0-0x00000001815E8D10
		private static bool GetMonthDayOrder(string pattern, DateTimeFormatInfo dtfi, out int order); // 0x00000001815E8550-0x00000001815E86E0
		private static bool TryAdjustYear(ref DateTimeResult result, int year, out int adjustedYear); // 0x00000001815EE810-0x00000001815EE870
		private static bool SetDateYMD(ref DateTimeResult result, int year, int month, int day); // 0x00000001815EE780-0x00000001815EE810
		private static bool SetDateMDY(ref DateTimeResult result, int month, int day, int year); // 0x00000001815EE680-0x00000001815EE700
		private static bool SetDateDMY(ref DateTimeResult result, int day, int month, int year); // 0x00000001815EE600-0x00000001815EE680
		private static bool SetDateYDM(ref DateTimeResult result, int year, int day, int month); // 0x00000001815EE700-0x00000001815EE780
		private static void GetDefaultYear(ref DateTimeResult result, ref DateTimeStyles styles); // 0x00000001815E8250-0x00000001815E82F0
		private static bool GetDayOfNN(ref DateTimeResult result, ref DateTimeStyles styles, ref DateTimeRawInfo raw, DateTimeFormatInfo dtfi); // 0x00000001815E7DA0-0x00000001815E7F10
		private static bool GetDayOfNNN(ref DateTimeResult result, ref DateTimeRawInfo raw, DateTimeFormatInfo dtfi); // 0x00000001815E79B0-0x00000001815E7C40
		private static bool GetDayOfMN(ref DateTimeResult result, ref DateTimeStyles styles, ref DateTimeRawInfo raw, DateTimeFormatInfo dtfi); // 0x00000001815E75F0-0x00000001815E77D0
		private static bool GetHebrewDayOfNM(ref DateTimeResult result, ref DateTimeRawInfo raw, DateTimeFormatInfo dtfi); // 0x00000001815E82F0-0x00000001815E8450
		private static bool GetDayOfNM(ref DateTimeResult result, ref DateTimeStyles styles, ref DateTimeRawInfo raw, DateTimeFormatInfo dtfi); // 0x00000001815E77D0-0x00000001815E79B0
		private static bool GetDayOfMNN(ref DateTimeResult result, ref DateTimeRawInfo raw, DateTimeFormatInfo dtfi); // 0x00000001815E72F0-0x00000001815E75F0
		private static bool GetDayOfYNN(ref DateTimeResult result, ref DateTimeRawInfo raw, DateTimeFormatInfo dtfi); // 0x00000001815E8080-0x00000001815E81A0
		private static bool GetDayOfNNY(ref DateTimeResult result, ref DateTimeRawInfo raw, DateTimeFormatInfo dtfi); // 0x00000001815E7C40-0x00000001815E7DA0
		private static bool GetDayOfYMN(ref DateTimeResult result, ref DateTimeRawInfo raw); // 0x00000001815E7F10-0x00000001815E7FD0
		private static bool GetDayOfYN(ref DateTimeResult result, ref DateTimeRawInfo raw); // 0x00000001815E81A0-0x00000001815E8250
		private static bool GetDayOfYM(ref DateTimeResult result, ref DateTimeRawInfo raw); // 0x00000001815E7FD0-0x00000001815E8080
		private static void AdjustTimeMark(DateTimeFormatInfo dtfi, ref DateTimeRawInfo raw); // 0x00000001815E51A0-0x00000001815E5260
		private static bool AdjustHour(ref int hour, TM timeMark); // 0x00000001815E5160-0x00000001815E51A0
		private static bool GetTimeOfN(ref DateTimeResult result, ref DateTimeRawInfo raw); // 0x00000001815E88C0-0x00000001815E8910
		private static bool GetTimeOfNN(ref DateTimeResult result, ref DateTimeRawInfo raw); // 0x00000001815E8860-0x00000001815E88C0
		private static bool GetTimeOfNNN(ref DateTimeResult result, ref DateTimeRawInfo raw); // 0x00000001815E87E0-0x00000001815E8860
		private static bool GetDateOfDSN(ref DateTimeResult result, ref DateTimeRawInfo raw); // 0x00000001815E6CE0-0x00000001815E6D20
		private static bool GetDateOfNDS(ref DateTimeResult result, ref DateTimeRawInfo raw); // 0x00000001815E6D20-0x00000001815E6DC0
		private static bool GetDateOfNNDS(ref DateTimeResult result, ref DateTimeRawInfo raw, DateTimeFormatInfo dtfi); // 0x00000001815E6DC0-0x00000001815E6FB0
		private static bool ProcessDateTimeSuffix(ref DateTimeResult result, ref DateTimeRawInfo raw, ref DateTimeToken dtok); // 0x00000001815ED9D0-0x00000001815EDA90
		internal static bool ProcessHebrewTerminalState(DS dps, ref __DTString str, ref DateTimeResult result, ref DateTimeStyles styles, ref DateTimeRawInfo raw, DateTimeFormatInfo dtfi); // 0x00000001815EDA90-0x00000001815EDFC0
		internal static bool ProcessTerminalState(DS dps, ref __DTString str, ref DateTimeResult result, ref DateTimeStyles styles, ref DateTimeRawInfo raw, DateTimeFormatInfo dtfi); // 0x00000001815EDFC0-0x00000001815EE600
		internal static DateTime Parse(ReadOnlySpan<char> s, DateTimeFormatInfo dtfi, DateTimeStyles styles); // 0x00000001815ED8B0-0x00000001815ED9D0
		internal static DateTime Parse(ReadOnlySpan<char> s, DateTimeFormatInfo dtfi, DateTimeStyles styles, out TimeSpan offset); // 0x00000001815ED780-0x00000001815ED8B0
		internal static bool TryParse(ReadOnlySpan<char> s, DateTimeFormatInfo dtfi, DateTimeStyles styles, out DateTime result); // 0x00000001815EF560-0x00000001815EF6D0
		internal static bool TryParse(ReadOnlySpan<char> s, DateTimeFormatInfo dtfi, DateTimeStyles styles, out DateTime result, out TimeSpan offset); // 0x00000001815EF3D0-0x00000001815EF560
		internal static bool TryParse(ReadOnlySpan<char> s, DateTimeFormatInfo dtfi, DateTimeStyles styles, ref DateTimeResult result); // 0x00000001815EF6D0-0x00000001815F0040
		private static bool DetermineTimeZoneAdjustments(ref __DTString str, ref DateTimeResult result, DateTimeStyles styles, bool bTimeOnly); // 0x00000001815E5B50-0x00000001815E5DA0
		private static bool DateTimeOffsetTimeZonePostProcessing(ref __DTString str, ref DateTimeResult result, DateTimeStyles styles); // 0x00000001815E58E0-0x00000001815E5B50
		private static bool AdjustTimeZoneToUniversal(ref DateTimeResult result); // 0x00000001815E54D0-0x00000001815E5600
		private static bool AdjustTimeZoneToLocal(ref DateTimeResult result, bool bTimeOnly); // 0x00000001815E5260-0x00000001815E54D0
		private static bool ParseISO8601(ref DateTimeRawInfo raw, ref __DTString str, DateTimeStyles styles, ref DateTimeResult result); // 0x00000001815ECA70-0x00000001815ECFB0
		internal static bool MatchHebrewDigits(ref __DTString str, int digitLen, out int number); // 0x00000001815EA4C0-0x00000001815EA5E0
		internal static bool ParseDigits(ref __DTString str, int digitLen, out int result); // 0x00000001815EC240-0x00000001815EC2E0
		internal static bool ParseDigits(ref __DTString str, int minDigitLen, int maxDigitLen, out int result); // 0x00000001815EC150-0x00000001815EC240
		private static bool ParseFractionExact(ref __DTString str, int maxDigitLen, ref double result); // 0x00000001815EC830-0x00000001815EC960
		private static bool ParseSign(ref __DTString str, ref bool result); // 0x00000001815ED0A0-0x00000001815ED140
		private static bool ParseTimeZoneOffset(ref __DTString str, int len, ref TimeSpan result); // 0x00000001815ED140-0x00000001815ED460
		private static bool MatchAbbreviatedMonthName(ref __DTString str, DateTimeFormatInfo dtfi, ref int result); // 0x00000001815E9F90-0x00000001815EA120
		private static bool MatchMonthName(ref __DTString str, DateTimeFormatInfo dtfi, ref int result); // 0x00000001815EA5E0-0x00000001815EA7A0
		private static bool MatchAbbreviatedDayName(ref __DTString str, DateTimeFormatInfo dtfi, ref int result); // 0x00000001815E9E70-0x00000001815E9F90
		private static bool MatchDayName(ref __DTString str, DateTimeFormatInfo dtfi, ref int result); // 0x00000001815EA240-0x00000001815EA360
		private static bool MatchEraName(ref __DTString str, DateTimeFormatInfo dtfi, ref int result); // 0x00000001815EA360-0x00000001815EA4C0
		private static bool MatchTimeMark(ref __DTString str, DateTimeFormatInfo dtfi, ref TM result); // 0x00000001815EA7A0-0x00000001815EA8F0
		private static bool MatchAbbreviatedTimeMark(ref __DTString str, DateTimeFormatInfo dtfi, ref TM result); // 0x00000001815EA120-0x00000001815EA240
		private static bool CheckNewValue(ref int currentValue, int newValue, char patternChar, ref DateTimeResult result); // 0x00000001815E5840-0x00000001815E58E0
		private static DateTime GetDateTimeNow(ref DateTimeResult result, ref DateTimeStyles styles); // 0x00000001815E6FB0-0x00000001815E7100
		private static bool CheckDefaultDateTime(ref DateTimeResult result, ref Calendar cal, DateTimeStyles styles); // 0x00000001815E5600-0x00000001815E5840
		private static string ExpandPredefinedFormat(ReadOnlySpan<char> format, ref DateTimeFormatInfo dtfi, ref ParsingInfo parseInfo, ref DateTimeResult result); // 0x00000001815E6650-0x00000001815E6CE0
		private static bool ParseJapaneseEraStart(ref __DTString str, DateTimeFormatInfo dtfi); // 0x00000001815ECFB0-0x00000001815ED0A0
		private static bool ParseByFormat(ref __DTString str, ref __DTString format, ref ParsingInfo parseInfo, DateTimeFormatInfo dtfi, ref DateTimeResult result); // 0x00000001815EAA50-0x00000001815EC150
		internal static bool TryParseQuoteString(ReadOnlySpan<char> format, int pos, StringBuilder result, out int returnValue); // 0x00000001815EF2E0-0x00000001815EF3D0
		private static bool DoStrictParse(ReadOnlySpan<char> s, ReadOnlySpan<char> formatParam, DateTimeStyles styles, DateTimeFormatInfo dtfi, ref DateTimeResult result); // 0x00000001815E5DA0-0x00000001815E6650
		private static Exception GetDateTimeParseException(ref DateTimeResult result); // 0x00000001815E7100-0x00000001815E72F0
	}
}
