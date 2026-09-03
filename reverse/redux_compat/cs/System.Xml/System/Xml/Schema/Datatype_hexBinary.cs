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
	internal class Datatype_hexBinary : Datatype_anySimpleType // TypeDefIndex: 7075
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AED3C0-0x0000000181AED410 
		public override XmlTypeCode TypeCode { get; } // 0x0000000181AED460-0x0000000181AED470 
		public override Type ValueType { get; } // 0x0000000181AED470-0x0000000181AED4C0 
		internal override Type ListValueType { get; } // 0x0000000181AED410-0x0000000181AED460 
		internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; } // 0x0000000180476390-0x00000001804763A0 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000181AE8220-0x0000000181AE8230 
	
		// Constructors
		public Datatype_hexBinary(); // 0x0000000181AED340-0x0000000181AED3C0
		static Datatype_hexBinary(); // 0x0000000181AED290-0x0000000181AED340
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AE8370-0x0000000181AE8380
		internal override int Compare(object value1, object value2); // 0x0000000181AED010-0x0000000181AED140
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AED140-0x0000000181AED290
	}
}
