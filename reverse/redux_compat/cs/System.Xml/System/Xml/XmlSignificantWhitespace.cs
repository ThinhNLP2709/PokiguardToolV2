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
	public class XmlSignificantWhitespace : XmlCharacterData // TypeDefIndex: 6844
	{
		// Properties
		public override string Name { get; } // 0x0000000181A8B2D0-0x0000000181A8B300 
		public override string LocalName { get; } // 0x0000000181A8B2D0-0x0000000181A8B300 
		public override XmlNodeType NodeType { get; } // 0x0000000180A2FD00-0x0000000180A2FD10 
		public override XmlNode ParentNode { get; } // 0x0000000181A8B300-0x0000000181A8B3B0 
		public override string Value { get; set; } // 0x00000001816251D0-0x00000001816251F0 0x0000000181A8B3B0-0x0000000181A8B450
		internal override bool IsText { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		protected internal XmlSignificantWhitespace(string strData, XmlDocument doc); // 0x0000000181A8B220-0x0000000181A8B2D0
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A8B160-0x0000000181A8B1D0
		public override void WriteTo(XmlWriter w); // 0x0000000181A8B1D0-0x0000000181A8B220
		public override void WriteContentTo(XmlWriter w); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
