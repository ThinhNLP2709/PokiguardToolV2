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
	public class ThaiBuddhistCalendar : Calendar // TypeDefIndex: 3437
	{
		// Fields
		internal static EraInfo[] thaiBuddhistEraInfo; // 0x00
		internal GregorianCalendarHelper helper; // 0x20
	
		// Properties
		[ComVisible(false)]
		public override DateTime MinSupportedDateTime { get; } // 0x000000018158E780-0x000000018158E7D0 
		[ComVisible(false)]
		public override DateTime MaxSupportedDateTime { get; } // 0x000000018158E730-0x000000018158E780 
		internal override int ID { get; } // 0x0000000180A2FB20-0x0000000180A2FB30 
		public override int[] Eras { get; } // 0x0000000181589D60-0x0000000181589D80 
		public override int TwoDigitYearMax { get; set; } // 0x000000018158E7D0-0x000000018158E820 0x000000018158E820-0x000000018158E960
	
		// Constructors
		public ThaiBuddhistCalendar(); // 0x000000018158E680-0x000000018158E730
		static ThaiBuddhistCalendar(); // 0x000000018158E560-0x000000018158E680
	
		// Methods
		public override int GetDaysInMonth(int year, int month, int era); // 0x0000000181589250-0x0000000181589280
		public override int GetDaysInYear(int year, int era); // 0x0000000181589280-0x00000001815892A0
		public override int GetDayOfMonth(DateTime time); // 0x0000000181589210-0x0000000181589230
		public override DayOfWeek GetDayOfWeek(DateTime time); // 0x0000000181589230-0x0000000181589250
		public override int GetMonthsInYear(int year, int era); // 0x0000000181589940-0x0000000181589970
		public override int GetEra(DateTime time); // 0x0000000181589900-0x0000000181589920
		public override int GetMonth(DateTime time); // 0x0000000181589920-0x0000000181589940
		public override int GetYear(DateTime time); // 0x0000000181589970-0x0000000181589990
		public override bool IsLeapYear(int year, int era); // 0x0000000181589990-0x00000001815899B0
		public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era); // 0x00000001815899E0-0x0000000181589A10
		public override int ToFourDigitYear(int year); // 0x000000018158E4A0-0x000000018158E560
	}
}
