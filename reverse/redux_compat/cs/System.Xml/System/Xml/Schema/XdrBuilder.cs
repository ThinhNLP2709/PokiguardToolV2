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
	internal sealed class XdrBuilder : SchemaBuilder // TypeDefIndex: 7159
	{
		// Fields
		private static readonly int[] S_XDR_Root_Element; // 0x00
		private static readonly int[] S_XDR_Root_SubElements; // 0x08
		private static readonly int[] S_XDR_ElementType_SubElements; // 0x10
		private static readonly int[] S_XDR_AttributeType_SubElements; // 0x18
		private static readonly int[] S_XDR_Group_SubElements; // 0x20
		private static readonly XdrAttributeEntry[] S_XDR_Root_Attributes; // 0x28
		private static readonly XdrAttributeEntry[] S_XDR_ElementType_Attributes; // 0x30
		private static readonly XdrAttributeEntry[] S_XDR_AttributeType_Attributes; // 0x38
		private static readonly XdrAttributeEntry[] S_XDR_Element_Attributes; // 0x40
		private static readonly XdrAttributeEntry[] S_XDR_Attribute_Attributes; // 0x48
		private static readonly XdrAttributeEntry[] S_XDR_Group_Attributes; // 0x50
		private static readonly XdrAttributeEntry[] S_XDR_ElementDataType_Attributes; // 0x58
		private static readonly XdrAttributeEntry[] S_XDR_AttributeDataType_Attributes; // 0x60
		private static readonly XdrEntry[] S_SchemaEntries; // 0x68
		private SchemaInfo _SchemaInfo; // 0x10
		private string _TargetNamespace; // 0x18
		private XmlReader _reader; // 0x20
		private PositionInfo positionInfo; // 0x28
		private ParticleContentValidator _contentValidator; // 0x30
		private XdrEntry _CurState; // 0x38
		private XdrEntry _NextState; // 0x40
		private HWStack _StateHistory; // 0x48
		private HWStack _GroupStack; // 0x50
		private string _XdrName; // 0x58
		private string _XdrPrefix; // 0x60
		private ElementContent _ElementDef; // 0x68
		private GroupContent _GroupDef; // 0x70
		private AttributeContent _AttributeDef; // 0x78
		private DeclBaseInfo _UndefinedAttributeTypes; // 0x80
		private DeclBaseInfo _BaseDecl; // 0x88
		private XmlNameTable _NameTable; // 0x90
		private SchemaNames _SchemaNames; // 0x98
		private XmlNamespaceManager _CurNsMgr; // 0xA0
		private string _Text; // 0xA8
		private ValidationEventHandler validationEventHandler; // 0xB0
		private Hashtable _UndeclaredElements; // 0xB8
		private XmlResolver xmlResolver; // 0xC0
	
		// Properties
		internal XmlResolver XmlResolver { set; } // 0x00000001806CCDA0-0x00000001806CCDC0
	
		// Nested types
		private sealed class DeclBaseInfo // TypeDefIndex: 7160
		{
			// Fields
			internal XmlQualifiedName _Name; // 0x10
			internal string _Prefix; // 0x18
			internal XmlQualifiedName _TypeName; // 0x20
			internal string _TypePrefix; // 0x28
			internal object _Default; // 0x30
			internal object _Revises; // 0x38
			internal uint _MaxOccurs; // 0x40
			internal uint _MinOccurs; // 0x44
			internal bool _Checking; // 0x48
			internal SchemaElementDecl _ElementDecl; // 0x50
			internal SchemaAttDef _Attdef; // 0x58
			internal DeclBaseInfo _Next; // 0x60
	
			// Constructors
			internal DeclBaseInfo(); // 0x00000001819C8560-0x00000001819C8580
	
			// Methods
			internal void Reset(); // 0x00000001819C8450-0x00000001819C8560
		}
	
		private sealed class GroupContent // TypeDefIndex: 7161
		{
			// Fields
			internal uint _MinVal; // 0x10
			internal uint _MaxVal; // 0x14
			internal bool _HasMaxAttr; // 0x18
			internal bool _HasMinAttr; // 0x19
			internal int _Order; // 0x1C
	
			// Constructors
			public GroupContent(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal static void Copy(GroupContent from, GroupContent to); // 0x00000001819C8580-0x00000001819C85B0
			internal static GroupContent Copy(GroupContent other); // 0x00000001819C85B0-0x00000001819C8630
		}
	
		private sealed class ElementContent // TypeDefIndex: 7162
		{
			// Fields
			internal SchemaElementDecl _ElementDecl; // 0x10
			internal int _ContentAttr; // 0x18
			internal int _OrderAttr; // 0x1C
			internal bool _MasterGroupRequired; // 0x20
			internal bool _ExistTerminal; // 0x21
			internal bool _AllowDataType; // 0x22
			internal bool _HasDataType; // 0x23
			internal bool _HasType; // 0x24
			internal bool _EnumerationRequired; // 0x25
			internal uint _MinVal; // 0x28
			internal uint _MaxVal; // 0x2C
			internal uint _MaxLength; // 0x30
			internal uint _MinLength; // 0x34
			internal Hashtable _AttDefList; // 0x38
	
			// Constructors
			public ElementContent(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private sealed class AttributeContent // TypeDefIndex: 7163
		{
			// Fields
			internal SchemaAttDef _AttDef; // 0x10
			internal XmlQualifiedName _Name; // 0x18
			internal string _Prefix; // 0x20
			internal bool _Required; // 0x28
			internal uint _MinVal; // 0x2C
			internal uint _MaxVal; // 0x30
			internal uint _MaxLength; // 0x34
			internal uint _MinLength; // 0x38
			internal bool _EnumerationRequired; // 0x3C
			internal bool _HasDataType; // 0x3D
			internal bool _Global; // 0x3E
			internal object _Default; // 0x40
	
			// Constructors
			public AttributeContent(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private delegate void XdrBuildFunction(XdrBuilder builder, object obj, string prefix); // TypeDefIndex: 7164; 0x0000000180A72B30-0x0000000180A72B50
	
		private delegate void XdrInitFunction(XdrBuilder builder, object obj); // TypeDefIndex: 7165; 0x0000000180A70FB0-0x0000000180A70FC0
	
		private delegate void XdrBeginChildFunction(XdrBuilder builder); // TypeDefIndex: 7166; 0x00000001804A78A0-0x00000001804A78B0
	
		private delegate void XdrEndChildFunction(XdrBuilder builder); // TypeDefIndex: 7167; 0x00000001804A78A0-0x00000001804A78B0
	
		private sealed class XdrAttributeEntry // TypeDefIndex: 7168
		{
			// Fields
			internal SchemaNames.Token _Attribute; // 0x10
			internal int _SchemaFlags; // 0x14
			internal XmlSchemaDatatype _Datatype; // 0x18
			internal XdrBuildFunction _BuildFunc; // 0x20
	
			// Constructors
			internal XdrAttributeEntry(SchemaNames.Token a, XmlTokenizedType ttype, XdrBuildFunction build); // 0x00000001819C8980-0x00000001819C8A20
			internal XdrAttributeEntry(SchemaNames.Token a, XmlTokenizedType ttype, int schemaFlags, XdrBuildFunction build); // 0x00000001819C88E0-0x00000001819C8980
		}
	
		private sealed class XdrEntry // TypeDefIndex: 7169
		{
			// Fields
			internal SchemaNames.Token _Name; // 0x10
			internal int[] _NextStates; // 0x18
			internal XdrAttributeEntry[] _Attributes; // 0x20
			internal XdrInitFunction _InitFunc; // 0x28
			internal XdrBeginChildFunction _BeginChildFunc; // 0x30
			internal XdrEndChildFunction _EndChildFunc; // 0x38
			internal bool _AllowText; // 0x40
	
			// Constructors
			internal XdrEntry(SchemaNames.Token n, int[] states, XdrAttributeEntry[] attributes, XdrInitFunction init, XdrBeginChildFunction begin, XdrEndChildFunction end, bool fText); // 0x00000001819D2720-0x00000001819D27C0
		}
	
		// Constructors
		internal XdrBuilder(XmlReader reader, XmlNamespaceManager curmgr, SchemaInfo sinfo, string targetNamspace, XmlNameTable nameTable, SchemaNames schemaNames, ValidationEventHandler eventhandler); // 0x00000001819D2450-0x00000001819D2720
		static XdrBuilder(); // 0x00000001819CF1C0-0x00000001819D2450
	
		// Methods
		internal override bool ProcessElement(string prefix, string name, string ns); // 0x00000001819CAA80-0x00000001819CACE0
		internal override void ProcessAttribute(string prefix, string name, string ns, string value); // 0x00000001819CA5F0-0x00000001819CAA00
		private bool LoadSchema(string uri); // 0x00000001819C9AC0-0x00000001819C9FB0
		internal static bool IsXdrSchema(string uri); // 0x00000001819C98F0-0x00000001819C9990
		internal override bool IsContentParsed(); // 0x00000001802E7990-0x00000001802E79A0
		internal override void ProcessMarkup(XmlNode[] markup); // 0x00000001819CACE0-0x00000001819CAD40
		internal override void ProcessCData(string value); // 0x00000001819CAA00-0x00000001819CAA80
		internal override void StartChildren(); // 0x00000001819CB240-0x00000001819CB280
		internal override void EndChildren(); // 0x00000001819C8E40-0x00000001819C8F10
		private void Push(); // 0x00000001819CAE00-0x00000001819CAE60
		private void Pop(); // 0x00000001819CA540-0x00000001819CA5F0
		private void PushGroupInfo(); // 0x00000001819CAD40-0x00000001819CAE00
		private void PopGroupInfo(); // 0x00000001819CA490-0x00000001819CA540
		private static void XDR_InitRoot(XdrBuilder builder, object obj); // 0x00000001819CF140-0x00000001819CF1C0
		private static void XDR_BuildRoot_Name(XdrBuilder builder, object obj, string prefix); // 0x00000001819CD6A0-0x00000001819CD740
		private static void XDR_BuildRoot_ID(XdrBuilder builder, object obj, string prefix); // 0x00000001802E76C0-0x00000001802E76D0
		private static void XDR_BeginRoot(XdrBuilder builder); // 0x00000001819CBAD0-0x00000001819CBBC0
		private static void XDR_EndRoot(XdrBuilder builder); // 0x00000001819CE5C0-0x00000001819CEA60
		private static void XDR_InitElementType(XdrBuilder builder, object obj); // 0x00000001819CED40-0x00000001819CEEE0
		private static void XDR_BuildElementType_Name(XdrBuilder builder, object obj, string prefix); // 0x00000001819CCEF0-0x00000001819CD100
		private static void XDR_BuildElementType_Content(XdrBuilder builder, object obj, string prefix); // 0x00000001819CC760-0x00000001819CC800
		private static void XDR_BuildElementType_Model(XdrBuilder builder, object obj, string prefix); // 0x00000001819CCD70-0x00000001819CCEF0
		private static void XDR_BuildElementType_Order(XdrBuilder builder, object obj, string prefix); // 0x00000001819CD100-0x00000001819CD1C0
		private static void XDR_BuildElementType_DtType(XdrBuilder builder, object obj, string prefix); // 0x00000001819CCB00-0x00000001819CCC70
		private static void XDR_BuildElementType_DtValues(XdrBuilder builder, object obj, string prefix); // 0x00000001819CCC70-0x00000001819CCD70
		private static void XDR_BuildElementType_DtMaxLength(XdrBuilder builder, object obj, string prefix); // 0x00000001819CC800-0x00000001819CC980
		private static void XDR_BuildElementType_DtMinLength(XdrBuilder builder, object obj, string prefix); // 0x00000001819CC980-0x00000001819CCB00
		private static void XDR_BeginElementType(XdrBuilder builder); // 0x00000001819CB760-0x00000001819CBAD0
		private static void XDR_EndElementType(XdrBuilder builder); // 0x00000001819CDDC0-0x00000001819CE2A0
		private static void XDR_InitAttributeType(XdrBuilder builder, object obj); // 0x00000001819CEAD0-0x00000001819CEBF0
		private static void XDR_BuildAttributeType_Name(XdrBuilder builder, object obj, string prefix); // 0x00000001819CC240-0x00000001819CC520
		private static void XDR_BuildAttributeType_Required(XdrBuilder builder, object obj, string prefix); // 0x00000001819CC520-0x00000001819CC5A0
		private static void XDR_BuildAttributeType_Default(XdrBuilder builder, object obj, string prefix); // 0x00000001819CBBC0-0x00000001819CBBF0
		private static void XDR_BuildAttributeType_DtType(XdrBuilder builder, object obj, string prefix); // 0x00000001819CBEF0-0x00000001819CC140
		private static void XDR_BuildAttributeType_DtValues(XdrBuilder builder, object obj, string prefix); // 0x00000001819CC140-0x00000001819CC240
		private static void XDR_BuildAttributeType_DtMaxLength(XdrBuilder builder, object obj, string prefix); // 0x00000001819CBBF0-0x00000001819CBD70
		private static void XDR_BuildAttributeType_DtMinLength(XdrBuilder builder, object obj, string prefix); // 0x00000001819CBD70-0x00000001819CBEF0
		private static void XDR_BeginAttributeType(XdrBuilder builder); // 0x00000001819CB280-0x00000001819CB300
		private static void XDR_EndAttributeType(XdrBuilder builder); // 0x00000001819CD940-0x00000001819CDC80
		private static void XDR_InitElement(XdrBuilder builder, object obj); // 0x00000001819CEEE0-0x00000001819CEF90
		private static void XDR_BuildElement_Type(XdrBuilder builder, object obj, string prefix); // 0x00000001819CD2C0-0x00000001819CD490
		private static void XDR_BuildElement_MinOccurs(XdrBuilder builder, object obj, string prefix); // 0x00000001819CD240-0x00000001819CD2C0
		private static void XDR_BuildElement_MaxOccurs(XdrBuilder builder, object obj, string prefix); // 0x00000001819CD1C0-0x00000001819CD240
		private static void XDR_EndElement(XdrBuilder builder); // 0x00000001819CE2A0-0x00000001819CE3B0
		private static void XDR_InitAttribute(XdrBuilder builder, object obj); // 0x00000001819CEBF0-0x00000001819CEC90
		private static void XDR_BuildAttribute_Type(XdrBuilder builder, object obj, string prefix); // 0x00000001819CC650-0x00000001819CC760
		private static void XDR_BuildAttribute_Required(XdrBuilder builder, object obj, string prefix); // 0x00000001819CC5D0-0x00000001819CC650
		private static void XDR_BuildAttribute_Default(XdrBuilder builder, object obj, string prefix); // 0x00000001819CC5A0-0x00000001819CC5D0
		private static void XDR_BeginAttribute(XdrBuilder builder); // 0x00000001819CB300-0x00000001819CB760
		private static void XDR_EndAttribute(XdrBuilder builder); // 0x00000001819CDC80-0x00000001819CDCB0
		private static void XDR_InitGroup(XdrBuilder builder, object obj); // 0x00000001819CEF90-0x00000001819CF140
		private static void XDR_BuildGroup_Order(XdrBuilder builder, object obj, string prefix); // 0x00000001819CD5B0-0x00000001819CD6A0
		private static void XDR_BuildGroup_MinOccurs(XdrBuilder builder, object obj, string prefix); // 0x00000001819CD520-0x00000001819CD5B0
		private static void XDR_BuildGroup_MaxOccurs(XdrBuilder builder, object obj, string prefix); // 0x00000001819CD490-0x00000001819CD520
		private static void XDR_EndGroup(XdrBuilder builder); // 0x00000001819CE3B0-0x00000001819CE5C0
		private static void XDR_InitElementDtType(XdrBuilder builder, object obj); // 0x00000001819CEC90-0x00000001819CED40
		private static void XDR_EndElementDtType(XdrBuilder builder); // 0x00000001819CDCB0-0x00000001819CDDC0
		private static void XDR_InitAttributeDtType(XdrBuilder builder, object obj); // 0x00000001819CEA60-0x00000001819CEAD0
		private static void XDR_EndAttributeDtType(XdrBuilder builder); // 0x00000001819CD850-0x00000001819CD940
		private bool GetNextState(XmlQualifiedName qname); // 0x00000001819C9240-0x00000001819C9430
		private bool IsSkipableElement(XmlQualifiedName qname); // 0x00000001819C97F0-0x00000001819C98F0
		private bool IsSkipableAttribute(XmlQualifiedName qname); // 0x00000001819C9630-0x00000001819C97F0
		private int GetOrder(XmlQualifiedName qname); // 0x00000001819C9430-0x00000001819C95F0
		private void AddOrder(); // 0x00000001819C8A20-0x00000001819C8AE0
		private static bool IsYes(object obj, XdrBuilder builder); // 0x00000001819C9990-0x00000001819C9AC0
		private static uint ParseMinOccurs(object obj, XdrBuilder builder); // 0x00000001819CA390-0x00000001819CA490
		private static uint ParseMaxOccurs(object obj, XdrBuilder builder); // 0x00000001819CA270-0x00000001819CA390
		private static void HandleMinMax(ParticleContentValidator pContent, uint cMin, uint cMax); // 0x00000001819C95F0-0x00000001819C9620
		private static void ParseDtMaxLength(ref uint cVal, object obj, XdrBuilder builder); // 0x00000001819C9FB0-0x00000001819CA0F0
		private static void ParseDtMinLength(ref uint cVal, object obj, XdrBuilder builder); // 0x00000001819CA0F0-0x00000001819CA230
		private static void CompareMinMaxLength(uint cMin, uint cMax, XdrBuilder builder); // 0x00000001819C8DC0-0x00000001819C8E40
		private static bool ParseInteger(string str, ref uint n); // 0x00000001819CA230-0x00000001819CA270
		private void XDR_CheckAttributeDefault(DeclBaseInfo decl, SchemaAttDef pAttdef); // 0x00000001819CD740-0x00000001819CD850
		private void SetAttributePresence(SchemaAttDef pAttdef, bool fRequired); // 0x00000001819CB1F0-0x00000001819CB240
		private int GetContent(XmlQualifiedName qname); // 0x00000001819C8F10-0x00000001819C9120
		private bool GetModel(XmlQualifiedName qname); // 0x00000001819C9120-0x00000001819C9240
		private XmlSchemaDatatype CheckDatatype(string str); // 0x00000001819C8AE0-0x00000001819C8C90
		private void CheckDefaultAttValue(SchemaAttDef attDef); // 0x00000001819C8C90-0x00000001819C8DC0
		private bool IsGlobal(int flags); // 0x00000001819C9620-0x00000001819C9630
		private void SendValidationEvent(string code, string[] args, XmlSeverityType severity); // 0x00000001819CAE60-0x00000001819CAFA0
		private void SendValidationEvent(string code); // 0x00000001819CB1D0-0x00000001819CB1F0
		private void SendValidationEvent(string code, string msg); // 0x00000001819CB0C0-0x00000001819CB1D0
		private void SendValidationEvent(XmlSchemaException e, XmlSeverityType severity); // 0x00000001819CAFA0-0x00000001819CB0C0
	}
}
