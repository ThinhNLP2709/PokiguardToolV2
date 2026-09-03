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
	public class XmlSchemaAppInfo : XmlSchemaObject // TypeDefIndex: 7180
	{
		// Fields
		private string source; // 0x38
		private XmlNode[] markup; // 0x40
	
		// Properties
		[XmlAttribute("source", DataType = "anyURI")]
		public string Source { set; } // 0x000000018033E850-0x000000018033E860
		[XmlAnyElement]
		[XmlText]
		public XmlNode[] Markup { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
	
		// Constructors
		public XmlSchemaAppInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	}
}
