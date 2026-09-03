/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class XmlListConverter : XmlBaseConverter // TypeDefIndex: 7278
	{
		// Fields
		protected XmlValueConverter atomicConverter; // 0x28
	
		// Constructors
		protected XmlListConverter(XmlBaseConverter atomicConverter); // 0x0000000181A02190-0x0000000181A02200
		protected XmlListConverter(XmlBaseConverter atomicConverter, Type clrTypeDefault); // 0x0000000181A06A60-0x0000000181A06AE0
		protected XmlListConverter(XmlSchemaType schemaType); // 0x0000000181A06AE0-0x0000000181A06B40
	
		// Methods
		public static XmlValueConverter Create(XmlValueConverter atomicConverter); // 0x0000000181A05F30-0x0000000181A060B0
		public override object ChangeType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A05B10-0x0000000181A05C30
		protected override object ChangeListType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A050B0-0x0000000181A05B10
		private bool IsListType(Type type); // 0x0000000181A060B0-0x0000000181A061C0
		private T[] ToArray<T>(object list, IXmlNamespaceResolver nsResolver);
		private IList ToList(object list, IXmlNamespaceResolver nsResolver); // 0x0000000181A06510-0x0000000181A06A60
		private List<string> StringAsList(string value); // 0x0000000181A06470-0x0000000181A06510
		private string ListAsString(IEnumerable list, IXmlNamespaceResolver nsResolver); // 0x0000000181A061C0-0x0000000181A06470
		private new Exception CreateInvalidClrMappingException(Type sourceType, Type destinationType); // 0x0000000181A05C30-0x0000000181A05F30
	}
}
