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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	internal class XmlAsyncCheckReaderWithLineInfoNS : XmlAsyncCheckReaderWithLineInfo, IXmlNamespaceResolver // TypeDefIndex: 6741
	{
		// Fields
		private readonly IXmlNamespaceResolver readerAsIXmlNamespaceResolver; // 0x28
	
		// Constructors
		public XmlAsyncCheckReaderWithLineInfoNS(XmlReader reader); // 0x0000000181A37190-0x0000000181A37240
	
		// Methods
		IDictionary<string, string> IXmlNamespaceResolver.GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181A37070-0x0000000181A370D0
		string IXmlNamespaceResolver.LookupNamespace(string prefix); // 0x0000000181A370D0-0x0000000181A37130
		string IXmlNamespaceResolver.LookupPrefix(string namespaceName); // 0x0000000181A37130-0x0000000181A37190
	}
}
