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
	internal sealed class Compiler : BaseProcessor // TypeDefIndex: 7153
	{
		// Fields
		private string restrictionErrorMsg; // 0x40
		private XmlSchemaObjectTable attributes; // 0x48
		private XmlSchemaObjectTable attributeGroups; // 0x50
		private XmlSchemaObjectTable elements; // 0x58
		private XmlSchemaObjectTable schemaTypes; // 0x60
		private XmlSchemaObjectTable groups; // 0x68
		private XmlSchemaObjectTable notations; // 0x70
		private XmlSchemaObjectTable examplars; // 0x78
		private XmlSchemaObjectTable identityConstraints; // 0x80
		private Stack complexTypeStack; // 0x88
		private Hashtable schemasToCompile; // 0x90
		private Hashtable importedSchemas; // 0x98
		private XmlSchema schemaForSchema; // 0xA0
	
		// Constructors
		public Compiler(XmlNameTable nameTable, ValidationEventHandler eventHandler, XmlSchema schemaForSchema, XmlSchemaCompilationSettings compilationSettings); // 0x00000001819BF0E0-0x00000001819BF370
	
		// Methods
		public bool Execute(XmlSchemaSet schemaSet, SchemaInfo schemaCompiledInfo); // 0x00000001819B84B0-0x00000001819B8570
		internal void Prepare(XmlSchema schema, bool cleanup); // 0x00000001819BD0D0-0x00000001819BE400
		private void UpdateSForSSimpleTypes(); // 0x00000001819BEF50-0x00000001819BF0E0
		private void Output(SchemaInfo schemaInfo); // 0x00000001819BC2A0-0x00000001819BD0D0
		internal void ImportAllCompiledSchemas(XmlSchemaSet schemaSet); // 0x00000001819B89C0-0x00000001819B8AC0
		internal bool Compile(); // 0x00000001819B67F0-0x00000001819B8420
		private void CleanupAttribute(XmlSchemaAttribute attribute); // 0x00000001819ADA80-0x00000001819ADB80
		private void CleanupAttributeGroup(XmlSchemaAttributeGroup attributeGroup); // 0x00000001819ADA00-0x00000001819ADA80
		private void CleanupComplexType(XmlSchemaComplexType complexType); // 0x00000001819ADC50-0x00000001819AE250
		private void CleanupSimpleType(XmlSchemaSimpleType simpleType); // 0x00000001819AE6F0-0x00000001819AE7C0
		private void CleanupElement(XmlSchemaElement element); // 0x00000001819AE250-0x00000001819AE4D0
		private void CleanupAttributes(XmlSchemaObjectCollection attributes); // 0x00000001819ADB80-0x00000001819ADC50
		private void CleanupGroup(XmlSchemaGroup group); // 0x00000001819AE4D0-0x00000001819AE530
		private void CleanupParticle(XmlSchemaParticle particle); // 0x00000001819AE530-0x00000001819AE6F0
		private void ProcessSubstitutionGroups(); // 0x00000001819BE400-0x00000001819BEAF0
		private void CompileSubstitutionGroup(XmlSchemaSubstitutionGroup substitutionGroup); // 0x00000001819B6200-0x00000001819B67F0
		private void RecursivelyCheckRedefinedGroups(XmlSchemaGroup redefinedGroup, XmlSchemaGroup baseGroup); // 0x00000001819BEBB0-0x00000001819BED50
		private void RecursivelyCheckRedefinedAttributeGroups(XmlSchemaAttributeGroup attributeGroup, XmlSchemaAttributeGroup baseAttributeGroup); // 0x00000001819BEB20-0x00000001819BEBB0
		private void CompileGroup(XmlSchemaGroup group); // 0x00000001819B32F0-0x00000001819B33D0
		private void CompileSimpleType(XmlSchemaSimpleType simpleType); // 0x00000001819B57B0-0x00000001819B6200
		private XmlSchemaSimpleType[] CompileBaseMemberTypes(XmlSchemaSimpleType simpleType); // 0x00000001819AFB30-0x00000001819AFF20
		private void CheckUnionType(XmlSchemaSimpleType unionMember, ArrayList memberTypeDefinitions, XmlSchemaSimpleType parentType); // 0x00000001819AD8D0-0x00000001819ADA00
		private void CompileComplexType(XmlSchemaComplexType complexType); // 0x00000001819B14D0-0x00000001819B20B0
		private void CompileSimpleContentExtension(XmlSchemaComplexType complexType, XmlSchemaSimpleContentExtension simpleExtension); // 0x00000001819B50D0-0x00000001819B5370
		private void CompileSimpleContentRestriction(XmlSchemaComplexType complexType, XmlSchemaSimpleContentRestriction simpleRestriction); // 0x00000001819B5370-0x00000001819B57B0
		private void CompileComplexContentExtension(XmlSchemaComplexType complexType, XmlSchemaComplexContent complexContent, XmlSchemaComplexContentExtension complexExtension); // 0x00000001819AFF20-0x00000001819B0320
		private void CompileComplexContentRestriction(XmlSchemaComplexType complexType, XmlSchemaComplexContent complexContent, XmlSchemaComplexContentRestriction complexRestriction); // 0x00000001819B0320-0x00000001819B0680
		private void CheckParticleDerivation(XmlSchemaComplexType complexType); // 0x00000001819AD290-0x00000001819AD7F0
		private void CheckParticleDerivation(XmlSchemaParticle derivedParticle, XmlSchemaParticle baseParticle); // 0x00000001819AD7F0-0x00000001819AD8D0
		private XmlSchemaParticle CompileContentTypeParticle(XmlSchemaParticle particle); // 0x00000001819B20B0-0x00000001819B2240
		private XmlSchemaParticle CannonicalizeParticle(XmlSchemaParticle particle, bool root); // 0x00000001819ABD00-0x00000001819AC000
		private XmlSchemaParticle CannonicalizeElement(XmlSchemaElement element); // 0x00000001819AB430-0x00000001819AB6B0
		private XmlSchemaParticle CannonicalizeGroupRef(XmlSchemaGroupRef groupRef, bool root); // 0x00000001819AB6B0-0x00000001819ABD00
		private XmlSchemaParticle CannonicalizeAll(XmlSchemaAll all, bool root); // 0x00000001819AAA10-0x00000001819AAD30
		private XmlSchemaParticle CannonicalizeChoice(XmlSchemaChoice choice, bool root); // 0x00000001819AAD30-0x00000001819AB430
		private XmlSchemaParticle CannonicalizeSequence(XmlSchemaSequence sequence, bool root); // 0x00000001819AC430-0x00000001819ACAA0
		private XmlSchemaParticle CannonicalizePointlessRoot(XmlSchemaParticle particle); // 0x00000001819AC000-0x00000001819AC430
		private bool IsValidRestriction(XmlSchemaParticle derivedParticle, XmlSchemaParticle baseParticle); // 0x00000001819BB0B0-0x00000001819BC2A0
		private bool IsElementFromElement(XmlSchemaElement derivedElement, XmlSchemaElement baseElement); // 0x00000001819B8F80-0x00000001819B9200
		private bool IsElementFromAny(XmlSchemaElement derivedElement, XmlSchemaAny baseAny); // 0x00000001819B8D90-0x00000001819B8F80
		private bool IsAnyFromAny(XmlSchemaAny derivedAny, XmlSchemaAny baseAny); // 0x00000001819B8AC0-0x00000001819B8BD0
		private bool IsGroupBaseFromAny(XmlSchemaGroupBase derivedGroupBase, XmlSchemaAny baseAny); // 0x00000001819B9DF0-0x00000001819BA2C0
		private bool IsElementFromGroupBase(XmlSchemaElement derivedElement, XmlSchemaGroupBase baseGroupBase); // 0x00000001819B9200-0x00000001819B9C70
		private bool IsChoiceFromChoiceSubstGroup(XmlSchemaChoice derivedChoice, XmlSchemaChoice baseChoice); // 0x00000001819B8BD0-0x00000001819B8D90
		private bool IsGroupBaseFromGroupBase(XmlSchemaGroupBase derivedGroupBase, XmlSchemaGroupBase baseGroupBase, bool skipEmptableOnly); // 0x00000001819BA2C0-0x00000001819BA610
		private bool IsSequenceFromAll(XmlSchemaSequence derivedSequence, XmlSchemaAll baseAll); // 0x00000001819BA7B0-0x00000001819BAAF0
		private bool IsSequenceFromChoice(XmlSchemaSequence derivedSequence, XmlSchemaChoice baseChoice); // 0x00000001819BAAF0-0x00000001819BAF00
		private bool IsValidOccurrenceRangeRestriction(XmlSchemaParticle derivedParticle, XmlSchemaParticle baseParticle); // 0x00000001819BAFC0-0x00000001819BB0B0
		private bool IsValidOccurrenceRangeRestriction(decimal minOccurs, decimal maxOccurs, decimal baseMinOccurs, decimal baseMaxOccurs); // 0x00000001819BAF00-0x00000001819BAFC0
		private int GetMappingParticle(XmlSchemaParticle particle, XmlSchemaObjectCollection collection); // 0x00000001819B87E0-0x00000001819B88E0
		private bool IsParticleEmptiable(XmlSchemaParticle particle); // 0x00000001819BA610-0x00000001819BA6C0
		private void CalculateEffectiveTotalRange(XmlSchemaParticle particle, out decimal minOccurs, out decimal maxOccurs); // 0x00000001819AA200-0x00000001819AAA10
		private void PushComplexType(XmlSchemaComplexType complexType); // 0x00000001819BEAF0-0x00000001819BEB20
		private XmlSchemaContentType GetSchemaContentType(XmlSchemaComplexType complexType, XmlSchemaComplexContent complexContent, XmlSchemaParticle particle); // 0x000000018199DDA0-0x000000018199DE20
		private void CompileAttributeGroup(XmlSchemaAttributeGroup attributeGroup); // 0x00000001819AE920-0x00000001819AF180
		private void CompileLocalAttributes(XmlSchemaComplexType baseType, XmlSchemaComplexType derivedType, XmlSchemaObjectCollection attributes, XmlSchemaAnyAttribute anyAttribute, XmlSchemaDerivationMethod derivedBy); // 0x00000001819B3A90-0x00000001819B4BF0
		private void CheckAtrributeGroupRestriction(XmlSchemaAttributeGroup baseAttributeGroup, XmlSchemaAttributeGroup derivedAttributeGroup); // 0x00000001819ACAA0-0x00000001819AD290
		private bool IsProcessContentsRestricted(XmlSchemaComplexType baseType, XmlSchemaAnyAttribute derivedAttributeWildcard, XmlSchemaAnyAttribute baseAttributeWildcard); // 0x00000001819BA6C0-0x00000001819BA7B0
		private XmlSchemaAnyAttribute CompileAnyAttributeUnion(XmlSchemaAnyAttribute a, XmlSchemaAnyAttribute b); // 0x00000001819AE870-0x00000001819AE920
		private XmlSchemaAnyAttribute CompileAnyAttributeIntersection(XmlSchemaAnyAttribute a, XmlSchemaAnyAttribute b); // 0x00000001819AE7C0-0x00000001819AE870
		private void CompileAttribute(XmlSchemaAttribute xa); // 0x00000001819AF180-0x00000001819AFB30
		private void SetDefaultFixed(XmlSchemaAttribute xa, SchemaAttDef decl); // 0x00000001819BED50-0x00000001819BEF50
		private void CompileIdentityConstraint(XmlSchemaIdentityConstraint xi); // 0x00000001819B33D0-0x00000001819B3A90
		private void CompileElement(XmlSchemaElement xe); // 0x00000001819B2240-0x00000001819B32F0
		private ContentValidator CompileComplexContent(XmlSchemaComplexType complexType); // 0x00000001819B0680-0x00000001819B1390
		private bool BuildParticleContentModel(ParticleContentValidator contentValidator, XmlSchemaParticle particle); // 0x00000001819A9C10-0x00000001819AA200
		private void CompileParticleElements(XmlSchemaComplexType complexType, XmlSchemaParticle particle); // 0x00000001819B4DE0-0x00000001819B50D0
		private void CompileParticleElements(XmlSchemaParticle particle); // 0x00000001819B4BF0-0x00000001819B4DE0
		private void CompileComplexTypeElements(XmlSchemaComplexType complexType); // 0x00000001819B1390-0x00000001819B14D0
		private XmlSchemaSimpleType GetSimpleType(XmlQualifiedName name); // 0x00000001819B88E0-0x00000001819B89C0
		private XmlSchemaComplexType GetComplexType(XmlQualifiedName name); // 0x00000001819B8730-0x00000001819B87E0
		private XmlSchemaType GetAnySchemaType(XmlQualifiedName name); // 0x00000001819B8570-0x00000001819B8730
		private void CopyPosition(XmlSchemaAnnotated to, XmlSchemaAnnotated from, bool copyParent); // 0x00000001819B8420-0x00000001819B84B0
		private bool IsFixedEqual(SchemaDeclBase baseDecl, SchemaDeclBase derivedDecl); // 0x00000001819B9C70-0x00000001819B9DF0
	}
}
