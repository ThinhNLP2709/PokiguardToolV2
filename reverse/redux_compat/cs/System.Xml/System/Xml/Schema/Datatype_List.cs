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
	internal class Datatype_List : Datatype_anySimpleType // TypeDefIndex: 7049
	{
		// Fields
		private DatatypeImplementation itemType; // 0x38
		private int minListSize; // 0x40
	
		// Properties
		public override Type ValueType { get; } // 0x0000000181AE8230-0x0000000181AE8250 
		public override XmlTokenizedType TokenizedType { get; } // 0x0000000181AE81C0-0x0000000181AE81F0 
		internal override Type ListValueType { get; } // 0x0000000181AE8190-0x0000000181AE81C0 
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AE8130-0x0000000181AE8190 
		public override XmlTypeCode TypeCode { get; } // 0x0000000181AE81F0-0x0000000181AE8220 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000181AE8220-0x0000000181AE8230 
	
		// Constructors
		internal Datatype_List(DatatypeImplementation type, int minListSize); // 0x0000000181AE8080-0x0000000181AE8130
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AE7240-0x0000000181AE75F0
		internal override int Compare(object value1, object value2); // 0x0000000181AE6F80-0x0000000181AE7240
		internal override Exception TryParseValue(object value, XmlNameTable nameTable, IXmlNamespaceResolver namespaceResolver, out object typedValue); // 0x0000000181AE75F0-0x0000000181AE7BB0
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AE7BB0-0x0000000181AE8080
	}
}
