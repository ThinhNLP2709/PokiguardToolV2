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
	internal class XmlUnionConverter : XmlBaseConverter // TypeDefIndex: 7279
	{
		// Fields
		private XmlValueConverter[] converters; // 0x28
		private bool hasAtomicMember; // 0x30
		private bool hasListMember; // 0x31
	
		// Constructors
		protected XmlUnionConverter(XmlSchemaType schemaType); // 0x0000000181A0DA00-0x0000000181A0DCB0
	
		// Methods
		public static XmlValueConverter Create(XmlSchemaType schemaType); // 0x0000000181A0D9A0-0x0000000181A0DA00
		public override object ChangeType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A0D590-0x0000000181A0D9A0
	}
}
