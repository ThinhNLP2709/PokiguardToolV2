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
	public class XmlSchemaSimpleTypeList : XmlSchemaSimpleTypeContent // TypeDefIndex: 7251
	{
		// Fields
		private XmlQualifiedName itemTypeName; // 0x50
		private XmlSchemaSimpleType itemType; // 0x58
		private XmlSchemaSimpleType baseItemType; // 0x60
	
		// Properties
		[XmlAttribute("itemType")]
		public XmlQualifiedName ItemTypeName { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001819F0F50-0x00000001819F0FE0
		[XmlElement("simpleType", typeof(XmlSchemaSimpleType))]
		public XmlSchemaSimpleType ItemType { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		[XmlIgnore]
		public XmlSchemaSimpleType BaseItemType { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
	
		// Constructors
		public XmlSchemaSimpleTypeList(); // 0x00000001819F0EE0-0x00000001819F0F50
	
		// Methods
		internal override XmlSchemaObject Clone(); // 0x00000001819F0DD0-0x00000001819F0EE0
	}
}
