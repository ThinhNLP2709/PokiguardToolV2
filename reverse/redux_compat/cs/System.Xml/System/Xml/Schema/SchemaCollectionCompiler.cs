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
	internal sealed class SchemaCollectionCompiler : BaseProcessor // TypeDefIndex: 7140
	{
		// Fields
		private bool compileContentModel; // 0x40
		private XmlSchemaObjectTable examplars; // 0x48
		private Stack complexTypeStack; // 0x50
		private XmlSchema schema; // 0x58
	
		// Constructors
		public SchemaCollectionCompiler(XmlNameTable nameTable, ValidationEventHandler eventHandler); // 0x00000001819A0F30-0x00000001819A1000
	
		// Methods
		public bool Execute(XmlSchema schema, SchemaInfo schemaInfo, bool compileContentModel); // 0x000000018199D990-0x000000018199DA10
		private void Prepare(); // 0x00000001819A0B80-0x00000001819A0F00
		private void Cleanup(); // 0x00000001819929F0-0x00000001819936E0
		internal static void Cleanup(XmlSchema schema); // 0x00000001819936E0-0x0000000181993EA0
		private void Compile(); // 0x000000018199BDC0-0x000000018199D990
		private void Output(SchemaInfo schemaInfo); // 0x000000018199FE90-0x00000001819A0B80
		private static void CleanupAttribute(XmlSchemaAttribute attribute); // 0x0000000181992040-0x0000000181992090
		private static void CleanupAttributeGroup(XmlSchemaAttributeGroup attributeGroup); // 0x0000000181991FE0-0x0000000181992040
		private static void CleanupComplexType(XmlSchemaComplexType complexType); // 0x0000000181992190-0x00000001819925E0
		private static void CleanupSimpleType(XmlSchemaSimpleType simpleType); // 0x00000001819929D0-0x00000001819929F0
		private static void CleanupElement(XmlSchemaElement element); // 0x00000001819925E0-0x00000001819927B0
		private static void CleanupAttributes(XmlSchemaObjectCollection attributes); // 0x0000000181992090-0x0000000181992190
		private static void CleanupGroup(XmlSchemaGroup group); // 0x00000001819927B0-0x00000001819927F0
		private static void CleanupParticle(XmlSchemaParticle particle); // 0x00000001819927F0-0x00000001819929D0
		private void CompileSubstitutionGroup(XmlSchemaSubstitutionGroupV1Compat substitutionGroup); // 0x000000018199B880-0x000000018199BDC0
		private void CheckSubstitutionGroup(XmlSchemaSubstitutionGroup substitutionGroup); // 0x0000000181991C70-0x0000000181991EB0
		private void CompileGroup(XmlSchemaGroup group); // 0x0000000181998BF0-0x0000000181998CE0
		private void CompileSimpleType(XmlSchemaSimpleType simpleType); // 0x000000018199AE70-0x000000018199B880
		private XmlSchemaSimpleType[] CompileBaseMemberTypes(XmlSchemaSimpleType simpleType); // 0x0000000181995370-0x0000000181995760
		private void CheckUnionType(XmlSchemaSimpleType unionMember, ArrayList memberTypeDefinitions, XmlSchemaSimpleType parentType); // 0x0000000181991EB0-0x0000000181991FE0
		private void CompileComplexType(XmlSchemaComplexType complexType); // 0x0000000181996DE0-0x0000000181997A80
		private void CompileSimpleContentExtension(XmlSchemaComplexType complexType, XmlSchemaSimpleContentExtension simpleExtension); // 0x000000018199A790-0x000000018199AA30
		private void CompileSimpleContentRestriction(XmlSchemaComplexType complexType, XmlSchemaSimpleContentRestriction simpleRestriction); // 0x000000018199AA30-0x000000018199AE70
		private void CompileComplexContentExtension(XmlSchemaComplexType complexType, XmlSchemaComplexContent complexContent, XmlSchemaComplexContentExtension complexExtension); // 0x0000000181995830-0x0000000181995D10
		private void CompileComplexContentRestriction(XmlSchemaComplexType complexType, XmlSchemaComplexContent complexContent, XmlSchemaComplexContentRestriction complexRestriction); // 0x0000000181995D10-0x0000000181996090
		private void CheckParticleDerivation(XmlSchemaComplexType complexType); // 0x0000000181991B40-0x0000000181991C70
		private XmlSchemaParticle CompileContentTypeParticle(XmlSchemaParticle particle, bool substitution); // 0x0000000181997A80-0x0000000181997C30
		private XmlSchemaParticle CannonicalizeParticle(XmlSchemaParticle particle, bool root, bool substitution); // 0x0000000181991050-0x0000000181991500
		private XmlSchemaParticle CannonicalizeElement(XmlSchemaElement element, bool substitution); // 0x0000000181990840-0x00000001819909E0
		private XmlSchemaParticle CannonicalizeGroupRef(XmlSchemaGroupRef groupRef, bool root, bool substitution); // 0x00000001819909E0-0x0000000181991050
		private XmlSchemaParticle CannonicalizeAll(XmlSchemaAll all, bool root, bool substitution); // 0x000000018198FBD0-0x0000000181990180
		private XmlSchemaParticle CannonicalizeChoice(XmlSchemaChoice choice, bool root, bool substitution); // 0x0000000181990180-0x0000000181990840
		private XmlSchemaParticle CannonicalizeSequence(XmlSchemaSequence sequence, bool root, bool substitution); // 0x0000000181991500-0x0000000181991B40
		private bool IsValidRestriction(XmlSchemaParticle derivedParticle, XmlSchemaParticle baseParticle); // 0x000000018199F2C0-0x000000018199FE90
		private bool IsElementFromElement(XmlSchemaElement derivedElement, XmlSchemaElement baseElement); // 0x000000018199E020-0x000000018199E160
		private bool IsElementFromAny(XmlSchemaElement derivedElement, XmlSchemaAny baseAny); // 0x000000018199DFB0-0x000000018199E020
		private bool IsAnyFromAny(XmlSchemaAny derivedAny, XmlSchemaAny baseAny); // 0x000000018199DF50-0x000000018199DFB0
		private bool IsGroupBaseFromAny(XmlSchemaGroupBase derivedGroupBase, XmlSchemaAny baseAny); // 0x000000018199E500-0x000000018199E7A0
		private bool IsElementFromGroupBase(XmlSchemaElement derivedElement, XmlSchemaGroupBase baseGroupBase, bool skipEmptableOnly); // 0x000000018199E160-0x000000018199E500
		private bool IsGroupBaseFromGroupBase(XmlSchemaGroupBase derivedGroupBase, XmlSchemaGroupBase baseGroupBase, bool skipEmptableOnly); // 0x000000018199E7A0-0x000000018199EA70
		private bool IsSequenceFromAll(XmlSchemaSequence derivedSequence, XmlSchemaAll baseAll); // 0x000000018199EB20-0x000000018199EE60
		private bool IsSequenceFromChoice(XmlSchemaSequence derivedSequence, XmlSchemaChoice baseChoice); // 0x000000018199EE60-0x000000018199F110
		private void CalculateSequenceRange(XmlSchemaSequence sequence, out decimal minOccurs, out decimal maxOccurs); // 0x000000018198F780-0x000000018198FBD0
		private bool IsValidOccurrenceRangeRestriction(XmlSchemaParticle derivedParticle, XmlSchemaParticle baseParticle); // 0x000000018199F1D0-0x000000018199F2C0
		private bool IsValidOccurrenceRangeRestriction(decimal minOccurs, decimal maxOccurs, decimal baseMinOccurs, decimal baseMaxOccurs); // 0x000000018199F110-0x000000018199F1D0
		private int GetMappingParticle(XmlSchemaParticle particle, XmlSchemaObjectCollection collection); // 0x000000018199DCA0-0x000000018199DDA0
		private bool IsParticleEmptiable(XmlSchemaParticle particle); // 0x000000018199EA70-0x000000018199EB20
		private void CalculateEffectiveTotalRange(XmlSchemaParticle particle, out decimal minOccurs, out decimal maxOccurs); // 0x000000018198ED60-0x000000018198F780
		private void PushComplexType(XmlSchemaComplexType complexType); // 0x00000001819A0F00-0x00000001819A0F30
		private XmlSchemaContentType GetSchemaContentType(XmlSchemaComplexType complexType, XmlSchemaComplexContent complexContent, XmlSchemaParticle particle); // 0x000000018199DDA0-0x000000018199DE20
		private void CompileAttributeGroup(XmlSchemaAttributeGroup attributeGroup); // 0x0000000181994000-0x0000000181994750
		private void CompileLocalAttributes(XmlSchemaComplexType baseType, XmlSchemaComplexType derivedType, XmlSchemaObjectCollection attributes, XmlSchemaAnyAttribute anyAttribute, XmlSchemaDerivationMethod derivedBy); // 0x00000001819993A0-0x000000018199A4A0
		private XmlSchemaAnyAttribute CompileAnyAttributeUnion(XmlSchemaAnyAttribute a, XmlSchemaAnyAttribute b); // 0x0000000181993F50-0x0000000181994000
		private XmlSchemaAnyAttribute CompileAnyAttributeIntersection(XmlSchemaAnyAttribute a, XmlSchemaAnyAttribute b); // 0x0000000181993EA0-0x0000000181993F50
		private void CompileAttribute(XmlSchemaAttribute xa); // 0x0000000181994750-0x0000000181995370
		private void CompileIdentityConstraint(XmlSchemaIdentityConstraint xi); // 0x0000000181998CE0-0x00000001819993A0
		private void CompileElement(XmlSchemaElement xe); // 0x0000000181997C30-0x0000000181998BF0
		private ContentValidator CompileComplexContent(XmlSchemaComplexType complexType); // 0x0000000181996090-0x0000000181996DE0
		private void BuildParticleContentModel(ParticleContentValidator contentValidator, XmlSchemaParticle particle); // 0x000000018198E770-0x000000018198ED60
		private void CompileParticleElements(XmlSchemaComplexType complexType, XmlSchemaParticle particle); // 0x000000018199A4A0-0x000000018199A790
		private void CompileCompexTypeElements(XmlSchemaComplexType complexType); // 0x0000000181995760-0x0000000181995830
		private XmlSchemaSimpleType GetSimpleType(XmlQualifiedName name); // 0x000000018199DE20-0x000000018199DF50
		private XmlSchemaComplexType GetComplexType(XmlQualifiedName name); // 0x000000018199DBE0-0x000000018199DCA0
		private XmlSchemaType GetAnySchemaType(XmlQualifiedName name); // 0x000000018199DA10-0x000000018199DBE0
	}
}
