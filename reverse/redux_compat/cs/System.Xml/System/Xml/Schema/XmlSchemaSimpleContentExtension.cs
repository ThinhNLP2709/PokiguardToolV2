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
	public class XmlSchemaSimpleContentExtension : XmlSchemaContent // TypeDefIndex: 7247
	{
		// Fields
		private XmlSchemaObjectCollection attributes; // 0x50
		private XmlSchemaAnyAttribute anyAttribute; // 0x58
		private XmlQualifiedName baseTypeName; // 0x60
	
		// Properties
		[XmlAttribute("base")]
		public XmlQualifiedName BaseTypeName { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001819F0BD0-0x00000001819F0C60
		[XmlElement("attributeGroup", typeof(XmlSchemaAttributeGroupRef))]
		[XmlElement("attribute", typeof(XmlSchemaAttribute))]
		public XmlSchemaObjectCollection Attributes { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		[XmlElement("anyAttribute")]
		public XmlSchemaAnyAttribute AnyAttribute { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
	
		// Constructors
		public XmlSchemaSimpleContentExtension(); // 0x00000001819F0B20-0x00000001819F0BD0
	
		// Methods
		internal void SetAttributes(XmlSchemaObjectCollection newAttributes); // 0x00000001806CCE80-0x00000001806CCE90
	}
}
