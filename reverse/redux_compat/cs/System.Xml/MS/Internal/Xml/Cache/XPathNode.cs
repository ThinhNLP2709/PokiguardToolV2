/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.XPath;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace MS.Internal.Xml.Cache
{
	internal struct XPathNode // TypeDefIndex: 7315
	{
		// Fields
		private XPathNodeInfoAtom _info; // 0x00
		private ushort _idxSibling; // 0x08
		private ushort _idxParent; // 0x0A
		private ushort _idxSimilar; // 0x0C
		private ushort _posOffset; // 0x0E
		private uint _props; // 0x10
		private string _value; // 0x18
	
		// Properties
		public XPathNodeType NodeType { get; } // 0x0000000181A23ED0-0x0000000181A23EE0 
		public string Prefix { get; } // 0x0000000181A23F00-0x0000000181A23F20 
		public string LocalName { get; } // 0x0000000181433720-0x0000000181433740 
		public string NamespaceUri { get; } // 0x0000000181A23EB0-0x0000000181A23ED0 
		public XPathDocument Document { get; } // 0x0000000181A23D50-0x0000000181A23D70 
		public int LineNumber { get; } // 0x0000000181A23E60-0x0000000181A23E90 
		public int LinePosition { get; } // 0x0000000181A23E90-0x0000000181A23EB0 
		public int CollapsedLinePosition { get; } // 0x0000000181A23D20-0x0000000181A23D50 
		public XPathNodePageInfo PageInfo { get; } // 0x0000000181A23EE0-0x0000000181A23F00 
		public bool IsXmlNamespaceNode { get; } // 0x0000000181A23DF0-0x0000000181A23E60 
		public bool HasSibling { get; } // 0x0000000181A23D90-0x0000000181A23DA0 
		public bool HasCollapsedText { get; } // 0x0000000181A23D70-0x0000000181A23D80 
		public bool IsText { get; } // 0x0000000181A23DA0-0x0000000181A23DF0 
		public bool HasNamespaceDecls { get; } // 0x0000000181A23D80-0x0000000181A23D90 
		public string Value { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Methods
		public int GetParent(out XPathNode[] pageNode); // 0x0000000181A23CA0-0x0000000181A23CE0
		public int GetSibling(out XPathNode[] pageNode); // 0x0000000181A23CE0-0x0000000181A23D20
	}
}
