/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class XmlTextReader : XmlReader, IXmlLineInfo, IXmlNamespaceResolver // TypeDefIndex: 6756
	{
		// Fields
		private XmlTextReaderImpl impl; // 0x10
	
		// Properties
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
		public override bool CanResolveEntity { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override bool CanReadValueChunk { get; } // 0x00000001802E7840-0x00000001802E7850 
		public int LineNumber { get; } // 0x0000000181A46890-0x0000000181A468B0 
		public int LinePosition { get; } // 0x0000000181A468B0-0x0000000181A468D0 
		public bool Namespaces { get; } // 0x0000000181A33A10-0x0000000181A33A30 
		public bool Normalization { get; set; } // 0x0000000181A33A30-0x0000000181A33A50 0x0000000181A46920-0x0000000181A46940
		public WhitespaceHandling WhitespaceHandling { set; } // 0x0000000181A46940-0x0000000181A46960
		public EntityHandling EntityHandling { set; } // 0x0000000181A46900-0x0000000181A46920
		public XmlResolver XmlResolver { set; } // 0x0000000181A46960-0x0000000181A46980
		internal XmlTextReaderImpl Impl { get; } // 0x0000000180377550-0x0000000180377560 
		internal override XmlNamespaceManager NamespaceManager { get; } // 0x0000000181A468D0-0x0000000181A46900 
		internal bool XmlValidatingReaderCompatibilityMode { set; } // 0x0000000181A46980-0x0000000181A46E00
		internal override IDtdInfo DtdInfo { get; } // 0x0000000181A46860-0x0000000181A46890 
	
		// Constructors
		public XmlTextReader(Stream input); // 0x0000000181A46520-0x0000000181A465E0
		public XmlTextReader(string url, Stream input, XmlNameTable nt); // 0x0000000181A46770-0x0000000181A46860
		public XmlTextReader(TextReader input); // 0x0000000181A466B0-0x0000000181A46770
		public XmlTextReader(TextReader input, XmlNameTable nt); // 0x0000000181A465E0-0x0000000181A466B0
	
		// Methods
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
		public override string LookupNamespace(string prefix); // 0x0000000181A46470-0x0000000181A464B0
		public override void ResolveEntity(); // 0x00000001818C1650-0x00000001818C1680
		public override string ReadString(); // 0x0000000181A464B0-0x0000000181A464E0
		public bool HasLineInfo(); // 0x00000001802E7990-0x00000001802E79A0
		IDictionary<string, string> IXmlNamespaceResolver.GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181A464E0-0x0000000181A46500
		string IXmlNamespaceResolver.LookupNamespace(string prefix); // 0x00000001815BE350-0x00000001815BE380
		string IXmlNamespaceResolver.LookupPrefix(string namespaceName); // 0x0000000181A46500-0x0000000181A46520
	}
}
