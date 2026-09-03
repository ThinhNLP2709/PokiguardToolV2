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
	internal class Datatype_double : Datatype_anySimpleType // TypeDefIndex: 7057
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AEC030-0x0000000181AEC080 
		public override XmlTypeCode TypeCode { get; } // 0x00000001808F5E70-0x00000001808F5E80 
		public override Type ValueType { get; } // 0x0000000181AEC0D0-0x0000000181AEC120 
		internal override Type ListValueType { get; } // 0x0000000181AEC080-0x0000000181AEC0D0 
		internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; } // 0x0000000180476390-0x00000001804763A0 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000181AEB1A0-0x0000000181AEB1B0 
	
		// Constructors
		public Datatype_double(); // 0x0000000181AEBFB0-0x0000000181AEC030
		static Datatype_double(); // 0x0000000181AEBF00-0x0000000181AEBFB0
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AEBD90-0x0000000181AEBDA0
		internal override int Compare(object value1, object value2); // 0x0000000181AEBD30-0x0000000181AEBD90
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEBDA0-0x0000000181AEBF00
	}
}
