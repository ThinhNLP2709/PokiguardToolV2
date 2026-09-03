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
using System.Text;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	public class XmlAttributeOverrides // TypeDefIndex: 6938
	{
		// Fields
		private Hashtable overrides; // 0x10
	
		// Properties
		public XmlAttributes this[Type type] { get => default; } // 0x0000000181AA8910-0x0000000181AA8930 
		public XmlAttributes this[Type type, string member] { get => default; } // 0x0000000181AA8930-0x0000000181AA8A30 
	
		// Constructors
		public XmlAttributeOverrides(); // 0x0000000181AA88A0-0x0000000181AA8910
	
		// Methods
		private TypeMember GetKey(Type type, string member); // 0x0000000181AA8830-0x0000000181AA88A0
		internal void AddKeyHash(StringBuilder sb); // 0x0000000181AA8420-0x0000000181AA8830
	}
}
