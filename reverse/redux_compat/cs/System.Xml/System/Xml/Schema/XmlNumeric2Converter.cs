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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class XmlNumeric2Converter : XmlBaseConverter // TypeDefIndex: 7270
	{
		// Constructors
		protected XmlNumeric2Converter(XmlSchemaType schemaType); // 0x0000000181A0CCB0-0x0000000181A0CD10
	
		// Methods
		public static XmlValueConverter Create(XmlSchemaType schemaType); // 0x0000000181A0C060-0x0000000181A0C0F0
		public override double ToDouble(string value); // 0x0000000181A0C3E0-0x0000000181A0C4B0
		public override double ToDouble(object value); // 0x0000000181A0C0F0-0x0000000181A0C3E0
		public override float ToSingle(double value); // 0x0000000181A0C580-0x0000000181A0C590
		public override float ToSingle(string value); // 0x0000000181A0C4B0-0x0000000181A0C580
		public override float ToSingle(object value); // 0x0000000181A0C590-0x0000000181A0C8B0
		public override string ToString(double value); // 0x0000000181A0C8B0-0x0000000181A0C960
		public override string ToString(float value); // 0x0000000181A0CC20-0x0000000181A0CCB0
		public override string ToString(object value, IXmlNamespaceResolver nsResolver); // 0x0000000181A0C960-0x0000000181A0CC20
		public override object ChangeType(double value, Type destinationType); // 0x0000000181A0BDD0-0x0000000181A0C060
		public override object ChangeType(string value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A0B590-0x0000000181A0B850
		public override object ChangeType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A0B850-0x0000000181A0BDD0
	}
}
