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
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	public class XmlTypeAttribute : Attribute // TypeDefIndex: 6980
	{
		// Fields
		private bool includeInSchema; // 0x10
		private string ns; // 0x18
		private string typeName; // 0x20
	
		// Properties
		public bool IncludeInSchema { get; } // 0x00000001805625D0-0x00000001805625E0 
		public string Namespace { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public string TypeName { get; } // 0x0000000181ADB2C0-0x0000000181ADB2E0 
	
		// Methods
		internal void AddKeyHash(StringBuilder sb); // 0x0000000181ADB220-0x0000000181ADB2C0
	}
}
