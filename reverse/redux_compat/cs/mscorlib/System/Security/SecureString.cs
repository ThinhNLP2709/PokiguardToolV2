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

namespace System.Security
{
	[MonoTODO("work in progress - encryption is missing")]
	public sealed class SecureString : IDisposable // TypeDefIndex: 2750
	{
		// Fields
		private int length; // 0x10
		private bool disposed; // 0x14
		private byte[] data; // 0x18
	
		// Properties
		public int Length { get; } // 0x00000001814813E0-0x0000000181481450 
	
		// Constructors
		public SecureString(); // 0x0000000181481380-0x00000001814813E0
		[CLSCompliant(false)]
		public unsafe SecureString(char* value, int length); // 0x0000000181481200-0x0000000181481380
	
		// Methods
		public void Dispose(); // 0x00000001814810E0-0x0000000181481140
		private void Encrypt(); // 0x00000001809CF740-0x00000001809CF750
		private void Decrypt(); // 0x00000001809CF740-0x00000001809CF750
		private void Alloc(int length, bool realloc); // 0x0000000181480F20-0x00000001814810E0
		internal byte[] GetBuffer(); // 0x0000000181481140-0x0000000181481200
	}
}
