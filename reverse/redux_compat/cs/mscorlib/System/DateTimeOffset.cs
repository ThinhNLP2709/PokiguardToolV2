/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[IsReadOnly]
	public struct DateTimeOffset : IComparable, IFormattable, IComparable<System.DateTimeOffset>, IEquatable<System.DateTimeOffset>, ISerializable, IDeserializationCallback, ISpanFormattable // TypeDefIndex: 2232
	{
		// Fields
		public static readonly DateTimeOffset MinValue; // 0x00
		public static readonly DateTimeOffset MaxValue; // 0x10
		public static readonly DateTimeOffset UnixEpoch; // 0x20
		private readonly DateTime _dateTime; // 0x00
		private readonly short _offsetMinutes; // 0x08
	
		// Properties
		public static DateTimeOffset Now { get; } // 0x00000001815E4970-0x00000001815E49D0 
		public static DateTimeOffset UtcNow { get; } // 0x00000001815E4D30-0x00000001815E4DE0 
		public DateTime DateTime { get; } // 0x00000001815E4410-0x00000001815E4460 
		public DateTime UtcDateTime { get; } // 0x00000001815E4C80-0x00000001815E4D30 
		public DateTime LocalDateTime { get; } // 0x00000001815E4610-0x00000001815E46D0 
		private DateTime ClockDateTime { get; } // 0x00000001815E4250-0x00000001815E4410 
		public int Day { get; } // 0x00000001815E4460-0x00000001815E4520 
		public int Hour { get; } // 0x00000001815E4520-0x00000001815E4610 
		public int Millisecond { get; } // 0x00000001815E46D0-0x00000001815E47C0 
		public int Minute { get; } // 0x00000001815E47C0-0x00000001815E48B0 
		public int Month { get; } // 0x00000001815E48B0-0x00000001815E4970 
		public TimeSpan Offset { get; } // 0x00000001815E49D0-0x00000001815E4A00 
		public int Second { get; } // 0x00000001815E4A00-0x00000001815E4AF0 
		public long Ticks { get; } // 0x00000001815E4AF0-0x00000001815E4BB0 
		public TimeSpan TimeOfDay { get; } // 0x00000001815E4BB0-0x00000001815E4C80 
		public int Year { get; } // 0x00000001815E4DE0-0x00000001815E4EA0 
	
		// Constructors
		public DateTimeOffset(long ticks, TimeSpan offset); // 0x00000001815E3C00-0x00000001815E3D10
		public DateTimeOffset(DateTime dateTime); // 0x00000001815E3EF0-0x00000001815E4040
		public DateTimeOffset(DateTime dateTime, TimeSpan offset); // 0x00000001815E3940-0x00000001815E3C00
		public DateTimeOffset(int year, int month, int day, int hour, int minute, int second, TimeSpan offset); // 0x00000001815E3D10-0x00000001815E3E00
		public DateTimeOffset(int year, int month, int day, int hour, int minute, int second, int millisecond, TimeSpan offset); // 0x00000001815E4040-0x00000001815E4250
		public DateTimeOffset(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, TimeSpan offset); // 0x00000001815E3E00-0x00000001815E3EF0
		private DateTimeOffset(SerializationInfo info, StreamingContext context); // 0x00000001815E37C0-0x00000001815E3940
		static DateTimeOffset(); // 0x00000001815E36A0-0x00000001815E37C0
	
		// Methods
		public DateTimeOffset AddMilliseconds(double milliseconds); // 0x00000001815E1570-0x00000001815E1690
		public static int Compare(DateTimeOffset first, DateTimeOffset second); // 0x00000001815E17D0-0x00000001815E1870
		int IComparable.CompareTo(object obj); // 0x00000001815E2360-0x00000001815E24B0
		public int CompareTo(DateTimeOffset other); // 0x00000001815E1690-0x00000001815E17D0
		public override bool Equals(object obj); // 0x00000001815E1870-0x00000001815E19A0
		public bool Equals(DateTimeOffset other); // 0x00000001815E19A0-0x00000001815E1A80
		public static DateTimeOffset FromUnixTimeMilliseconds(long milliseconds); // 0x00000001815E1A80-0x00000001815E1BE0
		void IDeserializationCallback.OnDeserialization(object sender); // 0x00000001815E24B0-0x00000001815E25D0
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001815E25D0-0x00000001815E2690
		public override int GetHashCode(); // 0x00000001815E1BE0-0x00000001815E1CA0
		public static DateTimeOffset Parse(string input, IFormatProvider formatProvider); // 0x00000001815E22D0-0x00000001815E2360
		public static DateTimeOffset Parse(string input, IFormatProvider formatProvider, DateTimeStyles styles); // 0x00000001815E2040-0x00000001815E22D0
		public static DateTimeOffset ParseExact(string input, string format, IFormatProvider formatProvider, DateTimeStyles styles); // 0x00000001815E1CA0-0x00000001815E2040
		public long ToUnixTimeSeconds(); // 0x00000001815E2A50-0x00000001815E2B30
		public long ToUnixTimeMilliseconds(); // 0x00000001815E2970-0x00000001815E2A50
		public override string ToString(); // 0x00000001815E2770-0x00000001815E2830
		public string ToString(IFormatProvider formatProvider); // 0x00000001815E2830-0x00000001815E2900
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001815E2690-0x00000001815E2770
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider formatProvider = null); // 0x00000001815E2B30-0x00000001815E2C40
		public DateTimeOffset ToUniversalTime(); // 0x00000001815E2900-0x00000001815E2970
		public static bool TryParse(string input, IFormatProvider formatProvider, DateTimeStyles styles, out DateTimeOffset result); // 0x00000001815E2FF0-0x00000001815E32E0
		public static bool TryParseExact(string input, string format, IFormatProvider formatProvider, DateTimeStyles styles, out DateTimeOffset result); // 0x00000001815E2C40-0x00000001815E2FF0
		private static short ValidateOffset(TimeSpan offset); // 0x00000001815E3420-0x00000001815E3580
		private static DateTime ValidateDate(DateTime dateTime, TimeSpan offset); // 0x00000001815E32E0-0x00000001815E3420
		private static DateTimeStyles ValidateStyles(DateTimeStyles style, string parameterName); // 0x00000001815E3580-0x00000001815E36A0
		public static implicit operator DateTimeOffset(DateTime dateTime); // 0x00000001815E4F80-0x00000001815E4FA0
		public static TimeSpan operator -(DateTimeOffset left, DateTimeOffset right); // 0x00000001815E5080-0x00000001815E5160
		public static bool operator ==(DateTimeOffset left, DateTimeOffset right); // 0x00000001815E4EA0-0x00000001815E4F80
		public static bool operator !=(DateTimeOffset left, DateTimeOffset right); // 0x00000001815E4FA0-0x00000001815E5080
	}
}
