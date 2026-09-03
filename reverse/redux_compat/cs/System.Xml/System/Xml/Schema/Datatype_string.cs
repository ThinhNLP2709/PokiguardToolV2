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
	internal class Datatype_string : Datatype_anySimpleType // TypeDefIndex: 7054
	{
		// Properties
		internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; } // 0x00000001802E7860-0x00000001802E7870 
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AEEC20-0x0000000181AEEC70 
		public override XmlTypeCode TypeCode { get; } // 0x0000000180740840-0x0000000180740850 
		public override XmlTokenizedType TokenizedType { get; } // 0x00000001802E7860-0x00000001802E7870 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000181AE8220-0x0000000181AE8230 
	
		// Constructors
		public Datatype_string(); // 0x0000000181AEEBA0-0x0000000181AEEC20
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AEEAA0-0x0000000181AEEAB0
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEEAB0-0x0000000181AEEBA0
	}
}
