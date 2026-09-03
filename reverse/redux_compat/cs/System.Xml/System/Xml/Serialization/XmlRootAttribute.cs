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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.ReturnValue)]
	public class XmlRootAttribute : Attribute // TypeDefIndex: 6956
	{
		// Fields
		private string dataType; // 0x10
		private string elementName; // 0x18
		private bool isNullable; // 0x20
		private string ns; // 0x28
	
		// Properties
		public string DataType { get; set; } // 0x0000000181A98E10-0x0000000181A98E30 0x00000001803780D0-0x00000001803780E0
		public string ElementName { get; set; } // 0x0000000181AA7EF0-0x0000000181AA7F10 0x00000001802FAF70-0x00000001802FAF80
		public bool IsNullable { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
		public string Namespace { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
	
		// Constructors
		public XmlRootAttribute(); // 0x0000000181AB4050-0x0000000181AB4060
		public XmlRootAttribute(string elementName); // 0x0000000181AB4060-0x0000000181AB40A0
	
		// Methods
		internal void AddKeyHash(StringBuilder sb); // 0x0000000181AB3F90-0x0000000181AB4050
	}
}
