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
using System.Text;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal abstract class FacetsChecker // TypeDefIndex: 7113
	{
		// Nested types
		private struct FacetsCompiler // TypeDefIndex: 7114
		{
			// Fields
			private DatatypeImplementation datatype; // 0x00
			private RestrictionFacets derivedRestriction; // 0x08
			private RestrictionFlags baseFlags; // 0x10
			private RestrictionFlags baseFixedFlags; // 0x14
			private RestrictionFlags validRestrictionFlags; // 0x18
			private XmlSchemaDatatype nonNegativeInt; // 0x20
			private XmlSchemaDatatype builtInType; // 0x28
			private XmlTypeCode builtInEnum; // 0x30
			private bool firstPattern; // 0x34
			private StringBuilder regStr; // 0x38
			private XmlSchemaPatternFacet pattern_facet; // 0x40
			private static readonly Map[] c_map; // 0x00
	
			// Nested types
			private struct Map // TypeDefIndex: 7115
			{
				// Fields
				internal char match; // 0x00
				internal string replacement; // 0x08
	
				// Constructors
				internal Map(char m, string r); // 0x0000000181AF9F70-0x0000000181AF9F90
			}
	
			// Constructors
			public FacetsCompiler(DatatypeImplementation baseDatatype, RestrictionFacets restriction); // 0x0000000181AF9CA0-0x0000000181AF9F70
			static FacetsCompiler(); // 0x0000000181AF9990-0x0000000181AF9CA0
	
			// Methods
			internal void CompileLengthFacet(XmlSchemaFacet facet); // 0x0000000181AF6AA0-0x0000000181AF6F20
			internal void CompileMinLengthFacet(XmlSchemaFacet facet); // 0x0000000181AF7C80-0x0000000181AF8070
			internal void CompileMaxLengthFacet(XmlSchemaFacet facet); // 0x0000000181AF73D0-0x0000000181AF77C0
			internal void CompilePatternFacet(XmlSchemaPatternFacet facet); // 0x0000000181AF8070-0x0000000181AF8200
			internal void CompileEnumerationFacet(XmlSchemaFacet facet, IXmlNamespaceResolver nsmgr, XmlNameTable nameTable); // 0x0000000181AF6060-0x0000000181AF61F0
			internal void CompileWhitespaceFacet(XmlSchemaFacet facet); // 0x0000000181AF8620-0x0000000181AF8A80
			internal void CompileMaxInclusiveFacet(XmlSchemaFacet facet); // 0x0000000181AF7180-0x0000000181AF73D0
			internal void CompileMaxExclusiveFacet(XmlSchemaFacet facet); // 0x0000000181AF6F20-0x0000000181AF7180
			internal void CompileMinInclusiveFacet(XmlSchemaFacet facet); // 0x0000000181AF7A20-0x0000000181AF7C80
			internal void CompileMinExclusiveFacet(XmlSchemaFacet facet); // 0x0000000181AF77C0-0x0000000181AF7A20
			internal void CompileTotalDigitsFacet(XmlSchemaFacet facet); // 0x0000000181AF8200-0x0000000181AF8620
			internal void CompileFractionDigitsFacet(XmlSchemaFacet facet); // 0x0000000181AF6760-0x0000000181AF6AA0
			internal void FinishFacetCompile(); // 0x0000000181AF90C0-0x0000000181AF9410
			private void CheckValue(object value, XmlSchemaFacet facet); // 0x0000000181AF59B0-0x0000000181AF6060
			internal void CompileFacetCombinations(); // 0x0000000181AF61F0-0x0000000181AF6760
			private void CopyFacetsFromBaseType(); // 0x0000000181AF8A80-0x0000000181AF90C0
			private object ParseFacetValue(XmlSchemaDatatype datatype, XmlSchemaFacet facet, string code, IXmlNamespaceResolver nsmgr, XmlNameTable nameTable); // 0x0000000181AF9410-0x0000000181AF95D0
			private static string Preprocess(string pattern); // 0x0000000181AF95D0-0x0000000181AF9900
			private void CheckProhibitedFlag(XmlSchemaFacet facet, RestrictionFlags flag, string errorCode); // 0x0000000181AF5910-0x0000000181AF59B0
			private void CheckDupFlag(XmlSchemaFacet facet, RestrictionFlags flag, string errorCode); // 0x0000000181AF5890-0x0000000181AF5910
			private void SetFlag(XmlSchemaFacet facet, RestrictionFlags flag); // 0x0000000181AF9930-0x0000000181AF9990
			private void SetFlag(RestrictionFlags flag); // 0x0000000181AF9900-0x0000000181AF9930
		}
	
		// Constructors
		protected FacetsChecker(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal virtual Exception CheckLexicalFacets(ref string parseString, XmlSchemaDatatype datatype); // 0x0000000181AF4E70-0x0000000181AF50D0
		internal virtual Exception CheckValueFacets(object value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal virtual Exception CheckValueFacets(decimal value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal virtual Exception CheckValueFacets(long value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal virtual Exception CheckValueFacets(int value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal virtual Exception CheckValueFacets(short value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal virtual Exception CheckValueFacets(DateTime value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal virtual Exception CheckValueFacets(double value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal virtual Exception CheckValueFacets(float value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal virtual Exception CheckValueFacets(string value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal virtual Exception CheckValueFacets(byte[] value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal virtual Exception CheckValueFacets(TimeSpan value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal virtual Exception CheckValueFacets(XmlQualifiedName value, XmlSchemaDatatype datatype); // 0x00000001802E7860-0x00000001802E7870
		internal void CheckWhitespaceFacets(ref string s, XmlSchemaDatatype datatype); // 0x0000000181AF5240-0x0000000181AF5340
		internal Exception CheckPatternFacets(RestrictionFacets restriction, string value); // 0x0000000181AF50D0-0x0000000181AF5240
		internal virtual bool MatchEnumeration(object value, ArrayList enumeration, XmlSchemaDatatype datatype); // 0x00000001802E7840-0x00000001802E7850
		internal virtual RestrictionFacets ConstructRestriction(DatatypeImplementation datatype, XmlSchemaObjectCollection facets, XmlNameTable nameTable); // 0x0000000181AF5340-0x0000000181AF5770
		internal static decimal Power(int x, int y); // 0x0000000181AF5770-0x0000000181AF5890
	}
}
