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
	internal class Datatype_long : Datatype_integer // TypeDefIndex: 7094
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
		private static readonly FacetsChecker numeric10FacetsChecker; // 0x10
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AEDE30-0x0000000181AEDE80 
		internal override bool HasValueFacets { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override XmlTypeCode TypeCode { get; } // 0x0000000181AEDED0-0x0000000181AEDEE0 
		public override Type ValueType { get; } // 0x0000000181AEDEE0-0x0000000181AEDF30 
		internal override Type ListValueType { get; } // 0x0000000181AEDE80-0x0000000181AEDED0 
	
		// Constructors
		public Datatype_long(); // 0x0000000181AEDAB0-0x0000000181AEDB00
		static Datatype_long(); // 0x0000000181AEDCC0-0x0000000181AEDE30
	
		// Methods
		internal override int Compare(object value1, object value2); // 0x0000000181AEDB00-0x0000000181AEDB60
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEDB60-0x0000000181AEDCC0
	}
}
