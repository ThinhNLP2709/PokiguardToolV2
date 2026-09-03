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

namespace System
{
	[Serializable]
	[IsReadOnly]
	public struct TimeSpan : IComparable, IComparable<System.TimeSpan>, IEquatable<System.TimeSpan>, IFormattable, ISpanFormattable // TypeDefIndex: 2348
	{
		// Fields
		public static readonly TimeSpan Zero; // 0x00
		public static readonly TimeSpan MaxValue; // 0x08
		public static readonly TimeSpan MinValue; // 0x10
		internal readonly long _ticks; // 0x00
	
		// Properties
		public long Ticks { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public int Days { get; } // 0x0000000181620B50-0x0000000181620B70 
		public int Hours { get; } // 0x0000000181620B70-0x0000000181620BB0 
		public int Milliseconds { get; } // 0x0000000181620BB0-0x0000000181620C00 
		public int Minutes { get; } // 0x0000000181620C00-0x0000000181620C50 
		public int Seconds { get; } // 0x0000000181620C50-0x0000000181620CA0 
		public double TotalDays { get; } // 0x0000000181620CA0-0x0000000181620CC0 
		public double TotalHours { get; } // 0x0000000181620CC0-0x0000000181620CE0 
		public double TotalMilliseconds { get; } // 0x0000000181620CE0-0x0000000181620D10 
		public double TotalMinutes { get; } // 0x0000000181620D10-0x0000000181620D30 
		public double TotalSeconds { get; } // 0x0000000181620D30-0x0000000181620D50 
	
		// Constructors
		public TimeSpan(long ticks); // 0x0000000180CBE820-0x0000000180CBE830
		public TimeSpan(int hours, int minutes, int seconds); // 0x0000000181620A60-0x0000000181620B50
		public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds); // 0x00000001816209A0-0x0000000181620A60
		static TimeSpan(); // 0x0000000181620920-0x00000001816209A0
	
		// Methods
		public TimeSpan Add(TimeSpan ts); // 0x000000018161FFF0-0x0000000181620070
		public static int Compare(TimeSpan t1, TimeSpan t2); // 0x0000000181620170-0x0000000181620190
		public int CompareTo(object value); // 0x0000000181620090-0x0000000181620170
		public int CompareTo(TimeSpan value); // 0x0000000181620070-0x0000000181620090
		public static TimeSpan FromDays(double value); // 0x0000000181620210-0x0000000181620270
		public override bool Equals(object value); // 0x0000000181620190-0x0000000181620210
		public bool Equals(TimeSpan obj); // 0x0000000180DF5FE0-0x0000000180DF5FF0
		public override int GetHashCode(); // 0x00000001815FDA50-0x00000001815FDA60
		public static TimeSpan FromHours(double value); // 0x0000000181620270-0x00000001816202D0
		private static TimeSpan Interval(double value, int scale); // 0x00000001816203F0-0x0000000181620500
		public static TimeSpan FromMilliseconds(double value); // 0x00000001816202D0-0x0000000181620330
		public static TimeSpan FromMinutes(double value); // 0x0000000181620330-0x0000000181620390
		public TimeSpan Negate(); // 0x0000000181620500-0x00000001816205B0
		public static TimeSpan FromSeconds(double value); // 0x0000000181620390-0x00000001816203F0
		public TimeSpan Subtract(TimeSpan ts); // 0x0000000181620680-0x0000000181620700
		public static TimeSpan FromTicks(long value); // 0x0000000180370C60-0x0000000180370C70
		internal static long TimeToTicks(int hour, int minute, int second); // 0x0000000181620700-0x00000001816207A0
		public static TimeSpan Parse(string s); // 0x0000000181620620-0x0000000181620680
		public static TimeSpan Parse(string input, IFormatProvider formatProvider); // 0x00000001816205B0-0x0000000181620620
		public override string ToString(); // 0x00000001816207A0-0x0000000181620800
		public string ToString(string format, IFormatProvider formatProvider); // 0x0000000181620800-0x0000000181620870
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider formatProvider = null); // 0x0000000181620870-0x0000000181620920
		public static TimeSpan operator -(TimeSpan t); // 0x0000000181620F10-0x0000000181620FC0
		public static TimeSpan operator -(TimeSpan t1, TimeSpan t2); // 0x0000000181620E50-0x0000000181620F10
		public static TimeSpan operator +(TimeSpan t1, TimeSpan t2); // 0x0000000181620D50-0x0000000181620E10
		public static bool operator ==(TimeSpan t1, TimeSpan t2); // 0x0000000180A29AB0-0x0000000180A29AC0
		public static bool operator !=(TimeSpan t1, TimeSpan t2); // 0x000000018126B560-0x000000018126B570
		public static bool operator <(TimeSpan t1, TimeSpan t2); // 0x0000000181620E40-0x0000000181620E50
		public static bool operator <=(TimeSpan t1, TimeSpan t2); // 0x0000000181620E30-0x0000000181620E40
		public static bool operator >(TimeSpan t1, TimeSpan t2); // 0x0000000181620E20-0x0000000181620E30
		public static bool operator >=(TimeSpan t1, TimeSpan t2); // 0x0000000181620E10-0x0000000181620E20
	}
}
