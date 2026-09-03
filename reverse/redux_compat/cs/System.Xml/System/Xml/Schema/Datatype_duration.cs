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
	internal class Datatype_duration : Datatype_anySimpleType // TypeDefIndex: 7059
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AEC4E0-0x0000000181AEC540 
		public override XmlTypeCode TypeCode { get; } // 0x0000000181777F20-0x0000000181777F30 
		public override Type ValueType { get; } // 0x0000000181AEC590-0x0000000181AEC5E0 
		internal override Type ListValueType { get; } // 0x0000000181AEC540-0x0000000181AEC590 
		internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; } // 0x0000000180476390-0x00000001804763A0 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000181AEB1A0-0x0000000181AEB1B0 
	
		// Constructors
		public Datatype_duration(); // 0x0000000181AEC460-0x0000000181AEC4E0
		static Datatype_duration(); // 0x0000000181AEC3B0-0x0000000181AEC460
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AE8370-0x0000000181AE8380
		internal override int Compare(object value1, object value2); // 0x0000000181AEC120-0x0000000181AEC1C0
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEC1C0-0x0000000181AEC3B0
	}
}
