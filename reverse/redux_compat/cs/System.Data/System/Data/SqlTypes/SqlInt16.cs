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
	public struct SqlInt16 : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11357
	{
		// Fields
		private bool m_fNotNull; // 0x00
		private short m_value; // 0x02
		private static readonly int s_MASKI2; // 0x00
		public static readonly SqlInt16 Null; // 0x04
		public static readonly SqlInt16 Zero; // 0x08
		public static readonly SqlInt16 MinValue; // 0x0C
		public static readonly SqlInt16 MaxValue; // 0x10
	
		// Properties
		public bool IsNull { get; } // 0x00000001818C64D0-0x00000001818C64E0 
		public short Value { get; } // 0x00000001818EAC50-0x00000001818EACB0 
	
		// Constructors
		private SqlInt16(bool fNull); // 0x00000001818EAC40-0x00000001818EAC50
		public SqlInt16(short value); // 0x0000000180C58A20-0x0000000180C58A30
		static SqlInt16(); // 0x00000001818EAB80-0x00000001818EAC40
	
		// Methods
		public static implicit operator SqlInt16(short x); // 0x00000001818EB220-0x00000001818EB240
		public override string ToString(); // 0x00000001818EAB20-0x00000001818EAB80
		public static SqlInt16 operator -(SqlInt16 x); // 0x00000001818EB4F0-0x00000001818EB570
		public static SqlInt16 operator +(SqlInt16 x, SqlInt16 y); // 0x00000001818EACB0-0x00000001818EADA0
		public static SqlInt16 operator -(SqlInt16 x, SqlInt16 y); // 0x00000001818EB400-0x00000001818EB4F0
		public static SqlInt16 operator *(SqlInt16 x, SqlInt16 y); // 0x00000001818EB300-0x00000001818EB400
		public static SqlInt16 operator /(SqlInt16 x, SqlInt16 y); // 0x00000001818EADA0-0x00000001818EAEF0
		public static implicit operator SqlInt16(SqlByte x); // 0x00000001818EB170-0x00000001818EB220
		public static explicit operator SqlInt16(SqlInt64 x); // 0x00000001818EAFB0-0x00000001818EB0B0
		public static SqlBoolean operator ==(SqlInt16 x, SqlInt16 y); // 0x00000001818EAEF0-0x00000001818EAFB0
		public static SqlBoolean operator <(SqlInt16 x, SqlInt16 y); // 0x00000001818EB240-0x00000001818EB300
		public static SqlBoolean operator >(SqlInt16 x, SqlInt16 y); // 0x00000001818EB0B0-0x00000001818EB170
		public static SqlBoolean LessThan(SqlInt16 x, SqlInt16 y); // 0x00000001818EA5F0-0x00000001818EA650
		public static SqlBoolean GreaterThan(SqlInt16 x, SqlInt16 y); // 0x00000001818EA590-0x00000001818EA5F0
		public SqlDouble ToSqlDouble(); // 0x00000001818EA8A0-0x00000001818EAA10
		public SqlInt64 ToSqlInt64(); // 0x00000001818EAA10-0x00000001818EAB20
		public int CompareTo(object value); // 0x00000001818EA040-0x00000001818EA220
		public int CompareTo(SqlInt16 value); // 0x00000001818EA220-0x00000001818EA310
		public override bool Equals(object value); // 0x00000001818EA310-0x00000001818EA4B0
		public override int GetHashCode(); // 0x00000001818EA4B0-0x00000001818EA520
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818EA650-0x00000001818EA780
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818EA780-0x00000001818EA8A0
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818EA520-0x00000001818EA590
	}
}
