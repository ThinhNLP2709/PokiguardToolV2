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
using System.Threading;
using Microsoft.Win32.SafeHandles;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net.Sockets
{
	internal sealed class SafeSocketHandle : SafeHandleMinusOneIsInvalid // TypeDefIndex: 9239
	{
		// Fields
		private List<Thread> blocking_threads; // 0x20
		private Dictionary<Thread, StackTrace> threads_stacktraces; // 0x28
		private bool in_cleanup; // 0x30
		private static bool THROW_ON_ABORT_RETRIES; // 0x00
	
		// Constructors
		public SafeSocketHandle(IntPtr preexistingHandle, bool ownsHandle); // 0x0000000181B2A750-0x0000000181B2A820
		static SafeSocketHandle(); // 0x0000000181B2A6E0-0x0000000181B2A750
	
		// Methods
		protected override bool ReleaseHandle(); // 0x0000000181B2A020-0x0000000181B2A540
		public void RegisterForBlockingSyscall(); // 0x0000000181B29E70-0x0000000181B2A020
		public void UnRegisterForBlockingSyscall(); // 0x0000000181B2A540-0x0000000181B2A6E0
	}
}
