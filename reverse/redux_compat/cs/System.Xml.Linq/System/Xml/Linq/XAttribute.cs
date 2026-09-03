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
	public class XAttribute : XObject // TypeDefIndex: 15380
	{
		// Fields
		internal XAttribute next; // 0x20
		internal XName name; // 0x28
		internal string value; // 0x30
	
		// Properties
		public bool IsNamespaceDeclaration { get; } // 0x0000000181957530-0x00000001819575C0 
		public XName Name { get; } // 0x000000018033D240-0x000000018033D250 
		public override XmlNodeType NodeType { get; } // 0x0000000180476390-0x00000001804763A0 
		public string Value { get; set; } // 0x000000018031E110-0x000000018031E120 0x00000001819575C0-0x00000001819576E0
	
		// Constructors
		public XAttribute(XName name, object value); // 0x0000000181957380-0x0000000181957490
		public XAttribute(XAttribute other); // 0x0000000181957490-0x0000000181957530
	
		// Methods
		public override string ToString(); // 0x0000000181956C20-0x0000000181956FD0
		internal string GetPrefixOfNamespace(XNamespace ns); // 0x0000000181956AF0-0x0000000181956C20
		private static void ValidateAttribute(XName name, string value); // 0x0000000181956FD0-0x0000000181957380
	}
}
