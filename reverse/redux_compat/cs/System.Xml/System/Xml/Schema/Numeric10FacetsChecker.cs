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
	internal class Numeric10FacetsChecker : FacetsChecker // TypeDefIndex: 7116
	{
		// Fields
		private static readonly char[] signs; // 0x00
		private decimal maxValue; // 0x10
		private decimal minValue; // 0x20
	
		// Constructors
		internal Numeric10FacetsChecker(decimal minVal, decimal maxVal); // 0x0000000181AFB5C0-0x0000000181AFB600
		static Numeric10FacetsChecker(); // 0x0000000181AFB520-0x0000000181AFB5C0
	
		// Methods
		internal override Exception CheckValueFacets(object value, XmlSchemaDatatype datatype); // 0x0000000181AFAAC0-0x0000000181AFAB60
		internal override Exception CheckValueFacets(decimal value, XmlSchemaDatatype datatype); // 0x0000000181AFAB60-0x0000000181AFB130
		internal override Exception CheckValueFacets(long value, XmlSchemaDatatype datatype); // 0x0000000181AFB1C0-0x0000000181AFB250
		internal override Exception CheckValueFacets(int value, XmlSchemaDatatype datatype); // 0x0000000181AFB130-0x0000000181AFB1C0
		internal override Exception CheckValueFacets(short value, XmlSchemaDatatype datatype); // 0x0000000181AFAA30-0x0000000181AFAAC0
		internal override bool MatchEnumeration(object value, ArrayList enumeration, XmlSchemaDatatype datatype); // 0x0000000181AFB250-0x0000000181AFB3F0
		internal bool MatchEnumeration(decimal value, ArrayList enumeration, XmlValueConverter valueConverter); // 0x0000000181AFB3F0-0x0000000181AFB520
		internal Exception CheckTotalAndFractionDigits(decimal value, int totalDigits, int fractionDigits, bool checkTotal, bool checkFraction); // 0x0000000181AFA710-0x0000000181AFAA30
	}
}
