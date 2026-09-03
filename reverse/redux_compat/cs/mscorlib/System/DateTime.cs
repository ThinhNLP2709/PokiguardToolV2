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
	public struct DateTime : IComparable, IFormattable, IConvertible, IComparable<System.DateTime>, IEquatable<System.DateTime>, ISerializable, ISpanFormattable // TypeDefIndex: 2230
	{
		// Fields
		private const long TicksPerMillisecond = 10000; // Metadata: 0x0064E2DF
		private const long TicksPerSecond = 10000000; // Metadata: 0x0064E2E7
		private const long TicksPerMinute = 600000000; // Metadata: 0x0064E2EF
		private const long TicksPerHour = 36000000000; // Metadata: 0x0064E2F7
		private const long TicksPerDay = 864000000000; // Metadata: 0x0064E2FF
		private const int MillisPerSecond = 1000; // Metadata: 0x0064E307
		private const int MillisPerMinute = 60000; // Metadata: 0x0064E309
		private const int MillisPerHour = 3600000; // Metadata: 0x0064E30D
		private const int MillisPerDay = 86400000; // Metadata: 0x0064E311
		private const int DaysPerYear = 365; // Metadata: 0x0064E315
		private const int DaysPer4Years = 1461; // Metadata: 0x0064E317
		private const int DaysPer100Years = 36524; // Metadata: 0x0064E319
		private const int DaysPer400Years = 146097; // Metadata: 0x0064E31D
		private const int DaysTo1601 = 584388; // Metadata: 0x0064E321
		private const int DaysTo1899 = 693593; // Metadata: 0x0064E325
		internal const int DaysTo1970 = 719162; // Metadata: 0x0064E329
		private const int DaysTo10000 = 3652059; // Metadata: 0x0064E32D
		internal const long MinTicks = 0; // Metadata: 0x0064E331
		internal const long MaxTicks = 3155378975999999999; // Metadata: 0x0064E339
		private const long MaxMillis = 315537897600000; // Metadata: 0x0064E341
		internal const long UnixEpochTicks = 621355968000000000; // Metadata: 0x0064E349
		private const long FileTimeOffset = 504911232000000000; // Metadata: 0x0064E351
		private const long DoubleDateOffset = 599264352000000000; // Metadata: 0x0064E359
		private const long OADateMinAsTicks = 31241376000000000; // Metadata: 0x0064E361
		private const double OADateMinAsDouble = -657435; // Metadata: 0x0064E369
		private const double OADateMaxAsDouble = 2958466; // Metadata: 0x0064E371
		private const int DatePartYear = 0; // Metadata: 0x0064E379
		private const int DatePartDayOfYear = 1; // Metadata: 0x0064E37A
		private const int DatePartMonth = 2; // Metadata: 0x0064E37B
		private const int DatePartDay = 3; // Metadata: 0x0064E37C
		private static readonly int[] s_daysToMonth365; // 0x00
		private static readonly int[] s_daysToMonth366; // 0x08
		public static readonly DateTime MinValue; // 0x10
		public static readonly DateTime MaxValue; // 0x18
		public static readonly DateTime UnixEpoch; // 0x20
		private const ulong TicksMask = 4611686018427387903; // Metadata: 0x0064E37D
		private const ulong FlagsMask = 13835058055282163712; // Metadata: 0x0064E385
		private const ulong LocalMask = 9223372036854775808; // Metadata: 0x0064E38D
		private const long TicksCeiling = 4611686018427387904; // Metadata: 0x0064E395
		private const ulong KindUnspecified = 0; // Metadata: 0x0064E39D
		private const ulong KindUtc = 4611686018427387904; // Metadata: 0x0064E3A5
		private const ulong KindLocal = 9223372036854775808; // Metadata: 0x0064E3AD
		private const ulong KindLocalAmbiguousDst = 13835058055282163712; // Metadata: 0x0064E3B5
		private const int KindShift = 62; // Metadata: 0x0064E3BD
		private const string TicksField = "ticks"; // Metadata: 0x0064E3BE
		private const string DateDataField = "dateData"; // Metadata: 0x0064E3C4
		private readonly ulong _dateData; // 0x00
	
		// Properties
		internal long InternalTicks { get; } // 0x00000001815F52A0-0x00000001815F52C0 
		private ulong InternalKind { get; } // 0x00000001815F5280-0x00000001815F52A0 
		public DateTime Date { get; } // 0x00000001815F5090-0x00000001815F5110 
		public int Day { get; } // 0x00000001815F51A0-0x00000001815F51F0 
		public DayOfWeek DayOfWeek { get; } // 0x00000001815F5110-0x00000001815F51A0 
		public int Hour { get; } // 0x00000001815F51F0-0x00000001815F5280 
		public DateTimeKind Kind { get; } // 0x00000001815F52C0-0x00000001815F5330 
		public int Millisecond { get; } // 0x00000001815F5330-0x00000001815F53C0 
		public int Minute { get; } // 0x00000001815F53C0-0x00000001815F5450 
		public int Month { get; } // 0x00000001815F5450-0x00000001815F54A0 
		public static DateTime Now { get; } // 0x00000001815F54A0-0x00000001815F5660 
		public int Second { get; } // 0x00000001815F5660-0x00000001815F56F0 
		public long Ticks { get; } // 0x00000001815F56F0-0x00000001815F5740 
		public TimeSpan TimeOfDay { get; } // 0x00000001815F5740-0x00000001815F57B0 
		public int Year { get; } // 0x00000001815F5810-0x00000001815F5860 
		public static DateTime UtcNow { get; } // 0x00000001815F57B0-0x00000001815F5810 
	
		// Constructors
		public DateTime(long ticks); // 0x00000001815F4890-0x00000001815F4920
		private DateTime(ulong dateData); // 0x0000000180CBE820-0x0000000180CBE830
		public DateTime(long ticks, DateTimeKind kind); // 0x00000001815F4FA0-0x00000001815F5090
		internal DateTime(long ticks, DateTimeKind kind, bool isAmbiguousDst); // 0x00000001815F4BB0-0x00000001815F4C50
		public DateTime(int year, int month, int day); // 0x00000001815F4C50-0x00000001815F4CD0
		public DateTime(int year, int month, int day, int hour, int minute, int second); // 0x00000001815F44D0-0x00000001815F4570
		public DateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind); // 0x00000001815F4E90-0x00000001815F4FA0
		public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond); // 0x00000001815F4CD0-0x00000001815F4E90
		public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar); // 0x00000001815F4920-0x00000001815F4BB0
		private DateTime(SerializationInfo info, StreamingContext context); // 0x00000001815F4570-0x00000001815F4890
		static DateTime(); // 0x00000001815F4360-0x00000001815F44D0
	
		// Methods
		public DateTime Add(TimeSpan value); // 0x00000001815F1290-0x00000001815F12F0
		private DateTime Add(double value, int scale); // 0x00000001815F1170-0x00000001815F1290
		public DateTime AddDays(double value); // 0x00000001815F0B20-0x00000001815F0B80
		public DateTime AddMilliseconds(double value); // 0x00000001815F0B80-0x00000001815F0BE0
		public DateTime AddMinutes(double value); // 0x00000001815F0BE0-0x00000001815F0C40
		public DateTime AddMonths(int months); // 0x00000001815F0C40-0x00000001815F0F50
		public DateTime AddSeconds(double value); // 0x00000001815F0F50-0x00000001815F0FB0
		public DateTime AddTicks(long value); // 0x00000001815F0FB0-0x00000001815F10A0
		public DateTime AddYears(int value); // 0x00000001815F10A0-0x00000001815F1170
		public static int Compare(DateTime t1, DateTime t2); // 0x00000001815F1440-0x00000001815F14C0
		public int CompareTo(object value); // 0x00000001815F12F0-0x00000001815F13E0
		public int CompareTo(DateTime value); // 0x00000001815F13E0-0x00000001815F1440
		private static long DateToTicks(int year, int month, int day); // 0x00000001815F14C0-0x00000001815F1650
		private static long TimeToTicks(int hour, int minute, int second); // 0x00000001815F3420-0x00000001815F34E0
		public static int DaysInMonth(int year, int month); // 0x00000001815F1650-0x00000001815F1750
		public override bool Equals(object value); // 0x00000001815F1750-0x00000001815F1800
		public bool Equals(DateTime value); // 0x00000001815F1800-0x00000001815F1860
		public static DateTime FromBinary(long dateData); // 0x00000001815F1900-0x00000001815F1BE0
		internal static DateTime FromBinaryRaw(long dateData); // 0x00000001815F1860-0x00000001815F1900
		public static DateTime FromFileTime(long fileTime); // 0x00000001815F1CA0-0x00000001815F1DD0
		public static DateTime FromFileTimeUtc(long fileTime); // 0x00000001815F1BE0-0x00000001815F1CA0
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001815F3330-0x00000001815F3420
		public static DateTime SpecifyKind(DateTime value, DateTimeKind kind); // 0x00000001815F2A50-0x00000001815F2AD0
		private int GetDatePart(int part); // 0x00000001815F1DD0-0x00000001815F1F90
		internal void GetDatePart(out int year, out int month, out int day); // 0x00000001815F1F90-0x00000001815F2150
		public override int GetHashCode(); // 0x00000001815F2150-0x00000001815F21B0
		internal bool IsAmbiguousDaylightSavingTime(); // 0x00000001815F21C0-0x00000001815F2220
		public static bool IsLeapYear(int year); // 0x00000001815F2220-0x00000001815F2300
		public static DateTime Parse(string s); // 0x00000001815F27A0-0x00000001815F2870
		public static DateTime Parse(string s, IFormatProvider provider); // 0x00000001815F2970-0x00000001815F2A50
		public static DateTime Parse(string s, IFormatProvider provider, DateTimeStyles styles); // 0x00000001815F2870-0x00000001815F2970
		public static DateTime ParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style); // 0x00000001815F2300-0x00000001815F25C0
		public static DateTime ParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style); // 0x00000001815F25C0-0x00000001815F27A0
		public TimeSpan Subtract(DateTime value); // 0x00000001815F2AD0-0x00000001815F2B40
		public DateTime ToLocalTime(); // 0x00000001815F3770-0x00000001815F37C0
		internal DateTime ToLocalTime(bool throwOnOverflow); // 0x00000001815F34E0-0x00000001815F3770
		public override string ToString(); // 0x00000001815F3830-0x00000001815F38E0
		public string ToString(string format); // 0x00000001815F3940-0x00000001815F39A0
		public string ToString(IFormatProvider provider); // 0x00000001815F38E0-0x00000001815F3940
		public string ToString(string format, IFormatProvider provider); // 0x00000001815F37C0-0x00000001815F3830
		public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider provider = null); // 0x00000001815F3BA0-0x00000001815F3CA0
		public DateTime ToUniversalTime(); // 0x00000001815F39A0-0x00000001815F3A00
		public static bool TryParse(string s, out DateTime result); // 0x00000001815F4170-0x00000001815F4250
		public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out DateTime result); // 0x00000001815F4250-0x00000001815F4360
		public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style, out DateTime result); // 0x00000001815F3EB0-0x00000001815F4170
		public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style, out DateTime result); // 0x00000001815F3CA0-0x00000001815F3EB0
		public static DateTime operator +(DateTime d, TimeSpan t); // 0x00000001815F5860-0x00000001815F5950
		public static DateTime operator -(DateTime d, TimeSpan t); // 0x00000001815F5BD0-0x00000001815F5CC0
		public static TimeSpan operator -(DateTime d1, DateTime d2); // 0x00000001815F5CC0-0x00000001815F5D30
		public static bool operator ==(DateTime d1, DateTime d2); // 0x00000001815F5950-0x00000001815F59B0
		public static bool operator !=(DateTime d1, DateTime d2); // 0x00000001815F5A90-0x00000001815F5AF0
		public static bool operator <(DateTime t1, DateTime t2); // 0x00000001815F5B60-0x00000001815F5BD0
		public static bool operator <=(DateTime t1, DateTime t2); // 0x00000001815F5AF0-0x00000001815F5B60
		public static bool operator >(DateTime t1, DateTime t2); // 0x00000001815F5A20-0x00000001815F5A90
		public static bool operator >=(DateTime t1, DateTime t2); // 0x00000001815F59B0-0x00000001815F5A20
		public TypeCode GetTypeCode(); // 0x00000001808F5E70-0x00000001808F5E80
		bool IConvertible.ToBoolean(IFormatProvider provider); // 0x00000001815F2B40-0x00000001815F2BD0
		char IConvertible.ToChar(IFormatProvider provider); // 0x00000001815F2C60-0x00000001815F2CF0
		sbyte IConvertible.ToSByte(IFormatProvider provider); // 0x00000001815F2FC0-0x00000001815F3050
		byte IConvertible.ToByte(IFormatProvider provider); // 0x00000001815F2BD0-0x00000001815F2C60
		short IConvertible.ToInt16(IFormatProvider provider); // 0x00000001815F2E10-0x00000001815F2EA0
		ushort IConvertible.ToUInt16(IFormatProvider provider); // 0x00000001815F3180-0x00000001815F3210
		int IConvertible.ToInt32(IFormatProvider provider); // 0x00000001815F2EA0-0x00000001815F2F30
		uint IConvertible.ToUInt32(IFormatProvider provider); // 0x00000001815F3210-0x00000001815F32A0
		long IConvertible.ToInt64(IFormatProvider provider); // 0x00000001815F2F30-0x00000001815F2FC0
		ulong IConvertible.ToUInt64(IFormatProvider provider); // 0x00000001815F32A0-0x00000001815F3330
		float IConvertible.ToSingle(IFormatProvider provider); // 0x00000001815F3050-0x00000001815F30E0
		double IConvertible.ToDouble(IFormatProvider provider); // 0x00000001815F2D80-0x00000001815F2E10
		decimal IConvertible.ToDecimal(IFormatProvider provider); // 0x00000001815F2CF0-0x00000001815F2D80
		DateTime IConvertible.ToDateTime(IFormatProvider provider); // 0x00000001808BADD0-0x00000001808BADE0
		object IConvertible.ToType(Type type, IFormatProvider provider); // 0x00000001815F30E0-0x00000001815F3180
		internal static bool TryCreate(int year, int month, int day, int hour, int minute, int second, int millisecond, out DateTime result); // 0x00000001815F3A00-0x00000001815F3BA0
		internal static long GetSystemTimeAsFileTime(); // 0x00000001815F21B0-0x00000001815F21C0
		internal long ToBinaryRaw(); // 0x00000001808BADD0-0x00000001808BADE0
	}
}
