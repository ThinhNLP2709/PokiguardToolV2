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
	internal class Datatype_decimal : Datatype_anySimpleType // TypeDefIndex: 7058
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
		private static readonly FacetsChecker numeric10FacetsChecker; // 0x10
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AEBA30-0x0000000181AEBA80 
		public override XmlTypeCode TypeCode { get; } // 0x0000000180A2FD00-0x0000000180A2FD10 
		public override Type ValueType { get; } // 0x0000000181AEBAE0-0x0000000181AEBB30 
		internal override Type ListValueType { get; } // 0x0000000181AEBA80-0x0000000181AEBAD0 
		internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; } // 0x0000000180476390-0x00000001804763A0 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000181AEBAD0-0x0000000181AEBAE0 
	
		// Constructors
		public Datatype_decimal(); // 0x0000000181AEB9B0-0x0000000181AEBA30
		static Datatype_decimal(); // 0x0000000181AEB820-0x0000000181AEB9B0
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AEB690-0x0000000181AEB6A0
		internal override int Compare(object value1, object value2); // 0x0000000181AEB5F0-0x0000000181AEB690
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEB6A0-0x0000000181AEB820
	}
}
