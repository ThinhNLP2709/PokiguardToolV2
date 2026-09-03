/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal abstract class BinXmlDateTime // TypeDefIndex: 6687
	{
		// Fields
		internal static int[] KatmaiTimeScaleMultiplicator; // 0x00
		private static readonly double SQLTicksPerMillisecond; // 0x08
		public static readonly int SQLTicksPerSecond; // 0x10
		public static readonly int SQLTicksPerMinute; // 0x14
		public static readonly int SQLTicksPerHour; // 0x18
		private static readonly int SQLTicksPerDay; // 0x1C
	
		// Constructors
		static BinXmlDateTime(); // 0x0000000181941360-0x0000000181941460
	
		// Methods
		private static void Write2Dig(StringBuilder sb, int val); // 0x00000001815DCD30-0x00000001815DCDB0
		private static void Write4DigNeg(StringBuilder sb, int val); // 0x000000018193F4B0-0x000000018193F600
		private static void Write3Dec(StringBuilder sb, int val); // 0x000000018193F3E0-0x000000018193F4B0
		private static void WriteDate(StringBuilder sb, int yr, int mnth, int day); // 0x000000018193F600-0x000000018193F740
		private static void WriteTime(StringBuilder sb, int hr, int min, int sec, int ms); // 0x000000018193FC10-0x000000018193FE40
		private static void WriteTimeFullPrecision(StringBuilder sb, int hr, int min, int sec, int fraction); // 0x000000018193F740-0x000000018193F9D0
		private static void WriteTimeZone(StringBuilder sb, TimeSpan zone); // 0x000000018193FB30-0x000000018193FC10
		private static void WriteTimeZone(StringBuilder sb, bool negTimeZone, int hr, int min); // 0x000000018193F9D0-0x000000018193FB30
		private static void BreakDownXsdDateTime(long val, out int yr, out int mnth, out int day, out int hr, out int min, out int sec, out int ms); // 0x000000018193E5E0-0x000000018193E800
		private static void BreakDownXsdDate(long val, out int yr, out int mnth, out int day, out bool negTimeZone, out int hr, out int min); // 0x000000018193E800-0x000000018193E9B0
		private static void BreakDownXsdTime(long val, out int hr, out int min, out int sec, out int ms); // 0x000000018193E9B0-0x000000018193EB00
		public static string XsdDateTimeToString(long val); // 0x000000018193FE40-0x0000000181940150
		public static string XsdDateToString(long val); // 0x0000000181940150-0x00000001819403C0
		public static string XsdTimeToString(long val); // 0x0000000181941160-0x0000000181941360
		public static string SqlDateTimeToString(int dateticks, uint timeticks); // 0x000000018193F160-0x000000018193F250
		public static DateTime SqlDateTimeToDateTime(int dateticks, uint timeticks); // 0x000000018193F080-0x000000018193F160
		public static string SqlSmallDateTimeToString(short dateticks, ushort timeticks); // 0x000000018193F2C0-0x000000018193F3E0
		public static DateTime SqlSmallDateTimeToDateTime(short dateticks, ushort timeticks); // 0x000000018193F250-0x000000018193F2C0
		public static DateTime XsdKatmaiDateToDateTime(byte[] data, int offset); // 0x0000000181940AF0-0x0000000181940BB0
		public static DateTime XsdKatmaiDateTimeToDateTime(byte[] data, int offset); // 0x0000000181940890-0x0000000181940960
		public static DateTime XsdKatmaiTimeToDateTime(byte[] data, int offset); // 0x0000000181940F90-0x0000000181940FF0
		public static DateTimeOffset XsdKatmaiDateOffsetToDateTimeOffset(byte[] data, int offset); // 0x00000001819403C0-0x0000000181940440
		public static DateTimeOffset XsdKatmaiDateTimeOffsetToDateTimeOffset(byte[] data, int offset); // 0x00000001819405B0-0x00000001819406D0
		public static DateTimeOffset XsdKatmaiTimeOffsetToDateTimeOffset(byte[] data, int offset); // 0x0000000181940D70-0x0000000181940DF0
		public static string XsdKatmaiDateToString(byte[] data, int offset); // 0x0000000181940BB0-0x0000000181940D70
		public static string XsdKatmaiDateTimeToString(byte[] data, int offset); // 0x0000000181940960-0x0000000181940AF0
		public static string XsdKatmaiTimeToString(byte[] data, int offset); // 0x0000000181940FF0-0x0000000181941160
		public static string XsdKatmaiDateOffsetToString(byte[] data, int offset); // 0x0000000181940440-0x00000001819405B0
		public static string XsdKatmaiDateTimeOffsetToString(byte[] data, int offset); // 0x00000001819406D0-0x0000000181940890
		public static string XsdKatmaiTimeOffsetToString(byte[] data, int offset); // 0x0000000181940DF0-0x0000000181940F90
		private static long GetKatmaiDateTicks(byte[] data, ref int pos); // 0x000000018193ED70-0x000000018193EDE0
		private static long GetKatmaiTimeTicks(byte[] data, ref int pos); // 0x000000018193EDE0-0x000000018193F030
		private static long GetKatmaiTimeZoneTicks(byte[] data, int pos); // 0x000000018193F030-0x000000018193F080
		private static int GetFractions(DateTime dt); // 0x000000018193EC40-0x000000018193ED70
		private static int GetFractions(DateTimeOffset dt); // 0x000000018193EB00-0x000000018193EC40
	}
}
