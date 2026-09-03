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
	internal class Datatype_base64Binary : Datatype_anySimpleType // TypeDefIndex: 7076
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AE9E00-0x0000000181AE9E50 
		public override XmlTypeCode TypeCode { get; } // 0x0000000181AE9EA0-0x0000000181AE9EB0 
		public override Type ValueType { get; } // 0x0000000181AE9EB0-0x0000000181AE9F00 
		internal override Type ListValueType { get; } // 0x0000000181AE9E50-0x0000000181AE9EA0 
		internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; } // 0x0000000180476390-0x00000001804763A0 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000181AE8220-0x0000000181AE8230 
	
		// Constructors
		public Datatype_base64Binary(); // 0x0000000181AE9D80-0x0000000181AE9E00
		static Datatype_base64Binary(); // 0x0000000181AE9CD0-0x0000000181AE9D80
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AE8370-0x0000000181AE8380
		internal override int Compare(object value1, object value2); // 0x0000000181AE9A60-0x0000000181AE9B90
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AE9B90-0x0000000181AE9CD0
	}
}
