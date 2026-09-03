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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class Numeric2FacetsChecker : FacetsChecker // TypeDefIndex: 7117
	{
		// Constructors
		public Numeric2FacetsChecker(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal override Exception CheckValueFacets(object value, XmlSchemaDatatype datatype); // 0x0000000181AFB950-0x0000000181AFB9E0
		internal override Exception CheckValueFacets(double value, XmlSchemaDatatype datatype); // 0x0000000181AFB600-0x0000000181AFB930
		internal override Exception CheckValueFacets(float value, XmlSchemaDatatype datatype); // 0x0000000181AFB930-0x0000000181AFB950
		internal override bool MatchEnumeration(object value, ArrayList enumeration, XmlSchemaDatatype datatype); // 0x0000000181AFBAA0-0x0000000181AFBBC0
		private bool MatchEnumeration(double value, ArrayList enumeration, XmlValueConverter valueConverter); // 0x0000000181AFB9E0-0x0000000181AFBAA0
	}
}
