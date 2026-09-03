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
using System.Xml.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(2)]
	internal class XObjectWrapper : IXmlNode // TypeDefIndex: 10408
	{
		// Fields
		private readonly XObject _xmlObject; // 0x10
	
		// Properties
		public object WrappedNode { get; } // 0x0000000180377550-0x0000000180377560 
		public virtual XmlNodeType NodeType { get; } // 0x0000000181779A60-0x0000000181779A80 
		public virtual string LocalName { get; } // 0x00000001802E7860-0x00000001802E7870 
		[Nullable(1)]
		public virtual List<IXmlNode> ChildNodes { [NullableContext(1)] get; } // 0x0000000181779A10-0x0000000181779A60 
		[Nullable(1)]
		public virtual List<IXmlNode> Attributes { [NullableContext(1)] get; } // 0x00000001817799C0-0x0000000181779A10 
		public virtual IXmlNode ParentNode { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual string Value { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x0000000181779A80-0x0000000181779AC0
		public virtual string NamespaceUri { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public XObjectWrapper(XObject xmlObject); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		[NullableContext(1)]
		public virtual IXmlNode AppendChild(IXmlNode newChild); // 0x0000000181779980-0x00000001817799C0
	}
}
