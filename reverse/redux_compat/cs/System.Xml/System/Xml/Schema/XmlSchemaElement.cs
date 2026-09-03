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
	public class XmlSchemaElement : XmlSchemaParticle // TypeDefIndex: 7200
	{
		// Fields
		private bool isAbstract; // 0x78
		private bool hasAbstractAttribute; // 0x79
		private bool isNillable; // 0x7A
		private bool hasNillableAttribute; // 0x7B
		private bool isLocalTypeDerivationChecked; // 0x7C
		private XmlSchemaDerivationMethod block; // 0x80
		private XmlSchemaDerivationMethod final; // 0x84
		private XmlSchemaForm form; // 0x88
		private string defaultValue; // 0x90
		private string fixedValue; // 0x98
		private string name; // 0xA0
		private XmlQualifiedName refName; // 0xA8
		private XmlQualifiedName substitutionGroup; // 0xB0
		private XmlQualifiedName typeName; // 0xB8
		private XmlSchemaType type; // 0xC0
		private XmlQualifiedName qualifiedName; // 0xC8
		private XmlSchemaType elementType; // 0xD0
		private XmlSchemaDerivationMethod blockResolved; // 0xD8
		private XmlSchemaDerivationMethod finalResolved; // 0xDC
		private XmlSchemaObjectCollection constraints; // 0xE0
		private SchemaElementDecl elementDecl; // 0xE8
	
		// Properties
		[DefaultValue(false)]
		[XmlAttribute("abstract")]
		public bool IsAbstract { get; set; } // 0x0000000180B255A0-0x0000000180B255B0 0x00000001819DD460-0x00000001819DD470
		[DefaultValue(XmlSchemaDerivationMethod.Empty | XmlSchemaDerivationMethod.None)]
		[XmlAttribute("block")]
		public XmlSchemaDerivationMethod Block { get; set; } // 0x0000000180CC3A10-0x0000000180CC3A20 0x0000000180CC3E80-0x0000000180CC3E90
		[DefaultValue(null)]
		[XmlAttribute("default")]
		public string DefaultValue { get; set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000180664160-0x0000000180664180
		[DefaultValue(XmlSchemaDerivationMethod.Empty | XmlSchemaDerivationMethod.None)]
		[XmlAttribute("final")]
		public XmlSchemaDerivationMethod Final { get; set; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 0x0000000180BE5D70-0x0000000180BE5D80
		[DefaultValue(null)]
		[XmlAttribute("fixed")]
		public string FixedValue { get; set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
		[DefaultValue(XmlSchemaForm.None)]
		[XmlAttribute("form")]
		public XmlSchemaForm Form { get; set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
		[DefaultValue("")]
		[XmlAttribute("name")]
		public string Name { get; set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		[DefaultValue(false)]
		[XmlAttribute("nillable")]
		public bool IsNillable { get; set; } // 0x000000018186F5B0-0x000000018186F5C0 0x00000001819DD480-0x00000001819DD490
		[XmlIgnore]
		internal bool HasNillableAttribute { get; } // 0x00000001819DD420-0x00000001819DD430 
		[XmlIgnore]
		internal bool HasAbstractAttribute { get; } // 0x00000001819DD3E0-0x00000001819DD3F0 
		[XmlAttribute("ref")]
		public XmlQualifiedName RefName { get; set; } // 0x000000018033D510-0x000000018033D520 0x00000001819DD490-0x00000001819DD520
		[XmlAttribute("substitutionGroup")]
		public XmlQualifiedName SubstitutionGroup { get; set; } // 0x00000001806BAE60-0x00000001806BAE70 0x00000001819DD5B0-0x00000001819DD640
		[XmlAttribute("type")]
		public XmlQualifiedName SchemaTypeName { get; set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x00000001819DD520-0x00000001819DD5B0
		[XmlElement("simpleType", typeof(XmlSchemaSimpleType))]
		[XmlElement("complexType", typeof(XmlSchemaComplexType))]
		public XmlSchemaType SchemaType { get; set; } // 0x00000001806CCB70-0x00000001806CCB80 0x00000001806CCDA0-0x00000001806CCDC0
		[XmlElement("key", typeof(XmlSchemaKey))]
		[XmlElement("keyref", typeof(XmlSchemaKeyref))]
		[XmlElement("unique", typeof(XmlSchemaUnique))]
		public XmlSchemaObjectCollection Constraints { get; } // 0x00000001819DD350-0x00000001819DD3D0 
		[XmlIgnore]
		public XmlQualifiedName QualifiedName { get; } // 0x00000001806CCB50-0x00000001806CCB60 
		[XmlIgnore]
		public XmlSchemaType ElementSchemaType { get; } // 0x00000001806CCB60-0x00000001806CCB70 
		[XmlIgnore]
		public XmlSchemaDerivationMethod BlockResolved { get; } // 0x0000000181846100-0x0000000181846110 
		[XmlIgnore]
		public XmlSchemaDerivationMethod FinalResolved { get; } // 0x00000001819DD3D0-0x00000001819DD3E0 
		internal bool HasConstraints { get; } // 0x00000001819DD3F0-0x00000001819DD420 
		internal bool IsLocalTypeDerivationChecked { get; set; } // 0x000000018198E6D0-0x000000018198E6E0 0x00000001819DD470-0x00000001819DD480
		internal SchemaElementDecl ElementDecl { get; set; } // 0x00000001806BAE70-0x00000001806BAE80 0x00000001806C0C20-0x00000001806C0C40
		[XmlIgnore]
		internal override string NameAttribute { get; set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		[XmlIgnore]
		internal override string NameString { get; } // 0x00000001819DD430-0x00000001819DD460 
	
		// Constructors
		public XmlSchemaElement(); // 0x00000001819DD230-0x00000001819DD350
	
		// Methods
		internal void SetQualifiedName(XmlQualifiedName value); // 0x00000001806CCD60-0x00000001806CCD80
		internal void SetElementType(XmlSchemaType value); // 0x00000001806CCD80-0x00000001806CCDA0
		internal void SetBlockResolved(XmlSchemaDerivationMethod value); // 0x00000001819DD210-0x00000001819DD220
		internal void SetFinalResolved(XmlSchemaDerivationMethod value); // 0x00000001819DD220-0x00000001819DD230
		internal override XmlSchemaObject Clone(); // 0x00000001819DD200-0x00000001819DD210
		internal XmlSchemaObject Clone(XmlSchema parentSchema); // 0x00000001819DCF70-0x00000001819DD200
	}
}
