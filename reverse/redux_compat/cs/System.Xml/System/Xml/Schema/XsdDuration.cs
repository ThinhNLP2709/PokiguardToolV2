/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal struct XsdDuration // TypeDefIndex: 7293
	{
		// Fields
		private int years; // 0x00
		private int months; // 0x04
		private int days; // 0x08
		private int hours; // 0x0C
		private int minutes; // 0x10
		private int seconds; // 0x14
		private uint nanoseconds; // 0x18
	
		// Properties
		public bool IsNegative { get; } // 0x0000000181A2D590-0x0000000181A2D5A0 
		public int Years { get; } // 0x0000000180732D10-0x0000000180732D20 
		public int Months { get; } // 0x00000001802E7C60-0x00000001802E7DA0 
		public int Days { get; } // 0x0000000180732D20-0x0000000180732D30 
		public int Hours { get; } // 0x0000000180732D30-0x0000000180732D40 
		public int Minutes { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public int Seconds { get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public int Nanoseconds { get; } // 0x0000000181A2D5A0-0x0000000181A2D5B0 
	
		// Nested types
		private enum Parts // TypeDefIndex: 7294
		{
			HasNone = 0,
			HasYears = 1,
			HasMonths = 2,
			HasDays = 4,
			HasHours = 8,
			HasMinutes = 16,
			HasSeconds = 32
		}
	
		public enum DurationType // TypeDefIndex: 7295
		{
			Duration = 0,
			YearMonthDuration = 1,
			DayTimeDuration = 2
		}
	
		// Constructors
		public XsdDuration(bool isNegative, int years, int months, int days, int hours, int minutes, int seconds, int nanoseconds); // 0x0000000181A2D250-0x0000000181A2D4E0
		public XsdDuration(TimeSpan timeSpan); // 0x0000000181A2CF20-0x0000000181A2CF30
		public XsdDuration(TimeSpan timeSpan, DurationType durationType); // 0x0000000181A2CF30-0x0000000181A2D1A0
		public XsdDuration(string s); // 0x0000000181A2D4E0-0x0000000181A2D590
		public XsdDuration(string s, DurationType durationType); // 0x0000000181A2D1A0-0x0000000181A2D250
	
		// Methods
		public TimeSpan ToTimeSpan(); // 0x0000000181A2BB50-0x0000000181A2BBA0
		public TimeSpan ToTimeSpan(DurationType durationType); // 0x0000000181A2BBA0-0x0000000181A2BBF0
		internal Exception TryToTimeSpan(out TimeSpan result); // 0x0000000181A2C8F0-0x0000000181A2C900
		internal Exception TryToTimeSpan(DurationType durationType, out TimeSpan result); // 0x0000000181A2C900-0x0000000181A2CF20
		public override string ToString(); // 0x0000000181A2B730-0x0000000181A2B740
		internal string ToString(DurationType durationType); // 0x0000000181A2B740-0x0000000181A2BB50
		internal static Exception TryParse(string s, out XsdDuration result); // 0x0000000181A2BD40-0x0000000181A2BD50
		internal static Exception TryParse(string s, DurationType durationType, out XsdDuration result); // 0x0000000181A2BD50-0x0000000181A2C8F0
		private static string TryParseDigits(string s, ref int offset, bool eatDigits, out int result, out int numDigits); // 0x0000000181A2BBF0-0x0000000181A2BD40
	}
}
