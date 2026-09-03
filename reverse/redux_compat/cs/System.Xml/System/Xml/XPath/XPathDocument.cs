/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using MS.Internal.Xml.Cache;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.XPath
{
	public class XPathDocument // TypeDefIndex: 6902
	{
		// Fields
		private XPathNode[] pageXmlNmsp; // 0x10
		private int idxXmlNmsp; // 0x18
		private XmlNameTable nameTable; // 0x20
		private bool hasLineInfo; // 0x28
		private Dictionary<XPathNodeRef, XPathNodeRef> mapNmsp; // 0x30
	
		// Properties
		internal XmlNameTable NameTable { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal bool HasLineInfo { get; } // 0x0000000180327270-0x0000000180327280 
	
		// Methods
		internal int GetXmlNamespaceNode(out XPathNode[] pageXmlNmsp); // 0x0000000181A96710-0x0000000181A96740
		internal int LookupNamespaces(XPathNode[] pageElem, int idxElem, out XPathNode[] pageNmsp); // 0x0000000181A96740-0x0000000181A96850
	}
}
