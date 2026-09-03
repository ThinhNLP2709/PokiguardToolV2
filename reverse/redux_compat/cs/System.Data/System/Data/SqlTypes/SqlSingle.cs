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
	public struct SqlSingle : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11361
	{
		// Fields
		private bool _fNotNull; // 0x00
		private float _value; // 0x04
		public static readonly SqlSingle Null; // 0x00
		public static readonly SqlSingle Zero; // 0x08
		public static readonly SqlSingle MinValue; // 0x10
		public static readonly SqlSingle MaxValue; // 0x18
	
		// Properties
		public bool IsNull { get; } // 0x00000001818C64D0-0x00000001818C64E0 
		public float Value { get; } // 0x00000001818F24A0-0x00000001818F2500 
	
		// Constructors
		private SqlSingle(bool fNull); // 0x00000001818EC2B0-0x00000001818EC2C0
		public SqlSingle(float value); // 0x00000001818F2420-0x00000001818F24A0
		public SqlSingle(double value); // 0x00000001818F23C0-0x00000001818F2420
		static SqlSingle(); // 0x00000001818F21D0-0x00000001818F23C0
	
		// Methods
		public static implicit operator SqlSingle(float x); // 0x00000001818F3100-0x00000001818F3190
		public override string ToString(); // 0x00000001818F2170-0x00000001818F21D0
		public static SqlSingle operator -(SqlSingle x); // 0x00000001818F36A0-0x00000001818F3790
		public static SqlSingle operator +(SqlSingle x, SqlSingle y); // 0x00000001818F2500-0x00000001818F2660
		public static SqlSingle operator -(SqlSingle x, SqlSingle y); // 0x00000001818F3540-0x00000001818F36A0
		public static SqlSingle operator *(SqlSingle x, SqlSingle y); // 0x00000001818F33E0-0x00000001818F3540
		public static SqlSingle operator /(SqlSingle x, SqlSingle y); // 0x00000001818F2660-0x00000001818F27C0
		public static implicit operator SqlSingle(SqlByte x); // 0x00000001818F2FD0-0x00000001818F3100
		public static implicit operator SqlSingle(SqlInt16 x); // 0x00000001818F2EC0-0x00000001818F2FD0
		public static implicit operator SqlSingle(SqlInt32 x); // 0x00000001818F3190-0x00000001818F3310
		public static implicit operator SqlSingle(SqlInt64 x); // 0x00000001818F2DB0-0x00000001818F2EC0
		public static implicit operator SqlSingle(SqlMoney x); // 0x00000001818F2AC0-0x00000001818F2C10
		public static implicit operator SqlSingle(SqlDecimal x); // 0x00000001818F2C10-0x00000001818F2DB0
		public static explicit operator SqlSingle(SqlDouble x); // 0x00000001818F28B0-0x00000001818F29F0
		public static SqlBoolean operator ==(SqlSingle x, SqlSingle y); // 0x00000001818F27C0-0x00000001818F28B0
		public static SqlBoolean operator <(SqlSingle x, SqlSingle y); // 0x00000001818F3310-0x00000001818F33E0
		public static SqlBoolean operator >(SqlSingle x, SqlSingle y); // 0x00000001818F29F0-0x00000001818F2AC0
		public static SqlBoolean LessThan(SqlSingle x, SqlSingle y); // 0x00000001818F1D40-0x00000001818F1DA0
		public static SqlBoolean GreaterThan(SqlSingle x, SqlSingle y); // 0x00000001818F1CE0-0x00000001818F1D40
		public SqlDouble ToSqlDouble(); // 0x00000001818F2000-0x00000001818F2170
		public int CompareTo(object value); // 0x00000001818F1870-0x00000001818F1A50
		public int CompareTo(SqlSingle value); // 0x00000001818F1770-0x00000001818F1870
		public override bool Equals(object value); // 0x00000001818F1A50-0x00000001818F1C00
		public override int GetHashCode(); // 0x00000001818F1C00-0x00000001818F1C70
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818F1DA0-0x00000001818F1ED0
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818F1ED0-0x00000001818F2000
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818F1C70-0x00000001818F1CE0
	}
}
