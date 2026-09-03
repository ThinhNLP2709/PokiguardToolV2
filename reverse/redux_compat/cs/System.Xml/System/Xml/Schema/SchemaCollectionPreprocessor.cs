/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal sealed class SchemaCollectionPreprocessor : BaseProcessor // TypeDefIndex: 7141
	{
		// Fields
		private XmlSchema schema; // 0x40
		private string targetNamespace; // 0x48
		private bool buildinIncluded; // 0x50
		private XmlSchemaForm elementFormDefault; // 0x54
		private XmlSchemaForm attributeFormDefault; // 0x58
		private XmlSchemaDerivationMethod blockDefault; // 0x5C
		private XmlSchemaDerivationMethod finalDefault; // 0x60
		private Hashtable schemaLocations; // 0x68
		private Hashtable referenceNamespaces; // 0x70
		private string Xmlns; // 0x78
		private XmlResolver xmlResolver; // 0x80
	
		// Properties
		internal XmlResolver XmlResolver { set; } // 0x000000018033EA30-0x000000018033EA40
	
		// Nested types
		private enum Compositor // TypeDefIndex: 7142
		{
			Root = 0,
			Include = 1,
			Import = 2
		}
	
		// Constructors
		public SchemaCollectionPreprocessor(XmlNameTable nameTable, SchemaNames schemaNames, ValidationEventHandler eventHandler); // 0x00000001819A9C00-0x00000001819A9C10
	
		// Methods
		public bool Execute(XmlSchema schema, string targetNamespace, bool loadExternals, XmlSchemaCollection xsc); // 0x00000001819A1ED0-0x00000001819A2130
		private void Cleanup(XmlSchema schema); // 0x00000001819A1940-0x00000001819A1BC0
		private void LoadExternals(XmlSchema schema, XmlSchemaCollection xsc); // 0x00000001819A21B0-0x00000001819A2E00
		private void BuildRefNamespaces(XmlSchema schema); // 0x00000001819A1000-0x00000001819A1220
		private void Preprocess(XmlSchema schema, string targetNamespace, Compositor compositor); // 0x00000001819A77A0-0x00000001819A9570
		private void PreprocessRedefine(XmlSchemaRedefine redefine); // 0x00000001819A5DB0-0x00000001819A7090
		private int CountGroupSelfReference(XmlSchemaObjectCollection items, XmlQualifiedName name); // 0x00000001819A1BC0-0x00000001819A1ED0
		private void CheckRefinedGroup(XmlSchemaGroup group); // 0x00000001819A1770-0x00000001819A1800
		private void CheckRefinedAttributeGroup(XmlSchemaAttributeGroup attributeGroup); // 0x00000001819A1220-0x00000001819A1380
		private void CheckRefinedSimpleType(XmlSchemaSimpleType stype); // 0x00000001819A1800-0x00000001819A1940
		private void CheckRefinedComplexType(XmlSchemaComplexType ctype); // 0x00000001819A1380-0x00000001819A1770
		private void PreprocessAttribute(XmlSchemaAttribute attribute); // 0x00000001819A3270-0x00000001819A3400
		private void PreprocessLocalAttribute(XmlSchemaAttribute attribute); // 0x00000001819A4CE0-0x00000001819A4EB0
		private void PreprocessAttributeContent(XmlSchemaAttribute attribute); // 0x00000001819A2F10-0x00000001819A3140
		private void PreprocessAttributeGroup(XmlSchemaAttributeGroup attributeGroup); // 0x00000001819A3140-0x00000001819A3270
		private void PreprocessElement(XmlSchemaElement element); // 0x00000001819A44E0-0x00000001819A4750
		private void PreprocessLocalElement(XmlSchemaElement element); // 0x00000001819A4EB0-0x00000001819A5260
		private void PreprocessElementContent(XmlSchemaElement element); // 0x00000001819A40E0-0x00000001819A44E0
		private void PreprocessIdentityConstraint(XmlSchemaIdentityConstraint constraint); // 0x00000001819A4930-0x00000001819A4CE0
		private void PreprocessSimpleType(XmlSchemaSimpleType simpleType, bool local); // 0x00000001819A7090-0x00000001819A77A0
		private void PreprocessComplexType(XmlSchemaComplexType complexType, bool local); // 0x00000001819A36B0-0x00000001819A40E0
		private void PreprocessGroup(XmlSchemaGroup group); // 0x00000001819A4750-0x00000001819A4930
		private void PreprocessNotation(XmlSchemaNotation notation); // 0x00000001819A5260-0x00000001819A5490
		private void PreprocessParticle(XmlSchemaParticle particle); // 0x00000001819A5490-0x00000001819A5DB0
		private void PreprocessAttributes(XmlSchemaObjectCollection attributes, XmlSchemaAnyAttribute anyAttribute, XmlSchemaObject parent); // 0x00000001819A3400-0x00000001819A36B0
		private void ValidateIdAttribute(XmlSchemaObject xso); // 0x00000001819A95C0-0x00000001819A97E0
		private void ValidateNameAttribute(XmlSchemaObject xso); // 0x00000001819A97E0-0x00000001819A9AE0
		private void ValidateQNameAttribute(XmlSchemaObject xso, string attributeName, XmlQualifiedName value); // 0x00000001819A9AE0-0x00000001819A9C00
		private void SetParent(XmlSchemaObject child, XmlSchemaObject parent); // 0x0000000181983160-0x0000000181983190
		private void PreprocessAnnotation(XmlSchemaObject schemaObject); // 0x00000001819A2E00-0x00000001819A2F10
		private Uri ResolveSchemaLocationUri(XmlSchema enclosingSchema, string location); // 0x00000001819A9570-0x00000001819A95C0
		private Stream GetSchemaEntity(Uri ruri); // 0x00000001819A2130-0x00000001819A21B0
	}
}
