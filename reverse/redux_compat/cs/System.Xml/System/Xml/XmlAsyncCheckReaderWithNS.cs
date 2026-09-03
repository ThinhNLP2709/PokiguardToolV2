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
	internal class XmlAsyncCheckReaderWithNS : XmlAsyncCheckReader, IXmlNamespaceResolver // TypeDefIndex: 6739
	{
		// Fields
		private readonly IXmlNamespaceResolver readerAsIXmlNamespaceResolver; // 0x20
	
		// Constructors
		public XmlAsyncCheckReaderWithNS(XmlReader reader); // 0x0000000181A37500-0x0000000181A375B0
	
		// Methods
		IDictionary<string, string> IXmlNamespaceResolver.GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181A373E0-0x0000000181A37440
		string IXmlNamespaceResolver.LookupNamespace(string prefix); // 0x0000000181A37440-0x0000000181A374A0
		string IXmlNamespaceResolver.LookupPrefix(string namespaceName); // 0x0000000181A374A0-0x0000000181A37500
	}
}
