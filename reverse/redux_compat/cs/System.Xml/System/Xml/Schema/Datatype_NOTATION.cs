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
	internal class Datatype_NOTATION : Datatype_anySimpleType // TypeDefIndex: 7090
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AE8930-0x0000000181AE8990 
		public override XmlTypeCode TypeCode { get; } // 0x0000000180A2FC60-0x0000000180A2FC70 
		public override XmlTokenizedType TokenizedType { get; } // 0x0000000180740830-0x0000000180740840 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000181AE8220-0x0000000181AE8230 
		public override Type ValueType { get; } // 0x0000000181AE89E0-0x0000000181AE8A30 
		internal override Type ListValueType { get; } // 0x0000000181AE8990-0x0000000181AE89E0 
		internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; } // 0x0000000180476390-0x00000001804763A0 
	
		// Constructors
		public Datatype_NOTATION(); // 0x0000000181AE88B0-0x0000000181AE8930
		static Datatype_NOTATION(); // 0x0000000181AE8800-0x0000000181AE88B0
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AE8370-0x0000000181AE8380
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AE8380-0x0000000181AE8550
		internal override void VerifySchemaValid(XmlSchemaObjectTable notations, XmlSchemaObject caller); // 0x0000000181AE8550-0x0000000181AE8800
	}
}
