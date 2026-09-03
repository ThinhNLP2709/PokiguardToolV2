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
	internal class Datatype_dateTimeBase : Datatype_anySimpleType // TypeDefIndex: 7062
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
		private XsdDateTimeFlags dateTimeFlags; // 0x38
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AEB100-0x0000000181AEB150 
		public override XmlTypeCode TypeCode { get; } // 0x0000000181458830-0x0000000181458840 
		public override Type ValueType { get; } // 0x0000000181AEB1B0-0x0000000181AEB200 
		internal override Type ListValueType { get; } // 0x0000000181AEB150-0x0000000181AEB1A0 
		internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; } // 0x0000000180476390-0x00000001804763A0 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000181AEB1A0-0x0000000181AEB1B0 
	
		// Constructors
		internal Datatype_dateTimeBase(XsdDateTimeFlags dateTimeFlags); // 0x0000000181AEB070-0x0000000181AEB100
		static Datatype_dateTimeBase(); // 0x0000000181AEAFC0-0x0000000181AEB070
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AEACA0-0x0000000181AEACB0
		internal override int Compare(object value1, object value2); // 0x0000000181AEAB90-0x0000000181AEACA0
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEACB0-0x0000000181AEAFC0
	}
}
