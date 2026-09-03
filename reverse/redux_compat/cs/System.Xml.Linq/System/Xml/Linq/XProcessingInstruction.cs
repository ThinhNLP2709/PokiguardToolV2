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
	public class XProcessingInstruction : XNode // TypeDefIndex: 15408
	{
		// Fields
		internal string target; // 0x28
		internal string data; // 0x30
	
		// Properties
		public string Data { get; set; } // 0x000000018031E110-0x000000018031E120 0x000000018195F0E0-0x000000018195F1F0
		public override XmlNodeType NodeType { get; } // 0x0000000180A2FB20-0x0000000180A2FB30 
		public string Target { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Constructors
		public XProcessingInstruction(string target, string data); // 0x000000018195EEE0-0x000000018195F040
		public XProcessingInstruction(XProcessingInstruction other); // 0x000000018195F040-0x000000018195F0E0
	
		// Methods
		public override void WriteTo(XmlWriter writer); // 0x000000018195EE50-0x000000018195EEE0
		internal override XNode CloneNode(); // 0x000000018195ECB0-0x000000018195ED70
		private static void ValidateName(string name); // 0x000000018195ED70-0x000000018195EE50
	}
}
