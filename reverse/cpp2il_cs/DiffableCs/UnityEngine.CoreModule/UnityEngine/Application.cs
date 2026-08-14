namespace UnityEngine;

[NativeHeader("Runtime/Utilities/URLUtility.h")]
[NativeHeader("Runtime/Application/AdsIdHandler.h")]
[NativeHeader("Runtime/Misc/Player.h")]
[NativeHeader("Runtime/Network/NetworkUtility.h")]
[NativeHeader("Runtime/Input/TargetFrameRate.h")]
[NativeHeader("Runtime/File/ApplicationSpecificPersistentDataPath.h")]
[NativeHeader("Runtime/Input/GetInput.h")]
[NativeHeader("Runtime/Input/InputManager.h")]
[NativeHeader("Runtime/Logging/LogSystem.h")]
[NativeHeader("Runtime/Misc/BuildSettings.h")]
[NativeHeader("Runtime/BaseClasses/IsPlaying.h")]
[NativeHeader("Runtime/Misc/PlayerSettings.h")]
[NativeHeader("Runtime/Utilities/Argv.h")]
[NativeHeader("Runtime/PreloadManager/LoadSceneOperation.h")]
[NativeHeader("Runtime/Misc/SystemInfo.h")]
[NativeHeader("Runtime/PreloadManager/PreloadManager.h")]
[NativeHeader("Runtime/Export/Application/Application.bindings.h")]
[NativeHeader("Runtime/Application/ApplicationInfo.h")]
public class Application
{
	internal sealed class LogCallback : MulticastDelegate
	{

		public LogCallback(object object, IntPtr method) { }

		public override void Invoke(string condition, string stackTrace, LogType type) { }

	}

	internal sealed class LowMemoryCallback : MulticastDelegate
	{

		public LowMemoryCallback(object object, IntPtr method) { }

		public override void Invoke() { }

	}

	internal sealed class MemoryUsageChangedCallback : MulticastDelegate
	{

		public MemoryUsageChangedCallback(object object, IntPtr method) { }

		public override void Invoke(in ApplicationMemoryUsageChange usage) { }

	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static LowMemoryCallback lowMemory; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static MemoryUsageChangedCallback memoryUsageChanged; //Field offset: 0x8
	private static LogCallback s_LogCallbackHandler; //Field offset: 0x10
	private static LogCallback s_LogCallbackHandlerThreaded; //Field offset: 0x18
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<Boolean> focusChanged; //Field offset: 0x20
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<String> deepLinkActivated; //Field offset: 0x28
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Func<Boolean> wantsToQuit; //Field offset: 0x30
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action quitting; //Field offset: 0x38
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action unloading; //Field offset: 0x40
	private static CancellationTokenSource s_currentCancellationTokenSource; //Field offset: 0x48

	public static event Action<Boolean> focusChanged
	{
		[CompilerGenerated]
		 add { } //Length: 261
		[CompilerGenerated]
		 remove { } //Length: 261
	}

	public static event LogCallback logMessageReceivedThreaded
	{
		 add { } //Length: 275
		 remove { } //Length: 239
	}

	public static event UnityAction onBeforeRender
	{
		 add { } //Length: 73
		 remove { } //Length: 73
	}

	public static event Action quitting
	{
		[CompilerGenerated]
		 add { } //Length: 242
		[CompilerGenerated]
		 remove { } //Length: 242
	}

	public static string dataPath
	{
		[FreeFunction("GetAppDataPath", IsThreadSafe = True)]
		 get { } //Length: 222
	}

	public static NetworkReachability internetReachability
	{
		[FreeFunction("GetInternetReachability")]
		 get { } //Length: 42
	}

	public static bool isBatchMode
	{
		[FreeFunction("::IsBatchmode")]
		 get { } //Length: 42
	}

	public static bool isEditor
	{
		 get { } //Length: 5
	}

	public static bool isFocused
	{
		[FreeFunction("IsPlayerFocused")]
		 get { } //Length: 42
	}

	public static bool isMobilePlatform
	{
		 get { } //Length: 146
	}

	public static bool isPlaying
	{
		[FreeFunction("IsWorldPlaying")]
		 get { } //Length: 42
	}

	public static string persistentDataPath
	{
		[FreeFunction("GetPersistentDataPathApplicationSpecific")]
		 get { } //Length: 222
	}

	public static RuntimePlatform platform
	{
		[FreeFunction("systeminfo::GetRuntimePlatform", IsThreadSafe = True)]
		 get { } //Length: 42
	}

	public static bool runInBackground
	{
		[FreeFunction("GetPlayerSettingsRunInBackground")]
		 get { } //Length: 42
	}

