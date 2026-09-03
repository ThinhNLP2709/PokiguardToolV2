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
	public class XmlCDataSection : XmlCharacterData // TypeDefIndex: 6814
	{
		// Properties
		public override string Name { get; } // 0x0000000181A5D230-0x0000000181A5D260 
		public override string LocalName { get; } // 0x0000000181A5D230-0x0000000181A5D260 
		public override XmlNodeType NodeType { get; } // 0x00000001804CB980-0x00000001804CB990 
		public override XmlNode ParentNode { get; } // 0x0000000181A5D260-0x0000000181A5D300 
		internal override bool IsText { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		protected internal XmlCDataSection(string data, XmlDocument doc); // 0x0000000181A5D1E0-0x0000000181A5D230
	
		// Methods
		public override XmlNode CloneNode(bool deep); // 0x0000000181A5D120-0x0000000181A5D190
		public override void WriteTo(XmlWriter w); // 0x0000000181A5D190-0x0000000181A5D1E0
		public override void WriteContentTo(XmlWriter w); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
