/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using Unity.Profiling;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Utilities/URLUtility.h")]
	[NativeHeader("Runtime/Input/TargetFrameRate.h")]
	[NativeHeader("Runtime/Application/AdsIdHandler.h")]
	[NativeHeader("Runtime/BaseClasses/IsPlaying.h")]
	[NativeHeader("Runtime/Export/Application/Application.bindings.h")]
	[NativeHeader("Runtime/File/ApplicationSpecificPersistentDataPath.h")]
	[NativeHeader("Runtime/Input/GetInput.h")]
	[NativeHeader("Runtime/Input/InputManager.h")]
	[NativeHeader("Runtime/Utilities/Argv.h")]
	[NativeHeader("Runtime/Application/ApplicationInfo.h")]
	[NativeHeader("Runtime/Misc/BuildSettings.h")]
	[NativeHeader("Runtime/Misc/Player.h")]
	[NativeHeader("Runtime/Misc/PlayerSettings.h")]
	[NativeHeader("Runtime/PreloadManager/PreloadManager.h")]
	[NativeHeader("Runtime/PreloadManager/LoadSceneOperation.h")]
	[NativeHeader("Runtime/Network/NetworkUtility.h")]
	[NativeHeader("Runtime/Misc/SystemInfo.h")]
	[NativeHeader("NativeKernel/Logging/LogSystem.h")]
	public class Application // TypeDefIndex: 7479
	{
		// Fields
		[CompilerGenerated]
		private static LowMemoryCallback lowMemory; // 0x00
		[CompilerGenerated]
		private static MemoryUsageChangedCallback memoryUsageChanged; // 0x08
		[AutoStaticsCleanupOnCodeReload]
		private static LogCallback s_LogCallbackHandler; // 0x10
		[AutoStaticsCleanupOnCodeReload]
		private static LogCallback s_LogCallbackHandlerThreaded; // 0x18
		[CompilerGenerated]
		private static Action<bool> focusChanged; // 0x20
		[CompilerGenerated]
		private static Action<string> deepLinkActivated; // 0x28
		[CompilerGenerated]
		private static Func<bool> wantsToQuit; // 0x30
		[CompilerGenerated]
		private static Action quitting; // 0x38
		[CompilerGenerated]
		private static Action unloading; // 0x40
		[AutoStaticsCleanupOnCodeReload]
		private static CancellationTokenSource s_currentCancellationTokenSource; // 0x48
		private static readonly ProfilerMarker s_CodeReloadInPlayModeReEnterScopeMarker; // 0x50
	
		// Properties
		public static bool isPlaying { [FreeFunction("IsWorldPlaying")] get; } // 0x0000000182179270-0x00000001821792A0 
		public static bool isFocused { [FreeFunction("IsPlayerFocused")] get; } // 0x0000000182179240-0x0000000182179270 
		public static bool runInBackground { [FreeFunction("GetPlayerSettingsRunInBackground")] get; } // 0x0000000182179400-0x0000000182179430 
		public static bool isBatchMode { [FreeFunction("::IsBatchmode")] get; } // 0x0000000182179210-0x0000000182179240 
		public static string dataPath { [FreeFunction("GetAppDataPath", IsThreadSafe = true)] get; } // 0x00000001821790F0-0x00000001821791E0 
		public static string streamingAssetsPath { [FreeFunction("GetStreamingAssetsPath", IsThreadSafe = true)] get; } // 0x0000000182179470-0x0000000182179560 
		public static string persistentDataPath { [FreeFunction("GetPersistentDataPathApplicationSpecific")] get; } // 0x00000001821792E0-0x00000001821793D0 
		public static string temporaryCachePath { [FreeFunction("GetTemporaryCachePathApplicationSpecific")] get; } // 0x00000001821795D0-0x00000001821796C0 
		internal static int unityVersionVer { [FreeFunction("Application_Bindings::GetUnityVersionVer", IsThreadSafe = true)] [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] get; } // 0x00000001821796F0-0x0000000182179720 
		internal static int unityVersionMaj { [FreeFunction("Application_Bindings::GetUnityVersionMaj", IsThreadSafe = true)] [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] get; } // 0x00000001821796C0-0x00000001821796F0 
		public static string version { [FreeFunction("GetApplicationInfo().GetVersion")] get; } // 0x0000000182179760-0x0000000182179850 
		public static int targetFrameRate { [FreeFunction("GetTargetFrameRate")] get; [FreeFunction("SetTargetFrameRate")] set; } // 0x0000000182179560-0x0000000182179590 0x0000000182179C40-0x0000000182179C80
		public static RuntimePlatform platform { [FreeFunction("systeminfo::GetRuntimePlatform", IsThreadSafe = true)] get; } // 0x00000001821793D0-0x0000000182179400 
		public static NetworkReachability internetReachability { [FreeFunction("GetInternetReachability")] get; } // 0x00000001821791E0-0x0000000182179210 
		public static bool isEditor { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Events
		public static event LogCallback logMessageReceived {
			add; // 0x0000000182178E70-0x0000000182178F90
			remove; // 0x0000000182179A30-0x0000000182179B20
		}
		public static event LogCallback logMessageReceivedThreaded {
			add; // 0x0000000182178D50-0x0000000182178E70
			remove; // 0x0000000182179940-0x0000000182179A30
		}
		public static event UnityAction onBeforeRender {
			add; // 0x0000000182178F90-0x0000000182178FE0
			remove; // 0x0000000182179B20-0x0000000182179B70
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<bool> focusChanged {
			add; // 0x0000000182178C60-0x0000000182178D50
			remove; // 0x0000000182179850-0x0000000182179940
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event Action quitting {
			add; // 0x0000000182178FE0-0x00000001821790B0
			remove; // 0x0000000182179B70-0x0000000182179C40
		}
	
		// Nested types
		public delegate void LowMemoryCallback(); // TypeDefIndex: 7480; 0x0000000180313920-0x00000001803139C0
	
		public delegate void MemoryUsageChangedCallback([IsReadOnly] in ApplicationMemoryUsageChange usage); // TypeDefIndex: 7481; 0x00000001804A78A0-0x00000001804A78B0
	
		public delegate void LogCallback(string condition, string stackTrace, LogType type); // TypeDefIndex: 7482; 0x0000000180A72B30-0x0000000180A72B50
	
		// Constructors
		static Application(); // 0x0000000182178BA0-0x0000000182178C60
	
		// Methods
		[FreeFunction("GetInputManager().QuitApplication")]
		public static void Quit(int exitCode); // 0x0000000182178A80-0x0000000182178AC0
		public static void Quit(); // 0x0000000182178AC0-0x0000000182178B20
		[FreeFunction("OpenURL")]
		public static void OpenURL(string url); // 0x0000000182178900-0x0000000182178A80
		[FreeFunction("Application_Bindings::SetLogCallbackDefined")]
		private static void SetLogCallbackDefined(bool defined); // 0x0000000182178B20-0x0000000182178B60
		[FreeFunction("SetStackTraceLogType")]
		public static void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceType); // 0x0000000182178B60-0x0000000182178BA0
		[RequiredByNativeCode]
		internal static void CallLowMemory(ApplicationMemoryUsage usage); // 0x0000000182177F90-0x00000001821780B0
		[RequiredByNativeCode]
		internal static bool HasLogCallback(); // 0x00000001821780B0-0x0000000182178110
		[RequiredByNativeCode]
		private static void CallLogCallback(string logString, string stackTrace, LogType type, bool invokedOnMainThread); // 0x0000000182177EA0-0x0000000182177F90
		[RequiredByNativeCode]
		private static bool Internal_ApplicationWantsToQuit(); // 0x00000001821781F0-0x0000000182178390
		[RequiredByNativeCode]
		private static void Internal_InitializeExitCancellationToken(); // 0x0000000182178670-0x0000000182178740
		[RequiredByNativeCode]
		private static void Internal_RaiseExitCancellationToken(); // 0x0000000182178740-0x00000001821787A0
		[RequiredByNativeCode]
		private static void Internal_ApplicationQuit(); // 0x0000000182178110-0x0000000182178180
		[RequiredByNativeCode]
		private static void Internal_ApplicationUnload(); // 0x0000000182178180-0x00000001821781F0
		[RequiredByNativeCode]
		internal static void Internal_EnterPlayModeLifecycleScope(); // 0x0000000182178390-0x00000001821785F0
		[RequiredByNativeCode]
		internal static void Internal_ExitPlayModeLifecycleScope(); // 0x00000001821785F0-0x0000000182178670
		[RequiredByNativeCode]
		internal static void InvokeOnBeforeRender(); // 0x0000000182178880-0x00000001821788C0
		[RequiredByNativeCode]
		internal static void InvokeFocusChanged(bool focus); // 0x0000000182178810-0x0000000182178880
		[RequiredByNativeCode]
		internal static void InvokeDeepLinkActivated(string url); // 0x00000001821787A0-0x0000000182178810
		private static void get_dataPath_Injected(); // 0x00000001821790B0-0x00000001821790F0
		private static void get_streamingAssetsPath_Injected(); // 0x0000000182179430-0x0000000182179470
		private static void get_persistentDataPath_Injected(); // 0x00000001821792A0-0x00000001821792E0
		private static void get_temporaryCachePath_Injected(); // 0x0000000182179590-0x00000001821795D0
		private static void get_version_Injected(); // 0x0000000182179720-0x0000000182179760
		private static void OpenURL_Injected(ref ManagedSpanWrapper url); // 0x00000001821788C0-0x0000000182178900
	}
}
