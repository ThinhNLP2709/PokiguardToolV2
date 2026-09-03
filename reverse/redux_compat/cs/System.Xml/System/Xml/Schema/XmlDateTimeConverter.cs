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
	internal class XmlDateTimeConverter : XmlBaseConverter // TypeDefIndex: 7271
	{
		// Constructors
		protected XmlDateTimeConverter(XmlSchemaType schemaType); // 0x0000000181A05050-0x0000000181A050B0
	
		// Methods
		public static XmlValueConverter Create(XmlSchemaType schemaType); // 0x0000000181A03E00-0x0000000181A03E90
		public override DateTime ToDateTime(DateTimeOffset value); // 0x0000000181A04420-0x0000000181A04480
		public override DateTime ToDateTime(string value); // 0x0000000181A04480-0x0000000181A04690
		public override DateTime ToDateTime(object value); // 0x0000000181A04690-0x0000000181A049A0
		public override DateTimeOffset ToDateTimeOffset(DateTime value); // 0x0000000181A041C0-0x0000000181A041F0
		public override DateTimeOffset ToDateTimeOffset(string value); // 0x0000000181A041F0-0x0000000181A04420
		public override DateTimeOffset ToDateTimeOffset(object value); // 0x0000000181A03E90-0x0000000181A041C0
		public override string ToString(DateTime value); // 0x0000000181A04BB0-0x0000000181A04D70
		public override string ToString(DateTimeOffset value); // 0x0000000181A049A0-0x0000000181A04BB0
		public override string ToString(object value, IXmlNamespaceResolver nsResolver); // 0x0000000181A04D70-0x0000000181A05050
		public override object ChangeType(DateTime value, Type destinationType); // 0x0000000181A03B40-0x0000000181A03E00
		public override object ChangeType(string value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A03260-0x0000000181A03540
		public override object ChangeType(object value, Type destinationType, IXmlNamespaceResolver nsResolver); // 0x0000000181A03540-0x0000000181A03B40
	}
}
