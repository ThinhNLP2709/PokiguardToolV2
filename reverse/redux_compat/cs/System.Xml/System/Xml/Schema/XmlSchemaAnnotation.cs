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
	public class XmlSchemaAnnotation : XmlSchemaObject // TypeDefIndex: 7177
	{
		// Fields
		private string id; // 0x38
		private XmlSchemaObjectCollection items; // 0x40
		private XmlAttribute[] moreAttributes; // 0x48
	
		// Properties
		[XmlAttribute("id", DataType = "ID")]
		public string Id { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		[XmlElement("documentation", typeof(XmlSchemaDocumentation))]
		[XmlElement("appinfo", typeof(XmlSchemaAppInfo))]
		public XmlSchemaObjectCollection Items { get; } // 0x0000000180377940-0x0000000180377950 
		[XmlIgnore]
		internal override string IdAttribute { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	
		// Constructors
		public XmlSchemaAnnotation(); // 0x00000001819D76F0-0x00000001819D7760
	
		// Methods
		internal override void SetUnhandledAttributes(XmlAttribute[] moreAttributes); // 0x00000001803780C0-0x00000001803780D0
	}
}
