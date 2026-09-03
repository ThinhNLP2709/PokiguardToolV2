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
	internal class DateTimeFacetsChecker : FacetsChecker // TypeDefIndex: 7119
	{
		// Constructors
		public DateTimeFacetsChecker(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal override Exception CheckValueFacets(object value, XmlSchemaDatatype datatype); // 0x0000000181AF17D0-0x0000000181AF1860
		internal override Exception CheckValueFacets(DateTime value, XmlSchemaDatatype datatype); // 0x0000000181AF1390-0x0000000181AF17D0
		internal override bool MatchEnumeration(object value, ArrayList enumeration, XmlSchemaDatatype datatype); // 0x0000000181AF1860-0x0000000181AF18F0
		private bool MatchEnumeration(DateTime value, ArrayList enumeration, XmlSchemaDatatype datatype); // 0x0000000181AF18F0-0x0000000181AF1A20
	}
}
