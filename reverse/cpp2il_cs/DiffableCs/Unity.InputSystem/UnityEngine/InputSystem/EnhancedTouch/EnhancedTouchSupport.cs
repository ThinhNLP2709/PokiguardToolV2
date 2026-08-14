namespace UnityEngine.InputSystem.EnhancedTouch;

public static class EnhancedTouchSupport
{
	private static int s_Enabled; //Field offset: 0x0
	private static UpdateMode s_UpdateMode; //Field offset: 0x4

	public static bool enabled
	{
		 get { } //Length: 57
	}

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	internal static void CheckEnabled() { }

	public static void Disable() { }

	public static void Enable() { }

	public static bool get_enabled() { }

	private static void OnDeviceChange(InputDevice device, InputDeviceChange change) { }

	private static void OnSettingsChange() { }

	internal static void Reset() { }

	private static void SetUpState() { }

	internal static void TearDownState() { }

}

