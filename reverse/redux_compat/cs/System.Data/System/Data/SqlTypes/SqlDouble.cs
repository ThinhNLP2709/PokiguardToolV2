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
	public struct SqlDouble : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11355
	{
		// Fields
		private bool m_fNotNull; // 0x00
		private double m_value; // 0x08
		public static readonly SqlDouble Null; // 0x00
		public static readonly SqlDouble Zero; // 0x10
		public static readonly SqlDouble MinValue; // 0x20
		public static readonly SqlDouble MaxValue; // 0x30
	
		// Properties
		public bool IsNull { get; } // 0x00000001818C64D0-0x00000001818C64E0 
		public double Value { get; } // 0x00000001818E8190-0x00000001818E81F0 
	
		// Constructors
		private SqlDouble(bool fNull); // 0x00000001818E8180-0x00000001818E8190
		public SqlDouble(double value); // 0x00000001818E80F0-0x00000001818E8180
		static SqlDouble(); // 0x00000001818E7EE0-0x00000001818E80F0
	
		// Methods
		public static implicit operator SqlDouble(double x); // 0x00000001818E88B0-0x00000001818E88D0
		public override string ToString(); // 0x00000001818E7E80-0x00000001818E7EE0
		public static SqlDouble operator -(SqlDouble x); // 0x00000001818E8F40-0x00000001818E8FE0
		public static SqlDouble operator +(SqlDouble x, SqlDouble y); // 0x00000001818E81F0-0x00000001818E8310
		public static SqlDouble operator -(SqlDouble x, SqlDouble y); // 0x00000001818E8E20-0x00000001818E8F40
		public static SqlDouble operator *(SqlDouble x, SqlDouble y); // 0x00000001818E8D00-0x00000001818E8E20
		public static SqlDouble operator /(SqlDouble x, SqlDouble y); // 0x00000001818E8310-0x00000001818E8480
		public static implicit operator SqlDouble(SqlByte x); // 0x00000001818E8B80-0x00000001818E8C40
		public static implicit operator SqlDouble(SqlInt16 x); // 0x00000001818E8AC0-0x00000001818E8B80
		public static implicit operator SqlDouble(SqlInt32 x); // 0x00000001818E88D0-0x00000001818E8A00
		public static implicit operator SqlDouble(SqlInt64 x); // 0x00000001818E8620-0x00000001818E86E0
		public static implicit operator SqlDouble(SqlSingle x); // 0x00000001818E8A00-0x00000001818E8AC0
		public static implicit operator SqlDouble(SqlMoney x); // 0x00000001818E87F0-0x00000001818E88B0
		public static implicit operator SqlDouble(SqlDecimal x); // 0x00000001818E86E0-0x00000001818E87F0
		public static SqlBoolean operator ==(SqlDouble x, SqlDouble y); // 0x00000001818E8480-0x00000001818E8560
		public static SqlBoolean operator <(SqlDouble x, SqlDouble y); // 0x00000001818E8C40-0x00000001818E8D00
		public static SqlBoolean operator >(SqlDouble x, SqlDouble y); // 0x00000001818E8560-0x00000001818E8620
		public static SqlBoolean LessThan(SqlDouble x, SqlDouble y); // 0x00000001818E7980-0x00000001818E7A90
		public static SqlBoolean GreaterThan(SqlDouble x, SqlDouble y); // 0x00000001818E7870-0x00000001818E7980
		public SqlSingle ToSqlSingle(); // 0x00000001818E7CF0-0x00000001818E7E80
		public int CompareTo(object value); // 0x00000001818E7260-0x00000001818E7390
		public int CompareTo(SqlDouble value); // 0x00000001818E7390-0x00000001818E75B0
		public override bool Equals(object value); // 0x00000001818E75B0-0x00000001818E7780
		public override int GetHashCode(); // 0x00000001818E7780-0x00000001818E7800
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818E7A90-0x00000001818E7BC0
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818E7BC0-0x00000001818E7CF0
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818E7800-0x00000001818E7870
	}
}
