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
	public class XmlSchemaSimpleTypeRestriction : XmlSchemaSimpleTypeContent // TypeDefIndex: 7252
	{
		// Fields
		private XmlQualifiedName baseTypeName; // 0x50
		private XmlSchemaSimpleType baseType; // 0x58
		private XmlSchemaObjectCollection facets; // 0x60
	
		// Properties
		[XmlAttribute("base")]
		public XmlQualifiedName BaseTypeName { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001819F11A0-0x00000001819F1230
		[XmlElement("simpleType", typeof(XmlSchemaSimpleType))]
		public XmlSchemaSimpleType BaseType { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		[XmlElement("totalDigits", typeof(XmlSchemaTotalDigitsFacet))]
		[XmlElement("length", typeof(XmlSchemaLengthFacet))]
		[XmlElement("maxInclusive", typeof(XmlSchemaMaxInclusiveFacet))]
		[XmlElement("minLength", typeof(XmlSchemaMinLengthFacet))]
		[XmlElement("maxExclusive", typeof(XmlSchemaMaxExclusiveFacet))]
		[XmlElement("minExclusive", typeof(XmlSchemaMinExclusiveFacet))]
		[XmlElement("enumeration", typeof(XmlSchemaEnumerationFacet))]
		[XmlElement("pattern", typeof(XmlSchemaPatternFacet))]
		[XmlElement("whiteSpace", typeof(XmlSchemaWhiteSpaceFacet))]
		[XmlElement("fractionDigits", typeof(XmlSchemaFractionDigitsFacet))]
		[XmlElement("minInclusive", typeof(XmlSchemaMinInclusiveFacet))]
		[XmlElement("maxLength", typeof(XmlSchemaMaxLengthFacet))]
		public XmlSchemaObjectCollection Facets { get; } // 0x0000000180333260-0x0000000180333490 
	
		// Constructors
		public XmlSchemaSimpleTypeRestriction(); // 0x00000001819F10F0-0x00000001819F11A0
	
		// Methods
		internal override XmlSchemaObject Clone(); // 0x00000001819F0FE0-0x00000001819F10F0
	}
}
