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

namespace Mono.Btls
{
	internal static class MonoBtlsError // TypeDefIndex: 8591
	{
		// Methods
		private static extern void mono_btls_error_clear_error(); // 0x00000001818186F0-0x0000000181818760
		private static extern int mono_btls_error_get_error_line(out IntPtr file, out int line); // 0x0000000181818AB0-0x0000000181818B40
		private static extern void mono_btls_error_get_error_string_n(int error, IntPtr buf, int len); // 0x0000000181818B40-0x0000000181818BE0
		private static extern int mono_btls_error_get_reason(int error); // 0x0000000181818760-0x00000001818187E0
		public static void ClearError(); // 0x00000001818186F0-0x0000000181818760
		public static string GetErrorString(int error); // 0x00000001818187E0-0x00000001818189D0
		public static int GetError(out string file, out int line); // 0x00000001818189D0-0x0000000181818AB0
		public static int GetErrorReason(int error); // 0x0000000181818760-0x00000001818187E0
	}
}
