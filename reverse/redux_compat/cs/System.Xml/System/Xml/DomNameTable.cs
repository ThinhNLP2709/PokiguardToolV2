/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class DomNameTable // TypeDefIndex: 6811
	{
		// Fields
		private XmlName[] entries; // 0x10
		private int count; // 0x18
		private int mask; // 0x1C
		private XmlDocument ownerDocument; // 0x20
		private XmlNameTable nameTable; // 0x28
	
		// Constructors
		public DomNameTable(XmlDocument document); // 0x0000000181A5A970-0x0000000181A5AA10
	
		// Methods
		public XmlName GetName(string prefix, string localName, string ns, IXmlSchemaInfo schemaInfo); // 0x0000000181A5A6C0-0x0000000181A5A800
		public XmlName AddName(string prefix, string localName, string ns, IXmlSchemaInfo schemaInfo); // 0x0000000181A5A2F0-0x0000000181A5A6C0
		private void Grow(); // 0x0000000181A5A800-0x0000000181A5A970
	}
}
