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

namespace System.Xml.Schema
{
	internal struct XsdDateTime // TypeDefIndex: 7289
	{
		// Fields
		private DateTime dt; // 0x00
		private uint extra; // 0x08
		private static readonly int Lzyyyy; // 0x00
		private static readonly int Lzyyyy_; // 0x04
		private static readonly int Lzyyyy_MM; // 0x08
		private static readonly int Lzyyyy_MM_; // 0x0C
		private static readonly int Lzyyyy_MM_dd; // 0x10
		private static readonly int Lzyyyy_MM_ddT; // 0x14
		private static readonly int LzHH; // 0x18
		private static readonly int LzHH_; // 0x1C
		private static readonly int LzHH_mm; // 0x20
		private static readonly int LzHH_mm_; // 0x24
		private static readonly int LzHH_mm_ss; // 0x28
		private static readonly int Lz_; // 0x2C
		private static readonly int Lz_zz; // 0x30
		private static readonly int Lz_zz_; // 0x34
		private static readonly int Lz_zz_zz; // 0x38
		private static readonly int Lz__; // 0x3C
		private static readonly int Lz__mm; // 0x40
		private static readonly int Lz__mm_; // 0x44
		private static readonly int Lz__mm__; // 0x48
		private static readonly int Lz__mm_dd; // 0x4C
		private static readonly int Lz___; // 0x50
		private static readonly int Lz___dd; // 0x54
		private static readonly XmlTypeCode[] typeCodes; // 0x58
	
		// Properties
		private DateTimeTypeCode InternalTypeCode { get; } // 0x0000000181A2AC20-0x0000000181A2AC30 
		private XsdDateTimeKind InternalKind { get; } // 0x00000001815770F0-0x0000000181577100 
		public int Year { get; } // 0x0000000181A2AD20-0x0000000181A2AD70 
		public int Month { get; } // 0x0000000181A2AC80-0x0000000181A2ACD0 
		public int Day { get; } // 0x0000000181A2AA60-0x0000000181A2AAB0 
		public int Hour { get; } // 0x0000000181A2ABD0-0x0000000181A2AC20 
		public int Minute { get; } // 0x0000000181A2AC30-0x0000000181A2AC80 
		public int Second { get; } // 0x0000000181A2ACD0-0x0000000181A2AD20 
		public int Fraction { get; } // 0x0000000181A2AAB0-0x0000000181A2ABD0 
		public int ZoneHour { get; } // 0x0000000181577100-0x0000000181577110 
		public int ZoneMinute { get; } // 0x0000000181325D60-0x0000000181325D70 
	
		// Nested types
		private enum DateTimeTypeCode // TypeDefIndex: 7290
		{
			DateTime = 0,
			Time = 1,
			Date = 2,
			GYearMonth = 3,
			GYear = 4,
			GMonthDay = 5,
			GDay = 6,
			GMonth = 7,
			XdrDateTime = 8
		}
	
		private enum XsdDateTimeKind // TypeDefIndex: 7291
		{
			Unspecified = 0,
			Zulu = 1,
			LocalWestOfZulu = 2,
			LocalEastOfZulu = 3
		}
	
		private struct Parser // TypeDefIndex: 7292
		{
			// Fields
			public DateTimeTypeCode typeCode; // 0x00
			public int year; // 0x04
			public int month; // 0x08
			public int day; // 0x0C
			public int hour; // 0x10
			public int minute; // 0x14
			public int second; // 0x18
			public int fraction; // 0x1C
			public XsdDateTimeKind kind; // 0x20
			public int zoneHour; // 0x24
			public int zoneMinute; // 0x28
			private string text; // 0x30
			private int length; // 0x38
			private static int[] Power10; // 0x00
	
			// Constructors
			static Parser(); // 0x0000000181A228F0-0x0000000181A22990
	
			// Methods
			public bool Parse(string text, XsdDateTimeFlags kinds); // 0x0000000181A21B50-0x0000000181A228E0
			private bool ParseDate(int start); // 0x0000000181A21350-0x0000000181A21560
			private bool ParseTimeAndZoneAndWhitespace(int start); // 0x0000000181A215D0-0x0000000181A21650
			private bool ParseTimeAndWhitespace(int start); // 0x0000000181A21560-0x0000000181A215D0
			private bool ParseTime(ref int start); // 0x0000000181A21650-0x0000000181A21950
			private bool ParseZoneAndWhitespace(int start); // 0x0000000181A21950-0x0000000181A21B50
			private bool Parse4Dig(int start, ref int num); // 0x0000000181A21220-0x0000000181A21310
			private bool Parse2Dig(int start, ref int num); // 0x0000000181A21190-0x0000000181A21220
			private bool ParseChar(int start, char ch); // 0x0000000181A21310-0x0000000181A21350
			private static bool Test(XsdDateTimeFlags left, XsdDateTimeFlags right); // 0x0000000181A228E0-0x0000000181A228F0
		}
	
		// Constructors
		public XsdDateTime(string text, XsdDateTimeFlags kinds); // 0x0000000181A2A490-0x0000000181A2A6C0
		private XsdDateTime(Parser parser); // 0x0000000181A2A6C0-0x0000000181A2A750
		public XsdDateTime(DateTime dateTime, XsdDateTimeFlags kinds); // 0x0000000181A2A750-0x0000000181A2A8D0
		public XsdDateTime(DateTimeOffset dateTimeOffset); // 0x0000000181A2A8D0-0x0000000181A2AA60
		public XsdDateTime(DateTimeOffset dateTimeOffset, XsdDateTimeFlags kinds); // 0x0000000181A2A340-0x0000000181A2A490
		static XsdDateTime(); // 0x0000000181A29E80-0x0000000181A2A340
	
		// Methods
		private void InitiateXsdDateTime(Parser parser); // 0x0000000181A28AA0-0x0000000181A28BD0
		internal static bool TryParse(string text, XsdDateTimeFlags kinds, out XsdDateTime result); // 0x0000000181A29D10-0x0000000181A29E80
		public static implicit operator DateTime(XsdDateTime xdt); // 0x0000000181A2AD70-0x0000000181A2B380
		public static implicit operator DateTimeOffset(XsdDateTime xdt); // 0x0000000181A2B380-0x0000000181A2B730
		public override string ToString(); // 0x0000000181A29840-0x0000000181A29D10
		private void PrintDate(StringBuilder sb); // 0x0000000181A28C80-0x0000000181A28F90
		private void PrintTime(StringBuilder sb); // 0x0000000181A28F90-0x0000000181A294B0
		private void PrintZone(StringBuilder sb); // 0x0000000181A294B0-0x0000000181A297C0
		private void IntToCharArray(char[] text, int start, int value, int digits); // 0x0000000181A28BD0-0x0000000181A28C80
		private void ShortToCharArray(char[] text, int start, int value); // 0x0000000181A297C0-0x0000000181A29840
	}
}
