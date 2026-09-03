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
using System.Xml.XPath;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace MS.Internal.Xml.Cache
{
	internal sealed class XPathDocumentNavigator : XPathNavigator, IXmlLineInfo // TypeDefIndex: 7314
	{
		// Fields
		private XPathNode[] _pageCurrent; // 0x10
		private XPathNode[] _pageParent; // 0x18
		private int _idxCurrent; // 0x20
		private int _idxParent; // 0x24
	
		// Properties
		public override string Value { get; } // 0x0000000181A23400-0x0000000181A236B0 
		public override XPathNodeType NodeType { get; } // 0x0000000181A23360-0x0000000181A233A0 
		public override string LocalName { get; } // 0x0000000181A23290-0x0000000181A232D0 
		public override string NamespaceURI { get; } // 0x0000000181A23320-0x0000000181A23360 
		public override string Prefix { get; } // 0x0000000181A233A0-0x0000000181A233E0 
		public override XmlNameTable NameTable { get; } // 0x0000000181A232D0-0x0000000181A23320 
		public override object UnderlyingObject { get; } // 0x0000000181A233E0-0x0000000181A23400 
		public int LineNumber { get; } // 0x0000000181A23170-0x0000000181A231F0 
		public int LinePosition { get; } // 0x0000000181A231F0-0x0000000181A23290 
	
		// Constructors
		public XPathDocumentNavigator(XPathNode[] pageCurrent, int idxCurrent, XPathNode[] pageParent, int idxParent); // 0x0000000181A230D0-0x0000000181A23170
	
		// Methods
		public override XPathNavigator Clone(); // 0x0000000181A22990-0x0000000181A22A70
		public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope); // 0x0000000181A22B60-0x0000000181A22E10
		public override bool MoveToNextNamespace(XPathNamespaceScope scope); // 0x0000000181A22E10-0x0000000181A22FE0
		public override bool MoveToParent(); // 0x0000000181A22FE0-0x0000000181A230D0
		public override bool IsSamePosition(XPathNavigator other); // 0x0000000181A22AD0-0x0000000181A22B60
		public bool HasLineInfo(); // 0x0000000181A22A80-0x0000000181A22AD0
		public int GetPositionHashCode(); // 0x0000000181A22A70-0x0000000181A22A80
	}
}
