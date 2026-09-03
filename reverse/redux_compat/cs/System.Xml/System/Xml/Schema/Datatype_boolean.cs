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
	internal class Datatype_boolean : Datatype_anySimpleType // TypeDefIndex: 7055
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AEA1D0-0x0000000181AEA220 
		public override XmlTypeCode TypeCode { get; } // 0x000000018161AF40-0x000000018161AF50 
		public override Type ValueType { get; } // 0x0000000181AEA270-0x0000000181AEA2C0 
		internal override Type ListValueType { get; } // 0x0000000181AEA220-0x0000000181AEA270 
		internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; } // 0x0000000180476390-0x00000001804763A0 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000180A2FAD0-0x0000000180A2FAE0 
	
		// Constructors
		public Datatype_boolean(); // 0x0000000181AEA150-0x0000000181AEA1D0
		static Datatype_boolean(); // 0x0000000181AEA0A0-0x0000000181AEA150
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AE9F70-0x0000000181AE9F80
		internal override int Compare(object value1, object value2); // 0x0000000181AE9F00-0x0000000181AE9F70
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AE9F80-0x0000000181AEA0A0
	}
}
