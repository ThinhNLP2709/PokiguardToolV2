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
	internal class Datatype_char : Datatype_anySimpleType // TypeDefIndex: 7108
	{
		// Fields
		private static readonly Type atomicValueType; // 0x00
		private static readonly Type listValueType; // 0x08
	
		// Properties
		public override Type ValueType { get; } // 0x0000000181AEAB40-0x0000000181AEAB90 
		internal override Type ListValueType { get; } // 0x0000000181AEAAF0-0x0000000181AEAB40 
		internal override RestrictionFlags ValidRestrictionFlags { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public Datatype_char(); // 0x0000000181AEAA70-0x0000000181AEAAF0
		static Datatype_char(); // 0x0000000181AEA9C0-0x0000000181AEAA70
	
		// Methods
		internal override int Compare(object value1, object value2); // 0x0000000181AEA750-0x0000000181AEA7C0
		public override object ParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr); // 0x0000000181AEA7C0-0x0000000181AEA910
		internal override Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue); // 0x0000000181AEA910-0x0000000181AEA9C0
	}
}
