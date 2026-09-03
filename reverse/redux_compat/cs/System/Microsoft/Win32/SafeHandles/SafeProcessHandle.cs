/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Microsoft.Win32.SafeHandles
{
	public sealed class SafeProcessHandle : SafeHandleZeroOrMinusOneIsInvalid // TypeDefIndex: 8645
	{
		// Fields
		internal static SafeProcessHandle InvalidHandle; // 0x00
	
		// Constructors
		internal SafeProcessHandle(IntPtr handle); // 0x0000000181B55150-0x0000000181B55180
		public SafeProcessHandle(IntPtr existingHandle, bool ownsHandle); // 0x0000000181B55180-0x0000000181B551B0
		static SafeProcessHandle(); // 0x0000000181B550D0-0x0000000181B55150
	
		// Methods
		protected override bool ReleaseHandle(); // 0x0000000181B550C0-0x0000000181B550D0
	}
}
