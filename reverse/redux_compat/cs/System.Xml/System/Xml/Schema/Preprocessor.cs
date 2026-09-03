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
	internal sealed class Preprocessor : BaseProcessor // TypeDefIndex: 7136
	{
		// Fields
		private string Xmlns; // 0x40
		private string NsXsi; // 0x48
		private string targetNamespace; // 0x50
		private XmlSchema rootSchema; // 0x58
		private XmlSchema currentSchema; // 0x60
		private XmlSchemaForm elementFormDefault; // 0x68
		private XmlSchemaForm attributeFormDefault; // 0x6C
		private XmlSchemaDerivationMethod blockDefault; // 0x70
		private XmlSchemaDerivationMethod finalDefault; // 0x74
		private Hashtable schemaLocations; // 0x78
		private Hashtable chameleonSchemas; // 0x80
		private Hashtable referenceNamespaces; // 0x88
		private Hashtable processedExternals; // 0x90
		private SortedList lockList; // 0x98
		private XmlReaderSettings readerSettings; // 0xA0
		private XmlSchema rootSchemaForRedefine; // 0xA8
		private ArrayList redefinedList; // 0xB0
		private static XmlSchema builtInSchemaForXmlNS; // 0x00
		private XmlResolver xmlResolver; // 0xB8
	
		// Properties
		internal XmlResolver XmlResolver { set; } // 0x00000001806CCDE0-0x00000001806CCE00
		internal XmlReaderSettings ReaderSettings { set; } // 0x00000001806CCE40-0x00000001806CCE60
		internal Hashtable SchemaLocations { set; } // 0x000000018033EA70-0x000000018033EA80
		internal Hashtable ChameleonSchemas { set; } // 0x000000018033EA30-0x000000018033EA40
		internal XmlSchema RootSchema { get; } // 0x00000001802F4000-0x00000001802F4010 
	
		// Constructors
		public Preprocessor(XmlNameTable nameTable, SchemaNames schemaNames, ValidationEventHandler eventHandler, XmlSchemaCompilationSettings compilationSettings); // 0x00000001819839F0-0x0000000181983B00
	
		// Methods
		public bool Execute(XmlSchema schema, string targetNamespace, bool loadExternals); // 0x000000018197B2F0-0x000000018197B970
		private void Cleanup(XmlSchema schema); // 0x0000000181979FB0-0x000000018197A0B0
		private void CleanupRedefine(XmlSchemaExternal include); // 0x0000000181979F10-0x0000000181979FB0
		private void BuildSchemaList(XmlSchema schema); // 0x0000000181979620-0x00000001819797C0
		private void LoadExternals(XmlSchema schema); // 0x000000018197C380-0x000000018197D2E0
		internal static XmlSchema GetBuildInSchema(); // 0x000000018197B970-0x000000018197BFF0
		private void BuildRefNamespaces(XmlSchema schema); // 0x0000000181979380-0x0000000181979620
		private void ParseUri(string uri, string code, XmlSchemaObject sourceSchemaObject); // 0x000000018197D2E0-0x000000018197D3B0
		private void Preprocess(XmlSchema schema, string targetNamespace, ArrayList imports); // 0x0000000181981B60-0x0000000181983110
		private void CopyIncludedComponents(XmlSchema includedSchema, XmlSchema schema); // 0x000000018197A0B0-0x000000018197AFA0
		private void PreprocessRedefine(RedefineEntry redefineEntry); // 0x0000000181980480-0x00000001819813B0
		private void GetIncludedSet(XmlSchema schema, ArrayList includesList); // 0x000000018197C160-0x000000018197C2C0
		internal static XmlSchema GetParentSchema(XmlSchemaObject currentSchemaObject); // 0x000000018197C2C0-0x000000018197C340
		private void SetSchemaDefaults(XmlSchema schema); // 0x0000000181983190-0x00000001819832A0
		private int CountGroupSelfReference(XmlSchemaObjectCollection items, XmlQualifiedName name, XmlSchemaGroup redefined); // 0x000000018197AFA0-0x000000018197B2F0
		private void CheckRefinedGroup(XmlSchemaGroup group); // 0x0000000181979D20-0x0000000181979DD0
		private void CheckRefinedAttributeGroup(XmlSchemaAttributeGroup attributeGroup); // 0x00000001819797C0-0x0000000181979930
		private void CheckRefinedSimpleType(XmlSchemaSimpleType stype); // 0x0000000181979DD0-0x0000000181979F10
		private void CheckRefinedComplexType(XmlSchemaComplexType ctype); // 0x0000000181979930-0x0000000181979D20
		private void PreprocessAttribute(XmlSchemaAttribute attribute); // 0x000000018197D870-0x000000018197DA00
		private void PreprocessLocalAttribute(XmlSchemaAttribute attribute); // 0x000000018197F310-0x000000018197F4E0
		private void PreprocessAttributeContent(XmlSchemaAttribute attribute); // 0x000000018197D520-0x000000018197D740
		private void PreprocessAttributeGroup(XmlSchemaAttributeGroup attributeGroup); // 0x000000018197D740-0x000000018197D870
		private void PreprocessElement(XmlSchemaElement element); // 0x000000018197EB10-0x000000018197ED80
		private void PreprocessLocalElement(XmlSchemaElement element); // 0x000000018197F4E0-0x000000018197F890
		private void PreprocessElementContent(XmlSchemaElement element); // 0x000000018197E750-0x000000018197EB10
		private void PreprocessIdentityConstraint(XmlSchemaIdentityConstraint constraint); // 0x000000018197EF60-0x000000018197F310
		private void PreprocessSimpleType(XmlSchemaSimpleType simpleType, bool local); // 0x00000001819813B0-0x0000000181981B60
		private void PreprocessComplexType(XmlSchemaComplexType complexType, bool local); // 0x000000018197DD20-0x000000018197E750
		private void PreprocessGroup(XmlSchemaGroup group); // 0x000000018197ED80-0x000000018197EF60
		private void PreprocessNotation(XmlSchemaNotation notation); // 0x000000018197F890-0x000000018197FAB0
		private void PreprocessParticle(XmlSchemaParticle particle); // 0x000000018197FAB0-0x0000000181980480
		private void PreprocessAttributes(XmlSchemaObjectCollection attributes, XmlSchemaAnyAttribute anyAttribute, XmlSchemaObject parent); // 0x000000018197DA00-0x000000018197DD20
		private void ValidateIdAttribute(XmlSchemaObject xso); // 0x00000001819832A0-0x0000000181983520
		private void ValidateNameAttribute(XmlSchemaObject xso); // 0x0000000181983520-0x0000000181983820
		private void ValidateQNameAttribute(XmlSchemaObject xso, string attributeName, XmlQualifiedName value); // 0x0000000181983820-0x00000001819839F0
		private Uri ResolveSchemaLocationUri(XmlSchema enclosingSchema, string location); // 0x0000000181983110-0x0000000181983160
		private object GetSchemaEntity(Uri ruri); // 0x000000018197C340-0x000000018197C380
		private XmlSchema GetChameleonSchema(string targetNamespace, XmlSchema schema); // 0x000000018197BFF0-0x000000018197C160
		private void SetParent(XmlSchemaObject child, XmlSchemaObject parent); // 0x0000000181983160-0x0000000181983190
		private void PreprocessAnnotation(XmlSchemaObject schemaObject); // 0x000000018197D3B0-0x000000018197D490
		private void PreprocessAnnotation(XmlSchemaAnnotation annotation); // 0x000000018197D490-0x000000018197D520
	}
}
