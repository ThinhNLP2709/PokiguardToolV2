/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	internal class TypeSpec // TypeDefIndex: 2501
	{
		// Fields
		private TypeIdentifier name; // 0x10
		private string assembly_name; // 0x18
		private List<TypeIdentifier> nested; // 0x20
		private List<TypeSpec> generic_params; // 0x28
		private List<ModifierSpec> modifier_spec; // 0x30
		private bool is_byref; // 0x38
		private string display_fullname; // 0x40
	
		// Properties
		internal bool HasModifiers { get; } // 0x00000001815014A0-0x00000001815014B0 
		internal string DisplayFullName { get; } // 0x00000001816782D0-0x0000000181678310 
	
		// Nested types
		[Flags]
		internal enum DisplayNameFormat // TypeDefIndex: 2502
		{
			Default = 0,
			WANT_ASSEMBLY = 1,
			NO_MODIFIERS = 2
		}
	
		// Constructors
		public TypeSpec(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private string GetDisplayFullName(DisplayNameFormat flags); // 0x0000000181676270-0x0000000181676690
		private StringBuilder GetModifierString(StringBuilder sb); // 0x0000000181676690-0x0000000181676860
		internal static TypeSpec Parse(string typeName); // 0x00000001816777B0-0x00000001816778A0
		internal static string UnescapeInternalName(string displayName); // 0x0000000181678210-0x00000001816782D0
		internal Type Resolve(Func<AssemblyName, Assembly> assemblyResolver, Func<Assembly, string, bool, Type> typeResolver, bool throwOnError, bool ignoreCase, ref StackCrawlMark stackMark); // 0x00000001816778A0-0x0000000181678170
		private void AddName(string type_name); // 0x0000000181676090-0x00000001816761E0
		private void AddModifier(ModifierSpec md); // 0x0000000181675F90-0x0000000181676090
		private static void SkipSpace(string name, ref int pos); // 0x0000000181678170-0x0000000181678210
		private static void BoundCheck(int idx, string s); // 0x00000001816761E0-0x0000000181676270
		private static TypeIdentifier ParsedTypeIdentifier(string displayName); // 0x0000000181675F10-0x0000000181675F90
		private static TypeSpec Parse(string name, ref int p, bool is_recurse, bool allow_aqn); // 0x0000000181676860-0x00000001816777B0
	}
}
