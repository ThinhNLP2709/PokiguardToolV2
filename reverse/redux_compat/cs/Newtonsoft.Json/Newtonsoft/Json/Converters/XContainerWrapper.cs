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
	internal class XContainerWrapper : XObjectWrapper // TypeDefIndex: 10407
	{
		// Fields
		[Nullable(new byte[2] {2, 1 })]
		private List<IXmlNode> _childNodes; // 0x18
	
		// Properties
		private XContainer Container { get; } // 0x0000000181777D10-0x0000000181777D80 
		public override List<IXmlNode> ChildNodes { get; } // 0x00000001817779C0-0x0000000181777D10 
		protected virtual bool HasChildNodes { get; } // 0x0000000181777D80-0x0000000181777E00 
		[Nullable(2)]
		public override IXmlNode ParentNode { [NullableContext(2)] get; } // 0x0000000181777E00-0x0000000181777EB0 
	
		// Constructors
		public XContainerWrapper(XContainer container); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal static IXmlNode WrapNode(XObject node); // 0x00000001817776D0-0x00000001817779C0
		public override IXmlNode AppendChild(IXmlNode newChild); // 0x00000001817775E0-0x00000001817776D0
	}
}
