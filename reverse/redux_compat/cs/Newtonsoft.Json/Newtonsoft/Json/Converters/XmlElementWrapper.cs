/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
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
	[NullableContext(1)]
	internal class XmlElementWrapper : XmlNodeWrapper, IXmlElement // TypeDefIndex: 10392
	{
		// Fields
		private readonly XmlElement _element; // 0x28
	
		// Properties
		public bool IsEmpty { get; } // 0x000000018177A9F0-0x000000018177AA10 
	
		// Constructors
		public XmlElementWrapper(XmlElement element); // 0x0000000181779F30-0x0000000181779F80
	
		// Methods
		public void SetAttributeNode(IXmlNode attribute); // 0x000000018177A900-0x000000018177A9F0
		public string GetPrefixOfNamespace(string namespaceUri); // 0x000000018177A8D0-0x000000018177A900
	}
}
