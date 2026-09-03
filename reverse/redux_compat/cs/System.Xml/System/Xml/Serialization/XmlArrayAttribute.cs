/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false)]
	public class XmlArrayAttribute : Attribute // TypeDefIndex: 6934
	{
		// Fields
		private string elementName; // 0x10
		private XmlSchemaForm form; // 0x18
		private bool isNullable; // 0x1C
		private string ns; // 0x20
		private int order; // 0x28
	
		// Properties
		public string ElementName { get; } // 0x0000000181A98E10-0x0000000181A98E30 
		public XmlSchemaForm Form { get; } // 0x0000000180B23260-0x0000000180B23270 
		public bool IsNullable { get; } // 0x0000000180E38E30-0x0000000180E38E40 
		public string Namespace { get; } // 0x00000001802F8630-0x00000001802F8640 
		public int Order { get; } // 0x0000000180377930-0x0000000180377940 
	
		// Methods
		internal void AddKeyHash(StringBuilder sb); // 0x0000000181AA7C40-0x0000000181AA7D70
	}
}
