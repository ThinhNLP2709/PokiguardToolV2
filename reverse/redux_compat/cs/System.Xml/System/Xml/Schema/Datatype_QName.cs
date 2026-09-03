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
	internal class Datatype_QName : Datatype_anySimpleType // TypeDefIndex: 7078
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AE9120-0x0000000181AE9180 
		public override XmlTypeCode TypeCode { get; } // 0x0000000180A2FB40-0x0000000180A2FB50 
		public override XmlTokenizedType TokenizedType { get; } // 0x0000000181626E00-0x0000000181626E10 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000181AE8220-0x0000000181AE8230 
		public override Type ValueType { get; } // 0x0000000181AE91D0-0x0000000181AE9220 
		internal override Type ListValueType { get; } // 0x0000000181AE9180-0x0000000181AE91D0 
		internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; } // 0x0000000180476390-0x00000001804763A0 
	
		// Constructors
		public Datatype_QName(); // 0x0000000181AE90A0-0x0000000181AE9120
		static Datatype_QName(); // 0x0000000181AE8FF0-0x0000000181AE90A0
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AE8370-0x0000000181AE8380
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AE8E20-0x0000000181AE8FF0
	}
}
