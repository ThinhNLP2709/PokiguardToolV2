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
	public struct SqlInt32 : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11358
	{
		// Fields
		private bool m_fNotNull; // 0x00
		private int m_value; // 0x04
		private static readonly long s_iIntMin; // 0x00
		private static readonly long s_lBitNotIntMax; // 0x08
		public static readonly SqlInt32 Null; // 0x10
		public static readonly SqlInt32 Zero; // 0x18
		public static readonly SqlInt32 MinValue; // 0x20
		public static readonly SqlInt32 MaxValue; // 0x28
	
		// Properties
		public bool IsNull { get; } // 0x00000001818C64D0-0x00000001818C64E0 
		public int Value { get; } // 0x00000001818EC2C0-0x00000001818EC350 
	
		// Constructors
		private SqlInt32(bool fNull); // 0x00000001818EC2B0-0x00000001818EC2C0
		public SqlInt32(int value); // 0x0000000180C62370-0x0000000180C62380
		static SqlInt32(); // 0x00000001818EC1D0-0x00000001818EC2B0
	
		// Methods
		public static implicit operator SqlInt32(int x); // 0x00000001818EC8E0-0x00000001818EC900
		public override string ToString(); // 0x00000001818EC170-0x00000001818EC1D0
		public static SqlInt32 operator -(SqlInt32 x); // 0x00000001818ECC70-0x00000001818ECCF0
		public static SqlInt32 operator +(SqlInt32 x, SqlInt32 y); // 0x00000001818EC350-0x00000001818EC440
		public static SqlInt32 operator -(SqlInt32 x, SqlInt32 y); // 0x00000001818ECB70-0x00000001818ECC70
		public static SqlInt32 operator *(SqlInt32 x, SqlInt32 y); // 0x00000001818ECA70-0x00000001818ECB70
		public static SqlInt32 operator /(SqlInt32 x, SqlInt32 y); // 0x00000001818EC440-0x00000001818EC590
		public static implicit operator SqlInt32(SqlByte x); // 0x00000001818EC830-0x00000001818EC8E0
		public static implicit operator SqlInt32(SqlInt16 x); // 0x00000001818EC900-0x00000001818EC9A0
		public static explicit operator SqlInt32(SqlInt64 x); // 0x00000001818EC660-0x00000001818EC760
		private static bool SameSignInt(int x, int y); // 0x00000001818EBB90-0x00000001818EBBB0
		public static SqlBoolean operator ==(SqlInt32 x, SqlInt32 y); // 0x00000001818EC590-0x00000001818EC660
		public static SqlBoolean operator <(SqlInt32 x, SqlInt32 y); // 0x00000001818EC9A0-0x00000001818ECA70
		public static SqlBoolean operator >(SqlInt32 x, SqlInt32 y); // 0x00000001818EC760-0x00000001818EC830
		public static SqlBoolean LessThan(SqlInt32 x, SqlInt32 y); // 0x00000001818EBB30-0x00000001818EBB90
		public static SqlBoolean GreaterThan(SqlInt32 x, SqlInt32 y); // 0x00000001818EBAD0-0x00000001818EBB30
		public SqlDouble ToSqlDouble(); // 0x00000001818EBE00-0x00000001818EBFF0
		public SqlInt64 ToSqlInt64(); // 0x00000001818EBFF0-0x00000001818EC170
		public int CompareTo(object value); // 0x00000001818EB670-0x00000001818EB850
		public int CompareTo(SqlInt32 value); // 0x00000001818EB570-0x00000001818EB670
		public override bool Equals(object value); // 0x00000001818EB850-0x00000001818EB9F0
		public override int GetHashCode(); // 0x00000001818EB9F0-0x00000001818EBA60
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818EBBB0-0x00000001818EBCE0
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818EBCE0-0x00000001818EBE00
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818EBA60-0x00000001818EBAD0
	}
}
