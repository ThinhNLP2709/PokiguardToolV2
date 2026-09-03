/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
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
	internal class XmlNodeReaderNavigator // TypeDefIndex: 6839
	{
		// Fields
		private XmlNode curNode; // 0x10
		private XmlNode elemNode; // 0x18
		private XmlNode logNode; // 0x20
		private int attrIndex; // 0x28
		private int logAttrIndex; // 0x2C
		private XmlNameTable nameTable; // 0x30
		private XmlDocument doc; // 0x38
		private int nAttrInd; // 0x40
		private int nDeclarationAttrCount; // 0x44
		private int nDocTypeAttrCount; // 0x48
		private int nLogLevel; // 0x4C
		private int nLogAttrInd; // 0x50
		private bool bLogOnAttrVal; // 0x54
		private bool bCreatedOnAttribute; // 0x55
		internal VirtualAttribute[] decNodeAttributes; // 0x58
		internal VirtualAttribute[] docTypeNodeAttributes; // 0x60
		private bool bOnAttrVal; // 0x68
	
		// Properties
		public XmlNodeType NodeType { get; } // 0x0000000181A85A20-0x0000000181A85A70 
		public string NamespaceURI { get; } // 0x0000000181781A70-0x0000000181781AA0 
		public string Name { get; } // 0x0000000181A85900-0x0000000181A85A20 
		public string LocalName { get; } // 0x0000000181A85840-0x0000000181A85900 
		internal bool CreatedOnAttribute { get; } // 0x0000000181A856A0-0x0000000181A856B0 
		public string Prefix { get; } // 0x00000001818C18A0-0x00000001818C18D0 
		public string Value { get; } // 0x0000000181A85A70-0x0000000181A85D00 
		public string BaseURI { get; } // 0x00000001818C15F0-0x00000001818C1620 
		public XmlSpace XmlSpace { get; } // 0x0000000181A85D30-0x0000000181A85D60 
		public string XmlLang { get; } // 0x0000000181A85D00-0x0000000181A85D30 
		public bool IsEmptyElement { get; } // 0x0000000181A85760-0x0000000181A85800 
		public bool IsDefault { get; } // 0x0000000181A856B0-0x0000000181A85760 
		public IXmlSchemaInfo SchemaInfo { get; } // 0x00000001817BECF0-0x00000001817BED20 
		public XmlNameTable NameTable { get; } // 0x000000018031E110-0x000000018031E120 
		public int AttributeCount { get; } // 0x0000000181A85550-0x0000000181A856A0 
		private bool IsOnDeclOrDocType { get; } // 0x0000000181A85800-0x0000000181A85840 
		public XmlDocument Document { get; } // 0x00000001803272A0-0x00000001803272B0 
	
		// Nested types
		internal struct VirtualAttribute // TypeDefIndex: 6840
		{
			// Fields
			internal string name; // 0x00
			internal string value; // 0x08
	
			// Constructors
			internal VirtualAttribute(string name, string value); // 0x0000000180CC3FE0-0x0000000180CC4020
		}
	
		// Constructors
		public XmlNodeReaderNavigator(XmlNode node); // 0x0000000181A851C0-0x0000000181A85550
	
		// Methods
		private bool IsLocalNameEmpty(XmlNodeType nt); // 0x0000000181A83A50-0x0000000181A83AA0
		private void CheckIndexCondition(int attributeIndex); // 0x0000000181A82330-0x0000000181A823A0
		private void InitDecAttr(); // 0x0000000181A83690-0x0000000181A838D0
		public string GetDeclarationAttr(XmlDeclaration decl, string name); // 0x0000000181A82EF0-0x0000000181A82FD0
		public string GetDeclarationAttr(int i); // 0x0000000181A82EA0-0x0000000181A82EF0
		public int GetDecAttrInd(string name); // 0x0000000181A82E10-0x0000000181A82EA0
		private void InitDocTypeAttr(); // 0x0000000181A838D0-0x0000000181A83A50
		public string GetDocumentTypeAttr(XmlDocumentType docType, string name); // 0x0000000181A830B0-0x0000000181A83150
		public string GetDocumentTypeAttr(int i); // 0x0000000181A83060-0x0000000181A830B0
		public int GetDocTypeAttrInd(string name); // 0x0000000181A82FD0-0x0000000181A83060
		private string GetAttributeFromElement(XmlElement elem, string name); // 0x0000000181A82560-0x0000000181A825C0
		public string GetAttribute(string name); // 0x0000000181A825C0-0x0000000181A828A0
		private string GetAttributeFromElement(XmlElement elem, string name, string ns); // 0x0000000181A82500-0x0000000181A82560
		public string GetAttribute(string name, string ns); // 0x0000000181A828A0-0x0000000181A82BB0
		public string GetAttribute(int attributeIndex); // 0x0000000181A82BB0-0x0000000181A82E10
		public void LogMove(int level); // 0x0000000181A83AA0-0x0000000181A83AF0
		public void RollBackMove(ref int level); // 0x0000000181A85170-0x0000000181A851C0
		public void ResetToAttribute(ref int level); // 0x0000000181A85090-0x0000000181A85170
		public void ResetMove(ref int level, ref XmlNodeType nt); // 0x0000000181A84DF0-0x0000000181A85090
		public bool MoveToAttribute(string name); // 0x0000000181A84750-0x0000000181A84770
		private bool MoveToAttributeFromElement(XmlElement elem, string name, string ns); // 0x0000000181A84230-0x0000000181A84320
		public bool MoveToAttribute(string name, string namespaceURI); // 0x0000000181A84510-0x0000000181A84750
		public void MoveToAttribute(int attributeIndex); // 0x0000000181A84320-0x0000000181A84510
		public bool MoveToNextAttribute(ref int level); // 0x0000000181A84860-0x0000000181A84A60
		public bool MoveToParent(); // 0x0000000181A84B50-0x0000000181A84BB0
		public bool MoveToFirstChild(); // 0x0000000181A84800-0x0000000181A84860
		private bool MoveToNextSibling(XmlNode node); // 0x0000000181A84A60-0x0000000181A84AC0
		public bool MoveToNext(); // 0x0000000181A84AC0-0x0000000181A84B50
		public bool MoveToElement(); // 0x0000000181A84770-0x0000000181A84800
		public string LookupNamespace(string prefix); // 0x0000000181A83AF0-0x0000000181A83E00
		internal string DefaultLookupNamespace(string prefix); // 0x0000000181A823A0-0x0000000181A82500
		internal string LookupPrefix(string namespaceName); // 0x0000000181A83E00-0x0000000181A84230
		internal IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181A83150-0x0000000181A83690
		public bool ReadAttributeValue(ref int level, ref bool bResolveEntity, ref XmlNodeType nt); // 0x0000000181A84BB0-0x0000000181A84DF0
	}
}
