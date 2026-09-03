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

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class DataTextReader : XmlReader // TypeDefIndex: 11344
	{
		// Fields
		private XmlReader _xmlreader; // 0x10
	
		// Properties
		public override XmlReaderSettings Settings { get; } // 0x0000000181738F00-0x0000000181738F30 
		public override XmlNodeType NodeType { get; } // 0x00000001818C1870-0x00000001818C18A0 
		public override string Name { get; } // 0x0000000181770170-0x00000001817701A0 
		public override string LocalName { get; } // 0x00000001818C1840-0x00000001818C1870 
		public override string NamespaceURI { get; } // 0x00000001815019E0-0x0000000181501A10 
		public override string Prefix { get; } // 0x0000000181501AD0-0x0000000181501B00 
		public override string Value { get; } // 0x0000000181501AA0-0x0000000181501AD0 
		public override int Depth { get; } // 0x00000001818C1780-0x00000001818C17B0 
		public override string BaseURI { get; } // 0x00000001818C1720-0x00000001818C1750 
		public override bool IsEmptyElement { get; } // 0x00000001818C1810-0x00000001818C1840 
		public override bool IsDefault { get; } // 0x00000001818C17E0-0x00000001818C1810 
		public override char QuoteChar { get; } // 0x0000000181501A70-0x0000000181501AA0 
		public override XmlSpace XmlSpace { get; } // 0x00000001815019B0-0x00000001815019E0 
		public override string XmlLang { get; } // 0x0000000181501A40-0x0000000181501A70 
		public override int AttributeCount { get; } // 0x00000001818C16F0-0x00000001818C1720 
		public override bool EOF { get; } // 0x00000001818C17B0-0x00000001818C17E0 
		public override ReadState ReadState { get; } // 0x00000001818C18A0-0x00000001818C18D0 
		public override XmlNameTable NameTable { get; } // 0x0000000181781A40-0x0000000181781A70 
		public override bool CanResolveEntity { get; } // 0x00000001818C1750-0x00000001818C1780 
		public override bool CanReadValueChunk { get; } // 0x00000001815AE950-0x00000001815AE980 
	
		// Constructors
		private DataTextReader(XmlReader input); // 0x00000001818C1680-0x00000001818C16F0
	
		// Methods
		internal static XmlReader CreateReader(XmlReader xr); // 0x00000001818C1460-0x00000001818C1500
		public override string GetAttribute(string name); // 0x00000001818C1530-0x00000001818C1560
		public override string GetAttribute(string localName, string namespaceURI); // 0x00000001818C1500-0x00000001818C1530
		public override string GetAttribute(int i); // 0x00000001818C1560-0x00000001818C1590
		public override bool MoveToAttribute(string name); // 0x00000001818C1590-0x00000001818C15C0
		public override void MoveToAttribute(int i); // 0x0000000180A6BAA0-0x0000000180A6BAD0
		public override bool MoveToFirstAttribute(); // 0x00000001818C15C0-0x00000001818C15F0
		public override bool MoveToNextAttribute(); // 0x000000018159B4F0-0x000000018159B520
		public override bool MoveToElement(); // 0x0000000181465D40-0x0000000181465D70
		public override bool ReadAttributeValue(); // 0x0000000181781A10-0x0000000181781A40
		public override bool Read(); // 0x00000001818C1620-0x00000001818C1650
		public override void Close(); // 0x0000000181781A70-0x0000000181781AA0
		public override void Skip(); // 0x00000001815AE920-0x00000001815AE950
		public override string LookupNamespace(string prefix); // 0x00000001815BE350-0x00000001815BE380
		public override void ResolveEntity(); // 0x00000001818C1650-0x00000001818C1680
		public override string ReadString(); // 0x00000001818C15F0-0x00000001818C1620
	}
}
