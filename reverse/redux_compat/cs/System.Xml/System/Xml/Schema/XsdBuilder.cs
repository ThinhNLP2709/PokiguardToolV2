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
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal sealed class XsdBuilder : SchemaBuilder // TypeDefIndex: 7280
	{
		// Fields
		private static readonly State[] SchemaElement; // 0x00
		private static readonly State[] SchemaSubelements; // 0x08
		private static readonly State[] AttributeSubelements; // 0x10
		private static readonly State[] ElementSubelements; // 0x18
		private static readonly State[] ComplexTypeSubelements; // 0x20
		private static readonly State[] SimpleContentSubelements; // 0x28
		private static readonly State[] SimpleContentExtensionSubelements; // 0x30
		private static readonly State[] SimpleContentRestrictionSubelements; // 0x38
		private static readonly State[] ComplexContentSubelements; // 0x40
		private static readonly State[] ComplexContentExtensionSubelements; // 0x48
		private static readonly State[] ComplexContentRestrictionSubelements; // 0x50
		private static readonly State[] SimpleTypeSubelements; // 0x58
		private static readonly State[] SimpleTypeRestrictionSubelements; // 0x60
		private static readonly State[] SimpleTypeListSubelements; // 0x68
		private static readonly State[] SimpleTypeUnionSubelements; // 0x70
		private static readonly State[] RedefineSubelements; // 0x78
		private static readonly State[] AttributeGroupSubelements; // 0x80
		private static readonly State[] GroupSubelements; // 0x88
		private static readonly State[] AllSubelements; // 0x90
		private static readonly State[] ChoiceSequenceSubelements; // 0x98
		private static readonly State[] IdentityConstraintSubelements; // 0xA0
		private static readonly State[] AnnotationSubelements; // 0xA8
		private static readonly State[] AnnotatedSubelements; // 0xB0
		private static readonly XsdAttributeEntry[] SchemaAttributes; // 0xB8
		private static readonly XsdAttributeEntry[] AttributeAttributes; // 0xC0
		private static readonly XsdAttributeEntry[] ElementAttributes; // 0xC8
		private static readonly XsdAttributeEntry[] ComplexTypeAttributes; // 0xD0
		private static readonly XsdAttributeEntry[] SimpleContentAttributes; // 0xD8
		private static readonly XsdAttributeEntry[] SimpleContentExtensionAttributes; // 0xE0
		private static readonly XsdAttributeEntry[] SimpleContentRestrictionAttributes; // 0xE8
		private static readonly XsdAttributeEntry[] ComplexContentAttributes; // 0xF0
		private static readonly XsdAttributeEntry[] ComplexContentExtensionAttributes; // 0xF8
		private static readonly XsdAttributeEntry[] ComplexContentRestrictionAttributes; // 0x100
		private static readonly XsdAttributeEntry[] SimpleTypeAttributes; // 0x108
		private static readonly XsdAttributeEntry[] SimpleTypeRestrictionAttributes; // 0x110
		private static readonly XsdAttributeEntry[] SimpleTypeUnionAttributes; // 0x118
		private static readonly XsdAttributeEntry[] SimpleTypeListAttributes; // 0x120
		private static readonly XsdAttributeEntry[] AttributeGroupAttributes; // 0x128
		private static readonly XsdAttributeEntry[] AttributeGroupRefAttributes; // 0x130
		private static readonly XsdAttributeEntry[] GroupAttributes; // 0x138
		private static readonly XsdAttributeEntry[] GroupRefAttributes; // 0x140
		private static readonly XsdAttributeEntry[] ParticleAttributes; // 0x148
		private static readonly XsdAttributeEntry[] AnyAttributes; // 0x150
		private static readonly XsdAttributeEntry[] IdentityConstraintAttributes; // 0x158
		private static readonly XsdAttributeEntry[] SelectorAttributes; // 0x160
		private static readonly XsdAttributeEntry[] FieldAttributes; // 0x168
		private static readonly XsdAttributeEntry[] NotationAttributes; // 0x170
		private static readonly XsdAttributeEntry[] IncludeAttributes; // 0x178
		private static readonly XsdAttributeEntry[] ImportAttributes; // 0x180
		private static readonly XsdAttributeEntry[] FacetAttributes; // 0x188
		private static readonly XsdAttributeEntry[] AnyAttributeAttributes; // 0x190
		private static readonly XsdAttributeEntry[] DocumentationAttributes; // 0x198
		private static readonly XsdAttributeEntry[] AppinfoAttributes; // 0x1A0
		private static readonly XsdAttributeEntry[] RedefineAttributes; // 0x1A8
		private static readonly XsdAttributeEntry[] AnnotationAttributes; // 0x1B0
		private static readonly XsdEntry[] SchemaEntries; // 0x1B8
		private static readonly int[] DerivationMethodValues; // 0x1C0
		private static readonly string[] DerivationMethodStrings; // 0x1C8
		private static readonly string[] FormStringValues; // 0x1D0
		private static readonly string[] UseStringValues; // 0x1D8
		private static readonly string[] ProcessContentsStringValues; // 0x1E0
		private XmlReader reader; // 0x10
		private PositionInfo positionInfo; // 0x18
		private XsdEntry currentEntry; // 0x20
		private XsdEntry nextEntry; // 0x28
		private bool hasChild; // 0x30
		private HWStack stateHistory; // 0x38
		private Stack containerStack; // 0x40
		private XmlNameTable nameTable; // 0x48
		private SchemaNames schemaNames; // 0x50
		private XmlNamespaceManager namespaceManager; // 0x58
		private bool canIncludeImport; // 0x60
		private XmlSchema schema; // 0x68
		private XmlSchemaObject xso; // 0x70
		private XmlSchemaElement element; // 0x78
		private XmlSchemaAny anyElement; // 0x80
		private XmlSchemaAttribute attribute; // 0x88
		private XmlSchemaAnyAttribute anyAttribute; // 0x90
		private XmlSchemaComplexType complexType; // 0x98
		private XmlSchemaSimpleType simpleType; // 0xA0
		private XmlSchemaComplexContent complexContent; // 0xA8
		private XmlSchemaComplexContentExtension complexContentExtension; // 0xB0
		private XmlSchemaComplexContentRestriction complexContentRestriction; // 0xB8
		private XmlSchemaSimpleContent simpleContent; // 0xC0
		private XmlSchemaSimpleContentExtension simpleContentExtension; // 0xC8
		private XmlSchemaSimpleContentRestriction simpleContentRestriction; // 0xD0
		private XmlSchemaSimpleTypeUnion simpleTypeUnion; // 0xD8
		private XmlSchemaSimpleTypeList simpleTypeList; // 0xE0
		private XmlSchemaSimpleTypeRestriction simpleTypeRestriction; // 0xE8
		private XmlSchemaGroup group; // 0xF0
		private XmlSchemaGroupRef groupRef; // 0xF8
		private XmlSchemaAll all; // 0x100
		private XmlSchemaChoice choice; // 0x108
		private XmlSchemaSequence sequence; // 0x110
		private XmlSchemaParticle particle; // 0x118
		private XmlSchemaAttributeGroup attributeGroup; // 0x120
		private XmlSchemaAttributeGroupRef attributeGroupRef; // 0x128
		private XmlSchemaNotation notation; // 0x130
		private XmlSchemaIdentityConstraint identityConstraint; // 0x138
		private XmlSchemaXPath xpath; // 0x140
		private XmlSchemaInclude include; // 0x148
		private XmlSchemaImport import; // 0x150
		private XmlSchemaAnnotation annotation; // 0x158
		private XmlSchemaAppInfo appInfo; // 0x160
		private XmlSchemaDocumentation documentation; // 0x168
		private XmlSchemaFacet facet; // 0x170
		private XmlNode[] markup; // 0x178
		private XmlSchemaRedefine redefine; // 0x180
		private ValidationEventHandler validationEventHandler; // 0x188
		private ArrayList unhandledAttributes; // 0x190
		private Hashtable namespaces; // 0x198
	
		// Properties
		private SchemaNames.Token CurrentElement { get; } // 0x000000018167FC20-0x000000018167FC40 
		private SchemaNames.Token ParentElement { get; } // 0x0000000181A209B0-0x0000000181A20A30 
		private XmlSchemaObject ParentContainer { get; } // 0x0000000181A20920-0x0000000181A209B0 
	
		// Nested types
		private enum State // TypeDefIndex: 7281
		{
			Root = 0,
			Schema = 1,
			Annotation = 2,
			Include = 3,
			Import = 4,
			Element = 5,
			Attribute = 6,
			AttributeGroup = 7,
			AttributeGroupRef = 8,
			AnyAttribute = 9,
			Group = 10,
			GroupRef = 11,
			All = 12,
			Choice = 13,
			Sequence = 14,
			Any = 15,
			Notation = 16,
			SimpleType = 17,
			ComplexType = 18,
			ComplexContent = 19,
			ComplexContentRestriction = 20,
			ComplexContentExtension = 21,
			SimpleContent = 22,
			SimpleContentExtension = 23,
			SimpleContentRestriction = 24,
			SimpleTypeUnion = 25,
			SimpleTypeList = 26,
			SimpleTypeRestriction = 27,
			Unique = 28,
			Key = 29,
			KeyRef = 30,
			Selector = 31,
			Field = 32,
			MinExclusive = 33,
			MinInclusive = 34,
			MaxExclusive = 35,
			MaxInclusive = 36,
			TotalDigits = 37,
			FractionDigits = 38,
			Length = 39,
			MinLength = 40,
			MaxLength = 41,
			Enumeration = 42,
			Pattern = 43,
			WhiteSpace = 44,
			AppInfo = 45,
			Documentation = 46,
			Redefine = 47
		}
	
		private delegate void XsdBuildFunction(XsdBuilder builder, string value); // TypeDefIndex: 7282; 0x0000000180A70FB0-0x0000000180A70FC0
	
		private delegate void XsdInitFunction(XsdBuilder builder, string value); // TypeDefIndex: 7283; 0x0000000180A70FB0-0x0000000180A70FC0
	
		private delegate void XsdEndChildFunction(XsdBuilder builder); // TypeDefIndex: 7284; 0x00000001804A78A0-0x00000001804A78B0
	
		private sealed class XsdAttributeEntry // TypeDefIndex: 7285
		{
			// Fields
			public SchemaNames.Token Attribute; // 0x10
			public XsdBuildFunction BuildFunc; // 0x18
	
			// Constructors
			public XsdAttributeEntry(SchemaNames.Token a, XsdBuildFunction build); // 0x00000001806F4520-0x00000001806F4560
		}
	
		private sealed class XsdEntry // TypeDefIndex: 7286
		{
			// Fields
			public SchemaNames.Token Name; // 0x10
			public State CurrentState; // 0x14
			public State[] NextStates; // 0x18
			public XsdAttributeEntry[] Attributes; // 0x20
			public XsdInitFunction InitFunc; // 0x28
			public XsdEndChildFunction EndChildFunc; // 0x30
			public bool ParseContent; // 0x38
	
			// Constructors
			public XsdEntry(SchemaNames.Token n, State state, State[] nextStates, XsdAttributeEntry[] attributes, XsdInitFunction init, XsdEndChildFunction end, bool parseContent); // 0x0000000181A2D5B0-0x0000000181A2D640
		}
	
		private class BuilderNamespaceManager : XmlNamespaceManager // TypeDefIndex: 7287
		{
			// Fields
			private XmlNamespaceManager nsMgr; // 0x50
			private XmlReader reader; // 0x58
	
			// Constructors
			public BuilderNamespaceManager(XmlNamespaceManager nsMgr, XmlReader reader); // 0x0000000181A20BF0-0x0000000181A20C40
	
			// Methods
			public override string LookupNamespace(string prefix); // 0x0000000181A20B80-0x0000000181A20BF0
		}
	
		// Constructors
		internal XsdBuilder(XmlReader reader, XmlNamespaceManager curmgr, XmlSchema schema, XmlNameTable nameTable, SchemaNames schemaNames, ValidationEventHandler eventhandler); // 0x0000000181A206C0-0x0000000181A20920
		static XsdBuilder(); // 0x0000000181A1A6F0-0x0000000181A206C0
	
		// Methods
		internal override bool ProcessElement(string prefix, string name, string ns); // 0x0000000181A18300-0x0000000181A184F0
		internal override void ProcessAttribute(string prefix, string name, string ns, string value); // 0x0000000181A17DC0-0x0000000181A182B0
		internal override bool IsContentParsed(); // 0x0000000181A17710-0x0000000181A17730
		internal override void ProcessMarkup(XmlNode[] markup); // 0x00000001813800F0-0x0000000181380110
		internal override void ProcessCData(string value); // 0x0000000181A182B0-0x0000000181A18300
		internal override void StartChildren(); // 0x0000000181A1A520-0x0000000181A1A6F0
		internal override void EndChildren(); // 0x0000000181A14B90-0x0000000181A14CA0
		private void Push(); // 0x0000000181A184F0-0x0000000181A187D0
		private void Pop(); // 0x0000000181A17CD0-0x0000000181A17DC0
		private XmlSchemaObject GetContainer(State state); // 0x0000000181A14D00-0x0000000181A14F50
		private void SetContainer(State state, object container); // 0x0000000181A18D80-0x0000000181A1A460
		private static void BuildAnnotated_Id(XsdBuilder builder, string value); // 0x0000000181A12F40-0x0000000181A12F70
		private static void BuildSchema_AttributeFormDefault(XsdBuilder builder, string value); // 0x0000000181A14450-0x0000000181A14500
		private static void BuildSchema_ElementFormDefault(XsdBuilder builder, string value); // 0x0000000181A14570-0x0000000181A14620
		private static void BuildSchema_TargetNamespace(XsdBuilder builder, string value); // 0x0000000181A14690-0x0000000181A146C0
		private static void BuildSchema_Version(XsdBuilder builder, string value); // 0x0000000181A146C0-0x0000000181A146F0
		private static void BuildSchema_FinalDefault(XsdBuilder builder, string value); // 0x0000000181A14620-0x0000000181A14690
		private static void BuildSchema_BlockDefault(XsdBuilder builder, string value); // 0x0000000181A14500-0x0000000181A14570
		private static void InitSchema(XsdBuilder builder, string value); // 0x0000000181A16B70-0x0000000181A16BA0
		private static void InitInclude(XsdBuilder builder, string value); // 0x0000000181A16920-0x0000000181A169F0
		private static void BuildInclude_SchemaLocation(XsdBuilder builder, string value); // 0x0000000181A14300-0x0000000181A14330
		private static void InitImport(XsdBuilder builder, string value); // 0x0000000181A16850-0x0000000181A16920
		private static void BuildImport_Namespace(XsdBuilder builder, string value); // 0x0000000181A142A0-0x0000000181A142D0
		private static void BuildImport_SchemaLocation(XsdBuilder builder, string value); // 0x0000000181A142D0-0x0000000181A14300
		private static void InitRedefine(XsdBuilder builder, string value); // 0x0000000181A16AA0-0x0000000181A16B70
		private static void BuildRedefine_SchemaLocation(XsdBuilder builder, string value); // 0x0000000181A14420-0x0000000181A14450
		private static void EndRedefine(XsdBuilder builder); // 0x0000000181A14CE0-0x0000000181A14D00
		private static void InitAttribute(XsdBuilder builder, string value); // 0x0000000181A158F0-0x0000000181A159D0
		private static void BuildAttribute_Default(XsdBuilder builder, string value); // 0x0000000181A13270-0x0000000181A132A0
		private static void BuildAttribute_Fixed(XsdBuilder builder, string value); // 0x0000000181A132A0-0x0000000181A132D0
		private static void BuildAttribute_Form(XsdBuilder builder, string value); // 0x0000000181A132D0-0x0000000181A13380
		private static void BuildAttribute_Use(XsdBuilder builder, string value); // 0x0000000181A134B0-0x0000000181A13560
		private static void BuildAttribute_Ref(XsdBuilder builder, string value); // 0x0000000181A133B0-0x0000000181A13430
		private static void BuildAttribute_Name(XsdBuilder builder, string value); // 0x0000000181A13380-0x0000000181A133B0
		private static void BuildAttribute_Type(XsdBuilder builder, string value); // 0x0000000181A13430-0x0000000181A134B0
		private static void InitElement(XsdBuilder builder, string value); // 0x0000000181A16000-0x0000000181A16120
		private static void BuildElement_Abstract(XsdBuilder builder, string value); // 0x0000000181A13A90-0x0000000181A13B10
		private static void BuildElement_Block(XsdBuilder builder, string value); // 0x0000000181A13B10-0x0000000181A13B80
		private static void BuildElement_Default(XsdBuilder builder, string value); // 0x0000000181A13B80-0x0000000181A13BB0
		private static void BuildElement_Form(XsdBuilder builder, string value); // 0x0000000181A13C50-0x0000000181A13D00
		private static void BuildElement_SubstitutionGroup(XsdBuilder builder, string value); // 0x0000000181A13E90-0x0000000181A13F10
		private static void BuildElement_Final(XsdBuilder builder, string value); // 0x0000000181A13BB0-0x0000000181A13C20
		private static void BuildElement_Fixed(XsdBuilder builder, string value); // 0x0000000181A13C20-0x0000000181A13C50
		private static void BuildElement_MaxOccurs(XsdBuilder builder, string value); // 0x0000000181A13D00-0x0000000181A13D30
		private static void BuildElement_MinOccurs(XsdBuilder builder, string value); // 0x0000000181A13D30-0x0000000181A13D60
		private static void BuildElement_Name(XsdBuilder builder, string value); // 0x0000000181A13D60-0x0000000181A13D90
		private static void BuildElement_Nillable(XsdBuilder builder, string value); // 0x0000000181A13D90-0x0000000181A13E10
		private static void BuildElement_Ref(XsdBuilder builder, string value); // 0x0000000181A13E10-0x0000000181A13E90
		private static void BuildElement_Type(XsdBuilder builder, string value); // 0x0000000181A13F10-0x0000000181A13F90
		private static void InitSimpleType(XsdBuilder builder, string value); // 0x0000000181A17360-0x0000000181A17710
		private static void BuildSimpleType_Name(XsdBuilder builder, string value); // 0x0000000181A14B20-0x0000000181A14B50
		private static void BuildSimpleType_Final(XsdBuilder builder, string value); // 0x0000000181A14AB0-0x0000000181A14B20
		private static void InitSimpleTypeUnion(XsdBuilder builder, string value); // 0x0000000181A17270-0x0000000181A17360
		private static void BuildSimpleTypeUnion_MemberTypes(XsdBuilder builder, string value); // 0x0000000181A148F0-0x0000000181A14AB0
		private static void InitSimpleTypeList(XsdBuilder builder, string value); // 0x0000000181A17090-0x0000000181A17180
		private static void BuildSimpleTypeList_ItemType(XsdBuilder builder, string value); // 0x0000000181A147F0-0x0000000181A14870
		private static void InitSimpleTypeRestriction(XsdBuilder builder, string value); // 0x0000000181A17180-0x0000000181A17270
		private static void BuildSimpleTypeRestriction_Base(XsdBuilder builder, string value); // 0x0000000181A14870-0x0000000181A148F0
		private static void InitComplexType(XsdBuilder builder, string value); // 0x0000000181A15D80-0x0000000181A15F20
		private static void BuildComplexType_Abstract(XsdBuilder builder, string value); // 0x0000000181A136E0-0x0000000181A13760
		private static void BuildComplexType_Block(XsdBuilder builder, string value); // 0x0000000181A13760-0x0000000181A137E0
		private static void BuildComplexType_Final(XsdBuilder builder, string value); // 0x0000000181A137E0-0x0000000181A13850
		private static void BuildComplexType_Mixed(XsdBuilder builder, string value); // 0x0000000181A13850-0x0000000181A138E0
		private static void BuildComplexType_Name(XsdBuilder builder, string value); // 0x0000000181A138E0-0x0000000181A13910
		private static void InitComplexContent(XsdBuilder builder, string value); // 0x0000000181A15C40-0x0000000181A15D80
		private static void BuildComplexContent_Mixed(XsdBuilder builder, string value); // 0x0000000181A13660-0x0000000181A136E0
		private static void InitComplexContentExtension(XsdBuilder builder, string value); // 0x0000000181A15A80-0x0000000181A15B90
		private static void BuildComplexContentExtension_Base(XsdBuilder builder, string value); // 0x0000000181A13560-0x0000000181A135E0
		private static void InitComplexContentRestriction(XsdBuilder builder, string value); // 0x0000000181A15B90-0x0000000181A15C40
		private static void BuildComplexContentRestriction_Base(XsdBuilder builder, string value); // 0x0000000181A135E0-0x0000000181A13660
		private static void InitSimpleContent(XsdBuilder builder, string value); // 0x0000000181A16F50-0x0000000181A17090
		private static void InitSimpleContentExtension(XsdBuilder builder, string value); // 0x0000000181A16D30-0x0000000181A16E40
		private static void BuildSimpleContentExtension_Base(XsdBuilder builder, string value); // 0x0000000181A146F0-0x0000000181A14770
		private static void InitSimpleContentRestriction(XsdBuilder builder, string value); // 0x0000000181A16E40-0x0000000181A16F50
		private static void BuildSimpleContentRestriction_Base(XsdBuilder builder, string value); // 0x0000000181A14770-0x0000000181A147F0
		private static void InitAttributeGroup(XsdBuilder builder, string value); // 0x0000000181A15810-0x0000000181A158F0
		private static void BuildAttributeGroup_Name(XsdBuilder builder, string value); // 0x0000000181A13240-0x0000000181A13270
		private static void InitAttributeGroupRef(XsdBuilder builder, string value); // 0x0000000181A15780-0x0000000181A15810
		private static void BuildAttributeGroupRef_Ref(XsdBuilder builder, string value); // 0x0000000181A131C0-0x0000000181A13240
		private static void InitAnyAttribute(XsdBuilder builder, string value); // 0x0000000181A152E0-0x0000000181A155F0
		private static void BuildAnyAttribute_Namespace(XsdBuilder builder, string value); // 0x0000000181A12F70-0x0000000181A12FA0
		private static void BuildAnyAttribute_ProcessContents(XsdBuilder builder, string value); // 0x0000000181A12FA0-0x0000000181A13050
		private static void InitGroup(XsdBuilder builder, string value); // 0x0000000181A16620-0x0000000181A166F0
		private static void BuildGroup_Name(XsdBuilder builder, string value); // 0x0000000181A14100-0x0000000181A14130
		private static void InitGroupRef(XsdBuilder builder, string value); // 0x0000000181A16570-0x0000000181A16620
		private static void BuildParticle_MaxOccurs(XsdBuilder builder, string value); // 0x0000000181A143C0-0x0000000181A143F0
		private static void BuildParticle_MinOccurs(XsdBuilder builder, string value); // 0x0000000181A143F0-0x0000000181A14420
		private static void BuildGroupRef_Ref(XsdBuilder builder, string value); // 0x0000000181A14080-0x0000000181A14100
		private static void InitAll(XsdBuilder builder, string value); // 0x0000000181A15130-0x0000000181A151E0
		private static void InitChoice(XsdBuilder builder, string value); // 0x0000000181A159D0-0x0000000181A15A80
		private static void InitSequence(XsdBuilder builder, string value); // 0x0000000181A16C80-0x0000000181A16D30
		private static void InitAny(XsdBuilder builder, string value); // 0x0000000181A155F0-0x0000000181A156A0
		private static void BuildAny_Namespace(XsdBuilder builder, string value); // 0x0000000181A13050-0x0000000181A13080
		private static void BuildAny_ProcessContents(XsdBuilder builder, string value); // 0x0000000181A13080-0x0000000181A13140
		private static void InitNotation(XsdBuilder builder, string value); // 0x0000000181A169F0-0x0000000181A16AA0
		private static void BuildNotation_Name(XsdBuilder builder, string value); // 0x0000000181A14330-0x0000000181A14360
		private static void BuildNotation_Public(XsdBuilder builder, string value); // 0x0000000181A14360-0x0000000181A14390
		private static void BuildNotation_System(XsdBuilder builder, string value); // 0x0000000181A14390-0x0000000181A143C0
		private static void InitFacet(XsdBuilder builder, string value); // 0x0000000181A16120-0x0000000181A16490
		private static void BuildFacet_Fixed(XsdBuilder builder, string value); // 0x0000000181A13F90-0x0000000181A14020
		private static void BuildFacet_Value(XsdBuilder builder, string value); // 0x0000000181A14020-0x0000000181A14050
		private static void InitIdentityConstraint(XsdBuilder builder, string value); // 0x0000000181A166F0-0x0000000181A16850
		private static void BuildIdentityConstraint_Name(XsdBuilder builder, string value); // 0x0000000181A14130-0x0000000181A14160
		private static void BuildIdentityConstraint_Refer(XsdBuilder builder, string value); // 0x0000000181A14160-0x0000000181A142A0
		private static void InitSelector(XsdBuilder builder, string value); // 0x0000000181A16BA0-0x0000000181A16C80
		private static void BuildSelector_XPath(XsdBuilder builder, string value); // 0x0000000181A14050-0x0000000181A14080
		private static void InitField(XsdBuilder builder, string value); // 0x0000000181A16490-0x0000000181A16570
		private static void BuildField_XPath(XsdBuilder builder, string value); // 0x0000000181A14050-0x0000000181A14080
		private static void InitAnnotation(XsdBuilder builder, string value); // 0x0000000181A151E0-0x0000000181A152E0
		private static void InitAppinfo(XsdBuilder builder, string value); // 0x0000000181A156A0-0x0000000181A15780
		private static void BuildAppinfo_Source(XsdBuilder builder, string value); // 0x0000000181A13140-0x0000000181A131C0
		private static void EndAppinfo(XsdBuilder builder); // 0x0000000181A14B50-0x0000000181A14B90
		private static void InitDocumentation(XsdBuilder builder, string value); // 0x0000000181A15F20-0x0000000181A16000
		private static void BuildDocumentation_Source(XsdBuilder builder, string value); // 0x0000000181A13910-0x0000000181A13990
		private static void BuildDocumentation_XmlLang(XsdBuilder builder, string value); // 0x0000000181A13990-0x0000000181A13A90
		private static void EndDocumentation(XsdBuilder builder); // 0x0000000181A14CA0-0x0000000181A14CE0
		private void AddAttribute(XmlSchemaObject value); // 0x0000000181A12940-0x0000000181A12BB0
		private void AddParticle(XmlSchemaParticle particle); // 0x0000000181A12BB0-0x0000000181A12F40
		private bool GetNextState(XmlQualifiedName qname); // 0x0000000181A14F50-0x0000000181A15130
		private bool IsSkipableElement(XmlQualifiedName qname); // 0x0000000181A17730-0x0000000181A17760
		private void SetMinOccurs(XmlSchemaParticle particle, string value); // 0x0000000181A1A4C0-0x0000000181A1A520
		private void SetMaxOccurs(XmlSchemaParticle particle, string value); // 0x0000000181A1A460-0x0000000181A1A4C0
		private bool ParseBoolean(string value, string attributeName); // 0x0000000181A17A40-0x0000000181A17AD0
		private int ParseEnum(string value, string attributeName, string[] values); // 0x0000000181A17AD0-0x0000000181A17BC0
		private XmlQualifiedName ParseQName(string value, string attributeName); // 0x0000000181A17BC0-0x0000000181A17CD0
		private int ParseBlockFinalEnum(string value, string attributeName); // 0x0000000181A17760-0x0000000181A17A40
		private static string ParseUriReference(string s); // 0x0000000180370C60-0x0000000180370C70
		private void SendValidationEvent(string code, string arg0, string arg1, string arg2); // 0x0000000181A188C0-0x0000000181A18A60
		private void SendValidationEvent(string code, string msg); // 0x0000000181A18A60-0x0000000181A18B70
		private void SendValidationEvent(string code, string[] args, XmlSeverityType severity); // 0x0000000181A18C60-0x0000000181A18D80
		private void SendValidationEvent(XmlSchemaException e, XmlSeverityType severity); // 0x0000000181A18B70-0x0000000181A18C60
		private void SendValidationEvent(XmlSchemaException e); // 0x0000000181A188B0-0x0000000181A188C0
		private void RecordPosition(); // 0x0000000181A187D0-0x0000000181A188B0
	}
}
