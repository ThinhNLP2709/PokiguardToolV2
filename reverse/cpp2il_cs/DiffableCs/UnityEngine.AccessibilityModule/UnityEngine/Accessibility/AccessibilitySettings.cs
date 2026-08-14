namespace UnityEngine.Accessibility;

[NativeHeader("Modules/Accessibility/Native/AccessibilitySettings.h")]
public static class AccessibilitySettings
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<Single> fontScaleChanged; //Field offset: 0x0
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<Boolean> boldTextStatusChanged; //Field offset: 0x8
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static Action<Boolean> closedCaptioningStatusChanged; //Field offset: 0x10

	[RequiredByNativeCode]
	private static void Internal_OnBoldTextStatusChanged(bool enabled) { }

	[RequiredByNativeCode]
	private static void Internal_OnClosedCaptioningStatusChanged(bool enabled) { }

	[RequiredByNativeCode]
	private static void Internal_OnFontScaleChanged(float newFontScale) { }

	internal static void InvokeBoldTextStatusChanged(bool enabled) { }

	internal static void InvokeClosedCaptionStatusChanged(bool enabled) { }

	internal static void InvokeFontScaleChanged(float newFontScale) { }

}

