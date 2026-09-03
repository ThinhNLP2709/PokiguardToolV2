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
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class DtdParser : IDtdParser // TypeDefIndex: 6858
	{
		// Fields
		private IDtdParserAdapter readerAdapter; // 0x10
		private IDtdParserAdapterWithValidation readerAdapterWithValidation; // 0x18
		private XmlNameTable nameTable; // 0x20
		private SchemaInfo schemaInfo; // 0x28
		private XmlCharType xmlCharType; // 0x30
		private string systemId; // 0x38
		private string publicId; // 0x40
		private bool normalize; // 0x48
		private bool validate; // 0x49
		private bool supportNamespaces; // 0x4A
		private bool v1Compat; // 0x4B
		private char[] chars; // 0x50
		private int charsUsed; // 0x58
		private int curPos; // 0x5C
		private ScanningFunction scanningFunction; // 0x60
		private ScanningFunction nextScaningFunction; // 0x64
		private ScanningFunction savedScanningFunction; // 0x68
		private bool whitespaceSeen; // 0x6C
		private int tokenStartPos; // 0x70
		private int colonPos; // 0x74
		private StringBuilder internalSubsetValueSb; // 0x78
		private int externalEntitiesDepth; // 0x80
		private int currentEntityId; // 0x84
		private bool freeFloatingDtd; // 0x88
		private bool hasFreeFloatingInternalSubset; // 0x89
		private StringBuilder stringBuilder; // 0x90
		private int condSectionDepth; // 0x98
		private LineInfo literalLineInfo; // 0x9C
		private char literalQuoteChar; // 0xA4
		private string documentBaseUri; // 0xA8
		private string externalDtdBaseUri; // 0xB0
		private Dictionary<string, UndeclaredNotation> undeclaredNotations; // 0xB8
		private int[] condSectionEntityIds; // 0xC0
	
		// Properties
		private bool ParsingInternalSubset { get; } // 0x0000000181A7F0F0-0x0000000181A7F100 
		private bool IgnoreEntityReferences { get; } // 0x0000000181A7F030-0x0000000181A7F040 
		private bool SaveInternalSubsetValue { get; } // 0x0000000181A7F120-0x0000000181A7F180 
		private bool ParsingTopLevelMarkup { get; } // 0x0000000181A7F100-0x0000000181A7F120 
		private bool SupportNamespaces { get; } // 0x0000000181A42140-0x0000000181A42150 
		private bool Normalize { get; } // 0x00000001804EFDA0-0x00000001804EFDB0 
		private int LineNo { get; } // 0x0000000181A7F040-0x0000000181A7F090 
		private int LinePos { get; } // 0x0000000181A7F090-0x0000000181A7F0F0 
		private string BaseUriStr { get; } // 0x0000000181A7EF70-0x0000000181A7F030 
	
		// Nested types
		private enum Token // TypeDefIndex: 6859
		{
			CDATA = 0,
			ID = 1,
			IDREF = 2,
			IDREFS = 3,
			ENTITY = 4,
			ENTITIES = 5,
			NMTOKEN = 6,
			NMTOKENS = 7,
			NOTATION = 8,
			None = 9,
			PERef = 10,
			AttlistDecl = 11,
			ElementDecl = 12,
			EntityDecl = 13,
			NotationDecl = 14,
			Comment = 15,
			PI = 16,
			CondSectionStart = 17,
			CondSectionEnd = 18,
			Eof = 19,
			REQUIRED = 20,
			IMPLIED = 21,
			FIXED = 22,
			QName = 23,
			Name = 24,
			Nmtoken = 25,
			Quote = 26,
			LeftParen = 27,
			RightParen = 28,
			GreaterThan = 29,
			Or = 30,
			LeftBracket = 31,
			RightBracket = 32,
			PUBLIC = 33,
			SYSTEM = 34,
			Literal = 35,
			DOCTYPE = 36,
			NData = 37,
			Percent = 38,
			Star = 39,
			QMark = 40,
			Plus = 41,
			PCDATA = 42,
			Comma = 43,
			ANY = 44,
			EMPTY = 45,
			IGNORE = 46,
			INCLUDE = 47
		}
	
		private enum ScanningFunction // TypeDefIndex: 6860
		{
			SubsetContent = 0,
			Name = 1,
			QName = 2,
			Nmtoken = 3,
			Doctype1 = 4,
			Doctype2 = 5,
			Element1 = 6,
			Element2 = 7,
			Element3 = 8,
			Element4 = 9,
			Element5 = 10,
			Element6 = 11,
			Element7 = 12,
			Attlist1 = 13,
			Attlist2 = 14,
			Attlist3 = 15,
			Attlist4 = 16,
			Attlist5 = 17,
			Attlist6 = 18,
			Attlist7 = 19,
			Entity1 = 20,
			Entity2 = 21,
			Entity3 = 22,
			Notation1 = 23,
			CondSection1 = 24,
			CondSection2 = 25,
			CondSection3 = 26,
			Literal = 27,
			SystemId = 28,
			PublicId1 = 29,
			PublicId2 = 30,
			ClosingTag = 31,
			ParamEntitySpace = 32,
			None = 33
		}
	
		private enum LiteralType // TypeDefIndex: 6861
		{
			AttributeValue = 0,
			EntityReplText = 1,
			SystemOrPublicID = 2
		}
	
		private class UndeclaredNotation // TypeDefIndex: 6862
		{
			// Fields
			internal string name; // 0x10
			internal int lineNo; // 0x18
			internal int linePos; // 0x1C
			internal UndeclaredNotation next; // 0x20
	
			// Constructors
			internal UndeclaredNotation(string name, int lineNo, int linePos); // 0x0000000181A95910-0x0000000181A95980
		}
	
		private class ParseElementOnlyContent_LocalFrame // TypeDefIndex: 6863
		{
			// Fields
			public int startParenEntityId; // 0x10
			public Token parsingSchema; // 0x14
	
			// Constructors
			public ParseElementOnlyContent_LocalFrame(int startParentEntityIdParam); // 0x0000000181A8C430-0x0000000181A8C460
		}
	
		// Constructors
		private DtdParser(); // 0x0000000181A7EE90-0x0000000181A7EF70
	
		// Methods
		internal static IDtdParser Create(); // 0x0000000181A73600-0x0000000181A73700
		private void Initialize(IDtdParserAdapter readerAdapter); // 0x0000000181A75770-0x0000000181A75A20
		private void InitializeFreeFloatingDtd(string baseUri, string docTypeName, string publicId, string systemId, string internalSubset, IDtdParserAdapter adapter); // 0x0000000181A75360-0x0000000181A75770
		IDtdInfo IDtdParser.ParseInternalDtd(IDtdParserAdapter adapter, bool saveInternalSubset); // 0x0000000181A7E490-0x0000000181A7E4D0
		IDtdInfo IDtdParser.ParseFreeFloatingDtd(string baseUri, string docTypeName, string publicId, string systemId, string internalSubset, IDtdParserAdapter adapter); // 0x0000000181A7E440-0x0000000181A7E490
		private void Parse(bool saveInternalSubset); // 0x0000000181A79390-0x0000000181A795F0
		private void ParseInDocumentDtd(bool saveInternalSubset); // 0x0000000181A78620-0x0000000181A78800
		private void ParseFreeFloatingDtd(); // 0x0000000181A78550-0x0000000181A785B0
		private void ParseInternalSubset(); // 0x0000000181A78800-0x0000000181A78810
		private void ParseExternalSubset(); // 0x0000000181A783B0-0x0000000181A78550
		private void ParseSubset(); // 0x0000000181A78C00-0x0000000181A792A0
		private void ParseAttlistDecl(); // 0x0000000181A75BA0-0x0000000181A761C0
		private void ParseAttlistType(SchemaAttDef attrDef, SchemaElementDecl elementDecl, bool ignoreErrors); // 0x0000000181A76430-0x0000000181A76B40
		private void ParseAttlistDefault(SchemaAttDef attrDef, bool ignoreErrors); // 0x0000000181A761C0-0x0000000181A76430
		private void ParseElementDecl(); // 0x0000000181A76FA0-0x0000000181A77400
		private void ParseElementOnlyContent(ParticleContentValidator pcv, int startParenEntityId); // 0x0000000181A776E0-0x0000000181A77AC0
		private void ParseHowMany(ParticleContentValidator pcv); // 0x0000000181A785B0-0x0000000181A78620
		private void ParseElementMixedContent(ParticleContentValidator pcv, int startParenEntityId); // 0x0000000181A77400-0x0000000181A776E0
		private void ParseEntityDecl(); // 0x0000000181A77AC0-0x0000000181A77EB0
		private void ParseNotationDecl(); // 0x0000000181A78810-0x0000000181A78B00
		private void AddUndeclaredNotation(string notationName); // 0x0000000181A733F0-0x0000000181A73600
		private void ParseComment(); // 0x0000000181A76B40-0x0000000181A76CE0
		private void ParsePI(); // 0x0000000181A78B00-0x0000000181A78C00
		private void ParseCondSection(); // 0x0000000181A76CE0-0x0000000181A76FA0
		private void ParseExternalId(Token idTokenType, Token declType, out string publicId, out string systemId); // 0x0000000181A77EB0-0x0000000181A783B0
		private Token GetToken(bool needWhiteSpace); // 0x0000000181A73A60-0x0000000181A74D90
		private Token ScanSubsetContent(); // 0x0000000181A7D5C0-0x0000000181A7DE20
		private Token ScanNameExpected(); // 0x0000000181A7CE60-0x0000000181A7CE90
		private Token ScanQNameExpected(); // 0x0000000181A7D300-0x0000000181A7D330
		private Token ScanNmtokenExpected(); // 0x0000000181A7CEA0-0x0000000181A7CED0
		private Token ScanDoctype1(); // 0x0000000181A7B210-0x0000000181A7B390
		private Token ScanDoctype2(); // 0x0000000181A7B390-0x0000000181A7B450
		private Token ScanClosingTag(); // 0x0000000181A7A7B0-0x0000000181A7A830
		private Token ScanElement1(); // 0x0000000181A7B450-0x0000000181A7B6D0
		private Token ScanElement2(); // 0x0000000181A7B6D0-0x0000000181A7B8F0
		private Token ScanElement3(); // 0x0000000181A7B8F0-0x0000000181A7B970
		private Token ScanElement4(); // 0x0000000181A7B970-0x0000000181A7BA50
		private Token ScanElement5(); // 0x0000000181A7BA50-0x0000000181A7BB50
		private Token ScanElement6(); // 0x0000000181A7BB50-0x0000000181A7BC20
		private Token ScanElement7(); // 0x0000000181A7BC20-0x0000000181A7BC70
		private Token ScanAttlist1(); // 0x0000000181A797B0-0x0000000181A79880
		private Token ScanAttlist2(); // 0x0000000181A79880-0x0000000181A7A030
		private Token ScanAttlist3(); // 0x0000000181A7A030-0x0000000181A7A0D0
		private Token ScanAttlist4(); // 0x0000000181A7A0D0-0x0000000181A7A1A0
		private Token ScanAttlist5(); // 0x0000000181A7A1A0-0x0000000181A7A270
		private Token ScanAttlist6(); // 0x0000000181A7A270-0x0000000181A7A700
		private Token ScanAttlist7(); // 0x0000000181A7A700-0x0000000181A7A7B0
		private Token ScanLiteral(LiteralType literalType); // 0x0000000181A7C070-0x0000000181A7CE60
		private XmlQualifiedName ScanEntityName(); // 0x0000000181A7BF60-0x0000000181A7C070
		private Token ScanNotation1(); // 0x0000000181A7D0A0-0x0000000181A7D1E0
		private Token ScanSystemId(); // 0x0000000181A7DE20-0x0000000181A7DED0
		private Token ScanEntity1(); // 0x0000000181A7BC70-0x0000000181A7BCE0
		private Token ScanEntity2(); // 0x0000000181A7BCE0-0x0000000181A7BE60
		private Token ScanEntity3(); // 0x0000000181A7BE60-0x0000000181A7BF60
		private Token ScanPublicId1(); // 0x0000000181A7D1E0-0x0000000181A7D290
		private Token ScanPublicId2(); // 0x0000000181A7D290-0x0000000181A7D300
		private Token ScanCondSection1(); // 0x0000000181A7A830-0x0000000181A7AB90
		private Token ScanCondSection2(); // 0x0000000181A7AB90-0x0000000181A7AC10
		private Token ScanCondSection3(); // 0x0000000181A7AC10-0x0000000181A7B210
		private void ScanName(); // 0x0000000181A7CE90-0x0000000181A7CEA0
		private void ScanQName(); // 0x0000000181A7D5B0-0x0000000181A7D5C0
		private void ScanQName(bool isQName); // 0x0000000181A7D330-0x0000000181A7D5B0
		private bool ReadDataInName(); // 0x0000000181A795F0-0x0000000181A79630
		private void ScanNmtoken(); // 0x0000000181A7CED0-0x0000000181A7D0A0
		private bool EatPublicKeyword(); // 0x0000000181A73700-0x0000000181A737C0
		private bool EatSystemKeyword(); // 0x0000000181A737C0-0x0000000181A73880
		private XmlQualifiedName GetNameQualified(bool canHavePrefix); // 0x0000000181A73880-0x0000000181A73A30
		private string GetNameString(); // 0x0000000181A73A30-0x0000000181A73A60
		private string GetNmtokenString(); // 0x0000000181A73A30-0x0000000181A73A60
		private string GetValue(); // 0x0000000181A74E20-0x0000000181A74EA0
		private string GetValueWithStrippedSpaces(); // 0x0000000181A74D90-0x0000000181A74E20
		private int ReadData(); // 0x0000000181A79630-0x0000000181A796B0
		private void LoadParsingBuffer(); // 0x0000000181A75A30-0x0000000181A75B40
		private void SaveParsingBuffer(); // 0x0000000181A797A0-0x0000000181A797B0
		private void SaveParsingBuffer(int internalSubsetValueEndPos); // 0x0000000181A796B0-0x0000000181A797A0
		private bool HandleEntityReference(bool paramEntity, bool inLiteral, bool inAttribute); // 0x0000000181A752F0-0x0000000181A75360
		private bool HandleEntityReference(XmlQualifiedName entityName, bool paramEntity, bool inLiteral, bool inAttribute); // 0x0000000181A75000-0x0000000181A752F0
		private bool HandleEntityEnd(bool inLiteral); // 0x0000000181A74EA0-0x0000000181A75000
		private SchemaEntity VerifyEntityReference(XmlQualifiedName entityName, bool paramEntity, bool mustBeDeclared, bool inAttribute); // 0x0000000181A7EC50-0x0000000181A7EE90
		private void SendValidationEvent(int pos, XmlSeverityType severity, string code, string arg); // 0x0000000181A7DED0-0x0000000181A7E030
		private void SendValidationEvent(XmlSeverityType severity, string code, string arg); // 0x0000000181A7E030-0x0000000181A7E170
		private void SendValidationEvent(XmlSeverityType severity, XmlSchemaException e); // 0x0000000181A7E170-0x0000000181A7E270
		private bool IsAttributeValueType(Token token); // 0x0000000181A75A20-0x0000000181A75A30
		private void OnUnexpectedError(); // 0x0000000181A75B40-0x0000000181A75BA0
		private void Throw(int curPos, string res); // 0x0000000181A7E760-0x0000000181A7E790
		private void Throw(int curPos, string res, string arg); // 0x0000000181A7E790-0x0000000181A7E950
		private void Throw(int curPos, string res, string[] args); // 0x0000000181A7EA90-0x0000000181A7EC50
		private void Throw(string res, string arg, int lineNo, int linePos); // 0x0000000181A7E950-0x0000000181A7EA90
		private void ThrowInvalidChar(int pos, string data, int invCharPos); // 0x0000000181A7E550-0x0000000181A7E5D0
		private void ThrowInvalidChar(char[] data, int length, int invCharPos); // 0x0000000181A7E4D0-0x0000000181A7E550
		private void ThrowUnexpectedToken(int pos, string expectedToken); // 0x0000000181A7E5D0-0x0000000181A7E5F0
		private void ThrowUnexpectedToken(int pos, string expectedToken1, string expectedToken2); // 0x0000000181A7E5F0-0x0000000181A7E760
		private string ParseUnexpectedToken(int startPos); // 0x0000000181A792A0-0x0000000181A79390
		internal static string StripSpaces(string value); // 0x0000000181A7E270-0x0000000181A7E440
	}
}
