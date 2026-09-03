/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.SqlTypes
{
	[Serializable]
	[XmlSchemaProvider("GetXsdType")]
	public struct SqlString : INullable, IComparable, IXmlSerializable // TypeDefIndex: 11363
	{
		// Fields
		private string m_value; // 0x00
		private CompareInfo m_cmpInfo; // 0x08
		private int m_lcid; // 0x10
		private SqlCompareOptions m_flag; // 0x14
		private bool m_fNotNull; // 0x18
		public static readonly SqlString Null; // 0x00
		internal static readonly UnicodeEncoding s_unicodeEncoding; // 0x20
		public static readonly int IgnoreCase; // 0x28
		public static readonly int IgnoreWidth; // 0x2C
		public static readonly int IgnoreNonSpace; // 0x30
		public static readonly int IgnoreKanaType; // 0x34
		public static readonly int BinarySort; // 0x38
		public static readonly int BinarySort2; // 0x3C
		private static readonly SqlCompareOptions s_iDefaultFlag; // 0x40
		private static readonly CompareOptions s_iValidCompareOptionMask; // 0x44
		internal static readonly SqlCompareOptions s_iValidSqlCompareOptionMask; // 0x48
		internal static readonly int s_lcidUSEnglish; // 0x4C
		private static readonly int s_lcidBinary; // 0x50
	
		// Properties
		public bool IsNull { get; } // 0x00000001818F51A0-0x00000001818F51B0 
		public string Value { get; } // 0x00000001818F51B0-0x00000001818F5240 
	
		// Constructors
		private SqlString(bool fNull); // 0x00000001818F5160-0x00000001818F51A0
		public SqlString(string data, int lcid, SqlCompareOptions compareOptions); // 0x00000001818F4EC0-0x00000001818F4F70
		public SqlString(string data); // 0x00000001818F4F70-0x00000001818F50A0
		private SqlString(int lcid, SqlCompareOptions compareOptions, string data, CompareInfo cmpInfo); // 0x00000001818F50A0-0x00000001818F5160
		static SqlString(); // 0x00000001818F4CF0-0x00000001818F4EC0
	
		// Methods
		private void SetCompareInfo(); // 0x00000001818F45A0-0x00000001818F4620
		public static implicit operator SqlString(string x); // 0x00000001818F5590-0x00000001818F56D0
		public override string ToString(); // 0x00000001818F4BE0-0x00000001818F4C40
		public static SqlString operator +(SqlString x, SqlString y); // 0x00000001818F5240-0x00000001818F5450
		private static int StringCompare(SqlString x, SqlString y); // 0x00000001818F4620-0x00000001818F49F0
		private static SqlBoolean Compare(SqlString x, SqlString y, EComparison ecExpectedResult); // 0x00000001818F3ED0-0x00000001818F4010
		public static SqlBoolean operator ==(SqlString x, SqlString y); // 0x00000001818F5450-0x00000001818F5590
		private static void ValidateSqlCompareOptions(SqlCompareOptions compareOptions); // 0x00000001818F4C40-0x00000001818F4CF0
		public static CompareOptions CompareOptionsFromSqlCompareOptions(SqlCompareOptions compareOptions); // 0x00000001818F3B20-0x00000001818F3BF0
		private bool FBinarySort(); // 0x00000001818F42C0-0x00000001818F4320
		private static int CompareBinary(SqlString x, SqlString y); // 0x00000001818F38F0-0x00000001818F3B20
		private static int CompareBinary2(SqlString x, SqlString y); // 0x00000001818F3790-0x00000001818F38F0
		public int CompareTo(object value); // 0x00000001818F3BF0-0x00000001818F3E00
		public int CompareTo(SqlString value); // 0x00000001818F3E00-0x00000001818F3ED0
		public override bool Equals(object value); // 0x00000001818F4010-0x00000001818F42C0
		public override int GetHashCode(); // 0x00000001818F4320-0x00000001818F4530
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x00000001818F49F0-0x00000001818F4B00
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818F4B00-0x00000001818F4BE0
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818F4530-0x00000001818F45A0
	}
}
