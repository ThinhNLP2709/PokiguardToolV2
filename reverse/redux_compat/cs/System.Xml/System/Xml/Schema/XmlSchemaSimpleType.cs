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
	public class XmlSchemaSimpleType : XmlSchemaType // TypeDefIndex: 7249
	{
		// Fields
		private XmlSchemaSimpleTypeContent content; // 0x98
	
		// Properties
		[XmlElement("restriction", typeof(XmlSchemaSimpleTypeRestriction))]
		[XmlElement("list", typeof(XmlSchemaSimpleTypeList))]
		[XmlElement("union", typeof(XmlSchemaSimpleTypeUnion))]
		public XmlSchemaSimpleTypeContent Content { get; set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
	
		// Constructors
		public XmlSchemaSimpleType(); // 0x00000001819F15B0-0x00000001819F1640
	
		// Methods
		internal override XmlSchemaObject Clone(); // 0x00000001819F1480-0x00000001819F15B0
	}
}