	public static string streamingAssetsPath
	{
		[FreeFunction("GetStreamingAssetsPath", IsThreadSafe = True)]
		 get { } //Length: 222
	}

	public static int targetFrameRate
	{
		[FreeFunction("GetTargetFrameRate")]
		 get { } //Length: 42
		[FreeFunction("SetTargetFrameRate")]
		 set { } //Length: 49
	}

	public static string temporaryCachePath
	{
		[FreeFunction("GetTemporaryCachePathApplicationSpecific")]
		 get { } //Length: 222
	}

	public static string version
	{
		[FreeFunction("GetApplicationInfo().GetVersion")]
		 get { } //Length: 222
	}

	private static Application() { }

	[CompilerGenerated]
	public static void add_focusChanged(Action<Boolean> value) { }

	public static void add_logMessageReceivedThreaded(LogCallback value) { }

	public static void add_onBeforeRender(UnityAction value) { }

	[CompilerGenerated]
	public static void add_quitting(Action value) { }

	[RequiredByNativeCode]
	private static void CallLogCallback(string logString, string stackTrace, LogType type, bool invokedOnMainThread) { }

	[RequiredByNativeCode]
	internal static void CallLowMemory(ApplicationMemoryUsage usage) { }

	[FreeFunction("GetAppDataPath", IsThreadSafe = True)]
	public static string get_dataPath() { }

	private static void get_dataPath_Injected(out ManagedSpanWrapper ret) { }

	[FreeFunction("GetInternetReachability")]
	public static NetworkReachability get_internetReachability() { }

	[FreeFunction("::IsBatchmode")]
	public static bool get_isBatchMode() { }

	public static bool get_isEditor() { }

	[FreeFunction("IsPlayerFocused")]
	public static bool get_isFocused() { }

	public static bool get_isMobilePlatform() { }

	[FreeFunction("IsWorldPlaying")]
	public static bool get_isPlaying() { }

	[FreeFunction("GetPersistentDataPathApplicationSpecific")]
	public static string get_persistentDataPath() { }

	private static void get_persistentDataPath_Injected(out ManagedSpanWrapper ret) { }

	[FreeFunction("systeminfo::GetRuntimePlatform", IsThreadSafe = True)]
	public static RuntimePlatform get_platform() { }

	[FreeFunction("GetPlayerSettingsRunInBackground")]
	public static bool get_runInBackground() { }

	[FreeFunction("GetStreamingAssetsPath", IsThreadSafe = True)]
	public static string get_streamingAssetsPath() { }

	private static void get_streamingAssetsPath_Injected(out ManagedSpanWrapper ret) { }

	[FreeFunction("GetTargetFrameRate")]
	public static int get_targetFrameRate() { }

	[FreeFunction("GetTemporaryCachePathApplicationSpecific")]
	public static string get_temporaryCachePath() { }

	private static void get_temporaryCachePath_Injected(out ManagedSpanWrapper ret) { }

	[FreeFunction("GetApplicationInfo().GetVersion")]
	public static string get_version() { }

	private static void get_version_Injected(out ManagedSpanWrapper ret) { }

	[RequiredByNativeCode]
	internal static bool HasLogCallback() { }

	[RequiredByNativeCode]
	private static void Internal_ApplicationInit() { }

	[RequiredByNativeCode]
	private static void Internal_ApplicationQuit() { }

	[RequiredByNativeCode]
	private static void Internal_ApplicationUnload() { }

	[RequiredByNativeCode]
	private static bool Internal_ApplicationWantsToQuit() { }

	[RequiredByNativeCode]
	internal static void InvokeDeepLinkActivated(string url) { }

	[RequiredByNativeCode]
	internal static void InvokeFocusChanged(bool focus) { }

	[RequiredByNativeCode]
	internal static void InvokeOnBeforeRender() { }

	[FreeFunction("OpenURL")]
	public static void OpenURL(string url) { }

	private static void OpenURL_Injected(ref ManagedSpanWrapper url) { }

	[FreeFunction("GetInputManager().QuitApplication")]
	public static void Quit(int exitCode) { }

	public static void Quit() { }

	[CompilerGenerated]
	public static void remove_focusChanged(Action<Boolean> value) { }

	public static void remove_logMessageReceivedThreaded(LogCallback value) { }

	public static void remove_onBeforeRender(UnityAction value) { }

	[CompilerGenerated]
	public static void remove_quitting(Action value) { }

	[FreeFunction("SetTargetFrameRate")]
	public static void set_targetFrameRate(int value) { }

	[FreeFunction("Application_Bindings::SetLogCallbackDefined")]
	private static void SetLogCallbackDefined(bool defined) { }

	[FreeFunction("SetStackTraceLogType")]
	public static void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceType) { }

}

