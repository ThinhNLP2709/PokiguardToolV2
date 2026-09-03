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
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
	public class XmlAttributeAttribute : Attribute // TypeDefIndex: 6937
	{
		// Fields
		private string attributeName; // 0x10
		private string dataType; // 0x18
		private Type type; // 0x20
		private XmlSchemaForm form; // 0x28
		private string ns; // 0x30
	
		// Properties
		public string AttributeName { get; } // 0x0000000181A98E10-0x0000000181A98E30 
		public string DataType { get; set; } // 0x0000000181AA7EF0-0x0000000181AA7F10 0x00000001802FAF70-0x00000001802FAF80
		public XmlSchemaForm Form { get; } // 0x0000000180377930-0x0000000180377940 
		public string Namespace { get; } // 0x000000018031E110-0x000000018031E120 
	
		// Constructors
		public XmlAttributeAttribute(string attributeName); // 0x00000001802E7420-0x00000001802E7460
	
		// Methods
		internal void AddKeyHash(StringBuilder sb); // 0x0000000181AA82E0-0x0000000181AA8420
	}
}
