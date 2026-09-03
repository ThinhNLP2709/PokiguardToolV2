/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 84: System.Runtime.Serialization.dll - Assembly: System.Runtime.Serialization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 15962-15966

namespace System.Runtime.Serialization
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	public sealed class DataMemberAttribute : Attribute // TypeDefIndex: 15964
	{
		// Fields
		private string name; // 0x10
		private bool isNameSetExplicitly; // 0x18
		private int order; // 0x1C
		private bool isRequired; // 0x20
		private bool emitDefaultValue; // 0x21
	
		// Properties
		public string Name { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000180439DF0-0x0000000180439E10
		public int Order { get; } // 0x0000000180B232F0-0x0000000180B23300 
		public bool IsRequired { get; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 
		public bool EmitDefaultValue { get; } // 0x000000018147B6C0-0x000000018147B6D0 
	
		// Constructors
		public DataMemberAttribute(); // 0x000000018193D200-0x000000018193D220
	}
}
