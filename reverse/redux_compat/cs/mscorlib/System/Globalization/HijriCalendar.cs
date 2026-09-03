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
	[ComVisible(true)]
	public class HijriCalendar : Calendar // TypeDefIndex: 3431
	{
		// Fields
		public static readonly int HijriEra; // 0x00
		internal static readonly int[] HijriMonthDays; // 0x08
		private int m_HijriAdvance; // 0x20
		internal static readonly DateTime calendarMinValue; // 0x10
		internal static readonly DateTime calendarMaxValue; // 0x18
	
		// Properties
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime { get; } // 0x0000000181588E80-0x0000000181588ED0 
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime { get; } // 0x0000000181588E30-0x0000000181588E80 
		internal override int ID { get; } // 0x0000000180A32610-0x0000000180A32620 
		public int HijriAdjustment { get; } // 0x0000000181588DD0-0x0000000181588E30 
		public override int[] Eras { get; } // 0x0000000181588D40-0x0000000181588DD0 
		public override int TwoDigitYearMax { get; set; } // 0x0000000181588ED0-0x0000000181588F20 0x0000000181588F20-0x0000000181589030
	
		// Constructors
		public HijriCalendar(); // 0x0000000181588D30-0x0000000181588D40
		static HijriCalendar(); // 0x0000000181588BF0-0x0000000181588D30
	
		// Methods
		private long GetAbsoluteDateHijri(int y, int m, int d); // 0x0000000181587DF0-0x0000000181587F00
		private long DaysUpToHijriYear(int HijriYear); // 0x0000000181587D30-0x0000000181587DF0
		private static int GetAdvanceHijriDate(); // 0x00000001802E7860-0x00000001802E7870
		internal static void CheckTicksRange(long ticks); // 0x00000001815877A0-0x0000000181587980
		internal static void CheckEraRange(int era); // 0x00000001815876D0-0x00000001815877A0
		internal static void CheckYearRange(int year, int era); // 0x0000000181587B40-0x0000000181587D30
		internal static void CheckYearMonthRange(int year, int month, int era); // 0x0000000181587980-0x0000000181587B40
		internal virtual int GetDatePart(long ticks, int part); // 0x0000000181587F00-0x0000000181588180
		public override int GetDayOfMonth(DateTime time); // 0x0000000181588180-0x00000001815881F0
		public override DayOfWeek GetDayOfWeek(DateTime time); // 0x00000001815881F0-0x0000000181588270
		public override int GetDaysInMonth(int year, int month, int era); // 0x0000000181588270-0x00000001815884C0
		public override int GetDaysInYear(int year, int era); // 0x00000001815884C0-0x0000000181588550
		public override int GetEra(DateTime time); // 0x0000000181588550-0x00000001815885E0
		public override int GetMonth(DateTime time); // 0x00000001815885E0-0x0000000181588650
		public override int GetMonthsInYear(int year, int era); // 0x0000000181588650-0x00000001815886B0
		public override int GetYear(DateTime time); // 0x00000001815886B0-0x0000000181588720
		public override bool IsLeapYear(int year, int era); // 0x0000000181588720-0x00000001815887A0
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era); // 0x00000001815887A0-0x0000000181588A60
		public override int ToFourDigitYear(int year); // 0x0000000181588A60-0x0000000181588BF0
	}
}
