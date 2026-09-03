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
	public struct SqlBoolean : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11348
	{
		// Fields
		private byte m_value; // 0x00
		public static readonly SqlBoolean True; // 0x00
		public static readonly SqlBoolean False; // 0x01
		public static readonly SqlBoolean Null; // 0x02
		public static readonly SqlBoolean Zero; // 0x03
		public static readonly SqlBoolean One; // 0x04
	
		// Properties
		public bool IsNull { get; } // 0x00000001818C64D0-0x00000001818C64E0 
		public bool Value { get; } // 0x00000001818C64F0-0x00000001818C6550 
		public bool IsTrue { get; } // 0x00000001818C64E0-0x00000001818C64F0 
		public bool IsFalse { get; } // 0x00000001818C64C0-0x00000001818C64D0 
		public byte ByteValue { get; } // 0x00000001818C6430-0x00000001818C64C0 
	
		// Constructors
		public SqlBoolean(bool value); // 0x00000001818C6420-0x00000001818C6430
		public SqlBoolean(int value); // 0x00000001818C63A0-0x00000001818C6400
		private SqlBoolean(int value, bool fNull); // 0x00000001818C6400-0x00000001818C6420
		static SqlBoolean(); // 0x00000001818C62B0-0x00000001818C63A0
	
		// Methods
		public static implicit operator SqlBoolean(bool x); // 0x00000001818C6790-0x00000001818C67A0
		public static bool op_True(SqlBoolean x); // 0x00000001818C67A0-0x00000001818C67F0
		public static SqlBoolean operator &(SqlBoolean x, SqlBoolean y); // 0x00000001818C6550-0x00000001818C6630
		public static SqlBoolean operator |(SqlBoolean x, SqlBoolean y); // 0x00000001818C6630-0x00000001818C6710
		public override string ToString(); // 0x00000001818C61C0-0x00000001818C62B0
		public static SqlBoolean operator ==(SqlBoolean x, SqlBoolean y); // 0x00000001818C6710-0x00000001818C6790
		public static SqlBoolean And(SqlBoolean x, SqlBoolean y); // 0x00000001818C5830-0x00000001818C5940
		public static SqlBoolean Or(SqlBoolean x, SqlBoolean y); // 0x00000001818C5E80-0x00000001818C5F90
		public int CompareTo(object value); // 0x00000001818C5A10-0x00000001818C5C00
		public int CompareTo(SqlBoolean value); // 0x00000001818C5940-0x00000001818C5A10
		public override bool Equals(object value); // 0x00000001818C5C00-0x00000001818C5D40
		public override int GetHashCode(); // 0x00000001818C5D40-0x00000001818C5E10
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818C5F90-0x00000001818C60B0
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818C60B0-0x00000001818C61C0
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818C5E10-0x00000001818C5E80
	}
}
