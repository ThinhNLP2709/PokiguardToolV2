/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	[Obsolete("Use XmlReader created by XmlReader.Create() method using appropriate XmlReaderSettings instead. https://go.microsoft.com/fwlink/?linkid=14202")]
	public class XmlValidatingReader : XmlReader // TypeDefIndex: 6782
	{
		// Fields
		private XmlValidatingReaderImpl impl; // 0x10
	
		// Properties
		public override XmlNodeType NodeType { get; } // 0x00000001818C1870-0x00000001818C18A0 
		public override string LocalName { get; } // 0x00000001818C1840-0x00000001818C1870 
		public override string NamespaceURI { get; } // 0x00000001815019E0-0x0000000181501A10 
		public override string Prefix { get; } // 0x0000000181501AD0-0x0000000181501B00 
		public override string Value { get; } // 0x0000000181501AA0-0x0000000181501AD0 
		public override int Depth { get; } // 0x00000001818C1780-0x00000001818C17B0 
		public override string BaseURI { get; } // 0x00000001818C1720-0x00000001818C1750 
		public override bool IsEmptyElement { get; } // 0x00000001818C1810-0x00000001818C1840 
		public override int AttributeCount { get; } // 0x00000001818C16F0-0x00000001818C1720 
		public override bool EOF { get; } // 0x00000001818C17B0-0x00000001818C17E0 
		public override ReadState ReadState { get; } // 0x00000001818C18A0-0x00000001818C18D0 
		public override XmlNameTable NameTable { get; } // 0x0000000181781A40-0x0000000181781A70 
		public bool Namespaces { get; } // 0x0000000181A52620-0x0000000181A52650 
	
		// Methods
		public override string GetAttribute(string name); // 0x00000001818C1530-0x00000001818C1560
		public override string GetAttribute(string localName, string namespaceURI); // 0x00000001818C1500-0x00000001818C1530
		public override string GetAttribute(int i); // 0x00000001818C1560-0x00000001818C1590
		public override bool MoveToAttribute(string name); // 0x00000001818C1590-0x00000001818C15C0
		public override bool MoveToFirstAttribute(); // 0x00000001818C15C0-0x00000001818C15F0
		public override bool MoveToNextAttribute(); // 0x000000018159B4F0-0x000000018159B520
		public override bool MoveToElement(); // 0x0000000181465D40-0x0000000181465D70
		public override bool ReadAttributeValue(); // 0x0000000181781A10-0x0000000181781A40
		public override bool Read(); // 0x00000001818C1620-0x00000001818C1650
		public override string LookupNamespace(string prefix); // 0x0000000181A46470-0x0000000181A464B0
		public override void ResolveEntity(); // 0x00000001818C1650-0x00000001818C1680
	}
}
