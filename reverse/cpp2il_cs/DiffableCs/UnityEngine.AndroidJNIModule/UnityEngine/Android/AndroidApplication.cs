namespace UnityEngine.Android;

[NativeHeader("Modules/AndroidJNI/Public/AndroidApplication.bindings.h")]
[StaticAccessor("AndroidApplication", StaticAccessorType::DoubleColon (2))]
public static class AndroidApplication
{
	private static SynchronizationContext m_MainThreadSynchronizationContext; //Field offset: 0x0
	private static AndroidConfiguration m_CurrentConfiguration; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<AndroidConfiguration> onConfigurationChanged; //Field offset: 0x10

	internal static IntPtr UnityPlayerRaw
	{
		[ThreadSafe]
		internal get { } //Length: 42
	}

	[RequiredByNativeCode(GenerateProxy = True)]
	private static void AcquireMainThreadSynchronizationContext() { }

	[RequiredByNativeCode(GenerateProxy = True)]
	private static void DispatchConfigurationChanged(bool notifySubscribers) { }

	[ThreadSafe]
	internal static IntPtr get_UnityPlayerRaw() { }

	[RequiredByNativeCode(GenerateProxy = True)]
	private static AndroidConfiguration GetCurrentConfiguration() { }

	[RequiredByNativeCode(GenerateProxy = True)]
	private static void SetCurrentConfiguration(AndroidConfiguration config) { }

}

