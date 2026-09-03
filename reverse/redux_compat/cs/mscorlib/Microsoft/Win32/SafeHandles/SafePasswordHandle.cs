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

namespace Microsoft.Win32.SafeHandles
{
	internal sealed class SafePasswordHandle : SafeHandle // TypeDefIndex: 2158
	{
		// Properties
		public override bool IsInvalid { get; } // 0x0000000181453300-0x0000000181453330 
	
		// Constructors
		public SafePasswordHandle(string password); // 0x00000001814532B0-0x0000000181453300
	
		// Methods
		private IntPtr CreateHandle(string password); // 0x0000000181453160-0x0000000181453190
		private void FreeHandle(); // 0x00000001814531F0-0x0000000181453220
		protected override bool ReleaseHandle(); // 0x0000000181453250-0x00000001814532B0
		protected override void Dispose(bool disposing); // 0x0000000181453190-0x00000001814531F0
		internal string Mono_DangerousGetString(); // 0x0000000181453220-0x0000000181453250
	}
}
