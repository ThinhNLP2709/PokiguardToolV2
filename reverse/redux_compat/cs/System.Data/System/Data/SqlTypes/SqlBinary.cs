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
	[DefaultMember("Item")]
	[XmlSchemaProvider("GetXsdType")]
	public struct SqlBinary : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11347
	{
		// Fields
		private byte[] _value; // 0x00
		public static readonly SqlBinary Null; // 0x00
	
		// Properties
		public bool IsNull { get; } // 0x0000000180E87410-0x0000000180E87420 
		public byte[] Value { get; } // 0x00000001818C5420-0x00000001818C54F0 
	
		// Constructors
		private SqlBinary(bool fNull); // 0x000000018103EDD0-0x000000018103EDE0
		public SqlBinary(byte[] value); // 0x00000001818C5390-0x00000001818C5420
		static SqlBinary(); // 0x00000001818C5320-0x00000001818C5390
	
		// Methods
		public static implicit operator SqlBinary(byte[] x); // 0x00000001818C56B0-0x00000001818C5750
		public override string ToString(); // 0x00000001818C5230-0x00000001818C5320
		private static EComparison PerformCompareByte(byte[] x, byte[] y); // 0x00000001818C4E40-0x00000001818C4F70
		public static SqlBoolean operator ==(SqlBinary x, SqlBinary y); // 0x00000001818C54F0-0x00000001818C55D0
		public static SqlBoolean operator <(SqlBinary x, SqlBinary y); // 0x00000001818C5750-0x00000001818C5830
		public static SqlBoolean operator >(SqlBinary x, SqlBinary y); // 0x00000001818C55D0-0x00000001818C56B0
		public int CompareTo(object value); // 0x00000001818C49E0-0x00000001818C4AF0
		public int CompareTo(SqlBinary value); // 0x00000001818C4750-0x00000001818C49E0
		public override bool Equals(object value); // 0x00000001818C4AF0-0x00000001818C4CA0
		internal static int HashByteArray(byte[] rgbValue, int length); // 0x00000001818C4DE0-0x00000001818C4E40
		public override int GetHashCode(); // 0x00000001818C4CA0-0x00000001818C4D70
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818C4F70-0x00000001818C5110
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818C5110-0x00000001818C5230
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818C4D70-0x00000001818C4DE0
	}
}
