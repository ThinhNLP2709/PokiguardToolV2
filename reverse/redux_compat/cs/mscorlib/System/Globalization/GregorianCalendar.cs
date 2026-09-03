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
	[ComVisible(true)]
	public class GregorianCalendar : Calendar // TypeDefIndex: 3427
	{
		// Fields
		internal GregorianCalendarTypes m_type; // 0x20
		internal static readonly int[] DaysToMonth365; // 0x00
		internal static readonly int[] DaysToMonth366; // 0x08
		private static Calendar s_defaultInstance; // 0x10
	
		// Properties
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime { get; } // 0x0000000181587520-0x0000000181587570 
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime { get; } // 0x00000001815874D0-0x0000000181587520 
		internal override int ID { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public override int[] Eras { get; } // 0x0000000181587470-0x00000001815874D0 
		public override int TwoDigitYearMax { get; set; } // 0x0000000181587570-0x00000001815875C0 0x00000001815875C0-0x00000001815876D0
	
		// Constructors
		public GregorianCalendar(); // 0x0000000181587310-0x0000000181587330
		public GregorianCalendar(GregorianCalendarTypes type); // 0x0000000181587330-0x0000000181587470
		static GregorianCalendar(); // 0x0000000181587200-0x0000000181587310
	
		// Methods
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx); // 0x0000000181586DC0-0x0000000181586EB0
		internal static Calendar GetDefaultInstance(); // 0x00000001815868D0-0x00000001815869A0
		internal virtual int GetDatePart(long ticks, int part); // 0x0000000181586130-0x0000000181586300
		internal static long GetAbsoluteDate(int year, int month, int day); // 0x0000000181585F40-0x0000000181586130
		public override int GetDayOfMonth(DateTime time); // 0x0000000181586300-0x0000000181586370
		public override DayOfWeek GetDayOfWeek(DateTime time); // 0x0000000181586370-0x00000001815863F0
		public override int GetDaysInMonth(int year, int month, int era); // 0x00000001815863F0-0x0000000181586700
		public override int GetDaysInYear(int year, int era); // 0x0000000181586700-0x00000001815868D0
		public override int GetEra(DateTime time); // 0x0000000180472790-0x00000001804727A0
		public override int GetMonth(DateTime time); // 0x00000001815869A0-0x0000000181586A10
		public override int GetMonthsInYear(int year, int era); // 0x0000000181586A10-0x0000000181586B90
		public override int GetYear(DateTime time); // 0x0000000181586B90-0x0000000181586C00
		public override bool IsLeapYear(int year, int era); // 0x0000000181586C00-0x0000000181586DC0
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era); // 0x0000000181586EB0-0x0000000181586F90
		internal override bool TryToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era, out DateTime result); // 0x0000000181587100-0x0000000181587200
		public override int ToFourDigitYear(int year); // 0x0000000181586F90-0x0000000181587100
	}
}
