/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Diagnostics/Validation.h")]
	[NativeHeader("Runtime/Diagnostics/IntegrityCheck.h")]
	[NativeHeader("Runtime/Export/Debug/Debug.bindings.h")]
	public class Debug // TypeDefIndex: 7515
	{
		// Fields
		[NoAutoStaticsCleanup]
		internal static readonly ILogger s_DefaultLogger; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		internal static ILogger s_Logger; // 0x08
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x10
	
		// Properties
		public static ILogger unityLogger { get; } // 0x000000018218C090-0x000000018218C0E0 
		public static bool isDebugBuild { get; } // 0x000000018218C060-0x000000018218C090 
	
		// Constructors
		static Debug(); // 0x000000018218BE60-0x000000018218C060
	
		// Methods
		[ExcludeFromDocs]
		public static void DrawLine(Vector3 start, Vector3 end, Color color); // 0x000000018218A9F0-0x000000018218AAF0
		[FreeFunction("DebugDrawLine", IsThreadSafe = true)]
		public static void DrawLine(Vector3 start, Vector3 end, [DefaultValue("Color.white")] Color color, [DefaultValue("0.0f")] float duration, [DefaultValue("true")] bool depthTest); // 0x000000018218A950-0x000000018218A9F0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe int ExtractStackTraceNoAlloc(byte* buffer, int bufferMax, string projectFolder); // 0x000000018218AB40-0x000000018218ACE0
		public static void Log(object message); // 0x000000018218BCC0-0x000000018218BD80
		public static void Log(object message, Object context); // 0x000000018218BBE0-0x000000018218BCC0
		public static void LogFormat(string format, params object[] args); // 0x000000018218B780-0x000000018218B860
		public static void LogFormat(LogType logType, LogOption logOptions, Object context, string format, params object[] args); // 0x000000018218B4E0-0x000000018218B780
		public static void LogError(object message); // 0x000000018218B280-0x000000018218B340
		public static void LogError(object message, Object context); // 0x000000018218B1A0-0x000000018218B280
		public static void LogErrorFormat(string format, params object[] args); // 0x000000018218B0C0-0x000000018218B1A0
		public static void LogErrorFormat(Object context, string format, params object[] args); // 0x000000018218AFE0-0x000000018218B0C0
		public static void LogException(Exception exception); // 0x000000018218B340-0x000000018218B410
		public static void LogException(Exception exception, Object context); // 0x000000018218B410-0x000000018218B4E0
		[VisibleToOtherModules(new string[1] {"UnityEditor.BurstModule" })]
		public static void LogWarning(object message); // 0x000000018218BB10-0x000000018218BBE0
		public static void LogWarning(object message, Object context); // 0x000000018218BA30-0x000000018218BB10
		public static void LogWarningFormat(string format, params object[] args); // 0x000000018218B860-0x000000018218B940
		public static void LogWarningFormat(Object context, string format, params object[] args); // 0x000000018218B940-0x000000018218BA30
		[Conditional("UNITY_ASSERTIONS")]
		public static void Assert(bool condition); // 0x000000018218A4B0-0x000000018218A590
		[Conditional("UNITY_ASSERTIONS")]
		public static void Assert(bool condition, string message); // 0x000000018218A590-0x000000018218A670
		[Conditional("UNITY_ASSERTIONS")]
		public static void AssertFormat(bool condition, string format, params object[] args); // 0x000000018218A3C0-0x000000018218A4B0
		[Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertion(object message); // 0x000000018218AF10-0x000000018218AFE0
		[Conditional("UNITY_ASSERTIONS")]
		public static void LogAssertionFormat(string format, params object[] args); // 0x000000018218AE30-0x000000018218AF10
		[RequiredByNativeCode]
		internal static bool CallOverridenDebugHandler(Exception exception, Object obj); // 0x000000018218A670-0x000000018218A8E0
		[RequiredByNativeCode]
		internal static bool IsLoggingEnabled(); // 0x000000018218ACE0-0x000000018218AE30
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018218BD80-0x000000018218BE60
		private static void DrawLine_Injected(in Vector3 start, in Vector3 end, [DefaultValue("Color.white")] in Color color, [DefaultValue("0.0f")] float duration, [DefaultValue("true")] bool depthTest); // 0x000000018218A8E0-0x000000018218A950
		private static unsafe int ExtractStackTraceNoAlloc_Injected(byte* buffer, int bufferMax, ref ManagedSpanWrapper projectFolder); // 0x000000018218AAF0-0x000000018218AB40
	}
}
