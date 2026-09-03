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
	[NullableContext(2)]
	internal interface IXmlNode // TypeDefIndex: 10400
	{
		// Properties
		XmlNodeType NodeType { get; }
		string LocalName { get; }
		[Nullable(1)]
		List<IXmlNode> ChildNodes { [NullableContext(1)] get; }
		[Nullable(1)]
		List<IXmlNode> Attributes { [NullableContext(1)] get; }
		IXmlNode ParentNode { get; }
		string Value { get; set; }
		string NamespaceUri { get; }
		object WrappedNode { get; }
	
		// Methods
		[NullableContext(1)]
		IXmlNode AppendChild(IXmlNode newChild);
	}
}
