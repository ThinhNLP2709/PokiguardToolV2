/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.InteropServices
{
	public abstract class SafeBuffer : SafeHandleZeroOrMinusOneIsInvalid // TypeDefIndex: 3121
	{
		// Fields
		private static readonly UIntPtr Uninitialized; // 0x00
		private UIntPtr _numBytes; // 0x20
	
		// Constructors
		static SafeBuffer(); // 0x000000018151A580-0x000000018151A5E0
	
		// Methods
		[CLSCompliant(false)]
		public unsafe void AcquirePointer(ref byte* pointer); // 0x000000018151A390-0x000000018151A470
		public void ReleasePointer(); // 0x000000018151A4D0-0x000000018151A580
		private static InvalidOperationException NotInitialized(); // 0x000000018151A470-0x000000018151A4D0
	}
}
