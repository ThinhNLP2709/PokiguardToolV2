/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 47: System.Xml.Linq.dll - Assembly: System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 - Types 15375-15412

namespace System.Xml.Linq
{
	internal struct NamespaceResolver // TypeDefIndex: 15397
	{
		// Fields
		private int _scope; // 0x00
		private NamespaceDeclaration _declaration; // 0x08
		private NamespaceDeclaration _rover; // 0x10
	
		// Nested types
		private class NamespaceDeclaration // TypeDefIndex: 15398
		{
			// Fields
			public string prefix; // 0x10
			public XNamespace ns; // 0x18
			public int scope; // 0x20
			public NamespaceDeclaration prev; // 0x28
	
			// Constructors
			public NamespaceDeclaration(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Methods
		public void PushScope(); // 0x0000000180D8C010-0x0000000180D8C020
		public void PopScope(); // 0x0000000181956380-0x0000000181956420
		public void Add(string prefix, XNamespace ns); // 0x0000000181956180-0x0000000181956270
		public void AddFirst(string prefix, XNamespace ns); // 0x0000000181956080-0x0000000181956180
		public string GetPrefixOfNamespace(XNamespace ns, bool allowDefaultNamespace); // 0x0000000181956270-0x0000000181956380
	}
}
