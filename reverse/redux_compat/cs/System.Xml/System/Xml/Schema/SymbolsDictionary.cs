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

namespace System.Xml.Schema
{
	internal class SymbolsDictionary // TypeDefIndex: 7021
	{
		// Fields
		private int last; // 0x10
		private Hashtable names; // 0x18
		private Hashtable wildcards; // 0x20
		private ArrayList particles; // 0x28
		private object particleLast; // 0x30
		private bool isUpaEnforced; // 0x38
	
		// Properties
		public int Count { get; } // 0x0000000181AD4450-0x0000000181AD4460 
		public bool IsUpaEnforced { get; set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
		public int this[XmlQualifiedName name] { get => default; } // 0x0000000181AD4460-0x0000000181AD4540 
	
		// Constructors
		public SymbolsDictionary(); // 0x0000000181AD43B0-0x0000000181AD4450
	
		// Methods
		public int AddName(XmlQualifiedName name, object particle); // 0x0000000181AD3330-0x0000000181AD3450
		public void AddNamespaceList(NamespaceList list, object particle, bool allowLocal); // 0x0000000181AD3450-0x0000000181AD36F0
		private void AddWildcard(string wildcard, object particle); // 0x0000000181AD36F0-0x0000000181AD3860
		public ICollection GetNamespaceListSymbols(NamespaceList list); // 0x0000000181AD38A0-0x0000000181AD3F20
		public bool Exists(XmlQualifiedName name); // 0x0000000181AD3860-0x0000000181AD38A0
		public object GetParticle(int symbol); // 0x0000000181AD3F20-0x0000000181AD3F60
		public string NameOf(int symbol); // 0x0000000181AD3F60-0x0000000181AD43B0
	}
}
