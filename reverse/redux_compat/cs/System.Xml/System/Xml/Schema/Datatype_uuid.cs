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
	internal class Datatype_uuid : Datatype_anySimpleType // TypeDefIndex: 7110
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
	
		// Properties
		public override Type ValueType { get; } // 0x0000000181AF1030-0x0000000181AF1080 
		internal override Type ListValueType { get; } // 0x0000000181AF0FE0-0x0000000181AF1030 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public Datatype_uuid(); // 0x0000000181AF0F60-0x0000000181AF0FE0
		static Datatype_uuid(); // 0x0000000181AF0EB0-0x0000000181AF0F60
	
		// Methods
		internal override int Compare(object value1, object value2); // 0x0000000181AF0C30-0x0000000181AF0CA0
		public override object ParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr); // 0x0000000181AF0CA0-0x0000000181AF0E00
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AF0E00-0x0000000181AF0EB0
	}
}
