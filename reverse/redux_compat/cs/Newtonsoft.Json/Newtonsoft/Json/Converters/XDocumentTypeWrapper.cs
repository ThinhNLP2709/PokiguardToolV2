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
using System.Xml.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(2)]
	internal class XDocumentTypeWrapper : XObjectWrapper, IXmlDocumentType // TypeDefIndex: 10402
	{
		// Fields
		[Nullable(1)]
		private readonly XDocumentType _documentType; // 0x18
	
		// Properties
		[Nullable(1)]
		public string Name { [NullableContext(1)] get; } // 0x0000000181778050-0x0000000181778070 
		public string System { get; } // 0x0000000181778090-0x00000001817780B0 
		public string Public { get; } // 0x0000000181778070-0x0000000181778090 
		public string InternalSubset { get; } // 0x0000000181778000-0x0000000181778020 
		public override string LocalName { get; } // 0x0000000181778020-0x0000000181778050 
	
		// Constructors
		[NullableContext(1)]
		public XDocumentTypeWrapper(XDocumentType documentType); // 0x0000000181777FB0-0x0000000181778000
	}
}
