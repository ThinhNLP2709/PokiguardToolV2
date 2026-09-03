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

// Image 47: System.Xml.Linq.dll - Assembly: System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 - Types 15375-15412

namespace System.Xml.Linq
{
	public class XComment : XNode // TypeDefIndex: 15382
	{
		// Fields
		internal string value; // 0x28
	
		// Properties
		public override XmlNodeType NodeType { get; } // 0x0000000180740830-0x0000000180740840 
		public string Value { get; set; } // 0x000000018033D240-0x000000018033D250 0x0000000181957B40-0x0000000181957C50
	
		// Constructors
		public XComment(string value); // 0x0000000181957AC0-0x0000000181957B40
		public XComment(XComment other); // 0x0000000181957A40-0x0000000181957AC0
	
		// Methods
		public override void WriteTo(XmlWriter writer); // 0x00000001819579C0-0x0000000181957A40
		internal override XNode CloneNode(); // 0x0000000181957910-0x00000001819579C0
	}
}
