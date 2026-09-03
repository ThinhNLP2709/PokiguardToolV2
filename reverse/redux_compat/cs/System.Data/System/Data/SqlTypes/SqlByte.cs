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
	public struct SqlByte : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11349
	{
		// Fields
		private bool m_fNotNull; // 0x00
		private byte m_value; // 0x01
		private static readonly int s_iBitNotByteMax; // 0x00
		public static readonly SqlByte Null; // 0x04
		public static readonly SqlByte Zero; // 0x06
		public static readonly SqlByte MinValue; // 0x08
		public static readonly SqlByte MaxValue; // 0x0A
	
		// Properties
		public bool IsNull { get; } // 0x00000001818C64D0-0x00000001818C64E0 
		public byte Value { get; } // 0x00000001818C7360-0x00000001818C73C0 
	
		// Constructors
		private SqlByte(bool fNull); // 0x00000001818C7350-0x00000001818C7360
		public SqlByte(byte value); // 0x0000000180C589D0-0x0000000180C589E0
		static SqlByte(); // 0x00000001818C7290-0x00000001818C7350
	
		// Methods
		public static implicit operator SqlByte(byte x); // 0x00000001818C7830-0x00000001818C7840
		public override string ToString(); // 0x00000001818C7210-0x00000001818C7290
		public static SqlByte operator +(SqlByte x, SqlByte y); // 0x00000001818C73C0-0x00000001818C74B0
		public static SqlByte operator -(SqlByte x, SqlByte y); // 0x00000001818C79E0-0x00000001818C7AD0
		public static SqlByte operator *(SqlByte x, SqlByte y); // 0x00000001818C78F0-0x00000001818C79E0
		public static SqlByte operator /(SqlByte x, SqlByte y); // 0x00000001818C74B0-0x00000001818C75A0
		public static explicit operator SqlByte(SqlInt64 x); // 0x00000001818C7650-0x00000001818C7780
		public static SqlBoolean operator ==(SqlByte x, SqlByte y); // 0x00000001818C75A0-0x00000001818C7650
		public static SqlBoolean operator <(SqlByte x, SqlByte y); // 0x00000001818C7840-0x00000001818C78F0
		public static SqlBoolean operator >(SqlByte x, SqlByte y); // 0x00000001818C7780-0x00000001818C7830
		public static SqlBoolean LessThan(SqlByte x, SqlByte y); // 0x00000001818C6E80-0x00000001818C6EE0
		public static SqlBoolean GreaterThan(SqlByte x, SqlByte y); // 0x00000001818C6E20-0x00000001818C6E80
		public SqlDouble ToSqlDouble(); // 0x00000001818C7130-0x00000001818C71A0
		public SqlInt64 ToSqlInt64(); // 0x00000001818C71A0-0x00000001818C7210
		public int CompareTo(object value); // 0x00000001818C6940-0x00000001818C6B80
		public int CompareTo(SqlByte value); // 0x00000001818C67F0-0x00000001818C6940
		public override bool Equals(object value); // 0x00000001818C6B80-0x00000001818C6D40
		public override int GetHashCode(); // 0x00000001818C6D40-0x00000001818C6DB0
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818C6EE0-0x00000001818C7010
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818C7010-0x00000001818C7130
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818C6DB0-0x00000001818C6E20
	}
}
