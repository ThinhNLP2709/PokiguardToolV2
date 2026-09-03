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
	internal sealed class XPathNodeInfoAtom // TypeDefIndex: 7319
	{
		// Fields
		private string _localName; // 0x10
		private string _namespaceUri; // 0x18
		private string _prefix; // 0x20
		private XPathNode[] _pageParent; // 0x28
		private XPathNode[] _pageSibling; // 0x30
		private XPathDocument _doc; // 0x38
		private int _lineNumBase; // 0x40
		private int _linePosBase; // 0x44
		private XPathNodePageInfo _pageInfo; // 0x48
	
		// Properties
		public XPathNodePageInfo PageInfo { get; } // 0x00000001803272B0-0x00000001803272C0 
		public string LocalName { get; } // 0x0000000180377550-0x0000000180377560 
		public string NamespaceUri { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public string Prefix { get; } // 0x00000001802F8630-0x00000001802F8640 
		public XPathNode[] SiblingPage { get; } // 0x000000018031E110-0x000000018031E120 
		public XPathNode[] ParentPage { get; } // 0x000000018033D240-0x000000018033D250 
		public XPathDocument Document { get; } // 0x00000001803272A0-0x00000001803272B0 
		public int LineNumberBase { get; } // 0x000000018033D790-0x000000018033D7A0 
		public int LinePositionBase { get; } // 0x000000018033D780-0x000000018033D790 
	}
}
