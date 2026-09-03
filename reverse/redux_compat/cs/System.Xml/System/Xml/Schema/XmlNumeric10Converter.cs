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
	internal class XmlNumeric10Converter : XmlBaseConverter // TypeDefIndex: 7269
	{
		// Constructors
		protected XmlNumeric10Converter(XmlSchemaType schemaType); // 0x0000000181A0B530-0x0000000181A0B590
	
		// Methods
		public static XmlValueConverter Create(XmlSchemaType schemaType); // 0x0000000181A0A200-0x0000000181A0A290
		public override decimal ToDecimal(string value); // 0x0000000181A0A630-0x0000000181A0A720
		public override decimal ToDecimal(object value); // 0x0000000181A0A290-0x0000000181A0A630
		public override int ToInt32(long value); // 0x0000000181A0A720-0x0000000181A0A770
		public override int ToInt32(string value); // 0x0000000181A0A770-0x0000000181A0A890
		public override int ToInt32(object value); // 0x0000000181A0A890-0x0000000181A0ABE0
		public override long ToInt64(int value); // 0x0000000181A0B050-0x0000000181A0B060
		public override long ToInt64(string value); // 0x0000000181A0ABE0-0x0000000181A0AD00
		public override long ToInt64(object value); // 0x0000000181A0AD00-0x0000000181A0B050
		public override string ToString(decimal value); // 0x0000000181A0B450-0x0000000181A0B530
		public override string ToString(int value); // 0x0000000181A0B400-0x0000000181A0B450
		public override string ToString(long value); // 0x0000000181A0B060-0x0000000181A0B0B0
		public override string ToString(object value, IXmlNamespaceResolver nsResolver); // 0x0000000181A0B0B0-0x0000000181A0B400
		public override object ChangeType(decimal value, Type destinationType); // 0x0000000181A09EA0-0x0000000181A0A200
		public override object ChangeType(int value, Type destinationType); // 0x0000000181A09BA0-0x0000000181A09EA0
		public override object ChangeType(long value, Type destinationType); // 0x0000000181A09570-0x0000000181A09880
		public override object ChangeType(string value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A09880-0x0000000181A09BA0
		public override object ChangeType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A089F0-0x0000000181A09570
		private object ChangeTypeWildcardDestination(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A08400-0x0000000181A08720
		private object ChangeTypeWildcardSource(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A08720-0x0000000181A089F0
	}
}
