/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	internal class TypeIdentifiers // TypeDefIndex: 2496
	{
		// Nested types
		private class Display : TypeNames.ATypeName, TypeIdentifier // TypeDefIndex: 2497
		{
			// Fields
			private string displayName; // 0x10
			private string internal_name; // 0x18
	
			// Properties
			public override string DisplayName { get; } // 0x0000000180377550-0x0000000180377560 
			public string InternalName { get; } // 0x000000018166D800-0x000000018166D8E0 
	
			// Constructors
			internal Display(string displayName); // 0x000000018166D7B0-0x000000018166D800
	
			// Methods
			private string GetInternalName(); // 0x000000018166D6F0-0x000000018166D7B0
		}
	
		// Methods
		internal static TypeIdentifier FromDisplay(string displayName); // 0x0000000181675F10-0x0000000181675F90
	}
}
