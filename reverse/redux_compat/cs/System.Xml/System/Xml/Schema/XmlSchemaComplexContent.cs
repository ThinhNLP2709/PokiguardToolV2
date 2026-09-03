/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public class XmlSchemaComplexContent : XmlSchemaContentModel // TypeDefIndex: 7189
	{
		// Fields
		private XmlSchemaContent content; // 0x50
		private bool isMixed; // 0x58
		private bool hasMixedAttribute; // 0x59
	
		// Properties
		[XmlAttribute("mixed")]
		public bool IsMixed { get; set; } // 0x0000000181424750-0x0000000181424760 0x00000001819D9810-0x00000001819D9820
		[XmlElement("restriction", typeof(XmlSchemaComplexContentRestriction))]
		[XmlElement("extension", typeof(XmlSchemaComplexContentExtension))]
		public override XmlSchemaContent Content { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		[XmlIgnore]
		internal bool HasMixedAttribute { get; } // 0x00000001802E7880-0x00000001802E7890 
	
		// Constructors
		public XmlSchemaComplexContent(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
