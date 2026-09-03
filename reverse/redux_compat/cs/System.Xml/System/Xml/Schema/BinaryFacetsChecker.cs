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
	internal class BinaryFacetsChecker : FacetsChecker // TypeDefIndex: 7123
	{
		// Constructors
		public BinaryFacetsChecker(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		internal override Exception CheckValueFacets(object value, XmlSchemaDatatype datatype); // 0x0000000181975670-0x0000000181975710
		internal override Exception CheckValueFacets(byte[] value, XmlSchemaDatatype datatype); // 0x0000000181975710-0x00000001819758F0
		internal override bool MatchEnumeration(object value, ArrayList enumeration, XmlSchemaDatatype datatype); // 0x00000001819758F0-0x0000000181975A50
		private bool MatchEnumeration(byte[] value, ArrayList enumeration, XmlSchemaDatatype datatype); // 0x0000000181975A50-0x0000000181975B60
	}
}
