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
	internal class DurationFacetsChecker : FacetsChecker // TypeDefIndex: 7118
	{
		// Constructors
		public DurationFacetsChecker(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal override Exception CheckValueFacets(object value, XmlSchemaDatatype datatype); // 0x0000000181AF4BD0-0x0000000181AF4CE0
		internal override Exception CheckValueFacets(TimeSpan value, XmlSchemaDatatype datatype); // 0x0000000181AF4830-0x0000000181AF4BD0
		internal override bool MatchEnumeration(object value, ArrayList enumeration, XmlSchemaDatatype datatype); // 0x0000000181AF4CE0-0x0000000181AF4D60
		private bool MatchEnumeration(TimeSpan value, ArrayList enumeration); // 0x0000000181AF4D60-0x0000000181AF4E70
	}
}
