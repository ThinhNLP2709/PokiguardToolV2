/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public class XmlSchemaSimpleContentRestriction : XmlSchemaContent // TypeDefIndex: 7248
	{
		// Fields
		private XmlQualifiedName baseTypeName; // 0x50
		private XmlSchemaSimpleType baseType; // 0x58
		private XmlSchemaObjectCollection facets; // 0x60
		private XmlSchemaObjectCollection attributes; // 0x68
		private XmlSchemaAnyAttribute anyAttribute; // 0x70
	
		// Properties
		[XmlAttribute("base")]
		public XmlQualifiedName BaseTypeName { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001819F0D40-0x00000001819F0DD0
		[XmlElement("simpleType", typeof(XmlSchemaSimpleType))]
		public XmlSchemaSimpleType BaseType { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		[XmlElement("minLength", typeof(XmlSchemaMinLengthFacet))]
		[XmlElement("whiteSpace", typeof(XmlSchemaWhiteSpaceFacet))]
		[XmlElement("fractionDigits", typeof(XmlSchemaFractionDigitsFacet))]
		[XmlElement("totalDigits", typeof(XmlSchemaTotalDigitsFacet))]
		[XmlElement("minExclusive", typeof(XmlSchemaMinExclusiveFacet))]
		[XmlElement("minInclusive", typeof(XmlSchemaMinInclusiveFacet))]
		[XmlElement("maxExclusive", typeof(XmlSchemaMaxExclusiveFacet))]
		[XmlElement("maxInclusive", typeof(XmlSchemaMaxInclusiveFacet))]
		[XmlElement("enumeration", typeof(XmlSchemaEnumerationFacet))]
		[XmlElement("length", typeof(XmlSchemaLengthFacet))]
		[XmlElement("pattern", typeof(XmlSchemaPatternFacet))]
		[XmlElement("maxLength", typeof(XmlSchemaMaxLengthFacet))]
		public XmlSchemaObjectCollection Facets { get; } // 0x0000000180333260-0x0000000180333490 
		[XmlElement("attributeGroup", typeof(XmlSchemaAttributeGroupRef))]
		[XmlElement("attribute", typeof(XmlSchemaAttribute))]
		public XmlSchemaObjectCollection Attributes { get; } // 0x0000000180316960-0x0000000180316970 
		[XmlElement("anyAttribute")]
		public XmlSchemaAnyAttribute AnyAttribute { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
	
		// Constructors
		public XmlSchemaSimpleContentRestriction(); // 0x00000001819F0C60-0x00000001819F0D40
	
		// Methods
		internal void SetAttributes(XmlSchemaObjectCollection newAttributes); // 0x0000000180316A40-0x0000000180316A50
	}
}
