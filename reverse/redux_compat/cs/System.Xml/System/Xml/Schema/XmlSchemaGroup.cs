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
	public class XmlSchemaGroup : XmlSchemaAnnotated // TypeDefIndex: 7219
	{
		// Fields
		private string name; // 0x50
		private XmlSchemaGroupBase particle; // 0x58
		private XmlSchemaParticle canonicalParticle; // 0x60
		private XmlQualifiedName qname; // 0x68
		private XmlSchemaGroup redefined; // 0x70
		private int selfReferenceCount; // 0x78
	
		// Properties
		[XmlAttribute("name")]
		public string Name { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		[XmlElement("choice", typeof(XmlSchemaChoice))]
		[XmlElement("all", typeof(XmlSchemaAll))]
		[XmlElement("sequence", typeof(XmlSchemaSequence))]
		public XmlSchemaGroupBase Particle { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		[XmlIgnore]
		public XmlQualifiedName QualifiedName { get; } // 0x0000000180316960-0x0000000180316970 
		[XmlIgnore]
		internal XmlSchemaParticle CanonicalParticle { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		[XmlIgnore]
		internal XmlSchemaGroup Redefined { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		[XmlIgnore]
		internal int SelfReferenceCount { get; set; } // 0x000000018169BB50-0x000000018169BB60 0x00000001805936B0-0x00000001805936C0
		[XmlIgnore]
		internal override string NameAttribute { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
	
		// Constructors
		public XmlSchemaGroup(); // 0x00000001819DE740-0x00000001819DE7B0
	
		// Methods
		internal void SetQualifiedName(XmlQualifiedName value); // 0x0000000180316A40-0x0000000180316A50
		internal override XmlSchemaObject Clone(); // 0x00000001819DE730-0x00000001819DE740
		internal XmlSchemaObject Clone(XmlSchema parentSchema); // 0x00000001819DE540-0x00000001819DE730
	}
}
