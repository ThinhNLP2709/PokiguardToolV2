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
using System.Text;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class XmlWellFormedWriter : XmlWriter // TypeDefIndex: 6786
	{
		// Fields
		private XmlWriter writer; // 0x18
		private XmlRawWriter rawWriter; // 0x20
		private IXmlNamespaceResolver predefinedNamespaces; // 0x28
		private Namespace[] nsStack; // 0x30
		private int nsTop; // 0x38
		private Dictionary<string, int> nsHashtable; // 0x40
		private bool useNsHashtable; // 0x48
		private ElementScope[] elemScopeStack; // 0x50
		private int elemTop; // 0x58
		private AttrName[] attrStack; // 0x60
		private int attrCount; // 0x68
		private Dictionary<string, int> attrHashTable; // 0x70
		private SpecialAttribute specAttr; // 0x78
		private AttributeValueCache attrValueCache; // 0x80
		private string curDeclPrefix; // 0x88
		private State[] stateTable; // 0x90
		private State currentState; // 0x98
		private bool checkCharacters; // 0x9C
		private bool omitDuplNamespaces; // 0x9D
		private bool writeEndDocumentOnClose; // 0x9E
		private ConformanceLevel conformanceLevel; // 0xA0
		private bool dtdWritten; // 0xA4
		private bool xmlDeclFollows; // 0xA5
		private XmlCharType xmlCharType; // 0xA8
		private SecureStringHasher hasher; // 0xB0
		internal static readonly string[] stateName; // 0x00
		internal static readonly string[] tokenName; // 0x08
		private static WriteState[] state2WriteState; // 0x10
		private static readonly State[] StateTableDocument; // 0x18
		private static readonly State[] StateTableAuto; // 0x20
	
		// Properties
		public override WriteState WriteState { get; } // 0x0000000181A58CD0-0x0000000181A58D60 
		internal XmlRawWriter RawWriter { get; } // 0x00000001802F8630-0x00000001802F8640 
		private bool SaveAttrValue { get; } // 0x000000018198E5F0-0x000000018198E600 
		private bool InBase64 { get; } // 0x0000000181A58CA0-0x0000000181A58CC0 
		private bool IsClosedOrErrorState { get; } // 0x0000000181A58CC0-0x0000000181A58CD0 
	
		// Nested types
		private enum State // TypeDefIndex: 6787
		{
			Start = 0,
			TopLevel = 1,
			Document = 2,
			Element = 3,
			Content = 4,
			B64Content = 5,
			B64Attribute = 6,
			AfterRootEle = 7,
			Attribute = 8,
			SpecialAttr = 9,
			EndDocument = 10,
			RootLevelAttr = 11,
			RootLevelSpecAttr = 12,
			RootLevelB64Attr = 13,
			AfterRootLevelAttr = 14,
			Closed = 15,
			Error = 16,
			StartContent = 101,
			StartContentEle = 102,
			StartContentB64 = 103,
			StartDoc = 104,
			StartDocEle = 106,
			EndAttrSEle = 107,
			EndAttrEEle = 108,
			EndAttrSCont = 109,
			EndAttrSAttr = 111,
			PostB64Cont = 112,
			PostB64Attr = 113,
			PostB64RootAttr = 114,
			StartFragEle = 115,
			StartFragCont = 116,
			StartFragB64 = 117,
			StartRootLevelAttr = 118
		}
	
		private enum Token // TypeDefIndex: 6788
		{
			StartDocument = 0,
			EndDocument = 1,
			PI = 2,
			Comment = 3,
			Dtd = 4,
			StartElement = 5,
			EndElement = 6,
			StartAttribute = 7,
			EndAttribute = 8,
			Text = 9,
			CData = 10,
			AtomicValue = 11,
			Base64 = 12,
			RawData = 13,
			Whitespace = 14
		}
	
		private class NamespaceResolverProxy : IXmlNamespaceResolver // TypeDefIndex: 6789
		{
			// Fields
			private XmlWellFormedWriter wfWriter; // 0x10
	
			// Constructors
			internal NamespaceResolverProxy(XmlWellFormedWriter wfWriter); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			IDictionary<string, string> IXmlNamespaceResolver.GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181A47230-0x0000000181A47270
			string IXmlNamespaceResolver.LookupNamespace(string prefix); // 0x0000000181A47270-0x0000000181A47290
			string IXmlNamespaceResolver.LookupPrefix(string namespaceName); // 0x0000000181A47290-0x0000000181A472C0
		}
	
		private struct ElementScope // TypeDefIndex: 6790
		{
			// Fields
			internal int prevNSTop; // 0x00
			internal string prefix; // 0x08
			internal string localName; // 0x10
			internal string namespaceUri; // 0x18
			internal XmlSpace xmlSpace; // 0x20
			internal string xmlLang; // 0x28
	
			// Methods
			internal void Set(string prefix, string localName, string namespaceUri, int prevNSTop); // 0x0000000181A47130-0x0000000181A471B0
			internal void WriteEndElement(XmlRawWriter rawWriter); // 0x0000000181A471B0-0x0000000181A471F0
			internal void WriteFullEndElement(XmlRawWriter rawWriter); // 0x0000000181A471F0-0x0000000181A47230
		}
	
		private enum NamespaceKind // TypeDefIndex: 6791
		{
			Written = 0,
			NeedToWrite = 1,
			Implied = 2,
			Special = 3
		}
	
		private struct Namespace // TypeDefIndex: 6792
		{
			// Fields
			internal string prefix; // 0x00
			internal string namespaceUri; // 0x08
			internal NamespaceKind kind; // 0x10
			internal int prevNsIndex; // 0x14
	
			// Methods
			internal void Set(string prefix, string namespaceUri, NamespaceKind kind); // 0x0000000181A472C0-0x0000000181A47310
			internal void WriteDecl(XmlWriter writer, XmlRawWriter rawWriter); // 0x0000000181A47360-0x0000000181A47490
		}
	
		private struct AttrName // TypeDefIndex: 6793
		{
			// Fields
			internal string prefix; // 0x00
			internal string namespaceUri; // 0x08
			internal string localName; // 0x10
			internal int prev; // 0x18
	
			// Methods
			internal void Set(string prefix, string localName, string namespaceUri); // 0x0000000181A58DF0-0x0000000181A58E50
			internal bool IsDuplicate(string prefix, string localName, string namespaceUri); // 0x0000000181A58D70-0x0000000181A58DF0
		}
	
		private enum SpecialAttribute // TypeDefIndex: 6794
		{
			No = 0,
			DefaultXmlns = 1,
			PrefixedXmlns = 2,
			XmlSpace = 3,
			XmlLang = 4
		}
	
		private class AttributeValueCache // TypeDefIndex: 6795
		{
			// Fields
			private StringBuilder stringValue; // 0x10
			private string singleStringValue; // 0x18
			private Item[] items; // 0x20
			private int firstItem; // 0x28
			private int lastItem; // 0x2C
	
			// Properties
			internal string StringValue { get; } // 0x0000000181A5A2B0-0x0000000181A5A2F0 
	
			// Nested types
			private enum ItemType // TypeDefIndex: 6796
			{
				EntityRef = 0,
				CharEntity = 1,
				SurrogateCharEntity = 2,
				Whitespace = 3,
				String = 4,
				StringChars = 5,
				Raw = 6,
				RawChars = 7,
				ValueString = 8
			}
	
			private class Item // TypeDefIndex: 6797
			{
				// Fields
				internal ItemType type; // 0x10
				internal object data; // 0x18
	
				// Constructors
				internal Item(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal void Set(ItemType type, object data); // 0x00000001814EDE70-0x00000001814EDE90
			}
	
			private class BufferChunk // TypeDefIndex: 6798
			{
				// Fields
				internal char[] buffer; // 0x10
				internal int index; // 0x18
				internal int count; // 0x1C
	
				// Constructors
				internal BufferChunk(char[] buffer, int index, int count); // 0x0000000181559600-0x0000000181559660
			}
	
			// Constructors
			public AttributeValueCache(); // 0x0000000181A5A250-0x0000000181A5A2B0
	
			// Methods
			internal void WriteEntityRef(string name); // 0x0000000181A59C10-0x0000000181A59DE0
			internal void WriteCharEntity(char ch); // 0x0000000181A59A50-0x0000000181A59B00
			internal void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A5A030-0x0000000181A5A130
			internal void WriteWhitespace(string ws); // 0x0000000181A5A1C0-0x0000000181A5A250
			internal void WriteString(string text); // 0x0000000181A59F80-0x0000000181A5A030
			internal void WriteChars(char[] buffer, int index, int count); // 0x0000000181A59B00-0x0000000181A59C10
			internal void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A59E70-0x0000000181A59F80
			internal void WriteRaw(string data); // 0x0000000181A59DE0-0x0000000181A59E70
			internal void WriteValue(string value); // 0x0000000181A5A130-0x0000000181A5A1C0
			internal void Replay(XmlWriter writer); // 0x0000000181A59120-0x0000000181A59560
			internal void Trim(); // 0x0000000181A595B0-0x0000000181A59A50
			internal void Clear(); // 0x0000000181A590D0-0x0000000181A59120
			private void StartComplexValue(); // 0x0000000181A59560-0x0000000181A595B0
			private void AddItem(ItemType type, object data); // 0x0000000181A58F40-0x0000000181A590D0
		}
	
		// Constructors
		internal XmlWellFormedWriter(XmlWriter writer, XmlWriterSettings settings); // 0x0000000181A58720-0x0000000181A58CA0
		static XmlWellFormedWriter(); // 0x0000000181A57EC0-0x0000000181A58720
	
		// Methods
		public override void WriteStartDocument(); // 0x0000000181A57770-0x0000000181A57780
		public override void WriteStartDocument(bool standalone); // 0x0000000181A57740-0x0000000181A57770
		public override void WriteEndDocument(); // 0x0000000181A56440-0x0000000181A56550
		public override void WriteDocType(string name, string pubid, string sysid, string subset); // 0x0000000181A55720-0x0000000181A55B90
		public override void WriteStartElement(string prefix, string localName, string ns); // 0x0000000181A57780-0x0000000181A57AE0
		public override void WriteEndElement(); // 0x0000000181A56550-0x0000000181A56710
		public override void WriteFullEndElement(); // 0x0000000181A56820-0x0000000181A569E0
		public override void WriteStartAttribute(string prefix, string localName, string namespaceName); // 0x0000000181A56EF0-0x0000000181A575B0
		public override void WriteEndAttribute(); // 0x0000000181A55B90-0x0000000181A56440
		public override void WriteCData(string text); // 0x0000000181A552B0-0x0000000181A55350
		public override void WriteComment(string text); // 0x0000000181A55680-0x0000000181A55720
		public override void WriteProcessingInstruction(string name, string text); // 0x0000000181A569E0-0x0000000181A56C30
		public override void WriteEntityRef(string name); // 0x0000000181A56710-0x0000000181A56820
		public override void WriteCharEntity(char ch); // 0x0000000181A55350-0x0000000181A55470
		public override void WriteSurrogateCharEntity(char lowChar, char highChar); // 0x0000000181A57B90-0x0000000181A57CC0
		public override void WriteWhitespace(string ws); // 0x0000000181A57D80-0x0000000181A57EC0
		public override void WriteString(string text); // 0x0000000181A57AE0-0x0000000181A57B90
		public override void WriteChars(char[] buffer, int index, int count); // 0x0000000181A55470-0x0000000181A55680
		public override void WriteRaw(char[] buffer, int index, int count); // 0x0000000181A56CE0-0x0000000181A56EF0
		public override void WriteRaw(string data); // 0x0000000181A56C30-0x0000000181A56CE0
		public override void WriteBase64(byte[] buffer, int index, int count); // 0x0000000181A54FE0-0x0000000181A551C0
		public override void Close(); // 0x0000000181A53290-0x0000000181A53810
		public override void Flush(); // 0x0000000181A53900-0x0000000181A53960
		public override string LookupPrefix(string ns); // 0x0000000181A53EC0-0x0000000181A54080
		public override void WriteValue(string value); // 0x0000000181A57CC0-0x0000000181A57D80
		public override void WriteBinHex(byte[] buffer, int index, int count); // 0x0000000181A551C0-0x0000000181A552B0
		private void SetSpecialAttribute(SpecialAttribute special); // 0x0000000181A54B40-0x0000000181A54BE0
		private void WriteStartDocumentImpl(XmlStandalone standalone); // 0x0000000181A575B0-0x0000000181A57740
		private void StartFragment(); // 0x0000000181A54DB0-0x0000000181A54DC0
		private void PushNamespaceImplicit(string prefix, string ns); // 0x0000000181A546E0-0x0000000181A54B40
		private bool PushNamespaceExplicit(string prefix, string ns); // 0x0000000181A54170-0x0000000181A546E0
		private void AddNamespace(string prefix, string ns, NamespaceKind kind); // 0x0000000181A52940-0x0000000181A52AD0
		private void AddToNamespaceHashtable(int namespaceIndex); // 0x0000000181A52C10-0x0000000181A52CF0
		private int LookupNamespaceIndex(string prefix); // 0x0000000181A53CE0-0x0000000181A53DD0
		private void PopNamespaces(int indexFrom, int indexTo); // 0x0000000181A54080-0x0000000181A54170
		private static XmlException DupAttrException(string prefix, string localName); // 0x0000000181A53810-0x0000000181A53900
		private void AdvanceState(Token token); // 0x0000000181A52CF0-0x0000000181A53130
		private void StartElementContent(); // 0x0000000181A54BE0-0x0000000181A54DB0
		private static string GetStateName(State state); // 0x0000000181A53A70-0x0000000181A53B00
		internal string LookupNamespace(string prefix); // 0x0000000181A53DD0-0x0000000181A53EC0
		private string LookupLocalNamespace(string prefix); // 0x0000000181A53C20-0x0000000181A53CE0
		private string GeneratePrefix(); // 0x0000000181A53960-0x0000000181A53A70
		private void CheckNCName(string ncname); // 0x0000000181A53130-0x0000000181A53290
		private static Exception InvalidCharsException(string name, int badCharIndex); // 0x0000000181A53B00-0x0000000181A53C20
		private void ThrowInvalidStateTransition(Token token, State currentState); // 0x0000000181A54DC0-0x0000000181A54FE0
		private void AddAttribute(string prefix, string localName, string namespaceName); // 0x0000000181A52650-0x0000000181A52940
		private void AddToAttrHashTable(int attributeIndex); // 0x0000000181A52AD0-0x0000000181A52C10
	}
}
