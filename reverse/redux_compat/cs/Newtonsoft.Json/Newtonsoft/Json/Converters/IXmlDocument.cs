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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[NullableContext(1)]
	internal interface IXmlDocument : IXmlNode // TypeDefIndex: 10396
	{
		// Properties
		[Nullable(2)]
		IXmlElement DocumentElement { [NullableContext(2)] get; }
	
		// Methods
		IXmlNode CreateComment([Nullable(2)] string text);
		IXmlNode CreateTextNode([Nullable(2)] string text);
		IXmlNode CreateCDataSection([Nullable(2)] string data);
		IXmlNode CreateWhitespace([Nullable(2)] string text);
		IXmlNode CreateSignificantWhitespace([Nullable(2)] string text);
		IXmlNode CreateXmlDeclaration(string version, [Nullable(2)] string encoding, [Nullable(2)] string standalone);
		[NullableContext(2)]
		IXmlNode CreateXmlDocumentType([Nullable(1)] string name, string publicId, string systemId, string internalSubset);
		IXmlNode CreateProcessingInstruction(string target, string data);
		IXmlElement CreateElement(string elementName);
		IXmlElement CreateElement(string qualifiedName, string namespaceUri);
		IXmlNode CreateAttribute(string name, string value);
		IXmlNode CreateAttribute(string qualifiedName, string namespaceUri, string value);
	}
}
