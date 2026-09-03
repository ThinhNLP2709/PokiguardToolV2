/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
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
	public class XmlSchemaAttribute : XmlSchemaAnnotated // TypeDefIndex: 7181
	{
		// Fields
		private string defaultValue; // 0x50
		private string fixedValue; // 0x58
		private string name; // 0x60
		private XmlSchemaForm form; // 0x68
		private XmlSchemaUse use; // 0x6C
		private XmlQualifiedName refName; // 0x70
		private XmlQualifiedName typeName; // 0x78
		private XmlQualifiedName qualifiedName; // 0x80
		private XmlSchemaSimpleType type; // 0x88
		private XmlSchemaSimpleType attributeType; // 0x90
		private SchemaAttDef attDef; // 0x98
	
		// Properties
		[DefaultValue(null)]
		[XmlAttribute("default")]
		public string DefaultValue { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		[DefaultValue(null)]
		[XmlAttribute("fixed")]
		public string FixedValue { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		[DefaultValue(XmlSchemaForm.None)]
		[XmlAttribute("form")]
		public XmlSchemaForm Form { get; set; } // 0x00000001803002C0-0x00000001803002D0 0x00000001803002E0-0x00000001803002F0
		[XmlAttribute("name")]
		public string Name { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		[XmlAttribute("ref")]
		public XmlQualifiedName RefName { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x00000001819D8660-0x00000001819D86F0
		[XmlAttribute("type")]
		public XmlQualifiedName SchemaTypeName { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x00000001819D86F0-0x00000001819D8780
		[XmlElement("simpleType")]
		public XmlSchemaSimpleType SchemaType { get; set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000180664140-0x0000000180664160
		[DefaultValue(XmlSchemaUse.None)]
		[XmlAttribute("use")]
		public XmlSchemaUse Use { get; set; } // 0x0000000180C55C40-0x0000000180C55C50 0x0000000180C55C60-0x0000000180C55C70
		[XmlIgnore]
		public XmlQualifiedName QualifiedName { get; } // 0x000000018033D4A0-0x000000018033D4B0 
		[XmlIgnore]
		public XmlSchemaSimpleType AttributeSchemaType { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		[XmlIgnore]
		internal XmlSchemaDatatype Datatype { get; } // 0x00000001819D8640-0x00000001819D8660 
		internal SchemaAttDef AttDef { get; set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
		[XmlIgnore]
		internal override string NameAttribute { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
	
		// Constructors
		public XmlSchemaAttribute(); // 0x00000001819D8590-0x00000001819D8640
	
		// Methods
		internal void SetQualifiedName(XmlQualifiedName value); // 0x000000018033EA30-0x000000018033EA40
		internal void SetAttributeType(XmlSchemaSimpleType value); // 0x0000000180664160-0x0000000180664180
		internal override XmlSchemaObject Clone(); // 0x00000001819D8490-0x00000001819D8590
	}
}
