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
	[Serializable]
	public sealed class DateTimeFormatInfo : IFormatProvider, ICloneable // TypeDefIndex: 3396
	{
		// Fields
		private static DateTimeFormatInfo s_invariantInfo; // 0x00
		[NonSerialized]
		private CultureData _cultureData; // 0x10
		private string _name; // 0x18
		[NonSerialized]
		private string _langName; // 0x20
		[NonSerialized]
		private CompareInfo _compareInfo; // 0x28
		[NonSerialized]
		private CultureInfo _cultureInfo; // 0x30
		private string amDesignator; // 0x38
		private string pmDesignator; // 0x40
		private string dateSeparator; // 0x48
		private string generalShortTimePattern; // 0x50
		private string generalLongTimePattern; // 0x58
		private string timeSeparator; // 0x60
		private string monthDayPattern; // 0x68
		private string dateTimeOffsetPattern; // 0x70
		private const string rfc1123Pattern = "ddd, dd MMM yyyy HH\':\'mm\':\'ss \'GMT\'"; // Metadata: 0x0064EE24
		private const string sortableDateTimePattern = "yyyy\'-\'MM\'-\'dd\'T\'HH\':\'mm\':\'ss"; // Metadata: 0x0064EE48
		private const string universalSortableDateTimePattern = "yyyy\'-\'MM\'-\'dd HH\':\'mm\':\'ss\'Z\'"; // Metadata: 0x0064EE66
		private Calendar calendar; // 0x78
		private int firstDayOfWeek; // 0x80
		private int calendarWeekRule; // 0x84
		private string fullDateTimePattern; // 0x88
		private string[] abbreviatedDayNames; // 0x90
		private string[] m_superShortDayNames; // 0x98
		private string[] dayNames; // 0xA0
		private string[] abbreviatedMonthNames; // 0xA8
		private string[] monthNames; // 0xB0
		private string[] genitiveMonthNames; // 0xB8
		private string[] m_genitiveAbbreviatedMonthNames; // 0xC0
		private string[] leapYearMonthNames; // 0xC8
		private string longDatePattern; // 0xD0
		private string shortDatePattern; // 0xD8
		private string yearMonthPattern; // 0xE0
		private string longTimePattern; // 0xE8
		private string shortTimePattern; // 0xF0
		private string[] allYearMonthPatterns; // 0xF8
		private string[] allShortDatePatterns; // 0x100
		private string[] allLongDatePatterns; // 0x108
		private string[] allShortTimePatterns; // 0x110
		private string[] allLongTimePatterns; // 0x118
		private string[] m_eraNames; // 0x120
		private string[] m_abbrevEraNames; // 0x128
		private string[] m_abbrevEnglishEraNames; // 0x130
		private CalendarId[] optionalCalendars; // 0x138
		private const int DEFAULT_ALL_DATETIMES_SIZE = 132; // Metadata: 0x0064EE85
		internal bool _isReadOnly; // 0x140
		private DateTimeFormatFlags formatFlags; // 0x144
		private static readonly char[] s_monthSpaces; // 0x08
		internal const string RoundtripFormat = "yyyy\'-\'MM\'-\'dd\'T\'HH\':\'mm\':\'ss.fffffffK"; // Metadata: 0x0064EE87
		internal const string RoundtripDateTimeUnfixed = "yyyy\'-\'MM\'-\'ddTHH\':\'mm\':\'ss zzz"; // Metadata: 0x0064EEAE
		private string _fullTimeSpanPositivePattern; // 0x148
		private string _fullTimeSpanNegativePattern; // 0x150
		internal const DateTimeStyles InvalidDateTimeStyles = DateTimeStyles.None; // Metadata: 0x0064EECE
		[NonSerialized]
		private TokenHashValue[] _dtfiTokenHash; // 0x158
		private const int TOKEN_HASH_SIZE = 199; // Metadata: 0x0064EED0
		private const int SECOND_PRIME = 197; // Metadata: 0x0064EED2
		private const string dateSeparatorOrTimeZoneOffset = "-"; // Metadata: 0x0064EED4
		private const string invariantDateSeparator = "/"; // Metadata: 0x0064EED6
		private const string invariantTimeSeparator = ":"; // Metadata: 0x0064EED8
		internal const string IgnorablePeriod = "."; // Metadata: 0x0064EEDA
		internal const string IgnorableComma = ","; // Metadata: 0x0064EEDC
		internal const string CJKYearSuff = "\u5E74"; // Metadata: 0x0064EEDE
		internal const string CJKMonthSuff = "\u6708"; // Metadata: 0x0064EEE2
		internal const string CJKDaySuff = "\u65E5"; // Metadata: 0x0064EEE6
		internal const string KoreanYearSuff = "\uB144"; // Metadata: 0x0064EEEA
		internal const string KoreanMonthSuff = "\uC6D4"; // Metadata: 0x0064EEEE
		internal const string KoreanDaySuff = "\uC77C"; // Metadata: 0x0064EEF2
		internal const string KoreanHourSuff = "\uC2DC"; // Metadata: 0x0064EEF6
		internal const string KoreanMinuteSuff = "\uBD84"; // Metadata: 0x0064EEFA
		internal const string KoreanSecondSuff = "\uCD08"; // Metadata: 0x0064EEFE
		internal const string CJKHourSuff = "\u6642"; // Metadata: 0x0064EF02
		internal const string ChineseHourSuff = "\u65F6"; // Metadata: 0x0064EF06
		internal const string CJKMinuteSuff = "\u5206"; // Metadata: 0x0064EF0A
		internal const string CJKSecondSuff = "\u79D2"; // Metadata: 0x0064EF0E
		internal const string JapaneseEraStart = "\u5143"; // Metadata: 0x0064EF12
		internal const string LocalTimeMark = "T"; // Metadata: 0x0064EF16
		internal const string GMTName = "GMT"; // Metadata: 0x0064EF18
		internal const string ZuluName = "Z"; // Metadata: 0x0064EF1C
		internal const string KoreanLangName = "ko"; // Metadata: 0x0064EF1E
		internal const string JapaneseLangName = "ja"; // Metadata: 0x0064EF21
		internal const string EnglishLangName = "en"; // Metadata: 0x0064EF24
		private static DateTimeFormatInfo s_jajpDTFI; // 0x10
		private static DateTimeFormatInfo s_zhtwDTFI; // 0x18
	
		// Properties
		private string CultureName { get; } // 0x000000018154F1B0-0x000000018154F1F0 
		private CultureInfo Culture { get; } // 0x000000018154F1F0-0x000000018154F270 
		private string LanguageName { get; } // 0x000000018154FD60-0x000000018154FDA0 
		public static DateTimeFormatInfo InvariantInfo { get; } // 0x000000018154FBE0-0x000000018154FCC0 
		public static DateTimeFormatInfo CurrentInfo { get; } // 0x000000018154F270-0x000000018154F360 
		public string AMDesignator { get; } // 0x000000018154EAD0-0x000000018154EB10 
		public Calendar Calendar { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x0000000181550AA0-0x0000000181551190
		private CalendarId[] OptionalCalendars { get; } // 0x0000000181550060-0x00000001815500B0 
		internal string[] EraNames { get; } // 0x000000018154F6C0-0x000000018154F740 
		internal string[] AbbreviatedEraNames { get; } // 0x000000018154EC20-0x000000018154ECA0 
		internal string[] AbbreviatedEnglishEraNames { get; } // 0x000000018154EBA0-0x000000018154EC20 
		public string DateSeparator { get; } // 0x000000018154F360-0x000000018154F3D0 
		public string FullDateTimePattern { get; } // 0x000000018154F760-0x000000018154F830 
		public string LongDatePattern { get; } // 0x000000018154FDA0-0x000000018154FE00 
		public string LongTimePattern { get; } // 0x000000018154FE00-0x000000018154FE90 
		public string MonthDayPattern { get; } // 0x000000018154FE90-0x000000018154FF00 
		public string PMDesignator { get; } // 0x00000001815500B0-0x00000001815500F0 
		public string RFC1123Pattern { get; } // 0x00000001815500F0-0x0000000181550120 
		public string ShortDatePattern { get; } // 0x0000000181550120-0x0000000181550180 
		public string ShortTimePattern { get; } // 0x0000000181550180-0x0000000181550210 
		public string SortableDateTimePattern { get; } // 0x0000000181550210-0x0000000181550240 
		internal string GeneralShortTimePattern { get; } // 0x000000018154FA50-0x000000018154FB10 
		internal string GeneralLongTimePattern { get; } // 0x000000018154F990-0x000000018154FA50 
		internal string DateTimeOffsetPattern { get; } // 0x000000018154F3D0-0x000000018154F630 
		public string TimeSeparator { get; } // 0x0000000181550240-0x0000000181550280 
		public string UniversalSortableDateTimePattern { get; } // 0x00000001815504A0-0x00000001815504D0 
		public string YearMonthPattern { get; } // 0x00000001815504D0-0x0000000181550530 
		public string[] AbbreviatedDayNames { get; } // 0x000000018154EB10-0x000000018154EBA0 
		public string[] DayNames { get; } // 0x000000018154F630-0x000000018154F6C0 
		public string[] AbbreviatedMonthNames { get; } // 0x000000018154ECA0-0x000000018154ED30 
		public string[] MonthNames { get; } // 0x000000018154FFD0-0x0000000181550060 
		internal bool HasSpacesInMonthNames { get; } // 0x000000018154FB80-0x000000018154FBB0 
		internal bool HasSpacesInDayNames { get; } // 0x000000018154FB50-0x000000018154FB80 
		private string[] AllYearMonthPatterns { get; } // 0x000000018154EFF0-0x000000018154F0A0 
		private string[] AllShortDatePatterns { get; } // 0x000000018154EE90-0x000000018154EF40 
		private string[] AllShortTimePatterns { get; } // 0x000000018154EF40-0x000000018154EFF0 
		private string[] AllLongDatePatterns { get; } // 0x000000018154ED30-0x000000018154EDE0 
		private string[] AllLongTimePatterns { get; } // 0x000000018154EDE0-0x000000018154EE90 
		private string[] UnclonedYearMonthPatterns { get; } // 0x0000000181550420-0x00000001815504A0 
		private string[] UnclonedShortDatePatterns { get; } // 0x0000000181550350-0x00000001815503D0 
		private string[] UnclonedLongDatePatterns { get; } // 0x0000000181550280-0x0000000181550300 
		private string[] UnclonedShortTimePatterns { get; } // 0x00000001815503D0-0x0000000181550420 
		private string[] UnclonedLongTimePatterns { get; } // 0x0000000181550300-0x0000000181550350 
		public bool IsReadOnly { get; } // 0x000000018154FCC0-0x000000018154FD60 
		public string[] MonthGenitiveNames { get; } // 0x000000018154FF00-0x000000018154FFD0 
		internal string FullTimeSpanPositivePattern { get; } // 0x000000018154F8A0-0x000000018154F990 
		internal string FullTimeSpanNegativePattern { get; } // 0x000000018154F830-0x000000018154F8A0 
		internal CompareInfo CompareInfo { get; } // 0x000000018154F0A0-0x000000018154F1B0 
		internal DateTimeFormatFlags FormatFlags { get; } // 0x000000018154F740-0x000000018154F760 
		internal bool HasForceTwoDigitYears { get; } // 0x000000018154FB10-0x000000018154FB50 
		internal bool HasYearMonthAdjustment { get; } // 0x000000018154FBB0-0x000000018154FBE0 
	
		// Nested types
		internal class TokenHashValue // TypeDefIndex: 3397
		{
			// Fields
			internal string tokenString; // 0x10
			internal TokenType tokenType; // 0x18
			internal int tokenValue; // 0x1C
	
			// Constructors
			internal TokenHashValue(string tokenString, TokenType tokenType, int tokenValue); // 0x0000000181559600-0x0000000181559660
		}
	
		// Constructors
		public DateTimeFormatInfo(); // 0x000000018154E7E0-0x000000018154EA60
		internal DateTimeFormatInfo(CultureData cultureData, Calendar cal); // 0x000000018154EA60-0x000000018154EAD0
		static DateTimeFormatInfo(); // 0x000000018154E740-0x000000018154E7E0
	
		// Methods
		private string[] internalGetAbbreviatedDayOfWeekNames(); // 0x00000001815505A0-0x00000001815505C0
		private string[] internalGetAbbreviatedDayOfWeekNamesCore(); // 0x0000000181550530-0x00000001815505A0
		private string[] internalGetDayOfWeekNames(); // 0x00000001815506C0-0x00000001815506E0
		private string[] internalGetDayOfWeekNamesCore(); // 0x0000000181550650-0x00000001815506C0
		private string[] internalGetAbbreviatedMonthNames(); // 0x0000000181550630-0x0000000181550650
		private string[] internalGetAbbreviatedMonthNamesCore(); // 0x00000001815505C0-0x0000000181550630
		private string[] internalGetMonthNames(); // 0x0000000181550A80-0x0000000181550AA0
		private string[] internalGetMonthNamesCore(); // 0x0000000181550A10-0x0000000181550A80
		private void InitializeOverridableProperties(CultureData cultureData, int calendarId); // 0x000000018154C240-0x000000018154C400
		public static DateTimeFormatInfo GetInstance(IFormatProvider provider); // 0x000000018154B580-0x000000018154B730
		public object GetFormat(Type formatType); // 0x000000018154B510-0x000000018154B580
		public object Clone(); // 0x0000000181549BE0-0x0000000181549D30
		public string GetEraName(int era); // 0x000000018154B3D0-0x000000018154B510
		public string GetAbbreviatedEraName(int era); // 0x000000018154AA20-0x000000018154AB90
		internal string internalGetMonthName(int month, MonthNameStyles style, bool abbreviated); // 0x0000000181550850-0x0000000181550A10
		private string[] internalGetGenitiveMonthNames(bool abbreviated); // 0x00000001815506E0-0x00000001815507D0
		internal string[] internalGetLeapYearMonthNames(); // 0x00000001815507D0-0x0000000181550850
		public string GetAbbreviatedDayName(DayOfWeek dayofweek); // 0x000000018154A910-0x000000018154AA20
		private static string[] GetCombinedPatterns(string[] patterns1, string[] patterns2, string connectString); // 0x000000018154B160-0x000000018154B2C0
		public string[] GetAllDateTimePatterns(char format); // 0x000000018154ACA0-0x000000018154B160
		public string GetDayName(DayOfWeek dayofweek); // 0x000000018154B2C0-0x000000018154B3D0
		public string GetAbbreviatedMonthName(int month); // 0x000000018154AB90-0x000000018154ACA0
		public string GetMonthName(int month); // 0x000000018154BAA0-0x000000018154BBB0
		private static string[] GetMergedPatterns(string[] patterns, string defaultPattern); // 0x000000018154B8D0-0x000000018154BAA0
		internal static void ValidateStyles(DateTimeStyles style, string parameterName); // 0x000000018154E4D0-0x000000018154E600
		private DateTimeFormatFlags InitializeFormatFlags(); // 0x000000018154BD50-0x000000018154C240
		internal bool YearMonthAdjustment(ref int year, ref int month, bool parsedMonthName); // 0x000000018154E600-0x000000018154E740
		internal static DateTimeFormatInfo GetJapaneseCalendarDTFI(); // 0x000000018154B730-0x000000018154B8D0
		internal static DateTimeFormatInfo GetTaiwanCalendarDTFI(); // 0x000000018154BBB0-0x000000018154BD50
		private void ClearTokenHashTable(); // 0x0000000181549BA0-0x0000000181549BE0
		internal TokenHashValue[] CreateTokenHashTable(); // 0x0000000181549E50-0x000000018154A910
		private void PopulateSpecialTokenHashTable(TokenHashValue[] temp, ref bool useDateSepAsIgnorableSymbol); // 0x000000018154CCA0-0x000000018154DBC0
		private static bool IsJapaneseCalendar(Calendar calendar); // 0x000000018154CBB0-0x000000018154CCA0
		private void AddMonthNames(TokenHashValue[] temp, string monthPostfix); // 0x0000000181549AD0-0x0000000181549BA0
		private static bool TryParseHebrewNumber(ref __DTString str, out bool badFormat, out int number); // 0x000000018154E1F0-0x000000018154E4D0
		private static bool IsHebrewChar(char ch); // 0x000000018154CB90-0x000000018154CBB0
		private bool IsAllowedJapaneseTokenFollowedByNonSpaceLetter(string tokenString, char nextCh); // 0x000000018154CA70-0x000000018154CB90
		internal bool Tokenize(TokenType TokenMask, out TokenType tokenType, out int tokenValue, ref __DTString str); // 0x000000018154DBC0-0x000000018154E1F0
		private void InsertAtCurrentHashNode(TokenHashValue[] hashTable, string str, char ch, TokenType tokenType, int tokenValue, int pos, int hashcode, int hashProbe); // 0x000000018154C400-0x000000018154C660
		private void InsertHash(TokenHashValue[] hashTable, string str, TokenType tokenType, int tokenValue); // 0x000000018154C660-0x000000018154CA70
		private bool CompareStringIgnoreCaseOptimized(string string1, int offset1, int length1, string string2, int offset2, int length2); // 0x0000000181549D30-0x0000000181549E50
	}
}
