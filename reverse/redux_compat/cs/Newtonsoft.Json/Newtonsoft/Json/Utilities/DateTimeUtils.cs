/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Xml;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class DateTimeUtils // TypeDefIndex: 10110
	{
		// Fields
		internal static readonly long InitialJavaScriptDateTicks; // 0x00
		private const string IsoDateFormat = "yyyy-MM-ddTHH:mm:ss.FFFFFFFK"; // Metadata: 0x006A06BE
		private const int DaysPer100Years = 36524; // Metadata: 0x006A06DB
		private const int DaysPer400Years = 146097; // Metadata: 0x006A06DF
		private const int DaysPer4Years = 1461; // Metadata: 0x006A06E3
		private const int DaysPerYear = 365; // Metadata: 0x006A06E5
		private const long TicksPerDay = 864000000000; // Metadata: 0x006A06E7
		private static readonly int[] DaysToMonth365; // 0x08
		private static readonly int[] DaysToMonth366; // 0x10
	
		// Constructors
		static DateTimeUtils(); // 0x00000001816EDA60-0x00000001816EDB90
	
		// Methods
		public static XmlDateTimeSerializationMode ToSerializationMode(DateTimeKind kind); // 0x00000001816EB040-0x00000001816EB0F0
		internal static DateTime EnsureDateTime(DateTime value, DateTimeZoneHandling timeZone); // 0x00000001816EAA30-0x00000001816EAC90
		private static DateTime SwitchToLocalTime(DateTime value); // 0x00000001816EAEE0-0x00000001816EAF90
		private static DateTime SwitchToUtcTime(DateTime value); // 0x00000001816EAF90-0x00000001816EB040
		private static long ToUniversalTicks(DateTime dateTime); // 0x00000001816EB200-0x00000001816EB300
		private static long ToUniversalTicks(DateTime dateTime, TimeSpan offset); // 0x00000001816EB0F0-0x00000001816EB200
		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime, TimeSpan offset); // 0x00000001816EA4B0-0x00000001816EA570
		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime); // 0x00000001816EA570-0x00000001816EA5C0
		internal static long ConvertDateTimeToJavaScriptTicks(DateTime dateTime, bool convertToUtc); // 0x00000001816EA5C0-0x00000001816EA7C0
		private static long UniversalTicksToJavaScriptTicks(long universalTicks); // 0x00000001816ECB90-0x00000001816ECC00
		internal static DateTime ConvertJavaScriptTicksToDateTime(long javaScriptTicks); // 0x00000001816EA7C0-0x00000001816EA840
		internal static bool TryParseDateTimeIso(StringReference text, DateTimeZoneHandling dateTimeZoneHandling, out DateTime dt); // 0x00000001816EB3F0-0x00000001816EB7C0
		internal static bool TryParseDateTimeOffsetIso(StringReference text, out DateTimeOffset dt); // 0x00000001816EB9B0-0x00000001816EBC50
		private static DateTime CreateDateTime(DateTimeParser dateTimeParser); // 0x00000001816EA8F0-0x00000001816EAA30
		internal static bool TryParseDateTime(StringReference s, DateTimeZoneHandling dateTimeZoneHandling, [Nullable(2)] string dateFormatString, CultureInfo culture, out DateTime dt); // 0x00000001816EC2C0-0x00000001816EC500
		internal static bool TryParseDateTime(string s, DateTimeZoneHandling dateTimeZoneHandling, [Nullable(2)] string dateFormatString, CultureInfo culture, out DateTime dt); // 0x00000001816EC500-0x00000001816EC7D0
		internal static bool TryParseDateTimeOffset(StringReference s, [Nullable(2)] string dateFormatString, CultureInfo culture, out DateTimeOffset dt); // 0x00000001816EBDC0-0x00000001816EBFE0
		internal static bool TryParseDateTimeOffset(string s, [Nullable(2)] string dateFormatString, CultureInfo culture, out DateTimeOffset dt); // 0x00000001816EBFE0-0x00000001816EC2C0
		private static bool TryParseMicrosoftDate(StringReference text, out long ticks, out TimeSpan offset, out DateTimeKind kind); // 0x00000001816EC7D0-0x00000001816EC960
		private static bool TryParseDateTimeMicrosoft(StringReference text, DateTimeZoneHandling dateTimeZoneHandling, out DateTime dt); // 0x00000001816EB7C0-0x00000001816EB900
		private static bool TryParseDateTimeExact(string text, DateTimeZoneHandling dateTimeZoneHandling, string dateFormatString, CultureInfo culture, out DateTime dt); // 0x00000001816EB300-0x00000001816EB3F0
		private static bool TryParseDateTimeOffsetMicrosoft(StringReference text, out DateTimeOffset dt); // 0x00000001816EBC50-0x00000001816EBDC0
		private static bool TryParseDateTimeOffsetExact(string text, string dateFormatString, CultureInfo culture, out DateTimeOffset dt); // 0x00000001816EB900-0x00000001816EB9B0
		private static bool TryReadOffset(StringReference offsetText, int startIndex, out TimeSpan offset); // 0x00000001816EC960-0x00000001816ECB90
		internal static void WriteDateTimeString(TextWriter writer, DateTime value, DateFormatHandling format, [Nullable(2)] string formatString, CultureInfo culture); // 0x00000001816ECFD0-0x00000001816ED180
		internal static int WriteDateTimeString(char[] chars, int start, DateTime value, TimeSpan? offset, DateTimeKind kind, DateFormatHandling format); // 0x00000001816ED180-0x00000001816ED500
		internal static int WriteDefaultIsoDate(char[] chars, int start, DateTime dt); // 0x00000001816ED500-0x00000001816EDA60
		private static void CopyIntToCharArray(char[] chars, int start, int value, int digits); // 0x00000001816EA840-0x00000001816EA8F0
		internal static int WriteDateTimeOffset(char[] chars, int start, TimeSpan offset, DateFormatHandling format); // 0x00000001816ECDD0-0x00000001816ECFD0
		internal static void WriteDateTimeOffsetString(TextWriter writer, DateTimeOffset value, DateFormatHandling format, [Nullable(2)] string formatString, CultureInfo culture); // 0x00000001816ECC00-0x00000001816ECDD0
		private static void GetDateValues(DateTime td, out int year, out int month, out int day); // 0x00000001816EAC90-0x00000001816EAE80
	
		// Extension methods
		public static TimeSpan GetUtcOffset(this DateTime d); // 0x00000001816EAE80-0x00000001816EAEE0
	}
}
