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
	internal class XmlBooleanConverter : XmlBaseConverter // TypeDefIndex: 7272
	{
		// Constructors
		protected XmlBooleanConverter(XmlSchemaType schemaType); // 0x0000000181A03200-0x0000000181A03260
	
		// Methods
		public static XmlValueConverter Create(XmlSchemaType schemaType); // 0x0000000181A02B80-0x0000000181A02C10
		public override bool ToBoolean(string value); // 0x0000000181A02EB0-0x0000000181A02F50
		public override bool ToBoolean(object value); // 0x0000000181A02C10-0x0000000181A02EB0
		public override string ToString(bool value); // 0x0000000181A031B0-0x0000000181A03200
		public override string ToString(object value, IXmlNamespaceResolver nsResolver); // 0x0000000181A02F50-0x0000000181A031B0
		public override object ChangeType(bool value, Type destinationType); // 0x0000000181A02200-0x0000000181A02460
		public override object ChangeType(string value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A02900-0x0000000181A02B80
		public override object ChangeType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A02460-0x0000000181A02900
	}
}
