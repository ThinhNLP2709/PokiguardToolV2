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
using System.Xml;
using System.Xml.Schema;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	internal sealed class XSDSchema : XMLSchema // TypeDefIndex: 11329
	{
		// Fields
		private XmlSchemaSet _schemaSet; // 0x10
		private XmlSchemaElement _dsElement; // 0x18
		private DataSet _ds; // 0x20
		private string _schemaName; // 0x28
		private ArrayList _columnExpressions; // 0x30
		private Hashtable _constraintNodes; // 0x38
		private ArrayList _refTables; // 0x40
		private ArrayList _complexTypes; // 0x48
		private XmlSchemaObjectCollection _annotations; // 0x50
		private XmlSchemaObjectCollection _elements; // 0x58
		private Hashtable _attributes; // 0x60
		private Hashtable _elementsTable; // 0x68
		private Hashtable _attributeGroups; // 0x70
		private Hashtable _schemaTypes; // 0x78
		private Hashtable _expressions; // 0x80
		private Dictionary<DataTable, List<DataTable>> _tableDictionary; // 0x88
		private Hashtable _udSimpleTypes; // 0x90
		private Hashtable _existingSimpleTypeMap; // 0x98
		private bool _fromInference; // 0xA0
		private static readonly NameType[] s_mapNameTypeXsd; // 0x00
	
		// Properties
		internal bool FromInference { get; set; } // 0x000000018165FFF0-0x0000000181660000 0x0000000181727470-0x0000000181727480
	
		// Nested types
		private sealed class NameType : IComparable // TypeDefIndex: 11330
		{
			// Fields
			public readonly string name; // 0x10
			public readonly Type type; // 0x18
	
			// Constructors
			public NameType(string n, Type t); // 0x0000000180CB0730-0x0000000180CB0780
	
			// Methods
			public int CompareTo(object obj); // 0x000000018189B650-0x000000018189B6A0
		}
	
		// Constructors
		public XSDSchema(); // 0x00000001802F4070-0x00000001802F4080
		static XSDSchema(); // 0x00000001818B7E70-0x00000001818B9470
	
		// Methods
		private void CollectElementsAnnotations(XmlSchema schema); // 0x00000001818A9CB0-0x00000001818A9D40
		private void CollectElementsAnnotations(XmlSchema schema, ArrayList schemaList); // 0x00000001818A9360-0x00000001818A9CB0
		internal static string QualifiedName(string name); // 0x00000001818B70A0-0x00000001818B7110
		internal static void SetProperties(object instance, XmlAttribute[] attrs); // 0x00000001818B7760-0x00000001818B7C70
		private static void SetExtProperties(object instance, XmlAttribute[] attrs); // 0x00000001818B73A0-0x00000001818B7760
		private void HandleColumnExpression(object instance, XmlAttribute[] attrs); // 0x00000001818ACCC0-0x00000001818ACED0
		internal static string GetMsdataAttribute(XmlSchemaAnnotated node, string ln); // 0x00000001818AAD90-0x00000001818AAEC0
		private static void SetExtProperties(object instance, XmlAttributeCollection attrs); // 0x00000001818B7110-0x00000001818B73A0
		internal void HandleRefTableProperties(ArrayList RefTables, XmlSchemaElement element); // 0x00000001818B0FC0-0x00000001818B10C0
		internal void HandleRelation(XmlElement node, bool fNested); // 0x00000001818B10C0-0x00000001818B1A50
		private bool HasAttributes(XmlSchemaObjectCollection attributes); // 0x00000001818B2F80-0x00000001818B3180
		private bool IsDatasetParticle(XmlSchemaParticle pt); // 0x00000001818B4B30-0x00000001818B5160
		private int DatasetElementCount(XmlSchemaObjectCollection elements); // 0x00000001818A9D40-0x00000001818A9F20
		private XmlSchemaElement FindDatasetElement(XmlSchemaObjectCollection elements); // 0x00000001818A9F20-0x00000001818AA470
		public void LoadSchema(XmlSchemaSet schemaSet, DataTable dt); // 0x00000001818B6DF0-0x00000001818B6E20
		public void LoadSchema(XmlSchemaSet schemaSet, DataSet ds); // 0x00000001818B54A0-0x00000001818B6DF0
		private void HandleRelations(XmlSchemaAnnotation ann, bool fNested); // 0x00000001818B1A50-0x00000001818B1CF0
		internal XmlSchemaObjectCollection GetParticleItems(XmlSchemaParticle pt); // 0x00000001818AB160-0x00000001818AB430
		internal void HandleParticle(XmlSchemaParticle pt, DataTable table, ArrayList tableChildren, bool isBase); // 0x00000001818B0700-0x00000001818B0FC0
		internal void HandleAttributes(XmlSchemaObjectCollection attributes, DataTable table, bool isBase); // 0x00000001818ACA00-0x00000001818ACCC0
		private void HandleAttributeGroup(XmlSchemaAttributeGroup attributeGroup, DataTable table, bool isBase); // 0x00000001818AC660-0x00000001818ACA00
		internal void HandleComplexType(XmlSchemaComplexType ct, DataTable table, ArrayList tableChildren, bool isNillable); // 0x00000001818ACED0-0x00000001818AD750
		internal XmlSchemaParticle GetParticle(XmlSchemaComplexType ct); // 0x00000001818AB430-0x00000001818AB5D0
		internal DataColumn FindField(DataTable table, string field); // 0x00000001818AA470-0x00000001818AA630
		internal DataColumn[] BuildKey(XmlSchemaIdentityConstraint keyNode, DataTable table); // 0x00000001818A90D0-0x00000001818A9360
		internal bool GetBooleanAttribute(XmlSchemaAnnotated element, string attrName, bool defVal); // 0x00000001818AAAE0-0x00000001818AAC40
		internal string GetStringAttribute(XmlSchemaAnnotated element, string attrName, string defVal); // 0x00000001818AB860-0x00000001818AB8E0
		internal static AcceptRejectRule TranslateAcceptRejectRule(string strRule); // 0x00000001818B7C70-0x00000001818B7CE0
		internal static Rule TranslateRule(string strRule); // 0x00000001818B7CE0-0x00000001818B7DB0
		internal void HandleKeyref(XmlSchemaKeyref keyref); // 0x00000001818AFE20-0x00000001818B0700
		internal void HandleConstraint(XmlSchemaIdentityConstraint keyNode); // 0x00000001818AD750-0x00000001818ADC10
		internal DataTable InstantiateSimpleTable(XmlSchemaElement node); // 0x00000001818B3180-0x00000001818B38D0
		internal string GetInstanceName(XmlSchemaAnnotated node); // 0x00000001818AAC40-0x00000001818AAD90
		internal DataTable InstantiateTable(XmlSchemaElement node, XmlSchemaComplexType typeNode, bool isRef); // 0x00000001818B38D0-0x00000001818B4B30
		public static Type XsdtoClr(string xsdTypeName); // 0x00000001818B7DB0-0x00000001818B7E70
		private static NameType FindNameType(string name); // 0x00000001818AA630-0x00000001818AA6F0
		private Type ParseDataType(string dt); // 0x00000001818B6E20-0x00000001818B70A0
		internal static bool IsXsdType(string name); // 0x00000001818B5430-0x00000001818B54A0
		internal XmlSchemaAnnotated FindTypeNode(XmlSchemaAnnotated node); // 0x00000001818AA6F0-0x00000001818AAAE0
		internal void HandleSimpleTypeSimpleContentColumn(XmlSchemaSimpleType typeNode, string strType, DataTable table, bool isBase, XmlAttribute[] attrs, bool isNillable); // 0x00000001818B2440-0x00000001818B2DC0
		internal void HandleSimpleContentColumn(string strType, DataTable table, bool isBase, XmlAttribute[] attrs, bool isNillable); // 0x00000001818B1CF0-0x00000001818B2440
		internal void HandleAttributeColumn(XmlSchemaAttribute attrib, DataTable table, bool isBase); // 0x00000001818ABB90-0x00000001818AC660
		internal void HandleElementColumn(XmlSchemaElement elem, DataTable table, bool isBase); // 0x00000001818AEE80-0x00000001818AFE20
		internal void HandleDataSet(XmlSchemaElement node, bool isNewDataSet); // 0x00000001818ADC10-0x00000001818AEE80
		private void AddTablesToList(List<DataTable> tableList, DataTable dt); // 0x00000001818A8F10-0x00000001818A90D0
		private string GetPrefix(string ns); // 0x00000001818AB5D0-0x00000001818AB860
		private string GetNamespaceFromPrefix(string prefix); // 0x00000001818AAEC0-0x00000001818AB160
		private string GetTableNamespace(XmlSchemaIdentityConstraint key); // 0x00000001818ABA00-0x00000001818ABB90
		private string GetTableName(XmlSchemaIdentityConstraint key); // 0x00000001818AB8E0-0x00000001818ABA00
		internal bool IsTable(XmlSchemaElement node); // 0x00000001818B5160-0x00000001818B5430
		internal DataTable HandleTable(XmlSchemaElement node); // 0x00000001818B2DC0-0x00000001818B2F80
	}
}
