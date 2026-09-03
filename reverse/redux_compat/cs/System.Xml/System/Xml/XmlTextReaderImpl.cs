/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class XmlTextReaderImpl : XmlReader, IXmlLineInfo, IXmlNamespaceResolver // TypeDefIndex: 6757
	{
		// Fields
		private readonly bool useAsync; // 0x10
		private LaterInitParam laterInitParam; // 0x18
		private XmlCharType xmlCharType; // 0x20
		private ParsingState ps; // 0x28
		private ParsingFunction parsingFunction; // 0xA0
		private ParsingFunction nextParsingFunction; // 0xA4
		private ParsingFunction nextNextParsingFunction; // 0xA8
		private NodeData[] nodes; // 0xB0
		private NodeData curNode; // 0xB8
		private int index; // 0xC0
		private int curAttrIndex; // 0xC4
		private int attrCount; // 0xC8
		private int attrHashtable; // 0xCC
		private int attrDuplWalkCount; // 0xD0
		private bool attrNeedNamespaceLookup; // 0xD4
		private bool fullAttrCleanup; // 0xD5
		private NodeData[] attrDuplSortingArray; // 0xD8
		private XmlNameTable nameTable; // 0xE0
		private bool nameTableFromSettings; // 0xE8
		private XmlResolver xmlResolver; // 0xF0
		private string url; // 0xF8
		private bool normalize; // 0x100
		private bool supportNamespaces; // 0x101
		private WhitespaceHandling whitespaceHandling; // 0x104
		private DtdProcessing dtdProcessing; // 0x108
		private EntityHandling entityHandling; // 0x10C
		private bool ignorePIs; // 0x110
		private bool ignoreComments; // 0x111
		private bool checkCharacters; // 0x112
		private int lineNumberOffset; // 0x114
		private int linePositionOffset; // 0x118
		private bool closeInput; // 0x11C
		private long maxCharactersInDocument; // 0x120
		private long maxCharactersFromEntities; // 0x128
		private bool v1Compat; // 0x130
		private XmlNamespaceManager namespaceManager; // 0x138
		private string lastPrefix; // 0x140
		private XmlContext xmlContext; // 0x148
		private ParsingState[] parsingStatesStack; // 0x150
		private int parsingStatesStackTop; // 0x158
		private string reportedBaseUri; // 0x160
		private Encoding reportedEncoding; // 0x168
		private IDtdInfo dtdInfo; // 0x170
		private XmlNodeType fragmentType; // 0x178
		private XmlParserContext fragmentParserContext; // 0x180
		private bool fragment; // 0x188
		private IncrementalReadDecoder incReadDecoder; // 0x190
		private IncrementalReadState incReadState; // 0x198
		private LineInfo incReadLineInfo; // 0x19C
		private int incReadDepth; // 0x1A4
		private int incReadLeftStartPos; // 0x1A8
		private int incReadLeftEndPos; // 0x1AC
		private int attributeValueBaseEntityId; // 0x1B0
		private bool emptyEntityInAttributeResolved; // 0x1B4
		private IValidationEventHandling validationEventHandling; // 0x1B8
		private OnDefaultAttributeUseDelegate onDefaultAttributeUse; // 0x1C0
		private bool validatingReaderCompatFlag; // 0x1C8
		private bool addDefaultAttributesAndNormalize; // 0x1C9
		private StringBuilder stringBuilder; // 0x1D0
		private bool rootElementParsed; // 0x1D8
		private bool standalone; // 0x1D9
		private int nextEntityId; // 0x1DC
		private ParsingMode parsingMode; // 0x1E0
		private ReadState readState; // 0x1E4
		private IDtdEntityInfo lastEntity; // 0x1E8
		private bool afterResetState; // 0x1F0
		private int documentStartBytePos; // 0x1F4
		private int readValueOffset; // 0x1F8
		private long charactersInDocument; // 0x200
		private long charactersFromEntities; // 0x208
		private Dictionary<IDtdEntityInfo, IDtdEntityInfo> currentEntities; // 0x210
		private bool disableUndeclaredEntityCheck; // 0x218
		private XmlReader outerReader; // 0x220
		private bool xmlResolverIsSet; // 0x228
		private string Xml; // 0x230
		private string XmlNs; // 0x238
		private Task<Tuple<int, int, int, bool>> parseText_dummyTask; // 0x240
	
		// Properties
		public override XmlReaderSettings Settings { get; } // 0x0000000181974AB0-0x0000000181974C40 
		public override XmlNodeType NodeType { get; } // 0x0000000181974A40-0x0000000181974A60 
		public override string Name { get; } // 0x00000001819749F0-0x0000000181974A20 
		public override string LocalName { get; } // 0x00000001819749D0-0x00000001819749F0 
		public override string NamespaceURI { get; } // 0x0000000181974A20-0x0000000181974A40 
		public override string Prefix { get; } // 0x0000000181974A60-0x0000000181974A80 
		public override string Value { get; } // 0x0000000181974C50-0x0000000181974DA0 
		public override int Depth { get; } // 0x00000001819746E0-0x0000000181974700 
		public override string BaseURI { get; } // 0x00000001819746D0-0x00000001819746E0 
		public override bool IsEmptyElement { get; } // 0x00000001819748F0-0x0000000181974920 
		public override bool IsDefault { get; } // 0x00000001819748C0-0x00000001819748F0 
		public override char QuoteChar { get; } // 0x0000000181974A80-0x0000000181974AB0 
		public override XmlSpace XmlSpace { get; } // 0x0000000181974DC0-0x0000000181974DE0 
		public override string XmlLang { get; } // 0x0000000181974DA0-0x0000000181974DC0 
		public override ReadState ReadState { get; } // 0x000000018033D480-0x000000018033D490 
		public override bool EOF { get; } // 0x0000000181974840-0x0000000181974850 
		public override XmlNameTable NameTable { get; } // 0x00000001806CCB80-0x00000001806CCB90 
		public override bool CanResolveEntity { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override int AttributeCount { get; } // 0x000000018158B020-0x000000018158B030 
		internal XmlReader OuterReader { set; } // 0x0000000181975220-0x0000000181975240
		public override bool CanReadValueChunk { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public int LineNumber { get; } // 0x0000000181974970-0x00000001819749A0 
		public int LinePosition { get; } // 0x00000001819749A0-0x00000001819749D0 
		internal bool Namespaces { get; set; } // 0x0000000181974830-0x0000000181974840 0x0000000181974EE0-0x0000000181975130
		internal bool Normalization { get; set; } // 0x000000018170B140-0x000000018170B150 0x0000000181975130-0x0000000181975200
		internal WhitespaceHandling WhitespaceHandling { set; } // 0x0000000181975240-0x0000000181975320
		internal EntityHandling EntityHandling { set; } // 0x0000000181974DF0-0x0000000181974E80
		internal bool IsResolverSet { get; } // 0x0000000181974960-0x0000000181974970 
		internal XmlResolver XmlResolver { set; } // 0x0000000181975320-0x00000001819753E0
		internal XmlNameTable DtdParserProxy_NameTable { get; } // 0x00000001806CCB80-0x00000001806CCB90 
		internal IXmlNamespaceResolver DtdParserProxy_NamespaceResolver { get; } // 0x0000000181974820-0x0000000181974830 
		internal bool DtdParserProxy_DtdValidation { get; } // 0x00000001819747E0-0x00000001819747F0 
		internal bool DtdParserProxy_Normalization { get; } // 0x000000018170B140-0x000000018170B150 
		internal bool DtdParserProxy_Namespaces { get; } // 0x0000000181974830-0x0000000181974840 
		internal bool DtdParserProxy_V1CompatibilityMode { get; } // 0x00000001805580E0-0x00000001805580F0 
		internal Uri DtdParserProxy_BaseUri { get; } // 0x0000000181974710-0x00000001819747E0 
		internal bool DtdParserProxy_IsEof { get; } // 0x00000001803B5710-0x00000001803B5720 
		internal char[] DtdParserProxy_ParsingBuffer { get; } // 0x000000018033D240-0x000000018033D250 
		internal int DtdParserProxy_ParsingBufferLength { get; } // 0x000000018033D0F0-0x000000018033D100 
		internal int DtdParserProxy_CurrentPosition { get; set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		internal int DtdParserProxy_EntityStackLength { get; } // 0x00000001819747F0-0x0000000181974800 
		internal bool DtdParserProxy_IsEntityEolNormalized { get; } // 0x0000000181974800-0x0000000181974810 
		internal IValidationEventHandling DtdParserProxy_ValidationEventHandling { get; } // 0x000000018033D6C0-0x000000018033D6D0 
		internal int DtdParserProxy_LineNo { get; } // 0x0000000180CC2260-0x0000000180CC2270 
		internal int DtdParserProxy_LineStartPosition { get; } // 0x0000000181974810-0x0000000181974820 
		private bool IsResolverNull { get; } // 0x0000000181974920-0x0000000181974960 
		private bool InAttributeValueIterator { get; } // 0x0000000181974860-0x0000000181974880 
		private bool DtdValidation { get; } // 0x00000001819747E0-0x00000001819747F0 
		private bool InEntity { get; } // 0x0000000181974880-0x0000000181974890 
		internal override IDtdInfo DtdInfo { get; } // 0x0000000181974700-0x0000000181974710 
		internal IValidationEventHandling ValidationEventHandling { set; } // 0x000000018033ECB0-0x000000018033ECD0
		internal OnDefaultAttributeUseDelegate OnDefaultAttributeUse { set; } // 0x0000000181975200-0x0000000181975220
		internal bool XmlValidatingReaderCompatibilityMode { set; } // 0x00000001819753E0-0x0000000181975670
		internal XmlNodeType FragmentType { get; } // 0x0000000181974850-0x0000000181974860 
		internal object InternalSchemaType { set; } // 0x0000000181974E80-0x0000000181974EB0
		internal object InternalTypedValue { get; set; } // 0x0000000181974890-0x00000001819748C0 0x0000000181974EB0-0x0000000181974EE0
		internal bool StandAlone { get; } // 0x0000000181974C40-0x0000000181974C50 
		internal override XmlNamespaceManager NamespaceManager { get; } // 0x0000000181974820-0x0000000181974830 
		internal bool V1Compat { get; } // 0x00000001805580E0-0x00000001805580F0 
		internal bool DisableUndeclaredEntityCheck { set; } // 0x0000000181974DE0-0x0000000181974DF0
	
		// Nested types
		private enum ParsingFunction // TypeDefIndex: 6758
		{
			ElementContent = 0,
			NoData = 1,
			OpenUrl = 2,
			SwitchToInteractive = 3,
			SwitchToInteractiveXmlDecl = 4,
			DocumentContent = 5,
			MoveToElementContent = 6,
			PopElementContext = 7,
			PopEmptyElementContext = 8,
			ResetAttributesRootLevel = 9,
			Error = 10,
			Eof = 11,
			ReaderClosed = 12,
			EntityReference = 13,
			InIncrementalRead = 14,
			FragmentAttribute = 15,
			ReportEndEntity = 16,
			AfterResolveEntityInContent = 17,
			AfterResolveEmptyEntityInContent = 18,
			XmlDeclarationFragment = 19,
			GoToEof = 20,
			PartialTextValue = 21,
			InReadAttributeValue = 22,
			InReadValueChunk = 23,
			InReadContentAsBinary = 24,
			InReadElementContentAsBinary = 25
		}
	
		private enum ParsingMode // TypeDefIndex: 6759
		{
			Full = 0,
			SkipNode = 1,
			SkipContent = 2
		}
	
		private enum EntityType // TypeDefIndex: 6760
		{
			CharacterDec = 0,
			CharacterHex = 1,
			CharacterNamed = 2,
			Expanded = 3,
			Skipped = 4,
			FakeExpanded = 5,
			Unexpanded = 6,
			ExpandedInAttribute = 7
		}
	
		private enum EntityExpandType // TypeDefIndex: 6761
		{
			All = 0,
			OnlyGeneral = 1,
			OnlyCharacter = 2
		}
	
		private enum IncrementalReadState // TypeDefIndex: 6762
		{
			Text = 0,
			StartTag = 1,
			PI = 2,
			CDATA = 3,
			Comment = 4,
			Attributes = 5,
			AttributeValue = 6,
			ReadData = 7,
			EndElement = 8,
			End = 9,
			ReadValueChunk_OnCachedValue = 10,
			ReadValueChunk_OnPartialValue = 11,
			ReadContentAsBinary_OnCachedValue = 12,
			ReadContentAsBinary_OnPartialValue = 13,
			ReadContentAsBinary_End = 14
		}
	
		private class LaterInitParam // TypeDefIndex: 6763
		{
			// Fields
			public bool useAsync; // 0x10
			public Stream inputStream; // 0x18
			public byte[] inputBytes; // 0x20
			public int inputByteCount; // 0x28
			public Uri inputbaseUri; // 0x30
			public string inputUriStr; // 0x38
			public XmlResolver inputUriResolver; // 0x40
			public XmlParserContext inputContext; // 0x48
			public TextReader inputTextReader; // 0x50
			public InitInputType initType; // 0x58
	
			// Constructors
			public LaterInitParam(); // 0x0000000181A345C0-0x0000000181A345D0
		}
	
		private enum InitInputType // TypeDefIndex: 6764
		{
			UriString = 0,
			Stream = 1,
			TextReader = 2,
			Invalid = 3
		}
	
		private struct ParsingState // TypeDefIndex: 6765
		{
			// Fields
			internal char[] chars; // 0x00
			internal int charPos; // 0x08
			internal int charsUsed; // 0x0C
			internal Encoding encoding; // 0x10
			internal bool appendMode; // 0x18
			internal Stream stream; // 0x20
			internal Decoder decoder; // 0x28
			internal byte[] bytes; // 0x30
			internal int bytePos; // 0x38
			internal int bytesUsed; // 0x3C
			internal TextReader textReader; // 0x40
			internal int lineNo; // 0x48
			internal int lineStartPos; // 0x4C
			internal string baseUriStr; // 0x50
			internal Uri baseUri; // 0x58
			internal bool isEof; // 0x60
			internal bool isStreamEof; // 0x61
			internal IDtdEntityInfo entity; // 0x68
			internal int entityId; // 0x70
			internal bool eolNormalized; // 0x74
			internal bool entityResolvedManually; // 0x75
	
			// Properties
			internal int LineNo { get; } // 0x000000018033D1C0-0x000000018033D1D0 
			internal int LinePos { get; } // 0x0000000181A350E0-0x0000000181A350F0 
	
			// Methods
			internal void Clear(); // 0x0000000181A34FC0-0x0000000181A35080
			internal void Close(bool closeInput); // 0x0000000181A35080-0x0000000181A350E0
		}
	
		private class XmlContext // TypeDefIndex: 6766
		{
			// Fields
			internal XmlSpace xmlSpace; // 0x10
			internal string xmlLang; // 0x18
			internal string defaultNamespace; // 0x20
			internal XmlContext previousContext; // 0x28
	
			// Constructors
			internal XmlContext(); // 0x0000000181A3A1A0-0x0000000181A3A210
			internal XmlContext(XmlContext previousContext); // 0x0000000181A3A210-0x0000000181A3A280
		}
	
		private class NoNamespaceManager : XmlNamespaceManager // TypeDefIndex: 6767
		{
			// Properties
			public override string DefaultNamespace { get; } // 0x00000001815B1550-0x00000001815B1570 
	
			// Constructors
			public NoNamespaceManager(); // 0x00000001802F4070-0x00000001802F4080
	
			// Methods
			public override void PushScope(); // 0x00000001802E76C0-0x00000001802E76D0
			public override bool PopScope(); // 0x00000001802E7840-0x00000001802E7850
			public override void AddNamespace(string prefix, string uri); // 0x00000001802E76C0-0x00000001802E76D0
			public override void RemoveNamespace(string prefix, string uri); // 0x00000001802E76C0-0x00000001802E76D0
			public override IEnumerator GetEnumerator(); // 0x00000001802E7860-0x00000001802E7870
			public override IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope); // 0x00000001802E7860-0x00000001802E7870
			public override string LookupNamespace(string prefix); // 0x00000001815B1550-0x00000001815B1570
			public override string LookupPrefix(string uri); // 0x00000001802E7860-0x00000001802E7870
		}
	
		internal class DtdParserProxy : IDtdParserAdapterV1 // TypeDefIndex: 6768
		{
			// Fields
			private XmlTextReaderImpl reader; // 0x10
	
			// Properties
			XmlNameTable IDtdParserAdapter.NameTable { get; } // 0x0000000181A33D50-0x0000000181A33D70 
			IXmlNamespaceResolver IDtdParserAdapter.NamespaceResolver { get; } // 0x0000000181A33D70-0x0000000181A33D90 
			Uri IDtdParserAdapter.BaseUri { get; } // 0x0000000181A33C70-0x0000000181A33C90 
			bool IDtdParserAdapter.IsEof { get; } // 0x0000000181A33CF0-0x0000000181A33D10 
			char[] IDtdParserAdapter.ParsingBuffer { get; } // 0x0000000181A33DB0-0x0000000181A33DD0 
			int IDtdParserAdapter.ParsingBufferLength { get; } // 0x0000000181A33D90-0x0000000181A33DB0 
			int IDtdParserAdapter.CurrentPosition { get; set; } // 0x0000000181A33C90-0x0000000181A33CB0 0x0000000181A33DD0-0x0000000181A33DF0
			int IDtdParserAdapter.EntityStackLength { get; } // 0x0000000181A33CB0-0x0000000181A33CD0 
			bool IDtdParserAdapter.IsEntityEolNormalized { get; } // 0x0000000181A33CD0-0x0000000181A33CF0 
			int IDtdParserAdapter.LineNo { get; } // 0x0000000181A33D10-0x0000000181A33D30 
			int IDtdParserAdapter.LineStartPosition { get; } // 0x0000000181A33D30-0x0000000181A33D50 
			bool IDtdParserAdapterWithValidation.DtdValidation { get; } // 0x0000000181A33A70-0x0000000181A33A90 
			IValidationEventHandling IDtdParserAdapterWithValidation.ValidationEventHandling { get; } // 0x0000000181A33A90-0x0000000181A33AB0 
			bool IDtdParserAdapterV1.Normalization { get; } // 0x0000000181A33A30-0x0000000181A33A50 
			bool IDtdParserAdapterV1.Namespaces { get; } // 0x0000000181A33A10-0x0000000181A33A30 
			bool IDtdParserAdapterV1.V1CompatibilityMode { get; } // 0x0000000181A33A50-0x0000000181A33A70 
	
			// Constructors
			internal DtdParserProxy(XmlTextReaderImpl reader); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			void IDtdParserAdapter.OnNewLine(int pos); // 0x0000000181A33AB0-0x0000000181A33AD0
			int IDtdParserAdapter.ReadData(); // 0x0000000181A33C30-0x0000000181A33C50
			int IDtdParserAdapter.ParseNumericCharRef(StringBuilder internalSubsetBuilder); // 0x0000000181A33B70-0x0000000181A33B90
			int IDtdParserAdapter.ParseNamedCharRef(bool expand, StringBuilder internalSubsetBuilder); // 0x0000000181A33B50-0x0000000181A33B70
			void IDtdParserAdapter.ParsePI(StringBuilder sb); // 0x0000000181A33B90-0x0000000181A33BB0
			void IDtdParserAdapter.ParseComment(StringBuilder sb); // 0x0000000181A33B30-0x0000000181A33B50
			bool IDtdParserAdapter.PushEntity(IDtdEntityInfo entity, out int entityId); // 0x0000000181A33BD0-0x0000000181A33BF0
			bool IDtdParserAdapter.PopEntity(out IDtdEntityInfo oldEntity, out int newEntityId); // 0x0000000181A33BB0-0x0000000181A33BD0
			bool IDtdParserAdapter.PushExternalSubset(string systemId, string publicId); // 0x0000000181A33BF0-0x0000000181A33C10
			void IDtdParserAdapter.PushInternalDtd(string baseUri, string internalDtd); // 0x0000000181A33C10-0x0000000181A33C30
			void IDtdParserAdapter.Throw(Exception e); // 0x0000000181A33C50-0x0000000181A33C70
			void IDtdParserAdapter.OnSystemId(string systemId, LineInfo keywordLineInfo, LineInfo systemLiteralLineInfo); // 0x0000000181A33B00-0x0000000181A33B30
			void IDtdParserAdapter.OnPublicId(string publicId, LineInfo keywordLineInfo, LineInfo publicLiteralLineInfo); // 0x0000000181A33AD0-0x0000000181A33B00
		}
	
		private class NodeData : IComparable // TypeDefIndex: 6769
		{
			// Fields
			private static NodeData s_None; // 0x00
			internal XmlNodeType type; // 0x10
			internal string localName; // 0x18
			internal string prefix; // 0x20
			internal string ns; // 0x28
			internal string nameWPrefix; // 0x30
			private string value; // 0x38
			private char[] chars; // 0x40
			private int valueStartPos; // 0x48
			private int valueLength; // 0x4C
			internal LineInfo lineInfo; // 0x50
			internal LineInfo lineInfo2; // 0x58
			internal char quoteChar; // 0x60
			internal int depth; // 0x64
			private bool isEmptyOrDefault; // 0x68
			internal int entityId; // 0x6C
			internal bool xmlContextPushed; // 0x70
			internal NodeData nextAttrValueChunk; // 0x78
			internal object schemaType; // 0x80
			internal object typedValue; // 0x88
	
			// Properties
			internal static NodeData None { get; } // 0x0000000181A34E30-0x0000000181A34F60 
			internal int LineNo { get; } // 0x000000018033D660-0x000000018033D670 
			internal int LinePos { get; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 
			internal bool IsEmptyElement { get; set; } // 0x0000000181A34E20-0x0000000181A34E30 0x0000000180B262C0-0x0000000180B262D0
			internal bool IsDefaultAttribute { get; set; } // 0x0000000181A34E10-0x0000000181A34E20 0x0000000180B262C0-0x0000000180B262D0
			internal bool ValueBuffered { get; } // 0x0000000181A34FB0-0x0000000181A34FC0 
			internal string StringValue { get; } // 0x0000000181A34F60-0x0000000181A34FB0 
	
			// Constructors
			internal NodeData(); // 0x0000000181A34D70-0x0000000181A34E10
	
			// Methods
			internal void TrimSpacesInValue(); // 0x0000000181A34D20-0x0000000181A34D70
			internal void Clear(XmlNodeType type); // 0x0000000181A34660-0x0000000181A346F0
			internal void ClearName(); // 0x0000000181A345D0-0x0000000181A34660
			internal void SetLineInfo(int lineNo, int linePos); // 0x0000000181A349C0-0x0000000181A349D0
			internal void SetLineInfo2(int lineNo, int linePos); // 0x0000000181A349B0-0x0000000181A349C0
			internal void SetValueNode(XmlNodeType type, string value); // 0x0000000181A34B20-0x0000000181A34B60
			internal void SetValueNode(XmlNodeType type, char[] chars, int startPos, int len); // 0x0000000181A34B60-0x0000000181A34BC0
			internal void SetNamedNode(XmlNodeType type, string localName); // 0x0000000181A349D0-0x0000000181A34A80
			internal void SetNamedNode(XmlNodeType type, string localName, string prefix, string nameWPrefix); // 0x0000000181A34A80-0x0000000181A34B20
			internal void SetValue(string value); // 0x0000000181A34BC0-0x0000000181A34BE0
			internal void SetValue(char[] chars, int startPos, int len); // 0x0000000181A34BE0-0x0000000181A34C40
			internal void OnBufferInvalidated(); // 0x0000000181A34950-0x0000000181A349B0
			internal void CopyTo(int valueOffset, StringBuilder sb); // 0x0000000181A34760-0x0000000181A347F0
			internal int CopyTo(int valueOffset, char[] buffer, int offset, int length); // 0x0000000181A346F0-0x0000000181A34760
			internal string GetNameWPrefix(XmlNameTable nt); // 0x0000000181A34890-0x0000000181A34950
			internal string CreateNameWPrefix(XmlNameTable nt); // 0x0000000181A347F0-0x0000000181A34890
			int IComparable.CompareTo(object obj); // 0x0000000181A34C40-0x0000000181A34D20
		}
	
		private class DtdDefaultAttributeInfoToNodeDataComparer : IComparer<object> // TypeDefIndex: 6770
		{
			// Fields
			private static IComparer<object> s_instance; // 0x00
	
			// Properties
			internal static IComparer<object> Instance { get; } // 0x0000000181A470E0-0x0000000181A47130 
	
			// Constructors
			public DtdDefaultAttributeInfoToNodeDataComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static DtdDefaultAttributeInfoToNodeDataComparer(); // 0x0000000181A47070-0x0000000181A470E0
	
			// Methods
			public int Compare(object x, object y); // 0x0000000181A46E00-0x0000000181A47070
		}
	
		internal delegate void OnDefaultAttributeUseDelegate(IDtdDefaultAttributeInfo defaultAttribute, XmlTextReaderImpl coreReader); // TypeDefIndex: 6771; 0x0000000180A70FB0-0x0000000180A70FC0
	
		// Constructors
		internal XmlTextReaderImpl(XmlNameTable nt); // 0x0000000181973610-0x0000000181973A80
		private XmlTextReaderImpl(XmlResolver resolver, XmlReaderSettings settings, XmlParserContext context); // 0x0000000181973BD0-0x0000000181974190
		internal XmlTextReaderImpl(Stream input); // 0x0000000181973380-0x00000001819734D0
		internal XmlTextReaderImpl(string url, Stream input, XmlNameTable nt); // 0x0000000181974220-0x0000000181974330
		internal XmlTextReaderImpl(TextReader input); // 0x0000000181974190-0x0000000181974220
		internal XmlTextReaderImpl(TextReader input, XmlNameTable nt); // 0x00000001819734D0-0x0000000181973510
		internal XmlTextReaderImpl(string url, TextReader input, XmlNameTable nt); // 0x0000000181973510-0x0000000181973610
		internal XmlTextReaderImpl(string xmlFragment, XmlNodeType fragType, XmlParserContext context); // 0x0000000181973100-0x0000000181973230
		internal XmlTextReaderImpl(string xmlFragment, XmlParserContext context); // 0x0000000181973A80-0x0000000181973BD0
		internal XmlTextReaderImpl(Stream stream, byte[] bytes, int byteCount, XmlReaderSettings settings, Uri baseUri, string baseUriStr, XmlParserContext context, bool closeInput); // 0x00000001819743D0-0x00000001819746D0
		internal XmlTextReaderImpl(TextReader input, XmlReaderSettings settings, string baseUriStr, XmlParserContext context); // 0x0000000181973230-0x0000000181973380
		internal XmlTextReaderImpl(string xmlFragment, XmlParserContext context, XmlReaderSettings settings); // 0x0000000181974330-0x00000001819743D0
	
		// Methods
		private void FinishInitUriString(); // 0x0000000181962D90-0x00000001819630F0
		private void FinishInitStream(); // 0x0000000181962C10-0x0000000181962CF0
		private void FinishInitTextReader(); // 0x0000000181962CF0-0x0000000181962D90
		public override string GetAttribute(string name); // 0x0000000181963790-0x0000000181963820
		public override string GetAttribute(string localName, string namespaceURI); // 0x0000000181963820-0x00000001819639B0
		public override string GetAttribute(int i); // 0x00000001819636E0-0x0000000181963790
		public override bool MoveToAttribute(string name); // 0x0000000181965DE0-0x0000000181965EB0
		public override void MoveToAttribute(int i); // 0x0000000181965EB0-0x0000000181965F90
		public override bool MoveToFirstAttribute(); // 0x0000000181966020-0x00000001819660A0
		public override bool MoveToNextAttribute(); // 0x00000001819660A0-0x0000000181966140
		public override bool MoveToElement(); // 0x0000000181965F90-0x0000000181966020
		private void FinishInit(); // 0x00000001819630F0-0x0000000181963140
		public override bool Read(); // 0x000000018196F9F0-0x0000000181970100
		public override void Close(); // 0x00000001819619E0-0x0000000181961AE0
		public override void Skip(); // 0x0000000181971A60-0x0000000181971C20
		public override string LookupNamespace(string prefix); // 0x0000000181965BC0-0x0000000181965C00
		public override bool ReadAttributeValue(); // 0x000000018196EBD0-0x000000018196EF30
		public override void ResolveEntity(); // 0x0000000181970540-0x00000001819707F0
		internal void MoveOffEntityReference(); // 0x0000000181965D10-0x0000000181965DE0
		public override string ReadString(); // 0x000000018196F400-0x000000018196F4D0
		public override int ReadValueChunk(char[] buffer, int index, int count); // 0x000000018196F4D0-0x000000018196F9F0
		public bool HasLineInfo(); // 0x00000001802E7990-0x00000001802E79A0
		IDictionary<string, string> IXmlNamespaceResolver.GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181963C90-0x0000000181963CC0
		string IXmlNamespaceResolver.LookupNamespace(string prefix); // 0x0000000181972160-0x0000000181972180
		string IXmlNamespaceResolver.LookupPrefix(string namespaceName); // 0x0000000181965CE0-0x0000000181965D10
		internal IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181963C90-0x0000000181963CC0
		internal string LookupPrefix(string namespaceName); // 0x0000000181965CE0-0x0000000181965D10
		internal void DtdParserProxy_OnNewLine(int pos); // 0x0000000181961CE0-0x0000000181961CF0
		internal int DtdParserProxy_ReadData(); // 0x0000000181962710-0x0000000181962720
		internal int DtdParserProxy_ParseNumericCharRef(StringBuilder internalSubsetBuilder); // 0x00000001819622A0-0x0000000181962350
		internal int DtdParserProxy_ParseNamedCharRef(bool expand, StringBuilder internalSubsetBuilder); // 0x0000000181962290-0x00000001819622A0
		internal void DtdParserProxy_ParsePI(StringBuilder sb); // 0x0000000181962350-0x00000001819623A0
		internal void DtdParserProxy_ParseComment(StringBuilder sb); // 0x0000000181961ED0-0x0000000181962290
		private XmlResolver GetTempResolver(); // 0x0000000181963D00-0x0000000181963D60
		internal bool DtdParserProxy_PushEntity(IDtdEntityInfo entity, out int entityId); // 0x0000000181962420-0x00000001819624F0
		internal bool DtdParserProxy_PopEntity(out IDtdEntityInfo oldEntity, out int newEntityId); // 0x00000001819623A0-0x0000000181962420
		internal bool DtdParserProxy_PushExternalSubset(string systemId, string publicId); // 0x00000001819624F0-0x0000000181962670
		internal void DtdParserProxy_PushInternalDtd(string baseUri, string internalDtd); // 0x0000000181962670-0x0000000181962710
		internal void DtdParserProxy_Throw(Exception e); // 0x0000000181962720-0x0000000181962730
		internal void DtdParserProxy_OnSystemId(string systemId, LineInfo keywordLineInfo, LineInfo systemLiteralLineInfo); // 0x0000000181961DE0-0x0000000181961ED0
		internal void DtdParserProxy_OnPublicId(string publicId, LineInfo keywordLineInfo, LineInfo publicLiteralLineInfo); // 0x0000000181961CF0-0x0000000181961DE0
		private void Throw(int pos, string res, string arg); // 0x0000000181972CE0-0x0000000181972D00
		private void Throw(int pos, string res, string[] args); // 0x0000000181972DC0-0x0000000181972DE0
		private void Throw(int pos, string res); // 0x0000000181972B40-0x0000000181972B80
		private void Throw(string res); // 0x0000000181972D00-0x0000000181972D30
		private void Throw(string res, int lineNo, int linePos); // 0x0000000181972AA0-0x0000000181972B40
		private void Throw(string res, string arg); // 0x0000000181972B80-0x0000000181972C30
		private void Throw(string res, string arg, int lineNo, int linePos); // 0x0000000181972D30-0x0000000181972DC0
		private void Throw(string res, string[] args); // 0x00000001819729F0-0x0000000181972AA0
		private void Throw(string res, string arg, Exception innerException); // 0x0000000181972960-0x00000001819729F0
		private void Throw(string res, string[] args, Exception innerException); // 0x0000000181972DE0-0x0000000181972E90
		private void Throw(Exception e); // 0x0000000181972C30-0x0000000181972CE0
		private void ReThrow(Exception e, int lineNo, int linePos); // 0x000000018196EB30-0x000000018196EBD0
		private void ThrowWithoutLineInfo(string res); // 0x00000001819728D0-0x0000000181972960
		private void ThrowWithoutLineInfo(string res, string arg); // 0x00000001819727C0-0x0000000181972840
		private void ThrowWithoutLineInfo(string res, string[] args, Exception innerException); // 0x0000000181972840-0x00000001819728D0
		private void ThrowInvalidChar(char[] data, int length, int invCharPos); // 0x0000000181972200-0x0000000181972270
		private void SetErrorState(); // 0x0000000181970AE0-0x0000000181970B00
		private void SendValidationEvent(XmlSeverityType severity, string code, string arg, int lineNo, int linePos); // 0x00000001819708D0-0x0000000181970A20
		private void SendValidationEvent(XmlSeverityType severity, XmlSchemaException exception); // 0x00000001819707F0-0x00000001819708D0
		private void FinishAttributeValueIterator(); // 0x0000000181962A00-0x0000000181962B80
		private void InitStreamInput(Stream stream, Encoding encoding); // 0x00000001819656F0-0x0000000181965730
		private void InitStreamInput(string baseUriStr, Stream stream, Encoding encoding); // 0x00000001819657B0-0x00000001819657E0
		private void InitStreamInput(Uri baseUri, Stream stream, Encoding encoding); // 0x0000000181965730-0x00000001819657B0
		private void InitStreamInput(Uri baseUri, string baseUriStr, Stream stream, Encoding encoding); // 0x00000001819657E0-0x0000000181965810
		private void InitStreamInput(Uri baseUri, string baseUriStr, Stream stream, byte[] bytes, int byteCount, Encoding encoding); // 0x0000000181965440-0x00000001819656F0
		private void InitTextReaderInput(string baseUriStr, TextReader input); // 0x0000000181965930-0x0000000181965950
		private void InitTextReaderInput(string baseUriStr, Uri baseUri, TextReader input); // 0x0000000181965950-0x0000000181965A50
		private void InitStringInput(string baseUriStr, Encoding originalEncoding, string str); // 0x0000000181965810-0x0000000181965930
		private void InitFragmentReader(XmlNodeType fragmentType, XmlParserContext parserContext, bool allowXmlDeclFragment); // 0x0000000181965180-0x0000000181965440
		private void ProcessDtdFromParserContext(XmlParserContext context); // 0x000000018196E1F0-0x000000018196E260
		private void OpenUrl(); // 0x0000000181966B20-0x0000000181966E30
		private void OpenUrlDelegate(object xmlResolver); // 0x00000001819669C0-0x0000000181966B20
		private Encoding DetectEncoding(); // 0x0000000181961AE0-0x0000000181961CE0
		private void SetupEncoding(Encoding encoding); // 0x0000000181970B00-0x0000000181970C90
		private void SwitchEncoding(Encoding newEncoding); // 0x0000000181971FC0-0x0000000181972160
		private Encoding CheckEncoding(string newEncodingName); // 0x00000001819615A0-0x00000001819618F0
		private void UnDecodeChars(); // 0x0000000181972E90-0x0000000181972F40
		private void SwitchEncodingToUTF8(); // 0x0000000181971F50-0x0000000181971FC0
		private int ReadData(); // 0x000000018196EF70-0x000000018196F400
		private int GetChars(int maxCharsCount); // 0x00000001819639B0-0x0000000181963A90
		private void InvalidCharRecovery(ref int bytesCount, out int charsCount); // 0x0000000181965A50-0x0000000181965BC0
		internal void Close(bool closeInput); // 0x00000001819618F0-0x00000001819619E0
		private void ShiftBuffer(int sourcePos, int destPos, int count); // 0x0000000181971120-0x0000000181971150
		private bool ParseXmlDeclaration(bool isTextDecl); // 0x000000018196CFA0-0x000000018196DFB0
		private bool ParseDocumentContent(); // 0x00000001819690E0-0x0000000181969670
		private bool ParseElementContent(); // 0x0000000181969B10-0x0000000181969E90
		private void ThrowUnclosedElements(); // 0x0000000181972440-0x0000000181972620
		private void ParseElement(); // 0x0000000181969E90-0x000000018196A3C0
		private void AddDefaultAttributesAndNormalize(); // 0x0000000181960480-0x0000000181960AD0
		private void ParseEndElement(); // 0x000000018196A3C0-0x000000018196A7B0
		private void ThrowTagMismatch(NodeData startTag); // 0x0000000181972270-0x0000000181972440
		private void ParseAttributes(); // 0x0000000181967EF0-0x0000000181968560
		private void ElementNamespaceLookup(); // 0x0000000181962970-0x0000000181962A00
		private void AttributeNamespaceLookup(); // 0x00000001819614A0-0x0000000181961570
		private void AttributeDuplCheck(); // 0x0000000181961070-0x00000001819614A0
		private void OnDefaultNamespaceDecl(NodeData attr); // 0x0000000181966250-0x0000000181966380
		private void OnNamespaceDecl(NodeData attr); // 0x0000000181966450-0x0000000181966540
		private void OnXmlReservedAttribute(NodeData attr); // 0x0000000181966540-0x0000000181966770
		private void ParseAttributeValueSlow(int curPos, char quoteChar, NodeData attr); // 0x0000000181967430-0x0000000181967EF0
		private void AddAttributeChunkToList(NodeData attr, NodeData chunk, ref NodeData lastChunk); // 0x000000018195F4D0-0x000000018195F550
		private bool ParseText(); // 0x000000018196C270-0x000000018196C700
		private bool ParseText(out int startPos, out int endPos, ref int outOrChars); // 0x000000018196C700-0x000000018196CE10
		private void FinishPartialValue(); // 0x0000000181963270-0x00000001819633B0
		private void FinishOtherValueIterator(); // 0x0000000181963140-0x0000000181963270
		private void SkipPartialTextValue(); // 0x00000001819714E0-0x0000000181971540
		private void FinishReadValueChunk(); // 0x00000001819635E0-0x0000000181963620
		private void FinishReadContentAsBinary(); // 0x00000001819633B0-0x0000000181963510
		private void FinishReadElementContentAsBinary(); // 0x0000000181963510-0x00000001819635E0
		private bool ParseRootLevelWhitespace(); // 0x000000018196C030-0x000000018196C270
		private void ParseEntityReference(); // 0x000000018196A8A0-0x000000018196A920
		private EntityType HandleEntityReference(bool isInAttributeValue, EntityExpandType expandType, out int charRefEndPos); // 0x0000000181963FB0-0x0000000181964240
		private EntityType HandleGeneralEntityReference(string name, bool isInAttributeValue, bool pushFakeEntityIfNullResolver, int entityStartLinePos); // 0x0000000181964240-0x00000001819646C0
		private bool HandleEntityEnd(bool checkEntityNesting); // 0x0000000181963E10-0x0000000181963FB0
		private void SetupEndEntityNodeInContent(); // 0x0000000181970D20-0x0000000181970E60
		private void SetupEndEntityNodeInAttribute(); // 0x0000000181970C90-0x0000000181970D20
		private bool ParsePI(); // 0x000000018196BD80-0x000000018196BD90
		private bool ParsePI(StringBuilder piInDtdStringBuilder); // 0x000000018196B980-0x000000018196BD80
		private bool ParsePIValue(out int outStartPos, out int outEndPos); // 0x000000018196B600-0x000000018196B980
		private bool ParseComment(); // 0x0000000181968BE0-0x0000000181968E10
		private void ParseCData(); // 0x0000000181968B50-0x0000000181968B60
		private void ParseCDataOrComment(XmlNodeType type); // 0x0000000181968990-0x0000000181968B50
		private bool ParseCDataOrComment(XmlNodeType type, out int outStartPos, out int outEndPos); // 0x0000000181968560-0x0000000181968990
		private bool ParseDoctypeDecl(); // 0x0000000181968E10-0x00000001819690E0
		private void ParseDtd(); // 0x0000000181969870-0x0000000181969B10
		private void SkipDtd(); // 0x0000000181971150-0x00000001819714E0
		private void SkipPublicOrSystemIdLiteral(); // 0x0000000181971540-0x00000001819715D0
		private void SkipUntil(char stopChar, bool recognizeLiterals); // 0x00000001819715D0-0x0000000181971A60
		private int EatWhitespaces(StringBuilder sb); // 0x0000000181962730-0x0000000181962970
		private int ParseCharRefInline(int startPos, out int charCount, out EntityType entityType); // 0x0000000181968B60-0x0000000181968BE0
		private int ParseNumericCharRef(bool expand, StringBuilder internalSubsetBuilder, out EntityType entityType); // 0x000000018196B530-0x000000018196B600
		private int ParseNumericCharRefInline(int startPos, bool expand, StringBuilder internalSubsetBuilder, out int charCount, out EntityType entityType); // 0x000000018196AD80-0x000000018196B530
		private int ParseNamedCharRef(bool expand, StringBuilder internalSubsetBuilder); // 0x000000018196AD00-0x000000018196AD80
		private int ParseNamedCharRefInline(int startPos, bool expand, StringBuilder internalSubsetBuilder); // 0x000000018196A9F0-0x000000018196AD00
		private int ParseName(); // 0x000000018196A9C0-0x000000018196A9F0
		private int ParseQName(out int colonPos); // 0x000000018196C010-0x000000018196C030
		private int ParseQName(bool isQName, int startOffset, out int colonPos); // 0x000000018196BD90-0x000000018196C010
		private bool ReadDataInName(ref int pos); // 0x000000018196EF30-0x000000018196EF70
		private string ParseEntityName(); // 0x000000018196A7B0-0x000000018196A8A0
		private NodeData AddNode(int nodeIndex, int nodeDepth); // 0x0000000181960D40-0x0000000181960EF0
		private NodeData AllocNode(int nodeIndex, int nodeDepth); // 0x0000000181960EF0-0x0000000181961070
		private NodeData AddAttributeNoChecks(string name, int attrDepth); // 0x000000018195F550-0x000000018195F5E0
		private NodeData AddAttribute(int endNamePos, int colonPos); // 0x000000018195F5E0-0x000000018195F7F0
		private NodeData AddAttribute(string localName, string prefix, string nameWPrefix); // 0x000000018195F7F0-0x000000018195F960
		private void PopElementContext(); // 0x000000018196DFB0-0x000000018196E030
		private void OnNewLine(int pos); // 0x0000000181961CE0-0x0000000181961CF0
		private void OnEof(); // 0x0000000181966380-0x0000000181966450
		private string LookupNamespace(NodeData node); // 0x0000000181965C00-0x0000000181965CE0
		private void AddNamespace(string prefix, string uri, NodeData attr); // 0x0000000181960AD0-0x0000000181960D40
		private void ResetAttributes(); // 0x0000000181970460-0x0000000181970540
		private void FullAttributeCleanup(); // 0x0000000181963620-0x00000001819636E0
		private void PushXmlContext(); // 0x000000018196EAA0-0x000000018196EB30
		private void PopXmlContext(); // 0x000000018196E1A0-0x000000018196E1F0
		private XmlNodeType GetWhitespaceType(); // 0x0000000181963DC0-0x0000000181963E10
		private XmlNodeType GetTextNodeType(int orChars); // 0x0000000181963D60-0x0000000181963DC0
		private void PushExternalEntityOrSubset(string publicId, string systemId, Uri baseUri, string entityName); // 0x000000018196E260-0x000000018196E5A0
		private bool OpenAndPush(Uri uri); // 0x0000000181966770-0x00000001819669C0
		private bool PushExternalEntity(IDtdEntityInfo entity); // 0x000000018196E5A0-0x000000018196E7B0
		private void PushInternalEntity(IDtdEntityInfo entity); // 0x000000018196E7B0-0x000000018196E910
		private void PopEntity(); // 0x000000018196E030-0x000000018196E0D0
		private void RegisterEntity(IDtdEntityInfo entity); // 0x0000000181970230-0x0000000181970460
		private void UnregisterEntity(); // 0x0000000181972F40-0x0000000181972FA0
		private void PushParsingState(); // 0x000000018196E910-0x000000018196EAA0
		private void PopParsingState(); // 0x000000018196E0D0-0x000000018196E1A0
		private int IncrementalRead(); // 0x00000001819646C0-0x0000000181965180
		private void FinishIncrementalRead(); // 0x0000000181962B80-0x0000000181962C10
		private bool ParseFragmentAttribute(); // 0x000000018196A920-0x000000018196A9C0
		private bool ParseAttributeValueChunk(); // 0x0000000181966E30-0x0000000181967430
		private void ParseXmlDeclarationFragment(); // 0x000000018196CF10-0x000000018196CFA0
		private void ThrowUnexpectedToken(int pos, string expectedToken); // 0x0000000181972650-0x0000000181972670
		private void ThrowUnexpectedToken(string expectedToken1); // 0x0000000181972640-0x0000000181972650
		private void ThrowUnexpectedToken(int pos, string expectedToken1, string expectedToken2); // 0x0000000181972620-0x0000000181972640
		private void ThrowUnexpectedToken(string expectedToken1, string expectedToken2); // 0x0000000181972670-0x00000001819727C0
		private string ParseUnexpectedToken(int pos); // 0x000000018196CE10-0x000000018196CE20
		private string ParseUnexpectedToken(); // 0x000000018196CE20-0x000000018196CF10
		private void ThrowExpectingWhitespace(int pos); // 0x0000000181972180-0x0000000181972200
		private int GetIndexOfAttributeWithoutPrefix(string name); // 0x0000000181963B80-0x0000000181963C90
		private int GetIndexOfAttributeWithPrefix(string name); // 0x0000000181963A90-0x0000000181963B80
		private bool ZeroEndingStream(int pos); // 0x0000000181973090-0x0000000181973100
		private void ParseDtdFromParserContext(); // 0x0000000181969670-0x0000000181969870
		private bool MoveToNextContentNode(bool moveIfOnContentNode); // 0x0000000181966140-0x0000000181966250
		private void SetupFromParserContext(XmlParserContext context, XmlReaderSettings settings); // 0x0000000181970E60-0x0000000181971120
		internal void SetDtdInfo(IDtdInfo newDtdInfo); // 0x0000000181970A20-0x0000000181970AE0
		internal void ChangeCurrentNodeType(XmlNodeType newNodeType); // 0x0000000181961580-0x00000001819615A0
		internal XmlResolver GetResolver(); // 0x0000000181963CC0-0x0000000181963D00
		private bool AddDefaultAttributeDtd(IDtdDefaultAttributeInfo defAttrInfo, bool definedInDtd, NodeData[] nameSortedNodeData); // 0x000000018195F960-0x000000018195FF10
		internal bool AddDefaultAttributeNonDtd(SchemaAttDef attrDef); // 0x00000001819601D0-0x0000000181960480
		private NodeData AddDefaultAttributeInternal(string localName, string ns, string prefix, string value, int lineNo, int linePos, int valueLineNo, int valueLinePos, bool isXmlAttribute); // 0x000000018195FF10-0x00000001819601D0
		private bool UriEqual(Uri uri1, string uri1Str, string uri2Str, XmlResolver resolver); // 0x0000000181972FA0-0x0000000181973090
		private void RegisterConsumedCharacters(long characters, bool inEntityReference); // 0x0000000181970100-0x0000000181970230
		internal static string StripSpaces(string value); // 0x0000000181971C20-0x0000000181971DF0
		internal static void StripSpaces(char[] value, int index, ref int len); // 0x0000000181971DF0-0x0000000181971F50
		internal static void BlockCopyChars(char[] src, int srcOffset, char[] dst, int dstOffset, int count); // 0x00000001816A6410-0x00000001816A6430
		internal static void BlockCopy(byte[] src, int srcOffset, byte[] dst, int dstOffset, int count); // 0x0000000181961570-0x0000000181961580
	}
}
