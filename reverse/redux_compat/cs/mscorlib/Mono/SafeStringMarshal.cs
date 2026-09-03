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
	internal struct SafeStringMarshal : IDisposable // TypeDefIndex: 2095
	{
		// Fields
		private readonly string str; // 0x00
		private IntPtr marshaled_string; // 0x08
	
		// Properties
		public IntPtr Value { get; } // 0x0000000181433A20-0x0000000181433A60 
	
		// Constructors
		public SafeStringMarshal(string str); // 0x0000000181433A00-0x0000000181433A20
	
		// Methods
		private static IntPtr StringToUtf8_icall(ref string str); // 0x00000001814339D0-0x00000001814339E0
		public static IntPtr StringToUtf8(string str); // 0x00000001814339E0-0x0000000181433A00
		public static void GFree(IntPtr ptr); // 0x00000001814339C0-0x00000001814339D0
		public void Dispose(); // 0x0000000181433990-0x00000001814339C0
	}
}
