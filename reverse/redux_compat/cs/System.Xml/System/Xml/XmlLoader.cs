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
	internal class XmlLoader // TypeDefIndex: 6829
	{
		// Fields
		private XmlDocument doc; // 0x10
		private XmlReader reader; // 0x18
		private bool preserveWhitespace; // 0x20
	
		// Constructors
		public XmlLoader(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal void Load(XmlDocument doc, XmlReader reader, bool preserveWhitespace); // 0x0000000181A6A660-0x0000000181A6A8E0
		private void LoadDocSequence(XmlDocument parentDoc); // 0x0000000181A685F0-0x0000000181A68670
		internal XmlNode ReadCurrentNode(XmlDocument doc, XmlReader reader); // 0x0000000181A6B150-0x0000000181A6B310
		private XmlNode LoadNode(bool skipOverWhitespace); // 0x0000000181A69F10-0x0000000181A6A660
		private XmlAttribute LoadAttributeNode(); // 0x0000000181A67B50-0x0000000181A67EE0
		private XmlAttribute LoadDefaultAttribute(); // 0x0000000181A68400-0x0000000181A685F0
		private void LoadAttributeValue(XmlNode parent, bool direct); // 0x0000000181A67EE0-0x0000000181A68210
		private XmlEntityReference LoadEntityReferenceNode(bool direct); // 0x0000000181A69500-0x0000000181A69750
		private XmlDeclaration LoadDeclarationNode(); // 0x0000000181A68210-0x0000000181A68400
		private XmlDocumentType LoadDocumentTypeNode(); // 0x0000000181A68670-0x0000000181A688C0
		private XmlNode LoadNodeDirect(); // 0x0000000181A69910-0x0000000181A69F10
		private XmlAttribute LoadAttributeNodeDirect(); // 0x0000000181A67980-0x0000000181A67B50
		internal void ParseDocumentType(XmlDocumentType dtNode); // 0x0000000181A6AB90-0x0000000181A6AC10
		private void ParseDocumentType(XmlDocumentType dtNode, bool bUseResolver, XmlResolver resolver); // 0x0000000181A6A8E0-0x0000000181A6AB90
		private void LoadDocumentType(IDtdInfo dtdInfo, XmlDocumentType dtNode); // 0x0000000181A688C0-0x0000000181A69500
		private XmlParserContext GetContext(XmlNode node); // 0x0000000181A670C0-0x0000000181A67980
		internal XmlNamespaceManager ParsePartialContent(XmlNode parentNode, string innerxmltext, XmlNodeType nt); // 0x0000000181A6AC10-0x0000000181A6AEA0
		internal void LoadInnerXmlElement(XmlElement node, string innerxmltext); // 0x0000000181A69770-0x0000000181A69910
		internal void LoadInnerXmlAttribute(XmlAttribute node, string innerxmltext); // 0x0000000181A69750-0x0000000181A69770
		private void RemoveDuplicateNamespace(XmlElement elem, XmlNamespaceManager mgr, bool fCheckElemAttrs); // 0x0000000181A6B310-0x0000000181A6B650
		private string EntitizeName(string name); // 0x0000000181A66A00-0x0000000181A66A50
		internal void ExpandEntity(XmlEntity ent); // 0x0000000181A67010-0x0000000181A670C0
		internal void ExpandEntityReference(XmlEntityReference eref); // 0x0000000181A66A50-0x0000000181A67010
		private XmlReader CreateInnerXmlReader(string xmlFragment, XmlNodeType nt, XmlParserContext context, XmlDocument doc); // 0x0000000181A66790-0x0000000181A66A00
		internal static void ParseXmlDeclarationValue(string strValue, out string version, out string encoding, out string standalone); // 0x0000000181A6AEA0-0x0000000181A6B150
		internal static Exception UnexpectedNodeType(XmlNodeType nodetype); // 0x0000000181A6B650-0x0000000181A6B730
	}
}
