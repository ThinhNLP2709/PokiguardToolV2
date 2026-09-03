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
	public struct SqlInt64 : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11359
	{
		// Fields
		private bool m_fNotNull; // 0x00
		private long m_value; // 0x08
		private static readonly long s_lLowIntMask; // 0x00
		private static readonly long s_lHighIntMask; // 0x08
		public static readonly SqlInt64 Null; // 0x10
		public static readonly SqlInt64 Zero; // 0x20
		public static readonly SqlInt64 MinValue; // 0x30
		public static readonly SqlInt64 MaxValue; // 0x40
	
		// Properties
		public bool IsNull { get; } // 0x00000001818C64D0-0x00000001818C64E0 
		public long Value { get; } // 0x00000001818EDE50-0x00000001818EDEB0 
	
		// Constructors
		private SqlInt64(bool fNull); // 0x00000001818E8180-0x00000001818E8190
		public SqlInt64(long value); // 0x0000000180C623B0-0x0000000180C623C0
		static SqlInt64(); // 0x00000001818EDD60-0x00000001818EDE50
	
		// Methods
		public static implicit operator SqlInt64(long x); // 0x00000001818EE770-0x00000001818EE790
		public override string ToString(); // 0x00000001818EDD00-0x00000001818EDD60
		public static SqlInt64 operator -(SqlInt64 x); // 0x00000001818EED80-0x00000001818EEE10
		public static SqlInt64 operator +(SqlInt64 x, SqlInt64 y); // 0x00000001818EDEB0-0x00000001818EDFB0
		public static SqlInt64 operator -(SqlInt64 x, SqlInt64 y); // 0x00000001818EEC80-0x00000001818EED80
		public static SqlInt64 operator *(SqlInt64 x, SqlInt64 y); // 0x00000001818EE9B0-0x00000001818EEC80
		public static SqlInt64 operator /(SqlInt64 x, SqlInt64 y); // 0x00000001818EDFB0-0x00000001818EE110
		public static SqlInt64 operator %(SqlInt64 x, SqlInt64 y); // 0x00000001818EE850-0x00000001818EE9B0
		public static implicit operator SqlInt64(SqlByte x); // 0x00000001818EE6B0-0x00000001818EE770
		public static implicit operator SqlInt64(SqlInt16 x); // 0x00000001818EE600-0x00000001818EE6B0
		public static implicit operator SqlInt64(SqlInt32 x); // 0x00000001818EE4D0-0x00000001818EE600
		public static explicit operator SqlInt64(SqlDecimal x); // 0x00000001818EE1D0-0x00000001818EE410
		private static bool SameSignLong(long x, long y); // 0x00000001818ED4F0-0x00000001818ED510
		public static SqlBoolean operator ==(SqlInt64 x, SqlInt64 y); // 0x00000001818EE110-0x00000001818EE1D0
		public static SqlBoolean operator <(SqlInt64 x, SqlInt64 y); // 0x00000001818EE790-0x00000001818EE850
		public static SqlBoolean operator >(SqlInt64 x, SqlInt64 y); // 0x00000001818EE410-0x00000001818EE4D0
		public static SqlBoolean LessThan(SqlInt64 x, SqlInt64 y); // 0x00000001818ED3F0-0x00000001818ED4F0
		public static SqlBoolean GreaterThan(SqlInt64 x, SqlInt64 y); // 0x00000001818ED2F0-0x00000001818ED3F0
		public SqlByte ToSqlByte(); // 0x00000001818ED760-0x00000001818ED7C0
		public SqlDouble ToSqlDouble(); // 0x00000001818ED8E0-0x00000001818EDA50
		public SqlInt16 ToSqlInt16(); // 0x00000001818EDA50-0x00000001818EDBA0
		public SqlInt32 ToSqlInt32(); // 0x00000001818EDBA0-0x00000001818EDD00
		public SqlDecimal ToSqlDecimal(); // 0x00000001818ED7C0-0x00000001818ED8E0
		public int CompareTo(object value); // 0x00000001818ECF20-0x00000001818ED050
		public int CompareTo(SqlInt64 value); // 0x00000001818ECCF0-0x00000001818ECF20
		public override bool Equals(object value); // 0x00000001818ED050-0x00000001818ED210
		public override int GetHashCode(); // 0x00000001818ED210-0x00000001818ED280
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818ED510-0x00000001818ED640
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818ED640-0x00000001818ED760
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818ED280-0x00000001818ED2F0
	}
}
