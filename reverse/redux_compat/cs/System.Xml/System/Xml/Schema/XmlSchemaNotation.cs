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
	public class XmlSchemaNotation : XmlSchemaAnnotated // TypeDefIndex: 7230
	{
		// Fields
		private string name; // 0x50
		private string publicId; // 0x58
		private string systemId; // 0x60
		private XmlQualifiedName qname; // 0x68
	
		// Properties
		[XmlAttribute("name")]
		public string Name { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		[XmlAttribute("public")]
		public string Public { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		[XmlAttribute("system")]
		public string System { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		[XmlIgnore]
		internal XmlQualifiedName QualifiedName { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		[XmlIgnore]
		internal override string NameAttribute { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
	
		// Constructors
		public XmlSchemaNotation(); // 0x00000001819DEDF0-0x00000001819DEE60
	}
}
