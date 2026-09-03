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
	public class XmlDeclaration : XmlLinkedNode // TypeDefIndex: 6819
	{
		// Fields
		private string version; // 0x20
		private string encoding; // 0x28
		private string standalone; // 0x30
	
		// Properties
		public string Version { get; internal set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public string Encoding { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181A5DE20-0x0000000181A5DE60
		public string Standalone { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000181A5E140-0x0000000181A5E280
		public override string Value { get; set; } // 0x0000000181A5CE10-0x0000000181A5CE30 0x0000000181A5D100-0x0000000181A5D120
		public override string InnerText { get; set; } // 0x0000000181A5DCA0-0x0000000181A5DDF0 0x0000000181A5DE60-0x0000000181A5E140
		public override string Name { get; } // 0x0000000181A5DDF0-0x0000000181A5DE20 
		public override string LocalName { get; } // 0x0000000181884190-0x00000001818841B0 
		public override XmlNodeType NodeType { get; } // 0x0000000181777F20-0x0000000181777F30 
	
		// Constructors
		protected internal XmlDeclaration(string version, string encoding, string standalone, XmlDocument doc); // 0x0000000181A5DA50-0x0000000181A5DCA0
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A5D900-0x0000000181A5D960
		public override void WriteTo(XmlWriter w); // 0x0000000181A5D9D0-0x0000000181A5DA50
		public override void WriteContentTo(XmlWriter w); // 0x00000001802E76C0-0x00000001802E76D0
		private bool IsValidXmlVersion(string ver); // 0x0000000181A5D960-0x0000000181A5D9D0
	}
}
