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
	public class XmlProcessingInstruction : XmlLinkedNode // TypeDefIndex: 6843
	{
		// Fields
		private string target; // 0x20
		private string data; // 0x28
	
		// Properties
		public override string Name { get; } // 0x0000000181A5D340-0x0000000181A5D360 
		public override string LocalName { get; } // 0x0000000181884190-0x00000001818841B0 
		public override string Value { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181A8B150-0x0000000181A8B160
		public string Data { set; } // 0x0000000181A8B070-0x0000000181A8B150
		public override string InnerText { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181A8B150-0x0000000181A8B160
		public override XmlNodeType NodeType { get; } // 0x0000000180A2FB20-0x0000000180A2FB30 
	
		// Constructors
		protected internal XmlProcessingInstruction(string target, string data, XmlDocument doc); // 0x0000000181A8B010-0x0000000181A8B070
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A8AF80-0x0000000181A8AFD0
		public override void WriteTo(XmlWriter w); // 0x0000000181A8AFD0-0x0000000181A8B010
		public override void WriteContentTo(XmlWriter w); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
