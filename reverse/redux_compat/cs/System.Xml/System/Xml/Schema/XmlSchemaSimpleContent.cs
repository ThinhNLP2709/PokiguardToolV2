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
	public class XmlSchemaSimpleContent : XmlSchemaContentModel // TypeDefIndex: 7246
	{
		// Fields
		private XmlSchemaContent content; // 0x50
	
		// Properties
		[XmlElement("extension", typeof(XmlSchemaSimpleContentExtension))]
		[XmlElement("restriction", typeof(XmlSchemaSimpleContentRestriction))]
		public override XmlSchemaContent Content { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
	
		// Constructors
		public XmlSchemaSimpleContent(); // 0x00000001802F4070-0x00000001802F4080
	}
}
