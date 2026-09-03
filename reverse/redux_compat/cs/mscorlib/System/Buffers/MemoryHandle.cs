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

namespace System.Buffers
{
	public struct MemoryHandle : IDisposable // TypeDefIndex: 3627
	{
		// Fields
		private unsafe void* _pointer; // 0x00
		private GCHandle _handle; // 0x08
		private IPinnable _pinnable; // 0x10
	
		// Properties
		[CLSCompliant(false)]
		public unsafe void* Pointer { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Constructors
		[CLSCompliant(false)]
		public unsafe MemoryHandle(void* pointer, GCHandle handle = default, IPinnable pinnable = null); // 0x00000001815AEB20-0x00000001815AEB40
	
		// Methods
		public void Dispose(); // 0x00000001815AEAB0-0x00000001815AEB20
	}
}
