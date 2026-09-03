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
	public abstract class XmlSchemaDatatype // TypeDefIndex: 7197
	{
		// Properties
		public abstract Type ValueType { get; }
		public abstract XmlTokenizedType TokenizedType { get; }
		public virtual XmlSchemaDatatypeVariety Variety { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual XmlTypeCode TypeCode { get; } // 0x00000001802E7860-0x00000001802E7870 
		internal abstract bool HasLexicalFacets { get; }
		internal abstract bool HasValueFacets { get; }
		internal abstract XmlValueConverter ValueConverter { get; }
		internal abstract RestrictionFacets Restriction { get; }
		internal abstract FacetsChecker FacetsChecker { get; }
		internal abstract XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; }
		internal string TypeCodeString { get; } // 0x00000001819DCC60-0x00000001819DCDB0 
	
		// Constructors
		protected XmlSchemaDatatype(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract object ParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr);
		public virtual bool IsDerivedFrom(XmlSchemaDatatype datatype); // 0x00000001802E7840-0x00000001802E7850
		internal abstract int Compare(object value1, object value2);
		internal abstract object ParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, bool createAtomicValue);
		internal abstract Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue);
		internal abstract Exception TryParseValue(object value, XmlNameTable nameTable, IXmlNamespaceResolver namespaceResolver, out object typedValue);
		internal abstract XmlSchemaDatatype DeriveByRestriction(XmlSchemaObjectCollection facets, XmlNameTable nameTable, XmlSchemaType schemaType);
		internal abstract XmlSchemaDatatype DeriveByList(XmlSchemaType schemaType);
		internal abstract void VerifySchemaValid(XmlSchemaObjectTable notations, XmlSchemaObject caller);
		internal abstract bool IsEqual(object o1, object o2);
		internal abstract bool IsComparable(XmlSchemaDatatype dtype);
		internal string TypeCodeToString(XmlTypeCode typeCode); // 0x00000001819DC520-0x00000001819DCAB0
		internal static string ConcatenatedToString(object value); // 0x00000001819DBE10-0x00000001819DC3D0
		internal static XmlSchemaDatatype FromXmlTokenizedType(XmlTokenizedType token); // 0x00000001819DC4D0-0x00000001819DC520
		internal static XmlSchemaDatatype FromXmlTokenizedTypeXsd(XmlTokenizedType token); // 0x00000001819DC480-0x00000001819DC4D0
		internal static XmlSchemaDatatype FromXdrName(string name); // 0x00000001819DC430-0x00000001819DC480
		internal static XmlSchemaDatatype DeriveByUnion(XmlSchemaSimpleType[] types, XmlSchemaType schemaType); // 0x00000001819DC3D0-0x00000001819DC430
		internal static string XdrCanonizeUri(string uri, XmlNameTable nameTable, SchemaNames schemaNames); // 0x00000001819DCAB0-0x00000001819DCC60
	}
}
