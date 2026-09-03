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
	public abstract class Calendar : ICloneable // TypeDefIndex: 3425
	{
		// Fields
		internal int m_currentEraValue; // 0x10
		[OptionalField(VersionAdded = 2)]
		private bool m_isReadOnly; // 0x14
		internal int twoDigitYearMax; // 0x18
	
		// Properties
		[ComVisible(false)]
		public virtual DateTime MinSupportedDateTime { get; } // 0x0000000181542320-0x0000000181542370 
		[ComVisible(false)]
		public virtual DateTime MaxSupportedDateTime { get; } // 0x00000001815422D0-0x0000000181542320 
		internal virtual int ID { get; } // 0x00000001815418D0-0x00000001815418E0 
		internal virtual int BaseCalendarID { get; } // 0x0000000181542050-0x0000000181542070 
		internal virtual int CurrentEraValue { get; } // 0x0000000181542070-0x00000001815422D0 
		public abstract int[] Eras { get; }
		public virtual int TwoDigitYearMax { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000181542370-0x00000001815423F0
	
		// Constructors
		protected Calendar(); // 0x0000000181542030-0x0000000181542050
	
		// Methods
		[ComVisible(false)]
		public virtual object Clone(); // 0x00000001815418E0-0x0000000181541960
		internal void VerifyWritable(); // 0x0000000181541FB0-0x0000000181542030
		internal void SetReadOnlyState(bool readOnly); // 0x0000000181541B70-0x0000000181541B80
		public abstract int GetDayOfMonth(DateTime time);
		public abstract DayOfWeek GetDayOfWeek(DateTime time);
		public abstract int GetDaysInMonth(int year, int month, int era);
		public abstract int GetDaysInYear(int year, int era);
		public abstract int GetEra(DateTime time);
		public abstract int GetMonth(DateTime time);
		public abstract int GetMonthsInYear(int year, int era);
		public abstract int GetYear(DateTime time);
		public virtual bool IsLeapYear(int year); // 0x00000001815419B0-0x00000001815419D0
		public abstract bool IsLeapYear(int year, int era);
		public virtual DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond); // 0x0000000181541D40-0x0000000181541DA0
		public abstract DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era);
		internal virtual bool TryToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era, out DateTime result); // 0x0000000181541EB0-0x0000000181541FB0
		internal virtual bool IsValidYear(int year, int era); // 0x0000000181541AE0-0x0000000181541B70
		internal virtual bool IsValidMonth(int year, int month, int era); // 0x0000000181541A60-0x0000000181541AE0
		internal virtual bool IsValidDay(int year, int month, int day, int era); // 0x00000001815419D0-0x0000000181541A60
		public virtual int ToFourDigitYear(int year); // 0x0000000181541DA0-0x0000000181541EB0
		internal static long TimeToTicks(int hour, int minute, int second, int millisecond); // 0x0000000181541B80-0x0000000181541D40
		internal static int GetSystemTwoDigitYearSetting(int CalID, int defaultYearValue); // 0x0000000181541960-0x00000001815419B0
	}
}
