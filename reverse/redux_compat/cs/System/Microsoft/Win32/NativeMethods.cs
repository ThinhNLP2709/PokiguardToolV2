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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Microsoft.Win32
{
	internal static class NativeMethods // TypeDefIndex: 8644
	{
		// Methods
		public static bool DuplicateHandle(HandleRef hSourceProcessHandle, HandleRef hSourceHandle, HandleRef hTargetProcess, out SafeProcessHandle targetHandle, int dwDesiredAccess, bool bInheritHandle, int dwOptions); // 0x0000000181B52710-0x0000000181B52860
		public static IntPtr GetCurrentProcess(); // 0x0000000181B52870-0x0000000181B52880
		public static bool GetExitCodeProcess(IntPtr processHandle, out int exitCode); // 0x0000000181B52970-0x0000000181B52980
		public static bool GetExitCodeProcess(SafeProcessHandle processHandle, out int exitCode); // 0x0000000181B52880-0x0000000181B52970
		public static int GetCurrentProcessId(); // 0x0000000181B52860-0x0000000181B52870
		public static bool CloseProcess(IntPtr handle); // 0x0000000181B52700-0x0000000181B52710
	}
}
