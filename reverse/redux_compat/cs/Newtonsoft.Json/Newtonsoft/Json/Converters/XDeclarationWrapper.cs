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
using System.Xml.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(2)]
	internal class XDeclarationWrapper : XObjectWrapper, IXmlDeclaration // TypeDefIndex: 10401
	{
		// Fields
		[CompilerGenerated]
		[Nullable(1)]
		private readonly XDeclaration _Declaration_k__BackingField; // 0x18
	
		// Properties
		[Nullable(1)]
		internal XDeclaration Declaration { [NullableContext(1)] [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public override XmlNodeType NodeType { get; } // 0x0000000181777F20-0x0000000181777F30 
		public string Version { get; } // 0x0000000181777F30-0x0000000181777F50 
		public string Encoding { get; set; } // 0x0000000181777F00-0x0000000181777F20 0x0000000181777F50-0x0000000181777F80
		public string Standalone { get; set; } // 0x0000000180E6D010-0x0000000180E6D030 0x0000000181777F80-0x0000000181777FB0
	
		// Constructors
		[NullableContext(1)]
		public XDeclarationWrapper(XDeclaration declaration); // 0x0000000181777EB0-0x0000000181777F00
	}
}
