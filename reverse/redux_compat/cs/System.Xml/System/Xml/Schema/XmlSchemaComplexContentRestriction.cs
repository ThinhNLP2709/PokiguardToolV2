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
	public class XmlSchemaComplexContentRestriction : XmlSchemaContent // TypeDefIndex: 7191
	{
		// Fields
		private XmlSchemaParticle particle; // 0x50
		private XmlSchemaObjectCollection attributes; // 0x58
		private XmlSchemaAnyAttribute anyAttribute; // 0x60
		private XmlQualifiedName baseTypeName; // 0x68
	
		// Properties
		[XmlAttribute("base")]
		public XmlQualifiedName BaseTypeName { get; set; } // 0x0000000180316960-0x0000000180316970 0x00000001819D9780-0x00000001819D9810
		[XmlElement("group", typeof(XmlSchemaGroupRef))]
		[XmlElement("choice", typeof(XmlSchemaChoice))]
		[XmlElement("all", typeof(XmlSchemaAll))]
		[XmlElement("sequence", typeof(XmlSchemaSequence))]
		public XmlSchemaParticle Particle { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		[XmlElement("attribute", typeof(XmlSchemaAttribute))]
		[XmlElement("attributeGroup", typeof(XmlSchemaAttributeGroupRef))]
		public XmlSchemaObjectCollection Attributes { get; } // 0x00000001802F4000-0x00000001802F4010 
		[XmlElement("anyAttribute")]
		public XmlSchemaAnyAttribute AnyAttribute { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
	
		// Constructors
		public XmlSchemaComplexContentRestriction(); // 0x00000001819D96D0-0x00000001819D9780
	
		// Methods
		internal void SetAttributes(XmlSchemaObjectCollection newAttributes); // 0x00000001802F4050-0x00000001802F4060
	}
}
