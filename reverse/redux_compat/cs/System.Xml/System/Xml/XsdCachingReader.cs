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
	[DefaultMember("Item")]
	internal class XsdCachingReader : XmlReader, IXmlLineInfo // TypeDefIndex: 6805
	{
		// Fields
		private XmlReader coreReader; // 0x10
		private XmlNameTable coreReaderNameTable; // 0x18
		private ValidatingReaderNodeData[] contentEvents; // 0x20
		private ValidatingReaderNodeData[] attributeEvents; // 0x28
		private ValidatingReaderNodeData cachedNode; // 0x30
		private CachingReaderState cacheState; // 0x38
		private int contentIndex; // 0x3C
		private int attributeCount; // 0x40
		private bool returnOriginalStringValues; // 0x44
		private CachingEventHandler cacheHandler; // 0x48
		private int currentAttrIndex; // 0x50
		private int currentContentIndex; // 0x54
		private bool readAhead; // 0x58
		private IXmlLineInfo lineInfo; // 0x60
		private ValidatingReaderNodeData textNode; // 0x68
	
		// Properties
		public override XmlReaderSettings Settings { get; } // 0x0000000181738F00-0x0000000181738F30 
		public override XmlNodeType NodeType { get; } // 0x0000000181A6EAB0-0x0000000181A6EAD0 
		public override string Name { get; } // 0x0000000181A6EA60-0x0000000181A6EA90 
		public override string LocalName { get; } // 0x0000000181A6EA40-0x0000000181A6EA60 
		public override string NamespaceURI { get; } // 0x0000000181A6EA90-0x0000000181A6EAB0 
		public override string Prefix { get; } // 0x0000000181A6EAD0-0x0000000181A6EAF0 
		public override string Value { get; } // 0x0000000181A6EAF0-0x0000000181A6EB20 
		public override int Depth { get; } // 0x0000000181A6E9E0-0x0000000181A6EA00 
		public override string BaseURI { get; } // 0x00000001818C1720-0x00000001818C1750 
		public override bool IsEmptyElement { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override bool IsDefault { get; } // 0x00000001802E7840-0x00000001802E7850 
		public override char QuoteChar { get; } // 0x0000000181501A70-0x0000000181501AA0 
		public override XmlSpace XmlSpace { get; } // 0x00000001815019B0-0x00000001815019E0 
		public override string XmlLang { get; } // 0x0000000181501A40-0x0000000181501A70 
		public override int AttributeCount { get; } // 0x000000018033D790-0x000000018033D7A0 
		public override bool EOF { get; } // 0x0000000181A6EA00-0x0000000181A6EA40 
		public override ReadState ReadState { get; } // 0x00000001818C18A0-0x00000001818C18D0 
		public override XmlNameTable NameTable { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		int IXmlLineInfo.LineNumber { get; } // 0x0000000181A6E8A0-0x0000000181A6E8C0 
		int IXmlLineInfo.LinePosition { get; } // 0x0000000181A6E8C0-0x0000000181A6E8E0 
	
		// Nested types
		private enum CachingReaderState // TypeDefIndex: 6806
		{
			None = 0,
			Init = 1,
			Record = 2,
			Replay = 3,
			ReaderClosed = 4,
			Error = 5
		}
	
		// Constructors
		internal XsdCachingReader(XmlReader reader, IXmlLineInfo lineInfo, CachingEventHandler handlerMethod); // 0x0000000181A6E8E0-0x0000000181A6E9E0
	
		// Methods
		private void Init(); // 0x0000000181A6D930-0x0000000181A6DAE0
		internal void Reset(XmlReader reader); // 0x0000000181A6E540-0x0000000181A6E570
		public override string GetAttribute(string name); // 0x0000000181A6D8A0-0x0000000181A6D930
		public override string GetAttribute(string name, string namespaceURI); // 0x0000000181A6D790-0x0000000181A6D8A0
		public override string GetAttribute(int i); // 0x0000000181A6D700-0x0000000181A6D790
		public override bool MoveToAttribute(string name); // 0x0000000181A6DB80-0x0000000181A6DC10
		public override void MoveToAttribute(int i); // 0x0000000181A6DAE0-0x0000000181A6DB80
		public override bool MoveToFirstAttribute(); // 0x0000000181A6DC60-0x0000000181A6DCB0
		public override bool MoveToNextAttribute(); // 0x0000000181A6DCB0-0x0000000181A6DD10
		public override bool MoveToElement(); // 0x0000000181A6DC10-0x0000000181A6DC60
		public override bool Read(); // 0x0000000181A6DE00-0x0000000181A6E180
		internal ValidatingReaderNodeData RecordTextNode(string textValue, string originalStringValue, int depth, int lineNo, int linePos); // 0x0000000181A6E4C0-0x0000000181A6E540
		internal void SwitchTextNodeAndEndElement(string textValue, string originalStringValue); // 0x0000000181A6E720-0x0000000181A6E8A0
		internal void RecordEndElementNode(); // 0x0000000181A6E360-0x0000000181A6E4C0
		public override void Close(); // 0x0000000181A6D470-0x0000000181A6D4B0
		public override void Skip(); // 0x0000000181A6E5E0-0x0000000181A6E720
		public override string LookupNamespace(string prefix); // 0x00000001815BE350-0x00000001815BE380
		public override void ResolveEntity(); // 0x0000000181A6E570-0x0000000181A6E5B0
		public override bool ReadAttributeValue(); // 0x0000000181A6DD10-0x0000000181A6DE00
		bool IXmlLineInfo.HasLineInfo(); // 0x00000001802E7990-0x00000001802E79A0
		internal void SetToReplayMode(); // 0x0000000181A6E5B0-0x0000000181A6E5E0
		internal XmlReader GetCoreReader(); // 0x0000000180377550-0x0000000180377560
		internal IXmlLineInfo GetLineInfo(); // 0x0000000180333260-0x0000000180333490
		private void ClearAttributesInfo(); // 0x0000000181A6D460-0x0000000181A6D470
		private ValidatingReaderNodeData AddAttribute(int attIndex); // 0x0000000181A6D140-0x0000000181A6D2D0
		private ValidatingReaderNodeData AddContent(XmlNodeType nodeType); // 0x0000000181A6D2D0-0x0000000181A6D460
		private void RecordAttributes(); // 0x0000000181A6E180-0x0000000181A6E360
		private int GetAttributeIndexWithoutPrefix(string name); // 0x0000000181A6D630-0x0000000181A6D700
		private int GetAttributeIndexWithPrefix(string name); // 0x0000000181A6D570-0x0000000181A6D630
		private ValidatingReaderNodeData CreateDummyTextNode(string attributeValue, int depth); // 0x0000000181A6D4B0-0x0000000181A6D570
	}
}
