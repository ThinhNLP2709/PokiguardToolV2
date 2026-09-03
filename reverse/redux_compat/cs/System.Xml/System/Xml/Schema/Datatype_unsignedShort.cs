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
	internal class Datatype_unsignedShort : Datatype_unsignedInt // TypeDefIndex: 7101
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
		private static readonly FacetsChecker numeric10FacetsChecker; // 0x10
	
		// Properties
		internal override FacetsChecker FacetsChecker { get; } // 0x0000000181AF0AD0-0x0000000181AF0B20 
		public override XmlTypeCode TypeCode { get; } // 0x0000000181AF0B70-0x0000000181AF0B80 
		public override Type ValueType { get; } // 0x0000000181AF0B80-0x0000000181AF0BD0 
		internal override Type ListValueType { get; } // 0x0000000181AF0B20-0x0000000181AF0B70 
	
		// Constructors
		public Datatype_unsignedShort(); // 0x0000000181AF0A50-0x0000000181AF0AD0
		static Datatype_unsignedShort(); // 0x0000000181AF08E0-0x0000000181AF0A50
	
		// Methods
		internal override int Compare(object value1, object value2); // 0x0000000181AF0720-0x0000000181AF0780
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AF0780-0x0000000181AF08E0
	}
}
