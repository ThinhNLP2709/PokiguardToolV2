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
	internal class XmlDocumentWrapper : XmlNodeWrapper, IXmlDocument // TypeDefIndex: 10391
	{
		// Fields
		private readonly XmlDocument _document; // 0x28
	
		// Properties
		[Nullable(2)]
		public IXmlElement DocumentElement { [NullableContext(2)] get; } // 0x000000018177A820-0x000000018177A8D0 
	
		// Constructors
		public XmlDocumentWrapper(XmlDocument document); // 0x0000000181779F30-0x0000000181779F80
	
		// Methods
		public IXmlNode CreateComment([Nullable(2)] string data); // 0x000000018177A270-0x000000018177A300
		public IXmlNode CreateTextNode([Nullable(2)] string text); // 0x000000018177A560-0x000000018177A5F0
		public IXmlNode CreateCDataSection([Nullable(2)] string data); // 0x000000018177A1E0-0x000000018177A270
		public IXmlNode CreateWhitespace([Nullable(2)] string text); // 0x000000018177A5F0-0x000000018177A680
		public IXmlNode CreateSignificantWhitespace([Nullable(2)] string text); // 0x000000018177A4D0-0x000000018177A560
		public IXmlNode CreateXmlDeclaration(string version, [Nullable(2)] string encoding, [Nullable(2)] string standalone); // 0x000000018177A680-0x000000018177A750
		[NullableContext(2)]
		public IXmlNode CreateXmlDocumentType([Nullable(1)] string name, string publicId, string systemId, string internalSubset); // 0x000000018177A750-0x000000018177A820
		public IXmlNode CreateProcessingInstruction(string target, string data); // 0x000000018177A430-0x000000018177A4D0
		public IXmlElement CreateElement(string elementName); // 0x000000018177A300-0x000000018177A390
		public IXmlElement CreateElement(string qualifiedName, string namespaceUri); // 0x000000018177A390-0x000000018177A430
		public IXmlNode CreateAttribute(string name, [Nullable(2)] string value); // 0x000000018177A070-0x000000018177A120
		public IXmlNode CreateAttribute(string qualifiedName, [Nullable(2)] string namespaceUri, [Nullable(2)] string value); // 0x000000018177A120-0x000000018177A1E0
	}
}
