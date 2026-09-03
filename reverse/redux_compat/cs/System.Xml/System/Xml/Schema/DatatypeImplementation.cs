/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal abstract class DatatypeImplementation : XmlSchemaDatatype // TypeDefIndex: 7047
	{
		// Fields
		private XmlSchemaDatatypeVariety variety; // 0x10
		private RestrictionFacets restriction; // 0x18
		private DatatypeImplementation baseType; // 0x20
		private XmlValueConverter valueConverter; // 0x28
		private XmlSchemaType parentSchemaType; // 0x30
		private static Hashtable builtinTypes; // 0x00
		private static XmlSchemaSimpleType[] enumToTypeCode; // 0x08
		private static XmlSchemaSimpleType anySimpleType; // 0x10
		private static XmlSchemaSimpleType anyAtomicType; // 0x18
		private static XmlSchemaSimpleType untypedAtomicType; // 0x20
		private static XmlSchemaSimpleType yearMonthDurationType; // 0x28
		private static XmlSchemaSimpleType dayTimeDurationType; // 0x30
		private static XmlSchemaSimpleType normalizedStringTypeV1Compat; // 0x38
		private static XmlSchemaSimpleType tokenTypeV1Compat; // 0x40
		internal static XmlQualifiedName QnAnySimpleType; // 0x48
		internal static XmlQualifiedName QnAnyType; // 0x50
		internal static FacetsChecker stringFacetsChecker; // 0x58
		internal static FacetsChecker miscFacetsChecker; // 0x60
		internal static FacetsChecker numeric2FacetsChecker; // 0x68
		internal static FacetsChecker binaryFacetsChecker; // 0x70
		internal static FacetsChecker dateTimeFacetsChecker; // 0x78
		internal static FacetsChecker durationFacetsChecker; // 0x80
		internal static FacetsChecker listFacetsChecker; // 0x88
		internal static FacetsChecker qnameFacetsChecker; // 0x90
		internal static FacetsChecker unionFacetsChecker; // 0x98
		private static readonly DatatypeImplementation c_anySimpleType; // 0xA0
		private static readonly DatatypeImplementation c_anyURI; // 0xA8
		private static readonly DatatypeImplementation c_base64Binary; // 0xB0
		private static readonly DatatypeImplementation c_boolean; // 0xB8
		private static readonly DatatypeImplementation c_byte; // 0xC0
		private static readonly DatatypeImplementation c_char; // 0xC8
		private static readonly DatatypeImplementation c_date; // 0xD0
		private static readonly DatatypeImplementation c_dateTime; // 0xD8
		private static readonly DatatypeImplementation c_dateTimeNoTz; // 0xE0
		private static readonly DatatypeImplementation c_dateTimeTz; // 0xE8
		private static readonly DatatypeImplementation c_day; // 0xF0
		private static readonly DatatypeImplementation c_decimal; // 0xF8
		private static readonly DatatypeImplementation c_double; // 0x100
		private static readonly DatatypeImplementation c_doubleXdr; // 0x108
		private static readonly DatatypeImplementation c_duration; // 0x110
		private static readonly DatatypeImplementation c_ENTITY; // 0x118
		private static readonly DatatypeImplementation c_ENTITIES; // 0x120
		private static readonly DatatypeImplementation c_ENUMERATION; // 0x128
		private static readonly DatatypeImplementation c_fixed; // 0x130
		private static readonly DatatypeImplementation c_float; // 0x138
		private static readonly DatatypeImplementation c_floatXdr; // 0x140
		private static readonly DatatypeImplementation c_hexBinary; // 0x148
		private static readonly DatatypeImplementation c_ID; // 0x150
		private static readonly DatatypeImplementation c_IDREF; // 0x158
		private static readonly DatatypeImplementation c_IDREFS; // 0x160
		private static readonly DatatypeImplementation c_int; // 0x168
		private static readonly DatatypeImplementation c_integer; // 0x170
		private static readonly DatatypeImplementation c_language; // 0x178
		private static readonly DatatypeImplementation c_long; // 0x180
		private static readonly DatatypeImplementation c_month; // 0x188
		private static readonly DatatypeImplementation c_monthDay; // 0x190
		private static readonly DatatypeImplementation c_Name; // 0x198
		private static readonly DatatypeImplementation c_NCName; // 0x1A0
		private static readonly DatatypeImplementation c_negativeInteger; // 0x1A8
		private static readonly DatatypeImplementation c_NMTOKEN; // 0x1B0
		private static readonly DatatypeImplementation c_NMTOKENS; // 0x1B8
		private static readonly DatatypeImplementation c_nonNegativeInteger; // 0x1C0
		private static readonly DatatypeImplementation c_nonPositiveInteger; // 0x1C8
		private static readonly DatatypeImplementation c_normalizedString; // 0x1D0
		private static readonly DatatypeImplementation c_NOTATION; // 0x1D8
		private static readonly DatatypeImplementation c_positiveInteger; // 0x1E0
		private static readonly DatatypeImplementation c_QName; // 0x1E8
		private static readonly DatatypeImplementation c_QNameXdr; // 0x1F0
		private static readonly DatatypeImplementation c_short; // 0x1F8
		private static readonly DatatypeImplementation c_string; // 0x200
		private static readonly DatatypeImplementation c_time; // 0x208
		private static readonly DatatypeImplementation c_timeNoTz; // 0x210
		private static readonly DatatypeImplementation c_timeTz; // 0x218
		private static readonly DatatypeImplementation c_token; // 0x220
		private static readonly DatatypeImplementation c_unsignedByte; // 0x228
		private static readonly DatatypeImplementation c_unsignedInt; // 0x230
		private static readonly DatatypeImplementation c_unsignedLong; // 0x238
		private static readonly DatatypeImplementation c_unsignedShort; // 0x240
		private static readonly DatatypeImplementation c_uuid; // 0x248
		private static readonly DatatypeImplementation c_year; // 0x250
		private static readonly DatatypeImplementation c_yearMonth; // 0x258
		internal static readonly DatatypeImplementation c_normalizedStringV1Compat; // 0x260
		internal static readonly DatatypeImplementation c_tokenV1Compat; // 0x268
		private static readonly DatatypeImplementation c_anyAtomicType; // 0x270
		private static readonly DatatypeImplementation c_dayTimeDuration; // 0x278
		private static readonly DatatypeImplementation c_untypedAtomicType; // 0x280
		private static readonly DatatypeImplementation c_yearMonthDuration; // 0x288
		private static readonly DatatypeImplementation[] c_tokenizedTypes; // 0x290
		private static readonly DatatypeImplementation[] c_tokenizedTypesXsd; // 0x298
		private static readonly SchemaDatatypeMap[] c_XdrTypes; // 0x2A0
		private static readonly SchemaDatatypeMap[] c_XsdTypes; // 0x2A8
	
		// Properties
		internal static XmlSchemaSimpleType AnySimpleType { get; } // 0x0000000181AE6DD0-0x0000000181AE6E20 
		internal static XmlSchemaSimpleType UntypedAtomicType { get; } // 0x0000000181AE6EB0-0x0000000181AE6F00 
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AE6E20-0x0000000181AE6E70 
		internal override XmlValueConverter ValueConverter { get; } // 0x0000000181AE6F00-0x0000000181AE6F50 
		public override XmlTokenizedType TokenizedType { get; } // 0x0000000180740840-0x0000000180740850 
		public override Type ValueType { get; } // 0x0000000181A44D00-0x0000000181A44D40 
		public override XmlSchemaDatatypeVariety Variety { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public override XmlTypeCode TypeCode { get; } // 0x00000001802E7860-0x00000001802E7870 
		internal override RestrictionFacets Restriction { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal override bool HasLexicalFacets { get; } // 0x0000000181AE6E70-0x0000000181AE6E90 
		internal override bool HasValueFacets { get; } // 0x0000000181AE6E90-0x0000000181AE6EB0 
		protected DatatypeImplementation Base { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal abstract Type ListValueType { get; }
		internal abstract RestrictionFlags ValidRestrictionFlags { get; }
		internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Nested types
		private class SchemaDatatypeMap : IComparable // TypeDefIndex: 7048
		{
			// Fields
			private string name; // 0x10
			private DatatypeImplementation type; // 0x18
			private int parentIndex; // 0x20
	
			// Properties
			public string Name { get; } // 0x0000000180377550-0x0000000180377560 
			public int ParentIndex { get; } // 0x0000000180C4F680-0x0000000180C4F690 
	
			// Constructors
			internal SchemaDatatypeMap(string name, DatatypeImplementation type); // 0x0000000180CB0730-0x0000000180CB0780
			internal SchemaDatatypeMap(string name, DatatypeImplementation type, int parentIndex); // 0x00000001818033E0-0x0000000181803440
	
			// Methods
			public static explicit operator DatatypeImplementation(SchemaDatatypeMap sdm); // 0x0000000180FB0360-0x0000000180FB0380
			public int CompareTo(object obj); // 0x000000018189B650-0x000000018189B6A0
		}
	
		// Constructors
		static DatatypeImplementation(); // 0x0000000181AE0E60-0x0000000181AE6DD0
		protected DatatypeImplementation(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		internal static new DatatypeImplementation FromXmlTokenizedType(XmlTokenizedType token); // 0x0000000181ADFB30-0x0000000181ADFBB0
		internal static new DatatypeImplementation FromXmlTokenizedTypeXsd(XmlTokenizedType token); // 0x0000000181ADFAB0-0x0000000181ADFB30
		internal static new DatatypeImplementation FromXdrName(string name); // 0x0000000181ADFA00-0x0000000181ADFAB0
		private static DatatypeImplementation FromTypeName(string name); // 0x0000000181ADF950-0x0000000181ADFA00
		internal static XmlSchemaSimpleType StartBuiltinType(XmlQualifiedName qname, XmlSchemaDatatype dataType); // 0x0000000181AE0A50-0x0000000181AE0B30
		internal static void FinishBuiltinType(XmlSchemaSimpleType derivedType, XmlSchemaSimpleType baseType); // 0x0000000181ADF6C0-0x0000000181ADF950
		internal static void CreateBuiltinTypes(); // 0x0000000181ADE620-0x0000000181ADF140
		internal static XmlSchemaSimpleType GetSimpleTypeFromTypeCode(XmlTypeCode typeCode); // 0x0000000181ADFF30-0x0000000181ADFFA0
		internal static XmlSchemaSimpleType GetSimpleTypeFromXsdType(XmlQualifiedName qname); // 0x0000000181ADFFA0-0x0000000181AE0060
		internal static XmlSchemaSimpleType GetNormalizedStringTypeV1Compat(); // 0x0000000181ADFC00-0x0000000181ADFDD0
		internal static XmlSchemaSimpleType GetTokenTypeV1Compat(); // 0x0000000181AE0060-0x0000000181AE0230
		internal static XmlSchemaSimpleType[] GetBuiltInTypes(); // 0x0000000181ADFBB0-0x0000000181ADFC00
		internal static XmlTypeCode GetPrimitiveTypeCode(XmlTypeCode typeCode); // 0x0000000181ADFDD0-0x0000000181ADFF30
		internal override XmlSchemaDatatype DeriveByRestriction(XmlSchemaObjectCollection facets, XmlNameTable nameTable, XmlSchemaType schemaType); // 0x0000000181ADF450-0x0000000181ADF590
		internal override XmlSchemaDatatype DeriveByList(XmlSchemaType schemaType); // 0x0000000181ADF140-0x0000000181ADF150
		internal XmlSchemaDatatype DeriveByList(int minSize, XmlSchemaType schemaType); // 0x0000000181ADF150-0x0000000181ADF450
		internal static new DatatypeImplementation DeriveByUnion(XmlSchemaSimpleType[] types, XmlSchemaType schemaType); // 0x0000000181ADF590-0x0000000181ADF6C0
		internal override void VerifySchemaValid(XmlSchemaObjectTable notations, XmlSchemaObject caller); // 0x00000001802E76C0-0x00000001802E76D0
		public override bool IsDerivedFrom(XmlSchemaDatatype datatype); // 0x0000000181AE03B0-0x0000000181AE0670
		internal override bool IsEqual(object o1, object o2); // 0x0000000181AE0670-0x0000000181AE06A0
		internal override bool IsComparable(XmlSchemaDatatype dtype); // 0x0000000181AE02B0-0x0000000181AE03B0
		internal virtual XmlValueConverter CreateValueConverter(XmlSchemaType schemaType); // 0x00000001802E7860-0x00000001802E7870
		public override object ParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr); // 0x0000000181AE0840-0x0000000181AE0A50
		internal override object ParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, bool createAtomicValue); // 0x0000000181AE06A0-0x0000000181AE0840
		internal override Exception TryParseValue(object value, XmlNameTable nameTable, IXmlNamespaceResolver namespaceResolver, out object typedValue); // 0x0000000181AE0B30-0x0000000181AE0E60
		internal string GetTypeName(); // 0x0000000181AE0230-0x0000000181AE02B0
		protected int Compare(byte[] value1, byte[] value2); // 0x0000000181ADE590-0x0000000181ADE620
	}
}
