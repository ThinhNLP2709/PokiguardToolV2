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
	public interface IXmlNamespaceResolver // TypeDefIndex: 6853
	{
		// Methods
		IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope);
		string LookupNamespace(string prefix);
		string LookupPrefix(string namespaceName);
	}
}
