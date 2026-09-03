/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	public class XmlSerializerNamespaces // TypeDefIndex: 6911
	{
		// Fields
		private Hashtable namespaces; // 0x10
	
		// Properties
		public int Count { get; } // 0x0000000181AA6C90-0x0000000181AA6D20 
		internal ArrayList NamespaceList { get; } // 0x0000000181AA6D20-0x0000000181AA7120 
		internal Hashtable Namespaces { get; set; } // 0x0000000181AA7120-0x0000000181AA7190 0x00000001803780D0-0x00000001803780E0
	
		// Constructors
		public XmlSerializerNamespaces(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Add(string prefix, string ns); // 0x0000000181AA6A90-0x0000000181AA6BB0
		internal void AddInternal(string prefix, string ns); // 0x0000000181AA69E0-0x0000000181AA6A90
		public XmlQualifiedName[] ToArray(); // 0x0000000181AA6BB0-0x0000000181AA6C90
	}
}
