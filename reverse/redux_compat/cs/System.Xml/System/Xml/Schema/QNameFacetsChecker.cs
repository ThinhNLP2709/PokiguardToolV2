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
	internal class QNameFacetsChecker : FacetsChecker // TypeDefIndex: 7121
	{
		// Constructors
		public QNameFacetsChecker(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		internal override Exception CheckValueFacets(object value, XmlSchemaDatatype datatype); // 0x0000000181983CF0-0x0000000181983E20
		internal override Exception CheckValueFacets(XmlQualifiedName value, XmlSchemaDatatype datatype); // 0x0000000181983B00-0x0000000181983CF0
		internal override bool MatchEnumeration(object value, ArrayList enumeration, XmlSchemaDatatype datatype); // 0x0000000181983F30-0x0000000181984110
		private bool MatchEnumeration(XmlQualifiedName value, ArrayList enumeration); // 0x0000000181983E20-0x0000000181983F30
	}
}
