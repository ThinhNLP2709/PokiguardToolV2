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
	internal class NamespaceList // TypeDefIndex: 7130
	{
		// Fields
		private ListType type; // 0x10
		private Hashtable set; // 0x18
		private string targetNamespace; // 0x20
	
		// Properties
		public ListType Type { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public string Excluded { get; } // 0x00000001802F8630-0x00000001802F8640 
		public ICollection Enumerate { get; } // 0x0000000181977480-0x0000000181977500 
	
		// Nested types
		public enum ListType // TypeDefIndex: 7131
		{
			Any = 0,
			Other = 1,
			Set = 2
		}
	
		// Constructors
		public NamespaceList(); // 0x00000001802E5CB0-0x00000001802E5CC0
		public NamespaceList(string namespaces, string targetNamespace); // 0x0000000181977230-0x0000000181977480
	
		// Methods
		public NamespaceList Clone(); // 0x0000000181975FC0-0x0000000181976130
		public virtual bool Allows(string ns); // 0x0000000181975F00-0x0000000181975F90
		public bool Allows(XmlQualifiedName qname); // 0x0000000181975F90-0x0000000181975FC0
		public override string ToString(); // 0x00000001819769F0-0x0000000181976DC0
		public static bool IsSubset(NamespaceList sub, NamespaceList super); // 0x0000000181976700-0x0000000181976980
		public static NamespaceList Union(NamespaceList o1, NamespaceList o2, bool v1Compat); // 0x0000000181976DC0-0x0000000181977230
		private NamespaceList CompareSetToOther(NamespaceList other); // 0x0000000181976130-0x00000001819762A0
		public static NamespaceList Intersection(NamespaceList o1, NamespaceList o2, bool v1Compat); // 0x00000001819762A0-0x0000000181976700
		private void RemoveNamespace(string tns); // 0x0000000181976980-0x00000001819769F0
	}
}
