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
	internal class XmlMiscConverter : XmlBaseConverter // TypeDefIndex: 7273
	{
		// Constructors
		protected XmlMiscConverter(XmlSchemaType schemaType); // 0x0000000181A083A0-0x0000000181A08400
	
		// Methods
		public static XmlValueConverter Create(XmlSchemaType schemaType); // 0x0000000181A07DC0-0x0000000181A07E50
		public override string ToString(object value, IXmlNamespaceResolver nsResolver); // 0x0000000181A07E50-0x0000000181A083A0
		public override object ChangeType(string value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A06DD0-0x0000000181A07280
		public override object ChangeType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A07280-0x0000000181A07DC0
		private object ChangeTypeWildcardDestination(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A06B40-0x0000000181A06C80
		private object ChangeTypeWildcardSource(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A06C80-0x0000000181A06DD0
	}
}
