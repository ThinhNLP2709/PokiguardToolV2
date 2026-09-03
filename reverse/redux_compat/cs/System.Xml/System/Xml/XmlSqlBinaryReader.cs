/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal sealed class XmlSqlBinaryReader : XmlReader, IXmlNamespaceResolver // TypeDefIndex: 6688
	{
		// Fields
		internal static readonly Type TypeOfObject; // 0x00
		internal static readonly Type TypeOfString; // 0x08
		private static Type[] TokenTypeMap; // 0x10
		private static byte[] XsdKatmaiTimeScaleToValueLengthMap; // 0x18
		private static ReadState[] ScanState2ReadState; // 0x20
		private Stream inStrm; // 0x10
		private byte[] data; // 0x18
		private int pos; // 0x20
		private int mark; // 0x24
		private int end; // 0x28
		private long offset; // 0x30
		private bool eof; // 0x38
		private bool sniffed; // 0x39
		private bool isEmpty; // 0x3A
		private int docState; // 0x3C
		private SymbolTables symbolTables; // 0x40
		private XmlNameTable xnt; // 0x60
		private bool xntFromSettings; // 0x68
		private string xml; // 0x70
		private string xmlns; // 0x78
		private string nsxmlns; // 0x80
		private string baseUri; // 0x88
		private ScanState state; // 0x90
		private XmlNodeType nodetype; // 0x94
		private BinXmlToken token; // 0x98
		private int attrIndex; // 0x9C
		private QName qnameOther; // 0xA0
		private QName qnameElement; // 0xB8
		private XmlNodeType parentNodeType; // 0xD0
		private ElemInfo[] elementStack; // 0xD8
		private int elemDepth; // 0xE0
		private AttrInfo[] attributes; // 0xE8
		private int[] attrHashTbl; // 0xF0
		private int attrCount; // 0xF8
		private int posAfterAttrs; // 0xFC
		private bool xmlspacePreserve; // 0x100
		private int tokLen; // 0x104
		private int tokDataPos; // 0x108
		private bool hasTypedValue; // 0x10C
		private Type valueType; // 0x110
		private string stringValue; // 0x118
		private Dictionary<string, NamespaceDecl> namespaces; // 0x120
		private NestedBinXml prevNameInfo; // 0x128
		private XmlReader textXmlReader; // 0x130
		private bool closeInput; // 0x138
		private bool checkCharacters; // 0x139
		private bool ignoreWhitespace; // 0x13A
		private bool ignorePIs; // 0x13B
		private bool ignoreComments; // 0x13C
		private DtdProcessing dtdProcessing; // 0x140
		private SecureStringHasher hasher; // 0x148
		private XmlCharType xmlCharType; // 0x150
		private Encoding unicode; // 0x158
		private byte version; // 0x160
	
		// Properties
		public override XmlReaderSettings Settings { get; } // 0x0000000181953230-0x0000000181953350 
		public override XmlNodeType NodeType { get; } // 0x000000018033D1E0-0x000000018033D1F0 
		public override string LocalName { get; } // 0x000000018033D510-0x000000018033D520 
		public override string NamespaceURI { get; } // 0x00000001806BAE60-0x00000001806BAE70 
		public override string Prefix { get; } // 0x00000001805B5990-0x00000001805B59A0 
		public override string Value { get; } // 0x0000000181953350-0x0000000181953700 
		public override int Depth { get; } // 0x00000001819530B0-0x0000000181953180 
		public override string BaseURI { get; } // 0x000000018038B8A0-0x000000018038B8B0 
		public override bool IsEmptyElement { get; } // 0x0000000181953190-0x00000001819531B0 
		public override XmlSpace XmlSpace { get; } // 0x00000001819537A0-0x0000000181953830 
		public override string XmlLang { get; } // 0x0000000181953700-0x00000001819537A0 
		public override Type ValueType { get; } // 0x000000018170B050-0x000000018170B060 
		public override int AttributeCount { get; } // 0x0000000181953050-0x00000001819530B0 
		public override bool EOF { get; } // 0x0000000181953180-0x0000000181953190 
		public override XmlNameTable NameTable { get; } // 0x0000000180333260-0x0000000180333490 
		public override ReadState ReadState { get; } // 0x00000001819531B0-0x0000000181953230 
	
		// Nested types
		private enum ScanState // TypeDefIndex: 6689
		{
			Doc = 0,
			XmlText = 1,
			Attr = 2,
			AttrVal = 3,
			AttrValPseudoValue = 4,
			Init = 5,
			Error = 6,
			EOF = 7,
			Closed = 8
		}
	
		internal struct QName // TypeDefIndex: 6690
		{
			// Fields
			public string prefix; // 0x00
			public string localname; // 0x08
			public string namespaceUri; // 0x10
	
			// Constructors
			public QName(string prefix, string lname, string nsUri); // 0x0000000180F466A0-0x0000000180F466F0
	
			// Methods
			public void Set(string prefix, string lname, string nsUri); // 0x0000000180F466A0-0x0000000180F466F0
			public void Clear(); // 0x0000000181946C90-0x0000000181946CF0
			public bool MatchNs(string lname, string nsUri); // 0x000000018193D490-0x000000018193D4E0
			public bool MatchPrefix(string prefix, string lname); // 0x0000000181946EC0-0x0000000181946F10
			public void CheckPrefixNS(string prefix, string namespaceUri); // 0x0000000181946B80-0x0000000181946C90
			public override int GetHashCode(); // 0x0000000181946E00-0x0000000181946E60
			public int GetNSHashCode(SecureStringHasher hasher); // 0x0000000181946E60-0x0000000181946EC0
			public override bool Equals(object other); // 0x0000000181946CF0-0x0000000181946E00
			public override string ToString(); // 0x0000000181946F10-0x0000000181946F70
			public static bool operator ==(QName a, QName b); // 0x0000000181946F70-0x0000000181947000
		}
	
		private struct ElemInfo // TypeDefIndex: 6691
		{
			// Fields
			public QName name; // 0x00
			public string xmlLang; // 0x18
			public XmlSpace xmlSpace; // 0x20
			public bool xmlspacePreserve; // 0x24
			public NamespaceDecl nsdecls; // 0x28
	
			// Methods
			public void Set(QName name, bool xmlspacePreserve); // 0x0000000181943150-0x00000001819431B0
			public NamespaceDecl Clear(); // 0x0000000181943120-0x0000000181943150
		}
	
		private struct AttrInfo // TypeDefIndex: 6692
		{
			// Fields
			public QName name; // 0x00
			public string val; // 0x18
			public int contentPos; // 0x20
			public int hashCode; // 0x24
			public int prevHash; // 0x28
	
			// Methods
			public void Set(QName n, string v); // 0x000000018193D530-0x000000018193D580
			public void Set(QName n, int pos); // 0x000000018193D4E0-0x000000018193D530
			public void GetLocalnameAndNamespaceUri(out string localname, out string namespaceUri); // 0x000000018193D3F0-0x000000018193D430
			public int GetLocalnameAndNamespaceUriAndHash(SecureStringHasher hasher, out string localname, out string namespaceUri); // 0x000000018193D370-0x000000018193D3F0
			public bool MatchNS(string localname, string namespaceUri); // 0x000000018193D490-0x000000018193D4E0
			public bool MatchHashNS(int hash, string localname, string namespaceUri); // 0x000000018193D430-0x000000018193D490
			public void AdjustPosition(int adj); // 0x000000018193D360-0x000000018193D370
		}
	
		private class NamespaceDecl // TypeDefIndex: 6693
		{
			// Fields
			public string prefix; // 0x10
			public string uri; // 0x18
			public NamespaceDecl scopeLink; // 0x20
			public NamespaceDecl prevLink; // 0x28
			public int scope; // 0x30
			public bool implied; // 0x34
	
			// Constructors
			public NamespaceDecl(string prefix, string nsuri, NamespaceDecl nextInScope, NamespaceDecl prevDecl, int scope, bool implied); // 0x0000000181946A80-0x0000000181946B10
		}
	
		private struct SymbolTables // TypeDefIndex: 6694
		{
			// Fields
			public string[] symtable; // 0x00
			public int symCount; // 0x08
			public QName[] qnametable; // 0x10
			public int qnameCount; // 0x18
	
			// Methods
			public void Init(); // 0x0000000181947000-0x00000001819470C0
		}
	
		private class NestedBinXml // TypeDefIndex: 6695
		{
			// Fields
			public SymbolTables symbolTables; // 0x10
			public int docState; // 0x30
			public NestedBinXml next; // 0x38
	
			// Constructors
			public NestedBinXml(SymbolTables symbolTables, int docState, NestedBinXml next); // 0x0000000181946B10-0x0000000181946B80
		}
	
		// Constructors
		public XmlSqlBinaryReader(Stream stream, byte[] data, int len, string baseUri, bool closeInput, XmlReaderSettings settings); // 0x0000000181952A50-0x0000000181953050
		static XmlSqlBinaryReader(); // 0x0000000181952890-0x0000000181952A50
	
		// Methods
		public override string GetAttribute(string name, string ns); // 0x0000000181949570-0x00000001819496E0
		public override string GetAttribute(string name); // 0x00000001819496E0-0x0000000181949750
		public override string GetAttribute(int i); // 0x00000001819494C0-0x0000000181949570
		public override bool MoveToAttribute(string name); // 0x000000018194B840-0x000000018194B8D0
		public override void MoveToAttribute(int i); // 0x000000018194B790-0x000000018194B840
		public override bool MoveToFirstAttribute(); // 0x000000018194BA00-0x000000018194BA90
		public override bool MoveToNextAttribute(); // 0x000000018194BA90-0x000000018194BB40
		public override bool MoveToElement(); // 0x000000018194B8D0-0x000000018194BA00
		public override bool ReadAttributeValue(); // 0x000000018194CB20-0x000000018194CD00
		public override void Close(); // 0x0000000181947BE0-0x0000000181947CA0
		public override string LookupNamespace(string prefix); // 0x000000018194B6D0-0x000000018194B790
		public override void ResolveEntity(); // 0x000000018194E660-0x000000018194E6A0
		public override bool Read(); // 0x000000018194E230-0x000000018194E3B0
		IDictionary<string, string> IXmlNamespaceResolver.GetNamespacesInScope(XmlNamespaceScope scope); // 0x000000018194FAB0-0x000000018194FE20
		string IXmlNamespaceResolver.LookupPrefix(string namespaceName); // 0x000000018194FE20-0x0000000181950020
		private void VerifyVersion(int requiredVersion, BinXmlToken token); // 0x0000000181952620-0x0000000181952670
		private void AddInitNamespace(string prefix, string uri); // 0x0000000181947170-0x00000001819472B0
		private void AddName(); // 0x00000001819472B0-0x0000000181947400
		private void AddQName(); // 0x0000000181947400-0x00000001819476E0
		private void NameFlush(); // 0x000000018194BB40-0x000000018194BBA0
		private void SkipExtn(); // 0x000000018194F980-0x000000018194FAB0
		private int ReadQNameRef(); // 0x000000018194DE80-0x000000018194DF50
		private int ReadNameRef(); // 0x000000018194DDB0-0x000000018194DE80
		private bool FillAllowEOF(); // 0x0000000181947CA0-0x0000000181947EF0
		private void Fill_(int require); // 0x0000000181947EF0-0x0000000181947F70
		private void Fill(int require); // 0x0000000181947F70-0x0000000181948000
		private byte ReadByte(); // 0x000000018194CD00-0x000000018194CD50
		private ushort ReadUShort(); // 0x000000018194E1D0-0x000000018194E230
		private int ParseMB32(); // 0x000000018194C160-0x000000018194C1C0
		private int ParseMB32_(byte b); // 0x000000018194C000-0x000000018194C160
		private int ParseMB32(int pos); // 0x000000018194C1C0-0x000000018194C2E0
		private int ParseMB64(); // 0x000000018194C160-0x000000018194C1C0
		private BinXmlToken PeekToken(); // 0x000000018194C3D0-0x000000018194C650
		private BinXmlToken ReadToken(); // 0x000000018194DF50-0x000000018194E1D0
		private BinXmlToken NextToken2(BinXmlToken token); // 0x000000018194BC10-0x000000018194BF60
		private BinXmlToken NextToken1(); // 0x000000018194BBA0-0x000000018194BC10
		private BinXmlToken NextToken(); // 0x000000018194BF60-0x000000018194C000
		private BinXmlToken PeekNextToken(); // 0x000000018194C3B0-0x000000018194C3D0
		private BinXmlToken RescanNextToken(); // 0x000000018194E3B0-0x000000018194E660
		private string ParseText(); // 0x000000018194C2E0-0x000000018194C3B0
		private int ScanText(out int start); // 0x000000018194F6B0-0x000000018194F810
		private string GetString(int pos, int cch); // 0x0000000181949B60-0x0000000181949D30
		private string GetStringAligned(byte[] data, int offset, int cch); // 0x0000000181949B20-0x0000000181949B60
		private string GetAttributeText(int i); // 0x0000000181949310-0x00000001819494C0
		private int LocateAttribute(string name, string ns); // 0x000000018194B530-0x000000018194B5E0
		private int LocateAttribute(string name); // 0x000000018194B5E0-0x000000018194B6D0
		private void PositionOnAttribute(int i); // 0x000000018194C730-0x000000018194C850
		private void GrowElements(); // 0x000000018194A010-0x000000018194A0B0
		private void GrowAttributes(); // 0x0000000181949F70-0x000000018194A010
		private void ClearAttributes(); // 0x0000000181947BC0-0x0000000181947BE0
		private void PushNamespace(string prefix, string ns, bool implied); // 0x000000018194C850-0x000000018194CB00
		private void PopNamespaces(NamespaceDecl firstInScopeChain); // 0x000000018194C650-0x000000018194C730
		private void GenerateImpliedXmlnsAttrs(); // 0x00000001819481C0-0x0000000181948410
		private bool ReadInit(bool skipXmlDecl); // 0x000000018194D6D0-0x000000018194DDB0
		private void ScanAttributes(); // 0x000000018194E6A0-0x000000018194EE10
		private void SimpleCheckForDuplicateAttributes(); // 0x000000018194F810-0x000000018194F980
		private void HashCheckForDuplicateAttributes(); // 0x000000018194A0B0-0x000000018194A3E0
		private string XmlDeclValue(); // 0x0000000181952670-0x00000001819527C0
		private string CDATAValue(); // 0x00000001819476E0-0x0000000181947800
		private void FinishCDATA(); // 0x0000000181948000-0x00000001819480A0
		private void FinishEndElement(); // 0x00000001819480A0-0x00000001819481C0
		private bool ReadDoc(); // 0x000000018194CD50-0x000000018194D6D0
		private void ImplReadData(BinXmlToken tokenType); // 0x000000018194A4B0-0x000000018194A660
		private void ImplReadElement(); // 0x000000018194AA60-0x000000018194AE30
		private void ImplReadEndElement(); // 0x000000018194AE30-0x000000018194AF30
		private void ImplReadDoctype(); // 0x000000018194A660-0x000000018194AA60
		private void ImplReadPI(); // 0x000000018194B0D0-0x000000018194B150
		private void ImplReadComment(); // 0x000000018194A470-0x000000018194A4B0
		private void ImplReadCDATA(); // 0x000000018194A3E0-0x000000018194A470
		private void ImplReadNest(); // 0x000000018194AFA0-0x000000018194B0D0
		private void ImplReadEndNest(); // 0x000000018194AF30-0x000000018194AFA0
		private void ImplReadXmlText(); // 0x000000018194B150-0x000000018194B530
		private void UpdateFromTextReader(); // 0x0000000181950270-0x0000000181950390
		private bool UpdateFromTextReader(bool needUpdate); // 0x0000000181950390-0x00000001819503B0
		private void CheckAllowContent(); // 0x0000000181947800-0x0000000181947860
		private void GenerateTokenTypeMap(); // 0x0000000181948410-0x0000000181949310
		private Type GetValueType(BinXmlToken token); // 0x0000000181949D30-0x0000000181949E10
		private void ReScanOverValue(BinXmlToken token); // 0x000000018194CB00-0x000000018194CB20
		private XmlNodeType ScanOverValue(BinXmlToken token, bool attr, bool checkChars); // 0x000000018194F490-0x000000018194F6B0
		private XmlNodeType ScanOverAnyValue(BinXmlToken token, bool attr, bool checkChars); // 0x000000018194EE10-0x000000018194F490
		private XmlNodeType CheckText(bool attr); // 0x0000000181947900-0x0000000181947B60
		private XmlNodeType CheckTextIsWS(); // 0x0000000181947860-0x0000000181947900
		private void CheckValueTokenBounds(); // 0x0000000181947B60-0x0000000181947BC0
		private int GetXsdKatmaiTokenLength(BinXmlToken token); // 0x0000000181949E10-0x0000000181949F70
		private int XsdKatmaiTimeScaleToValueLength(byte scale); // 0x00000001819527C0-0x0000000181952890
		private long ValueAsLong(); // 0x0000000181951710-0x0000000181951C50
		private ulong ValueAsULong(); // 0x0000000181952580-0x0000000181952620
		private decimal ValueAsDecimal(); // 0x0000000181951140-0x0000000181951510
		private double ValueAsDouble(); // 0x0000000181951510-0x0000000181951710
		private string ValueAsDateTimeString(); // 0x00000001819503B0-0x0000000181951140
		private string ValueAsString(BinXmlToken token); // 0x0000000181951C50-0x0000000181952580
		private short GetInt16(int pos); // 0x00000001819498B0-0x0000000181949900
		private ushort GetUInt16(int pos); // 0x00000001819498B0-0x0000000181949900
		private int GetInt32(int pos); // 0x0000000181949900-0x0000000181949980
		private uint GetUInt32(int pos); // 0x0000000181949900-0x0000000181949980
		private long GetInt64(int pos); // 0x0000000181949980-0x0000000181949AA0
		private ulong GetUInt64(int pos); // 0x0000000181949980-0x0000000181949AA0
		private float GetSingle(int offset); // 0x0000000181949AA0-0x0000000181949B20
		private double GetDouble(int offset); // 0x0000000181949750-0x00000001819498B0
		private Exception ThrowUnexpectedToken(BinXmlToken token); // 0x0000000181950090-0x0000000181950120
		private Exception ThrowXmlException(string res); // 0x0000000181950200-0x0000000181950270
		private Exception ThrowXmlException(string res, string arg1, string arg2); // 0x0000000181950120-0x0000000181950200
		private Exception ThrowNotSupported(string res); // 0x0000000181950020-0x0000000181950090
	}
}
