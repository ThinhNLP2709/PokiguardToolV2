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
	public struct SqlMoney : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11360
	{
		// Fields
		private bool _fNotNull; // 0x00
		private long _value; // 0x08
		internal static readonly int s_iMoneyScale; // 0x00
		private static readonly long s_lTickBase; // 0x08
		private static readonly double s_dTickBase; // 0x10
		private static readonly long s_minLong; // 0x18
		private static readonly long s_maxLong; // 0x20
		public static readonly SqlMoney Null; // 0x28
		public static readonly SqlMoney Zero; // 0x38
		public static readonly SqlMoney MinValue; // 0x48
		public static readonly SqlMoney MaxValue; // 0x58
	
		// Properties
		public bool IsNull { get; } // 0x00000001818C64D0-0x00000001818C64E0 
		public decimal Value { get; } // 0x00000001818F04F0-0x00000001818F05A0 
	
		// Constructors
		private SqlMoney(bool fNull); // 0x00000001818E8180-0x00000001818E8190
		internal SqlMoney(long value, int ignored); // 0x0000000180C623B0-0x0000000180C623C0
		public SqlMoney(int value); // 0x00000001818F01F0-0x00000001818F0260
		public SqlMoney(long value); // 0x00000001818F0130-0x00000001818F01F0
		public SqlMoney(decimal value); // 0x00000001818F0260-0x00000001818F04F0
		static SqlMoney(); // 0x00000001818EFFB0-0x00000001818F0130
	
		// Methods
		public decimal ToDecimal(); // 0x00000001818EF8D0-0x00000001818EF9B0
		public double ToDouble(); // 0x00000001818EF9B0-0x00000001818EFA40
		public static implicit operator SqlMoney(decimal x); // 0x00000001818F0D20-0x00000001818F0D50
		public static implicit operator SqlMoney(long x); // 0x00000001818F0F40-0x00000001818F0F90
		public override string ToString(); // 0x00000001818EFEF0-0x00000001818EFFB0
		public static SqlMoney operator -(SqlMoney x); // 0x00000001818F1430-0x00000001818F1510
		public static SqlMoney operator +(SqlMoney x, SqlMoney y); // 0x00000001818F05A0-0x00000001818F0700
		public static SqlMoney operator -(SqlMoney x, SqlMoney y); // 0x00000001818F12D0-0x00000001818F1430
		public static SqlMoney operator *(SqlMoney x, SqlMoney y); // 0x00000001818F11A0-0x00000001818F12D0
		public static SqlMoney operator /(SqlMoney x, SqlMoney y); // 0x00000001818F0700-0x00000001818F0830
		public static implicit operator SqlMoney(SqlByte x); // 0x00000001818F0E80-0x00000001818F0F40
		public static implicit operator SqlMoney(SqlInt16 x); // 0x00000001818F0C60-0x00000001818F0D20
		public static implicit operator SqlMoney(SqlInt32 x); // 0x00000001818F0D50-0x00000001818F0E80
		public static implicit operator SqlMoney(SqlInt64 x); // 0x00000001818F0F90-0x00000001818F10E0
		public static explicit operator SqlMoney(SqlDecimal x); // 0x00000001818F08F0-0x00000001818F0BA0
		public static SqlBoolean operator ==(SqlMoney x, SqlMoney y); // 0x00000001818F0830-0x00000001818F08F0
		public static SqlBoolean operator <(SqlMoney x, SqlMoney y); // 0x00000001818F10E0-0x00000001818F11A0
		public static SqlBoolean operator >(SqlMoney x, SqlMoney y); // 0x00000001818F0BA0-0x00000001818F0C60
		public static SqlBoolean LessThan(SqlMoney x, SqlMoney y); // 0x00000001818EF500-0x00000001818EF600
		public static SqlBoolean GreaterThan(SqlMoney x, SqlMoney y); // 0x00000001818EF400-0x00000001818EF500
		public SqlDouble ToSqlDouble(); // 0x00000001818EFC40-0x00000001818EFEF0
		public SqlDecimal ToSqlDecimal(); // 0x00000001818EFA40-0x00000001818EFC40
		public int CompareTo(object value); // 0x00000001818EF040-0x00000001818EF170
		public int CompareTo(SqlMoney value); // 0x00000001818EEE10-0x00000001818EF040
		public override bool Equals(object value); // 0x00000001818EF170-0x00000001818EF330
		public override int GetHashCode(); // 0x00000001818EF330-0x00000001818EF390
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818EF600-0x00000001818EF790
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818EF790-0x00000001818EF8D0
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818EF390-0x00000001818EF400
	}
}
