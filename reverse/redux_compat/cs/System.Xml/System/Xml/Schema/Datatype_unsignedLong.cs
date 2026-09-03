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
	internal class Datatype_unsignedLong : Datatype_nonNegativeInteger // TypeDefIndex: 7099
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
		private static readonly FacetsChecker numeric10FacetsChecker; // 0x10
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AF0630-0x0000000181AF0680 
		public override XmlTypeCode TypeCode { get; } // 0x0000000180A2FA90-0x0000000180A2FAA0 
		public override Type ValueType { get; } // 0x0000000181AF06D0-0x0000000181AF0720 
		internal override Type ListValueType { get; } // 0x0000000181AF0680-0x0000000181AF06D0 
	
		// Constructors
		public Datatype_unsignedLong(); // 0x0000000181AF05B0-0x0000000181AF0630
		static Datatype_unsignedLong(); // 0x0000000181AF0430-0x0000000181AF05B0
	
		// Methods
		internal override int Compare(object value1, object value2); // 0x0000000181AF0220-0x0000000181AF0280
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AF0280-0x0000000181AF0430
	}
}
