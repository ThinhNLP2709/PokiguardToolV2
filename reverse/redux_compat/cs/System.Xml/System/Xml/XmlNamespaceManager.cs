/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml
{
	public class XmlNamespaceManager : IXmlNamespaceResolver, IEnumerable // TypeDefIndex: 6892
	{
		// Fields
		private NamespaceDeclaration[] nsdecls; // 0x10
		private int lastDecl; // 0x18
		private XmlNameTable nameTable; // 0x20
		private int scopeId; // 0x28
		private Dictionary<string, int> hashTable; // 0x30
		private bool useHashtable; // 0x38
		private string xml; // 0x40
		private string xmlNs; // 0x48
	
		// Properties
		public virtual XmlNameTable NameTable { get; } // 0x00000001802F8630-0x00000001802F8640 
		public virtual string DefaultNamespace { get; } // 0x0000000181AA5360-0x0000000181AA53B0 
	
		// Nested types
		private struct NamespaceDeclaration // TypeDefIndex: 6893
		{
			// Fields
			public string prefix; // 0x00
			public string uri; // 0x08
			public int scopeId; // 0x10
			public int previousNsIndex; // 0x14
	
			// Methods
			public void Set(string prefix, string uri, int scopeId, int previousNsIndex); // 0x0000000181A8C3E0-0x0000000181A8C430
		}
	
		// Constructors
		internal XmlNamespaceManager(); // 0x00000001802E5CB0-0x00000001802E5CC0
		public XmlNamespaceManager(XmlNameTable nameTable); // 0x0000000181AA50F0-0x0000000181AA5360
	
		// Methods
		public virtual void PushScope(); // 0x00000001806FE3B0-0x00000001806FE3C0
		public virtual bool PopScope(); // 0x0000000181AA4E60-0x0000000181AA4F50
		public virtual void AddNamespace(string prefix, string uri); // 0x0000000181AA4400-0x0000000181AA4860
		public virtual void RemoveNamespace(string prefix, string uri); // 0x0000000181AA4F50-0x0000000181AA50F0
		public virtual IEnumerator GetEnumerator(); // 0x0000000181AA4860-0x0000000181AA49B0
		public virtual IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181AA49B0-0x0000000181AA4B60
		public virtual string LookupNamespace(string prefix); // 0x0000000181AA4D30-0x0000000181AA4D80
		private int LookupNamespaceDecl(string prefix); // 0x0000000181AA4B60-0x0000000181AA4D30
		public virtual string LookupPrefix(string uri); // 0x0000000181AA4D80-0x0000000181AA4E60
	}
}
