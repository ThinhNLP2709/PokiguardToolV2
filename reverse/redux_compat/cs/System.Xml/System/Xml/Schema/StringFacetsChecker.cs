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
using System.Text.RegularExpressions;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class StringFacetsChecker : FacetsChecker // TypeDefIndex: 7120
	{
		// Fields
		private static Regex languagePattern; // 0x00
	
		// Properties
		private static Regex LanguagePattern { get; } // 0x0000000181AFD5E0-0x0000000181AFD690 
	
		// Constructors
		public StringFacetsChecker(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal override Exception CheckValueFacets(object value, XmlSchemaDatatype datatype); // 0x0000000181AFCF30-0x0000000181AFCFC0
		internal override Exception CheckValueFacets(string value, XmlSchemaDatatype datatype); // 0x0000000181AFCF10-0x0000000181AFCF30
		internal Exception CheckValueFacets(string value, XmlSchemaDatatype datatype, bool verifyUri); // 0x0000000181AFCFC0-0x0000000181AFD210
		internal override bool MatchEnumeration(object value, ArrayList enumeration, XmlSchemaDatatype datatype); // 0x0000000181AFD3E0-0x0000000181AFD5E0
		private bool MatchEnumeration(string value, ArrayList enumeration, XmlSchemaDatatype datatype); // 0x0000000181AFD210-0x0000000181AFD3E0
		private Exception CheckBuiltInFacets(string s, XmlTypeCode typeCode, bool verifyUri); // 0x0000000181AFCC20-0x0000000181AFCF10
	}
}
