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

namespace System.Threading
{
	internal static class NativeEventCalls // TypeDefIndex: 2610
	{
		// Methods
		public static IntPtr CreateEvent_internal(bool manual, bool initial, string name, out int errorCode); // 0x0000000181681C50-0x0000000181681CC0
		private static unsafe IntPtr CreateEvent_icall(bool manual, bool initial, char* name, int name_length, out int errorCode); // 0x0000000181681C40-0x0000000181681C50
		public static bool SetEvent(SafeWaitHandle handle); // 0x0000000181681DC0-0x0000000181681EA0
		private static bool SetEvent_internal(IntPtr handle); // 0x0000000181681DB0-0x0000000181681DC0
		public static bool ResetEvent(SafeWaitHandle handle); // 0x0000000181681CD0-0x0000000181681DB0
		private static bool ResetEvent_internal(IntPtr handle); // 0x0000000181681CC0-0x0000000181681CD0
		public static void CloseEvent_internal(IntPtr handle); // 0x0000000181681C30-0x0000000181681C40
	}
}
