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
	internal class CultureData // TypeDefIndex: 3442
	{
		// Fields
		private string sAM1159; // 0x10
		private string sPM2359; // 0x18
		private string sTimeSeparator; // 0x20
		private string[] saLongTimes; // 0x28
		private string[] saShortTimes; // 0x30
		private int iFirstDayOfWeek; // 0x38
		private int iFirstWeekOfYear; // 0x3C
		private int[] waCalendars; // 0x40
		private CalendarData[] calendars; // 0x48
		private string sISO639Language; // 0x50
		private readonly string sRealName; // 0x58
		private bool bUseOverrides; // 0x60
		private int calendarId; // 0x64
		private int numberIndex; // 0x68
		private int iDefaultAnsiCodePage; // 0x6C
		private int iDefaultOemCodePage; // 0x70
		private int iDefaultMacCodePage; // 0x74
		private int iDefaultEbcdicCodePage; // 0x78
		private bool isRightToLeft; // 0x7C
		private string sListSeparator; // 0x80
		private static CultureData s_Invariant; // 0x00
	
		// Properties
		public static CultureData Invariant { get; } // 0x0000000181578E00-0x0000000181579200 
		internal string[] LongTimes { get; } // 0x0000000180DF0160-0x0000000180DF0180 
		internal string[] ShortTimes { get; } // 0x0000000181579240-0x0000000181579260 
		internal string SISO639LANGNAME { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal int IFIRSTDAYOFWEEK { get; } // 0x000000018047EDE0-0x000000018047EDF0 
		internal int IFIRSTWEEKOFYEAR { get; } // 0x00000001804EFAC0-0x00000001804EFAD0 
		internal string SAM1159 { get; } // 0x0000000180377550-0x0000000180377560 
		internal string SPM2359 { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal string TimeSeparator { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal int[] CalendarIds { get; } // 0x0000000181578C50-0x0000000181578E00 
		internal bool IsInvariantCulture { get; } // 0x0000000181579200-0x0000000181579210 
		internal string CultureName { get; } // 0x00000001802F4000-0x00000001802F4010 
		internal string SCOMPAREINFO { get; } // 0x0000000181579210-0x0000000181579240 
		internal string STEXTINFO { get; } // 0x00000001802F4000-0x00000001802F4010 
		internal bool UseUserOverride { get; } // 0x000000018033D4F0-0x000000018033D500 
	
		// Nested types
		internal struct NumberFormatEntryManaged // TypeDefIndex: 3443
		{
			// Fields
			internal int currency_decimal_digits; // 0x00
			internal int currency_decimal_separator; // 0x04
			internal int currency_group_separator; // 0x08
			internal int currency_group_sizes0; // 0x0C
			internal int currency_group_sizes1; // 0x10
			internal int currency_negative_pattern; // 0x14
			internal int currency_positive_pattern; // 0x18
			internal int currency_symbol; // 0x1C
			internal int nan_symbol; // 0x20
			internal int negative_infinity_symbol; // 0x24
			internal int negative_sign; // 0x28
			internal int number_decimal_digits; // 0x2C
			internal int number_decimal_separator; // 0x30
			internal int number_group_separator; // 0x34
			internal int number_group_sizes0; // 0x38
			internal int number_group_sizes1; // 0x3C
			internal int number_negative_pattern; // 0x40
			internal int per_mille_symbol; // 0x44
			internal int percent_negative_pattern; // 0x48
			internal int percent_positive_pattern; // 0x4C
			internal int percent_symbol; // 0x50
			internal int positive_infinity_symbol; // 0x54
			internal int positive_sign; // 0x58
		}
	
		// Constructors
		private CultureData(string name); // 0x0000000181578B40-0x0000000181578B80
	
		// Methods
		public static CultureData GetCultureData(string cultureName, bool useUserOverride); // 0x0000000181577F30-0x0000000181577F90
		public static CultureData GetCultureData(string cultureName, bool useUserOverride, int datetimeIndex, int calendarId, int numberIndex, string iso2lang, int ansiCodePage, int oemCodePage, int macCodePage, int ebcdicCodePage, bool rightToLeft, string listSeparator); // 0x0000000181577E10-0x0000000181577F30
		private void fill_culture_data(int datetimeIndex); // 0x0000000181578C30-0x0000000181578C40
		public CalendarData GetCalendar(int calendarId); // 0x0000000181577CD0-0x0000000181577E10
		internal CalendarId[] GetCalendarIds(); // 0x0000000181577BD0-0x0000000181577CD0
		internal string[] EraNames(int calendarId); // 0x0000000181577B90-0x0000000181577BB0
		internal string[] AbbrevEraNames(int calendarId); // 0x00000001815779F0-0x0000000181577A10
		internal string[] AbbreviatedEnglishEraNames(int calendarId); // 0x0000000181577A30-0x0000000181577A50
		internal string[] ShortDates(int calendarId); // 0x0000000181578980-0x00000001815789A0
		internal string[] LongDates(int calendarId); // 0x0000000181578920-0x0000000181578940
		internal string[] YearMonths(int calendarId); // 0x0000000181578B20-0x0000000181578B40
		internal string[] DayNames(int calendarId); // 0x0000000181577B70-0x0000000181577B90
		internal string[] AbbreviatedDayNames(int calendarId); // 0x0000000181577A10-0x0000000181577A30
		internal string[] MonthNames(int calendarId); // 0x0000000181578960-0x0000000181578980
		internal string[] GenitiveMonthNames(int calendarId); // 0x0000000181577BB0-0x0000000181577BD0
		internal string[] AbbreviatedMonthNames(int calendarId); // 0x0000000181577A80-0x0000000181577AA0
		internal string[] AbbreviatedGenitiveMonthNames(int calendarId); // 0x0000000181577A50-0x0000000181577A80
		internal string[] LeapYearMonthNames(int calendarId); // 0x00000001815788F0-0x0000000181578920
		internal string MonthDay(int calendarId); // 0x0000000181578940-0x0000000181578960
		internal string DateSeparator(int calendarId); // 0x0000000181577AA0-0x0000000181577B70
		private static string GetDateSeparator(string format); // 0x0000000181577F90-0x0000000181577FD0
		private static string GetSeparator(string format, string timeParts); // 0x0000000181578620-0x0000000181578800
		private static int IndexOfTimePart(string format, int startIndex, string timeParts); // 0x0000000181578800-0x00000001815788F0
		private static string UnescapeNlsString(string str, int start, int end); // 0x00000001815789A0-0x0000000181578B20
		internal static string[] ReescapeWin32Strings(string[] array); // 0x0000000180370C60-0x0000000180370C70
		internal static string ReescapeWin32String(string str); // 0x0000000180370C60-0x0000000180370C70
		private static unsafe int strlen(byte* s); // 0x00000001815792C0-0x00000001815792E0
		private static unsafe string idx2string(byte* data, int idx); // 0x0000000181579260-0x00000001815792C0
		private int[] create_group_sizes_array(int gs0, int gs1); // 0x0000000181578B80-0x0000000181578C30
		internal void GetNFIValues(NumberFormatInfo nfi); // 0x0000000181577FD0-0x0000000181578620
		private static unsafe byte* fill_number_data(int index, ref NumberFormatEntryManaged nfe); // 0x0000000181578C40-0x0000000181578C50
	}
}
