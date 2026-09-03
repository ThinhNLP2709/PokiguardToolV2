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
using System.Xml;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(2)]
	internal class XmlNodeWrapper : IXmlNode // TypeDefIndex: 10395
	{
		// Fields
		[Nullable(1)]
		private readonly XmlNode _node; // 0x10
		[Nullable(new byte[2] {2, 1 })]
		private List<IXmlNode> _childNodes; // 0x18
		[Nullable(new byte[2] {2, 1 })]
		private List<IXmlNode> _attributes; // 0x20
	
		// Properties
		public object WrappedNode { get; } // 0x0000000180377550-0x0000000180377560 
		public XmlNodeType NodeType { get; } // 0x00000001815019E0-0x0000000181501A10 
		public virtual string LocalName { get; } // 0x0000000181781A40-0x0000000181781A70 
		[Nullable(1)]
		public List<IXmlNode> ChildNodes { [NullableContext(1)] get; } // 0x0000000181781560-0x0000000181781950 
		protected virtual bool HasChildNodes { get; } // 0x0000000181781A10-0x0000000181781A40 
		[Nullable(1)]
		public List<IXmlNode> Attributes { [NullableContext(1)] get; } // 0x00000001817810F0-0x0000000181781560 
		private bool HasAttributes { get; } // 0x0000000181781950-0x0000000181781A10 
		public IXmlNode ParentNode { get; } // 0x0000000181781AA0-0x0000000181781B50 
		public string Value { get; set; } // 0x0000000181770170-0x00000001817701A0 0x0000000181781B50-0x0000000181781B80
		public string NamespaceUri { get; } // 0x0000000181781A70-0x0000000181781AA0 
	
		// Constructors
		[NullableContext(1)]
		public XmlNodeWrapper(XmlNode node); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		[NullableContext(1)]
		internal static IXmlNode WrapNode(XmlNode node); // 0x0000000181780F00-0x00000001817810F0
		[NullableContext(1)]
		public IXmlNode AppendChild(IXmlNode newChild); // 0x0000000181780E40-0x0000000181780F00
	}
}
