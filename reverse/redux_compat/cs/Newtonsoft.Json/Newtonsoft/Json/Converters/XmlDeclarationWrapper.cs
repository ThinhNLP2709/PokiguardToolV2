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
	internal class XmlDeclarationWrapper : XmlNodeWrapper, IXmlDeclaration // TypeDefIndex: 10393
	{
		// Fields
		[Nullable(1)]
		private readonly XmlDeclaration _declaration; // 0x28
	
		// Properties
		public string Version { get; } // 0x0000000181779FC0-0x0000000181779FE0 
		public string Encoding { get; set; } // 0x0000000181779F80-0x0000000181779FA0 0x0000000181779FE0-0x000000018177A000
		public string Standalone { get; set; } // 0x0000000181779FA0-0x0000000181779FC0 0x000000018177A000-0x000000018177A020
	
		// Constructors
		[NullableContext(1)]
		public XmlDeclarationWrapper(XmlDeclaration declaration); // 0x0000000181779F30-0x0000000181779F80
	}
}
