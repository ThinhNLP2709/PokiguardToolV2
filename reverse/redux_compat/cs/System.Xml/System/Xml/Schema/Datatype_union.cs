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
	internal class Datatype_union : Datatype_anySimpleType // TypeDefIndex: 7050
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
		private XmlSchemaSimpleType[] types; // 0x38
	
		// Properties
		public override Type ValueType { get; } // 0x0000000181AEF8E0-0x0000000181AEF930 
		public override XmlTypeCode TypeCode { get; } // 0x0000000181626E00-0x0000000181626E10 
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AEF830-0x0000000181AEF890 
		internal override Type ListValueType { get; } // 0x0000000181AEF890-0x0000000181AEF8E0 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x0000000180A2FA70-0x0000000180A2FA80 
		internal XmlSchemaSimpleType[] BaseMemberTypes { get; } // 0x00000001803272A0-0x00000001803272B0 
	
		// Constructors
		internal Datatype_union(XmlSchemaSimpleType[] types); // 0x0000000181AEF790-0x0000000181AEF830
		static Datatype_union(); // 0x0000000181AEF6E0-0x0000000181AEF790
	
		// Methods
		internal override XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x0000000181AEEE80-0x0000000181AEEE90
		internal override int Compare(object value1, object value2); // 0x0000000181AEED70-0x0000000181AEEE80
		internal bool HasAtomicMembers(); // 0x0000000181AEEE90-0x0000000181AEEF40
		internal bool IsUnionBaseOf(DatatypeImplementation derivedType); // 0x0000000181AEEF40-0x0000000181AEEFF0
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEEFF0-0x0000000181AEF260
		internal override Exception TryParseValue(object value, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEF260-0x0000000181AEF6E0
	}
}
