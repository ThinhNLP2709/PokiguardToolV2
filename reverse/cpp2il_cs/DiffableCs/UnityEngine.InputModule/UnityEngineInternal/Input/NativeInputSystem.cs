namespace UnityEngineInternal.Input;

[NativeHeader("Modules/Input/Private/InputModuleBindings.h")]
[NativeHeader("Modules/Input/Private/InputInternal.h")]
internal class NativeInputSystem
{
	public static NativeUpdateCallback onUpdate; //Field offset: 0x0
	public static Action<NativeInputUpdateType> onBeforeUpdate; //Field offset: 0x8
	public static Func<NativeInputUpdateType, Boolean> onShouldRunUpdate; //Field offset: 0x10
	private static Action<Int32, String> s_OnDeviceDiscoveredCallback; //Field offset: 0x18

	[NativeProperty(IsThreadSafe = True)]
	public static double currentTime
	{
		 get { } //Length: 42
	}

	[NativeProperty(IsThreadSafe = True)]
	public static double currentTimeOffsetToRealtimeSinceStartup
	{
		 get { } //Length: 42
	}

	internal static bool hasDeviceDiscoveredCallback
	{
		internal set { } //Length: 51
	}

	[NativeProperty("NormalizeScrollWheelDelta")]
	internal static bool normalizeScrollWheelDelta
	{
		internal get { } //Length: 42
		internal set { } //Length: 51
	}

	public static Action<Int32, String> onDeviceDiscovered
	{
		 get { } //Length: 79
		 set { } //Length: 168
	}

	private static NativeInputSystem() { }

	[FreeFunction("AllocateInputDeviceId")]
	public static int AllocateDeviceId() { }

	public static double get_currentTime() { }

	public static double get_currentTimeOffsetToRealtimeSinceStartup() { }

	internal static bool get_normalizeScrollWheelDelta() { }

	public static Action<Int32, String> get_onDeviceDiscovered() { }

	internal static float GetScrollWheelDeltaPerTick() { }

	public static long IOCTL(int deviceId, int code, IntPtr data, int sizeInBytes) { }

	[RequiredByNativeCode]
	internal static void NotifyBeforeUpdate(NativeInputUpdateType updateType) { }

	[RequiredByNativeCode]
	internal static void NotifyDeviceDiscovered(int deviceId, string deviceDescriptor) { }

	[RequiredByNativeCode]
	internal static void NotifyUpdate(NativeInputUpdateType updateType, IntPtr eventBuffer) { }

	[NativeMethod(IsThreadSafe = True)]
	public static void QueueInputEvent(IntPtr inputEvent) { }

	internal static void set_hasDeviceDiscoveredCallback(bool value) { }

	internal static void set_normalizeScrollWheelDelta(bool value) { }

	public static void set_onDeviceDiscovered(Action<Int32, String> value) { }

	public static void SetPollingFrequency(float hertz) { }

	[RequiredByNativeCode]
	internal static void ShouldRunUpdate(NativeInputUpdateType updateType, out bool retval) { }

	public static void Update(NativeInputUpdateType updateType) { }

}

