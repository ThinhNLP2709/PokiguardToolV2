/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	internal class CalendarData // TypeDefIndex: 3426
	{
		// Fields
		internal const int MAX_CALENDARS = 23; // Metadata: 0x0064EFE8
		internal string sNativeName; // 0x10
		internal string[] saShortDates; // 0x18
		internal string[] saYearMonths; // 0x20
		internal string[] saLongDates; // 0x28
		internal string sMonthDay; // 0x30
		internal string[] saEraNames; // 0x38
		internal string[] saAbbrevEraNames; // 0x40
		internal string[] saAbbrevEnglishEraNames; // 0x48
		internal string[] saDayNames; // 0x50
		internal string[] saAbbrevDayNames; // 0x58
		internal string[] saSuperShortDayNames; // 0x60
		internal string[] saMonthNames; // 0x68
		internal string[] saAbbrevMonthNames; // 0x70
		internal string[] saMonthGenitiveNames; // 0x78
		internal string[] saAbbrevMonthGenitiveNames; // 0x80
		internal string[] saLeapYearMonthNames; // 0x88
		internal int iTwoDigitYearMax; // 0x90
		internal int iCurrentEra; // 0x94
		internal bool bUseUserOverrides; // 0x98
		internal static CalendarData Invariant; // 0x00
		private static string[] HEBREW_MONTH_NAMES; // 0x08
		private static string[] HEBREW_LEAP_MONTH_NAMES; // 0x10
	
		// Constructors
		private CalendarData(); // 0x00000001815417B0-0x00000001815417D0
		static CalendarData(); // 0x0000000181540020-0x0000000181541070
		internal CalendarData(string localeName, int calendarId, bool bUseUserOverrides); // 0x0000000181541070-0x00000001815417B0
	
		// Methods
		private void InitializeEraNames(string localeName, int calendarId); // 0x000000018153FAF0-0x0000000181540020
		private static string[] GetJapaneseEraNames(); // 0x000000018153F660-0x000000018153F760
		private static string[] GetJapaneseEnglishEraNames(); // 0x000000018153F560-0x000000018153F660
		private void InitializeAbbreviatedEraNames(string localeName, int calendarId); // 0x000000018153F760-0x000000018153FAF0
		internal static CalendarData GetCalendarData(int calendarId); // 0x000000018153F380-0x000000018153F560
		private static string CalendarIdToCultureName(int calendarId); // 0x000000018153F1F0-0x000000018153F380
		public static int nativeGetTwoDigitYearMax(int calID); // 0x00000001815418D0-0x00000001815418E0
		private static bool nativeGetCalendarData(CalendarData data, string localeName, int calendarId); // 0x00000001815417E0-0x00000001815418D0
		private bool fill_calendar_data(string localeName, int datetimeIndex); // 0x00000001815417D0-0x00000001815417E0
	}
}
