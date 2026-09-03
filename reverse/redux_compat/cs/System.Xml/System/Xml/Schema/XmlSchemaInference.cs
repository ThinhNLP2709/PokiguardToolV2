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
	public sealed class XmlSchemaInference // TypeDefIndex: 7127
	{
		// Fields
		internal static XmlQualifiedName ST_boolean; // 0x00
		internal static XmlQualifiedName ST_byte; // 0x08
		internal static XmlQualifiedName ST_unsignedByte; // 0x10
		internal static XmlQualifiedName ST_short; // 0x18
		internal static XmlQualifiedName ST_unsignedShort; // 0x20
		internal static XmlQualifiedName ST_int; // 0x28
		internal static XmlQualifiedName ST_unsignedInt; // 0x30
		internal static XmlQualifiedName ST_long; // 0x38
		internal static XmlQualifiedName ST_unsignedLong; // 0x40
		internal static XmlQualifiedName ST_integer; // 0x48
		internal static XmlQualifiedName ST_decimal; // 0x50
		internal static XmlQualifiedName ST_float; // 0x58
		internal static XmlQualifiedName ST_double; // 0x60
		internal static XmlQualifiedName ST_duration; // 0x68
		internal static XmlQualifiedName ST_dateTime; // 0x70
		internal static XmlQualifiedName ST_time; // 0x78
		internal static XmlQualifiedName ST_date; // 0x80
		internal static XmlQualifiedName ST_gYearMonth; // 0x88
		internal static XmlQualifiedName ST_string; // 0x90
		internal static XmlQualifiedName ST_anySimpleType; // 0x98
		internal static XmlQualifiedName[] SimpleTypes; // 0xA0
		private XmlSchema rootSchema; // 0x10
		private XmlSchemaSet schemaSet; // 0x18
		private XmlReader xtr; // 0x20
		private NameTable nametable; // 0x28
		private string TargetNamespace; // 0x30
		private XmlNamespaceManager NamespaceManager; // 0x38
		private ArrayList schemaList; // 0x40
		private InferenceOption occurrence; // 0x48
		private InferenceOption typeInference; // 0x4C
	
		// Properties
		public InferenceOption Occurrence { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x000000018033E7A0-0x000000018033E7B0
		public InferenceOption TypeInference { set; } // 0x000000018033E790-0x000000018033E7A0
	
		// Nested types
		public enum InferenceOption // TypeDefIndex: 7128
		{
			Restricted = 0,
			Relaxed = 1
		}
	
		// Constructors
		public XmlSchemaInference(); // 0x000000018198E040-0x000000018198E2D0
		static XmlSchemaInference(); // 0x000000018198D130-0x000000018198E040
	
		// Methods
		public XmlSchemaSet InferSchema(XmlReader instanceDocument); // 0x000000018198A690-0x000000018198A710
		internal XmlSchemaSet InferSchema1(XmlReader instanceDocument, XmlSchemaSet schemas); // 0x0000000181989E10-0x000000018198A690
		private XmlSchemaAttribute AddAttribute(string localName, string prefix, string childURI, string attrValue, bool bCreatingNewType, XmlSchema parentSchema, XmlSchemaObjectCollection addLocation, XmlSchemaObjectTable compiledAttributes); // 0x0000000181984350-0x0000000181984CA0
		private XmlSchema CreateXmlSchema(string targetNS); // 0x00000001819857E0-0x0000000181985880
		private XmlSchemaElement AddElement(string localName, string prefix, string childURI, XmlSchema parentSchema, XmlSchemaObjectCollection addLocation, int positionWithinCollection); // 0x0000000181984CA0-0x00000001819853D0
		internal void InferElement(XmlSchemaElement xse, bool bCreatingNewType, XmlSchema parentSchema); // 0x0000000181987FE0-0x0000000181989E10
		private XmlSchemaSimpleContentExtension CheckSimpleContentExtension(XmlSchemaComplexType ct); // 0x00000001819853D0-0x0000000181985550
		private XmlSchemaType GetEffectiveSchemaType(XmlSchemaElement elem, bool bCreatingNewType); // 0x00000001819877C0-0x0000000181987940
		internal XmlSchemaElement FindMatchingElement(bool bCreatingNewType, XmlReader xtr, XmlSchemaComplexType ct, ref int lastUsedSeqItem, ref bool bParticleChanged, XmlSchema parentSchema, bool setMaxoccurs); // 0x00000001819862B0-0x00000001819877C0
		internal void ProcessAttributes(ref XmlSchemaElement xse, XmlSchemaType effectiveSchemaType, bool bCreatingNewType, XmlSchema parentSchema); // 0x000000018198BC20-0x000000018198C450
		private void MoveAttributes(XmlSchemaSimpleContentExtension scExtension, XmlSchemaComplexType ct); // 0x000000018198B8A0-0x000000018198B940
		private void MoveAttributes(XmlSchemaComplexType ct, XmlSchemaSimpleContentExtension simpleContentExtension, bool bCreatingNewType); // 0x000000018198B940-0x000000018198BC20
		internal XmlSchemaAttribute FindAttribute(ICollection attributes, string attrName); // 0x0000000181985BB0-0x0000000181985DD0
		internal XmlSchemaElement FindGlobalElement(string namespaceURI, string localName, out XmlSchema parentSchema); // 0x0000000181986070-0x00000001819862B0
		internal XmlSchemaElement FindElement(XmlSchemaObjectCollection elements, string elementName); // 0x0000000181985F40-0x0000000181986070
		internal XmlSchemaAttribute FindAttributeRef(ICollection attributes, string attributeName, string nsURI); // 0x0000000181985950-0x0000000181985BB0
		internal XmlSchemaElement FindElementRef(XmlSchemaObjectCollection elements, string elementName, string nsURI); // 0x0000000181985DD0-0x0000000181985F40
		internal void MakeExistingAttributesOptional(XmlSchemaComplexType ct, XmlSchemaObjectCollection attributesInInstance); // 0x000000018198B7D0-0x000000018198B8A0
		private void SwitchUseToOptional(XmlSchemaObjectCollection attributes, XmlSchemaObjectCollection attributesInInstance); // 0x000000018198D000-0x000000018198D130
		internal XmlQualifiedName RefineSimpleType(string s, ref int iTypeFlags); // 0x000000018198C450-0x000000018198CE20
		internal static int InferSimpleType(string s, ref bool bNeedsRangeCheck); // 0x000000018198A710-0x000000018198B7D0
		internal static int DateTime(string s, bool bDate, bool bTime); // 0x0000000181985880-0x0000000181985950
		private XmlSchemaElement CreateNewElementforChoice(XmlSchemaElement copyElement); // 0x0000000181985550-0x00000001819857E0
		private static int GetSchemaType(XmlQualifiedName qname); // 0x0000000181987940-0x0000000181987FE0
		internal void SetMinMaxOccurs(XmlSchemaElement el, bool setMaxOccurs); // 0x000000018198CE20-0x000000018198D000
	}
}
