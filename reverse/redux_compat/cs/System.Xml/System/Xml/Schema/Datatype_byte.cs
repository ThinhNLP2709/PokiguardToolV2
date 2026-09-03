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
	internal class Datatype_byte : Datatype_short // TypeDefIndex: 7097
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
		private static readonly FacetsChecker numeric10FacetsChecker; // 0x10
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AEA660-0x0000000181AEA6B0 
		public override XmlTypeCode TypeCode { get; } // 0x0000000181789710-0x0000000181789720 
		public override Type ValueType { get; } // 0x0000000181AEA700-0x0000000181AEA750 
		internal override Type ListValueType { get; } // 0x0000000181AEA6B0-0x0000000181AEA700 
	
		// Constructors
		public Datatype_byte(); // 0x0000000181AEA5E0-0x0000000181AEA660
		static Datatype_byte(); // 0x0000000181AEA480-0x0000000181AEA5E0
	
		// Methods
		internal override int Compare(object value1, object value2); // 0x0000000181AEA2C0-0x0000000181AEA320
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEA320-0x0000000181AEA480
	}
}
