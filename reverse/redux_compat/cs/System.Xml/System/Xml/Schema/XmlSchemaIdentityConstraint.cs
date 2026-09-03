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
	public class XmlSchemaIdentityConstraint : XmlSchemaAnnotated // TypeDefIndex: 7222
	{
		// Fields
		private string name; // 0x50
		private XmlSchemaXPath selector; // 0x58
		private XmlSchemaObjectCollection fields; // 0x60
		private XmlQualifiedName qualifiedName; // 0x68
		private CompiledIdentityConstraint compiledConstraint; // 0x70
	
		// Properties
		[XmlAttribute("name")]
		public string Name { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		[XmlElement("selector", typeof(XmlSchemaXPath))]
		public XmlSchemaXPath Selector { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		[XmlElement("field", typeof(XmlSchemaXPath))]
		public XmlSchemaObjectCollection Fields { get; } // 0x0000000180333260-0x0000000180333490 
		[XmlIgnore]
		public XmlQualifiedName QualifiedName { get; } // 0x0000000180316960-0x0000000180316970 
		[XmlIgnore]
		internal CompiledIdentityConstraint CompiledConstraint { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		[XmlIgnore]
		internal override string NameAttribute { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
	
		// Constructors
		public XmlSchemaIdentityConstraint(); // 0x00000001819DE7B0-0x00000001819DE860
	
		// Methods
		internal void SetQualifiedName(XmlQualifiedName value); // 0x0000000180316A40-0x0000000180316A50
	}
}
