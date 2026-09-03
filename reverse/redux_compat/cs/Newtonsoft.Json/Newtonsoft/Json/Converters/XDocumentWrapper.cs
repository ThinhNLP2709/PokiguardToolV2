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
	internal class XDocumentWrapper : XContainerWrapper, IXmlDocument // TypeDefIndex: 10403
	{
		// Properties
		private XDocument Document { get; } // 0x0000000181778BB0-0x0000000181778C20 
		public override List<IXmlNode> ChildNodes { get; } // 0x0000000181778930-0x0000000181778AB0 
		protected override bool HasChildNodes { get; } // 0x0000000181778C20-0x0000000181778CC0 
		[Nullable(2)]
		public IXmlElement DocumentElement { [NullableContext(2)] get; } // 0x0000000181778AB0-0x0000000181778BB0 
	
		// Constructors
		public XDocumentWrapper(XDocument document); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public IXmlNode CreateComment([Nullable(2)] string text); // 0x0000000181778360-0x00000001817783F0
		public IXmlNode CreateTextNode([Nullable(2)] string text); // 0x0000000181778670-0x0000000181778700
		public IXmlNode CreateCDataSection([Nullable(2)] string data); // 0x00000001817782D0-0x0000000181778360
		public IXmlNode CreateWhitespace([Nullable(2)] string text); // 0x0000000181778700-0x0000000181778790
		public IXmlNode CreateSignificantWhitespace([Nullable(2)] string text); // 0x00000001817785E0-0x0000000181778670
		public IXmlNode CreateXmlDeclaration(string version, [Nullable(2)] string encoding, [Nullable(2)] string standalone); // 0x0000000181778790-0x0000000181778860
		[NullableContext(2)]
		public IXmlNode CreateXmlDocumentType([Nullable(1)] string name, string publicId, string systemId, string internalSubset); // 0x0000000181778860-0x0000000181778930
		public IXmlNode CreateProcessingInstruction(string target, string data); // 0x0000000181778540-0x00000001817785E0
		public IXmlElement CreateElement(string elementName); // 0x00000001817783F0-0x0000000181778490
		public IXmlElement CreateElement(string qualifiedName, string namespaceUri); // 0x0000000181778490-0x0000000181778540
		public IXmlNode CreateAttribute(string name, string value); // 0x0000000181778160-0x0000000181778210
		public IXmlNode CreateAttribute(string qualifiedName, string namespaceUri, string value); // 0x0000000181778210-0x00000001817782D0
		public override IXmlNode AppendChild(IXmlNode newChild); // 0x00000001817780B0-0x0000000181778160
	}
}
