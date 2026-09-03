/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Export/Debug/Debug.bindings.h")]
	internal sealed class DebugLogHandler : ILogHandler // TypeDefIndex: 7514
	{
		// Constructors
		public DebugLogHandler(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		internal static void Internal_Log(LogType level, LogOption options, string msg, Object obj); // 0x000000018218A110-0x000000018218A280
		[NativeMethod(IsThreadSafe = true)]
		internal static void Internal_LogException(Exception ex, Object obj); // 0x000000018218A060-0x000000018218A0B0
		public void LogFormat(LogType logType, Object context, string format, params object[] args); // 0x000000018218A320-0x000000018218A370
		public void LogFormat(LogType logType, LogOption logOptions, Object context, string format, params object[] args); // 0x000000018218A370-0x000000018218A3C0
		public void LogException(Exception exception, Object context); // 0x000000018218A280-0x000000018218A320
		private static void Internal_Log_Injected(LogType level, LogOption options, ref ManagedSpanWrapper msg, IntPtr obj); // 0x000000018218A0B0-0x000000018218A110
		private static void Internal_LogException_Injected(Exception ex, IntPtr obj); // 0x000000018218A010-0x000000018218A060
	}
}
