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
	internal struct SafeGPtrArrayHandle : IDisposable // TypeDefIndex: 2094
	{
		// Fields
		private RuntimeGPtrArrayHandle handle; // 0x00
	
		// Properties
		internal int Length { get; } // 0x00000001814331A0-0x00000001814331C0 
		internal IntPtr this[int i] { get => default; } // 0x0000000181433120-0x00000001814331A0 
	
		// Constructors
		internal SafeGPtrArrayHandle(IntPtr ptr); // 0x0000000181432FE0-0x0000000181433000
	
		// Methods
		public void Dispose(); // 0x00000001814330F0-0x0000000181433110
	}
}
