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
	public struct SqlGuid : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11356
	{
		// Fields
		private static readonly int s_sizeOfGuid; // 0x00
		private static readonly int[] s_rgiGuidOrder; // 0x08
		private byte[] m_value; // 0x00
		public static readonly SqlGuid Null; // 0x10
	
		// Properties
		public bool IsNull { get; } // 0x0000000180E87410-0x0000000180E87420 
		public Guid Value { get; } // 0x00000001818E9CE0-0x00000001818E9D90 
	
		// Constructors
		private SqlGuid(bool fNull); // 0x000000018103EDD0-0x000000018103EDE0
		public SqlGuid(Guid g); // 0x00000001818E9CB0-0x00000001818E9CE0
		static SqlGuid(); // 0x00000001818E9BB0-0x00000001818E9CB0
	
		// Methods
		public static implicit operator SqlGuid(Guid x); // 0x00000001818E9F30-0x00000001818E9F70
		public override string ToString(); // 0x00000001818E9B30-0x00000001818E9BB0
		private static EComparison Compare(SqlGuid x, SqlGuid y); // 0x00000001818E94B0-0x00000001818E95D0
		public static SqlBoolean operator ==(SqlGuid x, SqlGuid y); // 0x00000001818E9D90-0x00000001818E9E60
		public static SqlBoolean operator <(SqlGuid x, SqlGuid y); // 0x00000001818E9F70-0x00000001818EA040
		public static SqlBoolean operator >(SqlGuid x, SqlGuid y); // 0x00000001818E9E60-0x00000001818E9F30
		public int CompareTo(object value); // 0x00000001818E8FE0-0x00000001818E92C0
		public int CompareTo(SqlGuid value); // 0x00000001818E92C0-0x00000001818E94B0
		public override bool Equals(object value); // 0x00000001818E95D0-0x00000001818E9740
		public override int GetHashCode(); // 0x00000001818E9740-0x00000001818E9840
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818E98B0-0x00000001818E99F0
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818E99F0-0x00000001818E9B30
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818E9840-0x00000001818E98B0
	}
}
