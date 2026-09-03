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
	public class UmAlQuraCalendar : Calendar // TypeDefIndex: 3438
	{
		// Fields
		private static readonly DateMapping[] HijriYearInfo; // 0x00
		internal static DateTime minDate; // 0x08
		internal static DateTime maxDate; // 0x10
	
		// Properties
		public override DateTime MinSupportedDateTime { get; } // 0x0000000181590300-0x0000000181590350 
		public override DateTime MaxSupportedDateTime { get; } // 0x00000001815902B0-0x0000000181590300 
		internal override int BaseCalendarID { get; } // 0x0000000180A32610-0x0000000180A32620 
		internal override int ID { get; } // 0x00000001815902A0-0x00000001815902B0 
		public override int[] Eras { get; } // 0x0000000181590240-0x00000001815902A0 
		public override int TwoDigitYearMax { get; set; } // 0x0000000181588ED0-0x0000000181588F20 0x0000000181590350-0x0000000181590470
	
		// Nested types
		internal struct DateMapping // TypeDefIndex: 3439
		{
			// Fields
			internal int HijriMonthsLengthFlags; // 0x00
			internal DateTime GregorianDate; // 0x08
	
			// Constructors
			internal DateMapping(int MonthsLengthFlags, int GYear, int GMonth, int GDay); // 0x00000001815792E0-0x0000000181579330
		}
	
		// Constructors
		public UmAlQuraCalendar(); // 0x0000000181590230-0x0000000181590240
		static UmAlQuraCalendar(); // 0x000000018158FF30-0x0000000181590230
	
		// Methods
		private static DateMapping[] InitDateMapping(); // 0x000000018158F880-0x000000018158FA20
		private static void ConvertHijriToGregorian(int HijriYear, int HijriMonth, int HijriDay, ref int yg, ref int mg, ref int dg); // 0x000000018158F0E0-0x000000018158F250
		private static long GetAbsoluteDateUmAlQura(int year, int month, int day); // 0x000000018158F250-0x000000018158F410
		internal static void CheckTicksRange(long ticks); // 0x000000018158E9F0-0x000000018158EBD0
		internal static void CheckEraRange(int era); // 0x000000018158E960-0x000000018158E9F0
		internal static void CheckYearRange(int year, int era); // 0x000000018158ECA0-0x000000018158EE50
		internal static void CheckYearMonthRange(int year, int month, int era); // 0x000000018158EBD0-0x000000018158ECA0
		private static void ConvertGregorianToHijri(DateTime time, ref int HijriYear, ref int HijriMonth, ref int HijriDay); // 0x000000018158EE50-0x000000018158F0E0
		internal virtual int GetDatePart(DateTime time, int part); // 0x000000018158F410-0x000000018158F5A0
		public override int GetDayOfMonth(DateTime time); // 0x000000018158F5A0-0x000000018158F5C0
		public override DayOfWeek GetDayOfWeek(DateTime time); // 0x000000018158F5C0-0x000000018158F640
		public override int GetDaysInMonth(int year, int month, int era); // 0x000000018158F640-0x000000018158F700
		internal static int RealGetDaysInYear(int year); // 0x000000018158FA90-0x000000018158FB30
		public override int GetDaysInYear(int year, int era); // 0x000000018158F700-0x000000018158F760
		public override int GetEra(DateTime time); // 0x000000018158F760-0x000000018158F7E0
		public override int GetMonth(DateTime time); // 0x000000018158F7E0-0x000000018158F800
		public override int GetMonthsInYear(int year, int era); // 0x000000018158F800-0x000000018158F860
		public override int GetYear(DateTime time); // 0x000000018158F860-0x000000018158F880
		public override bool IsLeapYear(int year, int era); // 0x000000018158FA20-0x000000018158FA90
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era); // 0x000000018158FB30-0x000000018158FDA0
		public override int ToFourDigitYear(int year); // 0x000000018158FDA0-0x000000018158FF30
	}
}
