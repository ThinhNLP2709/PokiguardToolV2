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
	public class XDocument : XContainer // TypeDefIndex: 15387
	{
		// Fields
		private XDeclaration _declaration; // 0x30
	
		// Properties
		public XDeclaration Declaration { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public override XmlNodeType NodeType { get; } // 0x00000001815FCAC0-0x00000001815FCAD0 
		public XElement Root { get; } // 0x000000018195AF70-0x000000018195AFB0 
	
		// Constructors
		public XDocument(); // 0x00000001802E5CB0-0x00000001802E5CC0
		public XDocument(XDocument other); // 0x000000018195AEA0-0x000000018195AF70
	
		// Methods
		public override void WriteTo(XmlWriter writer); // 0x000000018195AD50-0x000000018195AEA0
		internal override void AddAttribute(XAttribute a); // 0x000000018195A760-0x000000018195A7B0
		internal override void AddAttributeSkipNotify(XAttribute a); // 0x000000018195A710-0x000000018195A760
		internal override XNode CloneNode(); // 0x000000018195A7B0-0x000000018195A8A0
		private T GetFirstNode<T>()
			where T : XNode;
		internal static bool IsWhitespace(string s); // 0x000000018195A8A0-0x000000018195A920
		internal override void ValidateNode(XNode node, XNode previous); // 0x000000018195AA60-0x000000018195AC90
		private void ValidateDocument(XNode previous, XmlNodeType allowBefore, XmlNodeType allowAfter); // 0x000000018195A920-0x000000018195AA60
		internal override void ValidateString(string s); // 0x000000018195AC90-0x000000018195AD50
	}
}
