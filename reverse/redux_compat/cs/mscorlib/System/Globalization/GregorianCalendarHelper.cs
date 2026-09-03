/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Globalization
{
	[Serializable]
	internal class GregorianCalendarHelper // TypeDefIndex: 3429
	{
		// Fields
		internal static readonly int[] DaysToMonth365; // 0x00
		internal static readonly int[] DaysToMonth366; // 0x08
		[OptionalField(VersionAdded = 1)]
		internal int m_maxYear; // 0x10
		[OptionalField(VersionAdded = 1)]
		internal int m_minYear; // 0x14
		internal Calendar m_Cal; // 0x18
		[OptionalField(VersionAdded = 1)]
		internal EraInfo[] m_EraInfo; // 0x20
		[OptionalField(VersionAdded = 1)]
		internal int[] m_eras; // 0x28
		[OptionalField(VersionAdded = 1)]
		internal DateTime m_minDate; // 0x30
	
		// Properties
		internal int MaxYear { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public int[] Eras { get; } // 0x0000000181585E00-0x0000000181585F40 
	
		// Constructors
		internal GregorianCalendarHelper(Calendar cal, EraInfo[] eraInfo); // 0x0000000181585D40-0x0000000181585E00
		static GregorianCalendarHelper(); // 0x0000000181585C30-0x0000000181585D40
	
		// Methods
		private int GetYearOffset(int year, int era, bool throwOnError); // 0x0000000181585050-0x00000001815853C0
		internal int GetGregorianYear(int year, int era); // 0x0000000181584F90-0x0000000181584FC0
		internal bool IsValidYear(int year, int era); // 0x0000000181585570-0x0000000181585590
		internal virtual int GetDatePart(long ticks, int part); // 0x0000000181584930-0x0000000181584B20
		internal static long GetAbsoluteDate(int year, int month, int day); // 0x0000000181584740-0x0000000181584930
		internal static long DateToTicks(int year, int month, int day); // 0x00000001815846C0-0x0000000181584740
		internal static long TimeToTicks(int hour, int minute, int second, int millisecond); // 0x0000000181585590-0x0000000181585750
		internal void CheckTicksRange(long ticks); // 0x00000001815844C0-0x00000001815846C0
		public int GetDayOfMonth(DateTime time); // 0x0000000181584B20-0x0000000181584B90
		public DayOfWeek GetDayOfWeek(DateTime time); // 0x0000000181584B90-0x0000000181584C40
		public int GetDaysInMonth(int year, int month, int era); // 0x0000000181584C40-0x0000000181584DF0
		public int GetDaysInYear(int year, int era); // 0x0000000181584DF0-0x0000000181584E80
		public int GetEra(DateTime time); // 0x0000000181584E80-0x0000000181584F90
		public int GetMonth(DateTime time); // 0x0000000181584FC0-0x0000000181585030
		public int GetMonthsInYear(int year, int era); // 0x0000000181585030-0x0000000181585050
		public int GetYear(DateTime time); // 0x00000001815853C0-0x00000001815854F0
		public bool IsLeapYear(int year, int era); // 0x00000001815854F0-0x0000000181585570
		public DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era); // 0x0000000181585750-0x0000000181585A40
		public int ToFourDigitYear(int year, int twoDigitYearMax); // 0x0000000181585A40-0x0000000181585C30
	}
}
