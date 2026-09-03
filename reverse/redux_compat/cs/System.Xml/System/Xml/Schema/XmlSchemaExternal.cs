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
	public abstract class XmlSchemaExternal : XmlSchemaObject // TypeDefIndex: 7202
	{
		// Fields
		private string location; // 0x38
		private Uri baseUri; // 0x40
		private XmlSchema schema; // 0x48
		private string id; // 0x50
		private XmlAttribute[] moreAttributes; // 0x58
		private Compositor compositor; // 0x60
	
		// Properties
		[XmlAttribute("schemaLocation", DataType = "anyURI")]
		public string SchemaLocation { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		[XmlIgnore]
		public XmlSchema Schema { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		[XmlAttribute("id", DataType = "ID")]
		public string Id { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		[XmlIgnore]
		internal Uri BaseUri { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		[XmlIgnore]
		internal override string IdAttribute { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		internal Compositor Compositor { get; set; } // 0x000000018150C180-0x000000018150C190 0x000000018041DC00-0x000000018041DC10
	
		// Constructors
		protected XmlSchemaExternal(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal override void SetUnhandledAttributes(XmlAttribute[] moreAttributes); // 0x00000001802F4050-0x00000001802F4060
	}
}
