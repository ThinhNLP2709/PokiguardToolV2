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
	internal class Datatype_unsignedInt : Datatype_unsignedLong // TypeDefIndex: 7100
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
		private static readonly FacetsChecker numeric10FacetsChecker; // 0x10
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AF0120-0x0000000181AF0170 
		public override XmlTypeCode TypeCode { get; } // 0x0000000181AF01C0-0x0000000181AF01D0 
		public override Type ValueType { get; } // 0x0000000181AF01D0-0x0000000181AF0220 
		internal override Type ListValueType { get; } // 0x0000000181AF0170-0x0000000181AF01C0 
	
		// Constructors
		public Datatype_unsignedInt(); // 0x0000000181AF00D0-0x0000000181AF0120
		static Datatype_unsignedInt(); // 0x0000000181AEFF60-0x0000000181AF00D0
	
		// Methods
		internal override int Compare(object value1, object value2); // 0x0000000181AEFDA0-0x0000000181AEFE00
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEFE00-0x0000000181AEFF60
	}
}
