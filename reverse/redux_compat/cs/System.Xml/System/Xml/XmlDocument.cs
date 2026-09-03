/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public class XmlDocument : XmlNode // TypeDefIndex: 6820
	{
		// Fields
		private XmlImplementation implementation; // 0x18
		private DomNameTable domNameTable; // 0x20
		private XmlLinkedNode lastChild; // 0x28
		private XmlNamedNodeMap entities; // 0x30
		private Hashtable htElementIdMap; // 0x38
		private Hashtable htElementIDAttrDecl; // 0x40
		private SchemaInfo schemaInfo; // 0x48
		private XmlSchemaSet schemas; // 0x50
		private bool reportValidity; // 0x58
		private bool actualLoadingStatus; // 0x59
		private XmlNodeChangedEventHandler onNodeInsertingDelegate; // 0x60
		private XmlNodeChangedEventHandler onNodeInsertedDelegate; // 0x68
		private XmlNodeChangedEventHandler onNodeRemovingDelegate; // 0x70
		private XmlNodeChangedEventHandler onNodeRemovedDelegate; // 0x78
		private XmlNodeChangedEventHandler onNodeChangingDelegate; // 0x80
		private XmlNodeChangedEventHandler onNodeChangedDelegate; // 0x88
		internal bool fEntRefNodesPresent; // 0x90
		internal bool fCDataNodesPresent; // 0x91
		private bool preserveWhitespace; // 0x92
		private bool isLoading; // 0x93
		internal string strDocumentName; // 0x98
		internal string strDocumentFragmentName; // 0xA0
		internal string strCommentName; // 0xA8
		internal string strTextName; // 0xB0
		internal string strCDataSectionName; // 0xB8
		internal string strEntityName; // 0xC0
		internal string strID; // 0xC8
		internal string strXmlns; // 0xD0
		internal string strXml; // 0xD8
		internal string strSpace; // 0xE0
		internal string strLang; // 0xE8
		internal string strEmpty; // 0xF0
		internal string strNonSignificantWhitespaceName; // 0xF8
		internal string strSignificantWhitespaceName; // 0x100
		internal string strReservedXmlns; // 0x108
		internal string strReservedXml; // 0x110
		internal string baseURI; // 0x118
		private XmlResolver resolver; // 0x120
		internal bool bSetResolver; // 0x128
		internal object objLock; // 0x130
		internal static EmptyEnumerator EmptyEnumerator; // 0x00
		internal static IXmlSchemaInfo NotKnownSchemaInfo; // 0x08
		internal static IXmlSchemaInfo ValidSchemaInfo; // 0x10
		internal static IXmlSchemaInfo InvalidSchemaInfo; // 0x18
	
		// Properties
		internal SchemaInfo DtdSchemaInfo { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public override XmlNodeType NodeType { get; } // 0x00000001815FCAC0-0x00000001815FCAD0 
		public override XmlNode ParentNode { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual XmlDocumentType DocumentType { get; } // 0x0000000181A63680-0x0000000181A63710 
		internal virtual XmlDeclaration Declaration { get; } // 0x0000000181A63540-0x0000000181A635F0 
		public XmlImplementation Implementation { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public override string Name { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		public override string LocalName { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		public XmlElement DocumentElement { get; } // 0x0000000181A635F0-0x0000000181A63680 
		internal override bool IsContainer { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal override XmlLinkedNode LastNode { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public override XmlDocument OwnerDocument { get; } // 0x00000001802E7860-0x00000001802E7870 
		public XmlSchemaSet Schemas { set; } // 0x00000001806CCE80-0x00000001806CCE90
		internal bool CanReportValidity { get; } // 0x0000000181424750-0x0000000181424760 
		internal bool HasSetResolver { get; } // 0x0000000181A637B0-0x0000000181A637C0 
		public virtual XmlResolver XmlResolver { set; } // 0x0000000181A639A0-0x0000000181A63AF0
		public XmlNameTable NameTable { get; } // 0x0000000181777F30-0x0000000181777F50 
		public override bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
		internal XmlNamedNodeMap Entities { get; set; } // 0x0000000181A63740-0x0000000181A637B0 0x0000000180378110-0x0000000180378120
		internal bool IsLoading { get; set; } // 0x0000000181845FA0-0x0000000181845FB0 0x0000000181A58D60-0x0000000181A58D70
		internal bool ActualLoadingStatus { get; } // 0x00000001802E7880-0x00000001802E7890 
		public override string InnerText { set; } // 0x0000000181A63940-0x0000000181A639A0
		public override string InnerXml { set; } // 0x00000001816D3500-0x00000001816D3520
		internal string Version { get; } // 0x0000000181A63910-0x0000000181A63940 
		internal string Encoding { get; } // 0x0000000181A63710-0x0000000181A63740 
		internal string Standalone { get; } // 0x0000000181A638E0-0x0000000181A63910 
		public override IXmlSchemaInfo SchemaInfo { get; } // 0x0000000181A637C0-0x0000000181A638E0 
		public override string BaseURI { get; } // 0x000000018171E0D0-0x000000018171E0E0 
	
		// Constructors
		public XmlDocument(); // 0x0000000181A62E90-0x0000000181A62F40
		public XmlDocument(XmlNameTable nt); // 0x0000000181A62F40-0x0000000181A62FC0
		protected internal XmlDocument(XmlImplementation imp); // 0x0000000181A62FC0-0x0000000181A63540
		static XmlDocument(); // 0x0000000181A62D30-0x0000000181A62E90
	
		// Methods
		internal static void CheckName(string name); // 0x0000000181A5F9D0-0x0000000181A5FAA0
		internal XmlName AddXmlName(string prefix, string localName, string namespaceURI, IXmlSchemaInfo schemaInfo); // 0x0000000181A5F320-0x0000000181A5F350
		internal XmlName GetXmlName(string prefix, string localName, string namespaceURI, IXmlSchemaInfo schemaInfo); // 0x0000000181A61330-0x0000000181A61480
		internal XmlName AddAttrXmlName(string prefix, string localName, string namespaceURI, IXmlSchemaInfo schemaInfo); // 0x0000000181A5EBE0-0x0000000181A5ED20
		internal bool AddIdInfo(XmlName eleName, XmlName attrName); // 0x0000000181A5F240-0x0000000181A5F320
		private XmlName GetIDInfoByElement_(XmlName eleName); // 0x0000000181A60F40-0x0000000181A61120
		internal XmlName GetIDInfoByElement(XmlName eleName); // 0x0000000181A61120-0x0000000181A61140
		private WeakReference GetElement(ArrayList elementList, XmlElement elem); // 0x0000000181A608D0-0x0000000181A60D60
		internal void AddElementWithId(string id, XmlElement elem); // 0x0000000181A5F030-0x0000000181A5F240
		internal void RemoveElementWithId(string id, XmlElement elem); // 0x0000000181A62630-0x0000000181A62790
		public override XmlNode CloneNode(bool deep); // 0x0000000181A5FAA0-0x0000000181A5FB90
		internal XmlResolver GetResolver(); // 0x000000018170C2D0-0x000000018170C2E0
		internal override bool IsValidChildType(XmlNodeType type); // 0x0000000181A61F50-0x0000000181A62120
		private bool HasNodeTypeInPrevSiblings(XmlNodeType nt, XmlNode refNode); // 0x0000000181A61500-0x0000000181A615F0
		private bool HasNodeTypeInNextSiblings(XmlNodeType nt, XmlNode refNode); // 0x0000000181A61480-0x0000000181A61500
		internal override bool CanInsertBefore(XmlNode newChild, XmlNode refChild); // 0x0000000181A5F810-0x0000000181A5F9D0
		internal override bool CanInsertAfter(XmlNode newChild, XmlNode refChild); // 0x0000000181A5F6C0-0x0000000181A5F810
		public XmlAttribute CreateAttribute(string name); // 0x0000000181A5FC30-0x0000000181A5FD50
		internal void SetDefaultNamespace(string prefix, string localName, ref string namespaceURI); // 0x0000000181A629F0-0x0000000181A62AA0
		public virtual XmlCDataSection CreateCDataSection(string data); // 0x0000000181A5FDE0-0x0000000181A5FE70
		public virtual XmlComment CreateComment(string data); // 0x0000000181A5FE70-0x0000000181A5FF00
		public virtual XmlDocumentType CreateDocumentType(string name, string publicId, string systemId, string internalSubset); // 0x0000000181A60050-0x0000000181A601E0
		public virtual XmlDocumentFragment CreateDocumentFragment(); // 0x0000000181A5FF90-0x0000000181A60050
		public XmlElement CreateElement(string name); // 0x0000000181A60270-0x0000000181A60300
		internal void AddDefaultAttributes(XmlElement elem); // 0x0000000181A5ED20-0x0000000181A5F030
		private SchemaElementDecl GetSchemaElementDecl(XmlElement elem); // 0x0000000181A61210-0x0000000181A61330
		private XmlAttribute PrepareDefaultAttribute(SchemaAttDef attdef, string attrPrefix, string attrLocalname, string attrNamespaceURI); // 0x0000000181A623F0-0x0000000181A62550
		public virtual XmlEntityReference CreateEntityReference(string name); // 0x0000000181A603D0-0x0000000181A60440
		public virtual XmlProcessingInstruction CreateProcessingInstruction(string target, string data); // 0x0000000181A60440-0x0000000181A604C0
		public virtual XmlDeclaration CreateXmlDeclaration(string version, string encoding, string standalone); // 0x0000000181A60610-0x0000000181A606A0
		public virtual XmlText CreateTextNode(string text); // 0x0000000181A60530-0x0000000181A605A0
		public virtual XmlSignificantWhitespace CreateSignificantWhitespace(string text); // 0x0000000181A604C0-0x0000000181A60530
		public virtual XmlWhitespace CreateWhitespace(string text); // 0x0000000181A605A0-0x0000000181A60610
		public XmlAttribute CreateAttribute(string qualifiedName, string namespaceURI); // 0x0000000181A5FD50-0x0000000181A5FDE0
		public XmlElement CreateElement(string qualifiedName, string namespaceURI); // 0x0000000181A601E0-0x0000000181A60270
		private XmlNode ImportNodeInternal(XmlNode node, bool deep); // 0x0000000181A61820-0x0000000181A61F50
		private void ImportAttributes(XmlNode fromElem, XmlNode toElem); // 0x0000000181A615F0-0x0000000181A61760
		private void ImportChildren(XmlNode fromNode, XmlNode toNode, bool deep); // 0x0000000181A61760-0x0000000181A61820
		public virtual XmlAttribute CreateAttribute(string prefix, string localName, string namespaceURI); // 0x0000000181A5FB90-0x0000000181A5FC30
		protected internal virtual XmlAttribute CreateDefaultAttribute(string prefix, string localName, string namespaceURI); // 0x0000000181A5FF00-0x0000000181A5FF90
		public virtual XmlElement CreateElement(string prefix, string localName, string namespaceURI); // 0x0000000181A60300-0x0000000181A603D0
		public virtual XmlNode ReadNode(XmlReader reader); // 0x0000000181A62550-0x0000000181A62630
		private XmlTextReader SetupReader(XmlTextReader tr); // 0x0000000181A62AA0-0x0000000181A62B10
		public virtual void Load(XmlReader reader); // 0x0000000181A622B0-0x0000000181A623F0
		public virtual void LoadXml(string xml); // 0x0000000181A62120-0x0000000181A622B0
		public virtual void Save(XmlWriter w); // 0x0000000181A62790-0x0000000181A629F0
		public override void WriteTo(XmlWriter w); // 0x0000000181A5E700-0x0000000181A5E720
		public override void WriteContentTo(XmlWriter xw); // 0x0000000181A62B10-0x0000000181A62D30
		internal override XmlNodeChangedEventArgs GetEventArgs(XmlNode node, XmlNode oldParent, XmlNode newParent, string oldValue, string newValue, XmlNodeChangedAction action); // 0x0000000181A60E40-0x0000000181A60F40
		internal XmlNodeChangedEventArgs GetInsertEventArgsForLoad(XmlNode node, XmlNode newParent); // 0x0000000181A61140-0x0000000181A61210
		internal override void BeforeEvent(XmlNodeChangedEventArgs args); // 0x0000000181A5F640-0x0000000181A5F6C0
		internal override void AfterEvent(XmlNodeChangedEventArgs args); // 0x0000000181A5F350-0x0000000181A5F3D0
		internal XmlAttribute GetDefaultAttribute(XmlElement elem, string attrPrefix, string attrLocalname, string attrNamespaceURI); // 0x0000000181A606A0-0x0000000181A608D0
		internal XmlEntity GetEntityNode(string name); // 0x0000000181A60D60-0x0000000181A60E40
		internal void SetBaseURI(string inBaseURI); // 0x0000000180504EA0-0x0000000180504EC0
		internal override XmlNode AppendChildForLoad(XmlNode newChild, XmlDocument doc); // 0x0000000181A5F3D0-0x0000000181A5F640
	}
}
