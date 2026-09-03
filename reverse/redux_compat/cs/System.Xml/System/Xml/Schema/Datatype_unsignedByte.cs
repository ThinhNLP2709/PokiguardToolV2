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
	internal class Datatype_unsignedByte : Datatype_unsignedShort // TypeDefIndex: 7102
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
		private static readonly FacetsChecker numeric10FacetsChecker; // 0x10
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AEFCB0-0x0000000181AEFD00 
		public override XmlTypeCode TypeCode { get; } // 0x00000001817ADEF0-0x00000001817ADF00 
		public override Type ValueType { get; } // 0x0000000181AEFD50-0x0000000181AEFDA0 
		internal override Type ListValueType { get; } // 0x0000000181AEFD00-0x0000000181AEFD50 
	
		// Constructors
		public Datatype_unsignedByte(); // 0x0000000181AEFC60-0x0000000181AEFCB0
		static Datatype_unsignedByte(); // 0x0000000181AEFAF0-0x0000000181AEFC60
	
		// Methods
		internal override int Compare(object value1, object value2); // 0x0000000181AEF930-0x0000000181AEF990
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEF990-0x0000000181AEFAF0
	}
}
