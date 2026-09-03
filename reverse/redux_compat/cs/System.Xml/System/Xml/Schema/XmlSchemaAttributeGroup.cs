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
	public class XmlSchemaAttributeGroup : XmlSchemaAnnotated // TypeDefIndex: 7182
	{
		// Fields
		private string name; // 0x50
		private XmlSchemaObjectCollection attributes; // 0x58
		private XmlSchemaAnyAttribute anyAttribute; // 0x60
		private XmlQualifiedName qname; // 0x68
		private XmlSchemaAttributeGroup redefined; // 0x70
		private XmlSchemaObjectTable attributeUses; // 0x78
		private XmlSchemaAnyAttribute attributeWildcard; // 0x80
		private int selfReferenceCount; // 0x88
	
		// Properties
		[XmlAttribute("name")]
		public string Name { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		[XmlElement("attribute", typeof(XmlSchemaAttribute))]
		[XmlElement("attributeGroup", typeof(XmlSchemaAttributeGroupRef))]
		public XmlSchemaObjectCollection Attributes { get; } // 0x00000001802F4000-0x00000001802F4010 
		[XmlElement("anyAttribute")]
		public XmlSchemaAnyAttribute AnyAttribute { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		[XmlIgnore]
		public XmlQualifiedName QualifiedName { get; } // 0x0000000180316960-0x0000000180316970 
		[XmlIgnore]
		internal XmlSchemaObjectTable AttributeUses { get; } // 0x00000001819D8420-0x00000001819D8490 
		[XmlIgnore]
		internal XmlSchemaAnyAttribute AttributeWildcard { get; set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
		[XmlIgnore]
		public XmlSchemaAttributeGroup RedefinedAttributeGroup { get; } // 0x000000018033D4D0-0x000000018033D4E0 
		[XmlIgnore]
		internal XmlSchemaAttributeGroup Redefined { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		[XmlIgnore]
		internal int SelfReferenceCount { get; set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
		[XmlIgnore]
		internal override string NameAttribute { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
	
		// Constructors
		public XmlSchemaAttributeGroup(); // 0x00000001819D8370-0x00000001819D8420
	
		// Methods
		internal void SetQualifiedName(XmlQualifiedName value); // 0x0000000180316A40-0x0000000180316A50
		internal override XmlSchemaObject Clone(); // 0x00000001819D8270-0x00000001819D8370
	}
}
