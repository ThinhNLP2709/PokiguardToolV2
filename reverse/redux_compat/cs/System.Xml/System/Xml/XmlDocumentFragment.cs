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
	public class XmlDocumentFragment : XmlNode // TypeDefIndex: 6821
	{
		// Fields
		private XmlLinkedNode lastChild; // 0x18
	
		// Properties
		public override string Name { get; } // 0x0000000181A5E7B0-0x0000000181A5E7E0 
		public override string LocalName { get; } // 0x0000000181A5E7B0-0x0000000181A5E7E0 
		public override XmlNodeType NodeType { get; } // 0x00000001815FDA60-0x00000001815FDA70 
		public override XmlNode ParentNode { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override XmlDocument OwnerDocument { get; } // 0x0000000181A5E7E0-0x0000000181A5E850 
		public override string InnerXml { set; } // 0x0000000181A5E850-0x0000000181A5E8F0
		internal override bool IsContainer { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal override XmlLinkedNode LastNode { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Constructors
		protected internal XmlDocumentFragment(XmlDocument ownerDocument); // 0x0000000181A5E720-0x0000000181A5E7B0
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A5E380-0x0000000181A5E420
		internal override bool IsValidChildType(XmlNodeType type); // 0x0000000181A5E420-0x0000000181A5E4E0
		internal override bool CanInsertAfter(XmlNode newChild, XmlNode refChild); // 0x0000000181A5E280-0x0000000181A5E300
		internal override bool CanInsertBefore(XmlNode newChild, XmlNode refChild); // 0x0000000181A5E300-0x0000000181A5E380
		public override void WriteTo(XmlWriter w); // 0x0000000181A5E700-0x0000000181A5E720
		public override void WriteContentTo(XmlWriter w); // 0x0000000181A5E4E0-0x0000000181A5E700
	}
}
