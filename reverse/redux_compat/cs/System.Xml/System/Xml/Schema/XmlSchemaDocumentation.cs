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
	public class XmlSchemaDocumentation : XmlSchemaObject // TypeDefIndex: 7199
	{
		// Fields
		private string source; // 0x38
		private string language; // 0x40
		private XmlNode[] markup; // 0x48
		private static XmlSchemaSimpleType languageType; // 0x00
	
		// Properties
		[XmlAttribute("source", DataType = "anyURI")]
		public string Source { set; } // 0x000000018033E850-0x000000018033E860
		[XmlAttribute("xml:lang")]
		public string Language { set; } // 0x00000001819DCE80-0x00000001819DCF70
		[XmlAnyElement]
		[XmlText]
		public XmlNode[] Markup { set; } // 0x00000001803780C0-0x00000001803780D0
	
		// Constructors
		public XmlSchemaDocumentation(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static XmlSchemaDocumentation(); // 0x00000001819DCDB0-0x00000001819DCE80
	}
}
