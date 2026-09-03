/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class XsdValidatingReader : XmlReader, IXmlSchemaInfo, IXmlLineInfo, IXmlNamespaceResolver // TypeDefIndex: 6809
	{
		// Fields
		private XmlReader coreReader; // 0x10
		private IXmlNamespaceResolver coreReaderNSResolver; // 0x18
		private IXmlNamespaceResolver thisNSResolver; // 0x20
		private XmlSchemaValidator validator; // 0x28
		private XmlResolver xmlResolver; // 0x30
		private ValidationEventHandler validationEvent; // 0x38
		private ValidatingReaderState validationState; // 0x40
		private XmlValueGetter valueGetter; // 0x48
		private XmlNamespaceManager nsManager; // 0x50
		private bool manageNamespaces; // 0x58
		private bool processInlineSchema; // 0x59
		private bool replayCache; // 0x5A
		private ValidatingReaderNodeData cachedNode; // 0x60
		private AttributePSVIInfo attributePSVI; // 0x68
		private int attributeCount; // 0x70
		private int coreReaderAttributeCount; // 0x74
		private int currentAttrIndex; // 0x78
		private AttributePSVIInfo[] attributePSVINodes; // 0x80
		private ArrayList defaultAttributes; // 0x88
		private Parser inlineSchemaParser; // 0x90
		private object atomicValue; // 0x98
		private XmlSchemaInfo xmlSchemaInfo; // 0xA0
		private string originalAtomicValueString; // 0xA8
		private XmlNameTable coreReaderNameTable; // 0xB0
		private XsdCachingReader cachingReader; // 0xB8
		private ValidatingReaderNodeData textNode; // 0xC0
		private string NsXmlNs; // 0xC8
		private string NsXs; // 0xD0
		private string NsXsi; // 0xD8
		private string XsiType; // 0xE0
		private string XsiNil; // 0xE8
		private string XsdSchema; // 0xF0
		private string XsiSchemaLocation; // 0xF8
		private string XsiNoNamespaceSchemaLocation; // 0x100
		private XmlCharType xmlCharType; // 0x108
		private IXmlLineInfo lineInfo; // 0x110
		private ReadContentAsBinaryHelper readBinaryHelper; // 0x118
		private ValidatingReaderState savedState; // 0x120
		private static Type TypeOfString; // 0x00
	
		// Properties
		public override XmlReaderSettings Settings { get; } // 0x0000000181A731E0-0x0000000181A732C0 
		public override XmlNodeType NodeType { get; } // 0x0000000181A730B0-0x0000000181A73150 
		public override string Name { get; } // 0x0000000181A72F20-0x0000000181A73060 
		public override string LocalName { get; } // 0x0000000181A72ED0-0x0000000181A72F20 
		public override string NamespaceURI { get; } // 0x0000000181A73060-0x0000000181A730B0 
		public override string Prefix { get; } // 0x0000000181A73150-0x0000000181A731A0 
		public override string Value { get; } // 0x0000000181A733A0-0x0000000181A733F0 
		public override int Depth { get; } // 0x0000000181A72D80-0x0000000181A72DD0 
		public override string BaseURI { get; } // 0x00000001818C1720-0x00000001818C1750 
		public override bool IsEmptyElement { get; } // 0x00000001818C1810-0x00000001818C1840 
		public override bool IsDefault { get; } // 0x0000000181A72DD0-0x0000000181A72E10 
		public override char QuoteChar { get; } // 0x0000000181501A70-0x0000000181501AA0 
		public override XmlSpace XmlSpace { get; } // 0x00000001815019B0-0x00000001815019E0 
		public override string XmlLang { get; } // 0x0000000181501A40-0x0000000181501A70 
		public override IXmlSchemaInfo SchemaInfo { get; } // 0x0000000180370C60-0x0000000180370C70 
		public override Type ValueType { get; } // 0x0000000181A732C0-0x0000000181A733A0 
		public override int AttributeCount { get; } // 0x0000000180CC2260-0x0000000180CC2270 
		public override bool EOF { get; } // 0x00000001818C17B0-0x00000001818C17E0 
		public override ReadState ReadState { get; } // 0x0000000181A731A0-0x0000000181A731E0 
		public override XmlNameTable NameTable { get; } // 0x00000001806BAE60-0x00000001806BAE70 
		bool IXmlSchemaInfo.IsDefault { get; } // 0x0000000181A72490-0x0000000181A72520 
		bool IXmlSchemaInfo.IsNil { get; } // 0x0000000181A72520-0x0000000181A72570 
		XmlSchemaValidity IXmlSchemaInfo.Validity { get; } // 0x0000000181A72840-0x0000000181A728F0 
		XmlSchemaSimpleType IXmlSchemaInfo.MemberType { get; } // 0x0000000181A72570-0x0000000181A72730 
		XmlSchemaType IXmlSchemaInfo.SchemaType { get; } // 0x0000000181A727E0-0x0000000181A72840 
		XmlSchemaElement IXmlSchemaInfo.SchemaElement { get; } // 0x0000000181A72780-0x0000000181A727E0 
		XmlSchemaAttribute IXmlSchemaInfo.SchemaAttribute { get; } // 0x0000000181A72730-0x0000000181A72780 
		public int LineNumber { get; } // 0x0000000181A72E10-0x0000000181A72E70 
		public int LinePosition { get; } // 0x0000000181A72E70-0x0000000181A72ED0 
		private XmlSchemaInfo AttributeSchemaInfo { get; } // 0x0000000181A72D60-0x0000000181A72D80 
	
		// Nested types
		private enum ValidatingReaderState // TypeDefIndex: 6810
		{
			OnReadAttributeValue = -2,
			OnDefaultAttribute = -1,
			None = 0,
			Init = 1,
			Read = 2,
			OnAttribute = 3,
			ClearAttributes = 4,
			ParseInlineSchema = 5,
			ReadAhead = 6,
			OnReadBinaryContent = 7,
			ReaderClosed = 8,
			EOF = 9,
			Error = 10
		}
	
		// Constructors
		internal XsdValidatingReader(XmlReader reader, XmlResolver xmlResolver, XmlReaderSettings readerSettings, XmlSchemaObject partialValidationType); // 0x0000000181A72B30-0x0000000181A72D40
		internal XsdValidatingReader(XmlReader reader, XmlResolver xmlResolver, XmlReaderSettings readerSettings); // 0x0000000181A72D40-0x0000000181A72D60
	
		// Methods
		private void Init(); // 0x0000000181A6FEB0-0x0000000181A702A0
		private void SetupValidator(XmlReaderSettings readerSettings, XmlReader reader, XmlSchemaObject partialValidationType); // 0x0000000181A71EA0-0x0000000181A720F0
		public override string GetAttribute(string name); // 0x0000000181A6F2B0-0x0000000181A6F330
		public override string GetAttribute(string name, string namespaceURI); // 0x0000000181A6F330-0x0000000181A6F440
		public override string GetAttribute(int i); // 0x0000000181A6F1C0-0x0000000181A6F2B0
		public override bool MoveToAttribute(string name); // 0x0000000181A70350-0x0000000181A70440
		public override void MoveToAttribute(int i); // 0x0000000181A70440-0x0000000181A70670
		public override bool MoveToFirstAttribute(); // 0x0000000181A706D0-0x0000000181A708C0
		public override bool MoveToNextAttribute(); // 0x0000000181A708C0-0x0000000181A70AB0
		public override bool MoveToElement(); // 0x0000000181A70670-0x0000000181A706D0
		public override bool Read(); // 0x0000000181A71B80-0x0000000181A71E60
		public override void Close(); // 0x0000000181A6EE20-0x0000000181A6EE60
		public override void Skip(); // 0x0000000181A720F0-0x0000000181A72280
		public override string LookupNamespace(string prefix); // 0x0000000181A702F0-0x0000000181A70350
		public override void ResolveEntity(); // 0x0000000181A71E60-0x0000000181A71EA0
		public override bool ReadAttributeValue(); // 0x0000000181A71A00-0x0000000181A71B80
		public bool HasLineInfo(); // 0x00000001802E7990-0x00000001802E79A0
		IDictionary<string, string> IXmlNamespaceResolver.GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181A72280-0x0000000181A72370
		string IXmlNamespaceResolver.LookupNamespace(string prefix); // 0x0000000181A72370-0x0000000181A72400
		string IXmlNamespaceResolver.LookupPrefix(string namespaceName); // 0x0000000181A72400-0x0000000181A72490
		private object GetStringValue(); // 0x0000000181501AA0-0x0000000181501AD0
		private void ProcessReaderEvent(); // 0x0000000181A71570-0x0000000181A71780
		private void ProcessElementEvent(); // 0x0000000181A70AB0-0x0000000181A71110
		private void ProcessEndElementEvent(); // 0x0000000181A71110-0x0000000181A71440
		private void ValidateAttributes(); // 0x0000000181A728F0-0x0000000181A72B30
		private void ClearAttributesInfo(); // 0x0000000181A6EDC0-0x0000000181A6EE20
		private AttributePSVIInfo GetAttributePSVI(string name); // 0x0000000181A6EFE0-0x0000000181A6F1C0
		private AttributePSVIInfo GetAttributePSVI(string localName, string ns); // 0x0000000181A6EF30-0x0000000181A6EFE0
		private ValidatingReaderNodeData GetDefaultAttribute(string name, bool updatePosition); // 0x0000000181A6F880-0x0000000181A6F9D0
		private ValidatingReaderNodeData GetDefaultAttribute(string attrLocalName, string ns, bool updatePosition); // 0x0000000181A6F710-0x0000000181A6F880
		private AttributePSVIInfo AddAttributePSVI(int attIndex); // 0x0000000181A6EB20-0x0000000181A6ED60
		private bool IsXSDRoot(string localName, string ns); // 0x0000000181A702A0-0x0000000181A702F0
		private void ProcessInlineSchema(); // 0x0000000181A71440-0x0000000181A71570
		private void ReadAheadForMemberType(); // 0x0000000181A71780-0x0000000181A71A00
		private void GetIsDefault(); // 0x0000000181A6F9D0-0x0000000181A6FD10
		private void GetMemberType(); // 0x0000000181A6FD10-0x0000000181A6FE30
		private XsdCachingReader GetCachingReader(); // 0x0000000181A6F440-0x0000000181A6F710
		internal ValidatingReaderNodeData CreateDummyTextNode(string attributeValue, int depth); // 0x0000000181A6EE60-0x0000000181A6EF30
		internal void CachingCallBack(XsdCachingReader cachingReader); // 0x0000000181A6ED60-0x0000000181A6EDC0
		private string GetOriginalAtomicValueStringOfElement(); // 0x0000000181A6FE30-0x0000000181A6FEB0
	}
}
