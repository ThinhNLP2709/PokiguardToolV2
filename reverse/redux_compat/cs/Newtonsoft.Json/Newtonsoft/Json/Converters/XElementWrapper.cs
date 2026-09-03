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
using System.Runtime.Versioning;
using System.Xml.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class XElementWrapper : XContainerWrapper, IXmlElement // TypeDefIndex: 10410
	{
		// Fields
		[Nullable(new byte[2] {2, 1 })]
		private List<IXmlNode> _attributes; // 0x20
	
		// Properties
		private XElement Element { get; } // 0x0000000181779660-0x00000001817796D0 
		public override List<IXmlNode> Attributes { get; } // 0x00000001817791F0-0x0000000181779660 
		[Nullable(2)]
		public override string Value { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x0000000181779850-0x00000001817798D0 0x00000001817798D0-0x0000000181779980
		[Nullable(2)]
		public override string LocalName { [NullableContext(2)] get; } // 0x0000000181779750-0x00000001817797D0 
		[Nullable(2)]
		public override string NamespaceUri { [NullableContext(2)] get; } // 0x00000001817797D0-0x0000000181779850 
		public bool IsEmpty { get; } // 0x00000001817796D0-0x0000000181779750 
	
		// Constructors
		public XElementWrapper(XElement element); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public void SetAttributeNode(IXmlNode attribute); // 0x00000001817790F0-0x00000001817791F0
		private bool HasImplicitNamespaceAttribute(string namespaceUri); // 0x0000000181778DA0-0x00000001817790F0
		public override IXmlNode AppendChild(IXmlNode newChild); // 0x0000000181778CC0-0x0000000181778D00
		public string GetPrefixOfNamespace(string namespaceUri); // 0x0000000181778D00-0x0000000181778DA0
	}
}
