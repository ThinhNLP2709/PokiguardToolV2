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
	public class XmlSchemaAnnotated : XmlSchemaObject // TypeDefIndex: 7176
	{
		// Fields
		private string id; // 0x38
		private XmlSchemaAnnotation annotation; // 0x40
		private XmlAttribute[] moreAttributes; // 0x48
	
		// Properties
		[XmlAttribute("id", DataType = "ID")]
		public string Id { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		[XmlElement("annotation", typeof(XmlSchemaAnnotation))]
		public XmlSchemaAnnotation Annotation { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		[XmlAnyAttribute]
		public XmlAttribute[] UnhandledAttributes { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		[XmlIgnore]
		internal override string IdAttribute { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	
		// Constructors
		public XmlSchemaAnnotated(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal override void SetUnhandledAttributes(XmlAttribute[] moreAttributes); // 0x00000001803780C0-0x00000001803780D0
		internal override void AddAnnotation(XmlSchemaAnnotation annotation); // 0x0000000180378120-0x0000000180378130
	}
}
