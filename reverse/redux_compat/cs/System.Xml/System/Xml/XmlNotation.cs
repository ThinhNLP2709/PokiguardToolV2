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
	public class XmlNotation : XmlNode // TypeDefIndex: 6842
	{
		// Fields
		private string publicId; // 0x18
		private string systemId; // 0x20
		private string name; // 0x28
	
		// Properties
		public override string Name { get; } // 0x000000018033D240-0x000000018033D250 
		public override string LocalName { get; } // 0x000000018033D240-0x000000018033D250 
		public override XmlNodeType NodeType { get; } // 0x0000000180740840-0x0000000180740850 
		public override bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public override string InnerXml { set; } // 0x0000000181A8AF20-0x0000000181A8AF80
	
		// Constructors
		internal XmlNotation(string name, string publicId, string systemId, XmlDocument doc); // 0x0000000181A8AE00-0x0000000181A8AF20
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A8ADA0-0x0000000181A8AE00
		public override void WriteTo(XmlWriter w); // 0x00000001802E76C0-0x00000001802E76D0
		public override void WriteContentTo(XmlWriter w); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
