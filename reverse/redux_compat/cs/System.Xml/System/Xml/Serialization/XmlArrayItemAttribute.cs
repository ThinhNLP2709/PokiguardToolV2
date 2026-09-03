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
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true)]
	public class XmlArrayItemAttribute : Attribute // TypeDefIndex: 6935
	{
		// Fields
		private string dataType; // 0x10
		private string elementName; // 0x18
		private XmlSchemaForm form; // 0x20
		private string ns; // 0x28
		private bool isNullable; // 0x30
		private bool isNullableSpecified; // 0x31
		private int nestingLevel; // 0x34
		private Type type; // 0x38
	
		// Properties
		public string DataType { get; } // 0x0000000181A98E10-0x0000000181A98E30 
		public string ElementName { get; } // 0x0000000181AA7EF0-0x0000000181AA7F10 
		public XmlSchemaForm Form { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public string Namespace { get; } // 0x000000018033D240-0x000000018033D250 
		public bool IsNullable { get; } // 0x00000001802E8950-0x00000001802E8960 
		internal bool IsNullableSpecified { get; } // 0x0000000180634F10-0x0000000180634F20 
		public Type Type { get; } // 0x00000001803272A0-0x00000001803272B0 
		public int NestingLevel { get; } // 0x000000018033D0F0-0x000000018033D100 
	
		// Methods
		internal void AddKeyHash(StringBuilder sb); // 0x0000000181AA7D70-0x0000000181AA7EF0
	}
}
