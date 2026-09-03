/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

// Image 47: System.Xml.Linq.dll - Assembly: System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 - Types 15375-15412

namespace System.Xml.Linq
{
	public class XText : XNode // TypeDefIndex: 15410
	{
		// Fields
		internal string text; // 0x28
	
		// Properties
		public override XmlNodeType NodeType { get; } // 0x000000018071E4A0-0x000000018071E4B0 
		public string Value { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018195F3C0-0x000000018195F4D0
	
		// Constructors
		public XText(string value); // 0x0000000181957810-0x0000000181957890
		public XText(XText other); // 0x0000000181957890-0x0000000181957910
	
		// Methods
		public override void WriteTo(XmlWriter writer); // 0x000000018195F2D0-0x000000018195F3C0
		internal override void AppendText(StringBuilder sb); // 0x000000018195F1F0-0x000000018195F220
		internal override XNode CloneNode(); // 0x000000018195F220-0x000000018195F2D0
	}
}
