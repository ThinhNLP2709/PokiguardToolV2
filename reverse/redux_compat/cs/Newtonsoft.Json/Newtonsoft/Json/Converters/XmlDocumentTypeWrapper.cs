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
	[NullableContext(2)]
	internal class XmlDocumentTypeWrapper : XmlNodeWrapper, IXmlDocumentType // TypeDefIndex: 10394
	{
		// Fields
		[Nullable(1)]
		private readonly XmlDocumentType _documentType; // 0x28
	
		// Properties
		[Nullable(1)]
		public string Name { [NullableContext(1)] get; } // 0x0000000180DFE6D0-0x0000000180DFE700 
		public string System { get; } // 0x0000000181779FA0-0x0000000181779FC0 
		public string Public { get; } // 0x0000000181779F80-0x0000000181779FA0 
		public string InternalSubset { get; } // 0x000000018177A020-0x000000018177A040 
		public override string LocalName { get; } // 0x000000018177A040-0x000000018177A070 
	
		// Constructors
		[NullableContext(1)]
		public XmlDocumentTypeWrapper(XmlDocumentType documentType); // 0x0000000181779F30-0x0000000181779F80
	}
}
