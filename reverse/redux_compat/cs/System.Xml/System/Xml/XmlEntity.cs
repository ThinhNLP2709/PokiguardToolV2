/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public class XmlEntity : XmlNode // TypeDefIndex: 6824
	{
		// Fields
		private string publicId; // 0x18
		private string systemId; // 0x20
		private string notationName; // 0x28
		private string name; // 0x30
		private string unparsedReplacementStr; // 0x38
		private string baseURI; // 0x40
		private XmlLinkedNode lastChild; // 0x48
		private bool childrenFoliating; // 0x50
	
		// Properties
		public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override string Name { get; } // 0x000000018031E110-0x000000018031E120 
		public override string LocalName { get; } // 0x000000018031E110-0x000000018031E120 
		public override string InnerText { get; set; } // 0x0000000181A65520-0x0000000181A65530 0x0000000181A664E0-0x0000000181A66540
		internal override bool IsContainer { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal override XmlLinkedNode LastNode { get; set; } // 0x0000000181A663E0-0x0000000181A664E0 0x00000001803780C0-0x00000001803780D0
		public override XmlNodeType NodeType { get; } // 0x0000000180A32610-0x0000000180A32620 
		public string SystemId { get; } // 0x00000001802F8630-0x00000001802F8640 
		public override string InnerXml { set; } // 0x0000000181A66540-0x0000000181A665A0
		public override string BaseURI { get; } // 0x0000000180377940-0x0000000180377950 
	
		// Constructors
		internal XmlEntity(string name, string strdata, string publicId, string systemId, string notationName, XmlDocument doc); // 0x0000000181A662F0-0x0000000181A663E0
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A66270-0x0000000181A662D0
		internal override bool IsValidChildType(XmlNodeType type); // 0x0000000181A662D0-0x0000000181A662F0
		public override void WriteTo(XmlWriter w); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteContentTo(XmlWriter w); // 0x00000001802E76C0-0x00000001802E76D0
		internal void SetBaseURI(string inBaseURI); // 0x0000000180378120-0x0000000180378130
	}
}
