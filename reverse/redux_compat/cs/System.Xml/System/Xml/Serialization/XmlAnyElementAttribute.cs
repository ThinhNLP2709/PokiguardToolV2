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
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true)]
	public class XmlAnyElementAttribute : Attribute // TypeDefIndex: 6932
	{
		// Fields
		private string elementName; // 0x10
		private string ns; // 0x18
		private int order; // 0x20
	
		// Properties
		public string Name { get; } // 0x0000000181A98E10-0x0000000181A98E30 
		public string Namespace { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public int Order { get; } // 0x0000000180C4F680-0x0000000180C4F690 
	
		// Constructors
		public XmlAnyElementAttribute(); // 0x0000000181A98E00-0x0000000181A98E10
	
		// Methods
		internal void AddKeyHash(StringBuilder sb); // 0x0000000181A98C50-0x0000000181A98E00
	}
}
