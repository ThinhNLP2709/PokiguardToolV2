/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.SqlTypes
{
	[Serializable]
	[XmlSchemaProvider("GetXsdType")]
	public struct SqlDateTime : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11353
	{
		// Fields
		private bool m_fNotNull; // 0x00
		private int m_day; // 0x04
		private int m_time; // 0x08
		private static readonly double s_SQLTicksPerMillisecond; // 0x00
		public static readonly int SQLTicksPerSecond; // 0x08
		public static readonly int SQLTicksPerMinute; // 0x0C
		public static readonly int SQLTicksPerHour; // 0x10
		private static readonly int s_SQLTicksPerDay; // 0x14
		private static readonly long s_ticksPerSecond; // 0x18
		private static readonly DateTime s_SQLBaseDate; // 0x20
		private static readonly long s_SQLBaseDateTicks; // 0x28
		private static readonly int s_minYear; // 0x30
		private static readonly int s_maxYear; // 0x34
		private static readonly int s_minDay; // 0x38
		private static readonly int s_maxDay; // 0x3C
		private static readonly int s_minTime; // 0x40
		private static readonly int s_maxTime; // 0x44
		private static readonly int s_dayBase; // 0x48
		private static readonly int[] s_daysToMonth365; // 0x50
		private static readonly int[] s_daysToMonth366; // 0x58
		private static readonly DateTime s_minDateTime; // 0x60
		private static readonly DateTime s_maxDateTime; // 0x68
		private static readonly TimeSpan s_minTimeSpan; // 0x70
		private static readonly TimeSpan s_maxTimeSpan; // 0x78
		private static readonly string s_ISO8601_DateTimeFormat; // 0x80
		private static readonly string[] s_dateTimeFormats; // 0x88
		public static readonly SqlDateTime MinValue; // 0x90
		public static readonly SqlDateTime MaxValue; // 0x9C
		public static readonly SqlDateTime Null; // 0xA8
	
		// Properties
		public bool IsNull { get; } // 0x00000001818C64D0-0x00000001818C64E0 
		public DateTime Value { get; } // 0x00000001818DEBF0-0x00000001818DECA0 
		public int DayTicks { get; } // 0x00000001818DEB30-0x00000001818DEB90 
		public int TimeTicks { get; } // 0x00000001818DEB90-0x00000001818DEBF0 
	
		// Constructors
		private SqlDateTime(bool fNull); // 0x00000001818DEA50-0x00000001818DEA60
		public SqlDateTime(DateTime value); // 0x00000001818DE9E0-0x00000001818DEA50
		public SqlDateTime(int dayTicks, int timeTicks); // 0x00000001818DEA60-0x00000001818DEB30
		static SqlDateTime(); // 0x00000001818DE280-0x00000001818DE9E0
	
		// Methods
		private static TimeSpan ToTimeSpan(SqlDateTime value); // 0x00000001818DE1F0-0x00000001818DE280
		private static DateTime ToDateTime(SqlDateTime value); // 0x00000001818DE020-0x00000001818DE140
		private static SqlDateTime FromTimeSpan(TimeSpan value); // 0x00000001818DD6F0-0x00000001818DD8A0
		private static SqlDateTime FromDateTime(DateTime value); // 0x00000001818DD3A0-0x00000001818DD6F0
		public static implicit operator SqlDateTime(DateTime value); // 0x00000001818DEE40-0x00000001818DEEC0
		public override string ToString(); // 0x00000001818DE140-0x00000001818DE1F0
		public static SqlBoolean operator ==(SqlDateTime x, SqlDateTime y); // 0x00000001818DECA0-0x00000001818DED70
		public static SqlBoolean operator <(SqlDateTime x, SqlDateTime y); // 0x00000001818DEEC0-0x00000001818DEF90
		public static SqlBoolean operator >(SqlDateTime x, SqlDateTime y); // 0x00000001818DED70-0x00000001818DEE40
		public static SqlBoolean LessThan(SqlDateTime x, SqlDateTime y); // 0x00000001818DDB20-0x00000001818DDC90
		public static SqlBoolean GreaterThan(SqlDateTime x, SqlDateTime y); // 0x00000001818DD9B0-0x00000001818DDB20
		public int CompareTo(object value); // 0x00000001818DCCD0-0x00000001818DCFA0
		public int CompareTo(SqlDateTime value); // 0x00000001818DCFA0-0x00000001818DD1C0
		public override bool Equals(object value); // 0x00000001818DD1C0-0x00000001818DD3A0
		public override int GetHashCode(); // 0x00000001818DD8A0-0x00000001818DD940
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818DDC90-0x00000001818DDED0
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818DDED0-0x00000001818DE020
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818DD940-0x00000001818DD9B0
	}
}
