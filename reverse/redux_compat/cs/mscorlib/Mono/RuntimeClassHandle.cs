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

namespace Mono
{
	internal struct RuntimeClassHandle // TypeDefIndex: 2074
	{
		// Fields
		private unsafe RuntimeStructs.MonoClass* value; // 0x00
	
		// Properties
		internal unsafe RuntimeStructs.MonoClass* Value { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Constructors
		internal unsafe RuntimeClassHandle(RuntimeStructs.MonoClass* value); // 0x0000000180CBE820-0x0000000180CBE830
		internal unsafe RuntimeClassHandle(IntPtr ptr); // 0x0000000181432FE0-0x0000000181433000
	
		// Methods
		public override bool Equals(object obj); // 0x0000000181432EB0-0x0000000181432F90
		public override int GetHashCode(); // 0x0000000181432F90-0x0000000181432FC0
		internal static unsafe IntPtr GetTypeFromClass(RuntimeStructs.MonoClass* klass); // 0x0000000181432FC0-0x0000000181432FD0
		internal RuntimeTypeHandle GetTypeHandle(); // 0x0000000181432FD0-0x0000000181432FE0
	}
}
