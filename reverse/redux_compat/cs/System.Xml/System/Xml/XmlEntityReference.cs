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
	public class XmlEntityReference : XmlLinkedNode // TypeDefIndex: 6825
	{
		// Fields
		private string name; // 0x20
		private XmlLinkedNode lastChild; // 0x28
	
		// Properties
		public override string Name { get; } // 0x00000001802F8630-0x00000001802F8640 
		public override string LocalName { get; } // 0x00000001802F8630-0x00000001802F8640 
		public override string Value { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x0000000181A66210-0x0000000181A66270
		public override XmlNodeType NodeType { get; } // 0x0000000180A32630-0x0000000180A32640 
		public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal override bool IsContainer { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal override XmlLinkedNode LastNode { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public override string BaseURI { get; } // 0x0000000181A65FB0-0x0000000181A65FF0 
		internal string ChildBaseURI { get; } // 0x0000000181A65FF0-0x0000000181A66210 
	
		// Constructors
		protected internal XmlEntityReference(string name, XmlDocument doc); // 0x0000000181A65EA0-0x0000000181A65FB0
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A65A50-0x0000000181A65AA0
		internal override void SetParent(XmlNode node); // 0x0000000181A65B80-0x0000000181A65C40
		internal override void SetParentForLoad(XmlNode node); // 0x0000000181A65B60-0x0000000181A65B80
		internal override bool IsValidChildType(XmlNodeType type); // 0x0000000181A645B0-0x0000000181A64610
		public override void WriteTo(XmlWriter w); // 0x0000000181A65E60-0x0000000181A65EA0
		public override void WriteContentTo(XmlWriter w); // 0x0000000181A65C40-0x0000000181A65E60
		private string ConstructBaseURI(string baseURI, string systemId); // 0x0000000181A65AA0-0x0000000181A65B60
	}
}
