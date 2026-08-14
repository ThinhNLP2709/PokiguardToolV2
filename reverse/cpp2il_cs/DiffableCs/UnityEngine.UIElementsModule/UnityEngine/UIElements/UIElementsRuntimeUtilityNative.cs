namespace UnityEngine.UIElements;

[NativeHeader("Modules/UIElements/Core/Native/UIElementsRuntimeUtilityNative.h")]
[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"Unity.UIElements"})]
internal static class UIElementsRuntimeUtilityNative
{
	internal static Action UpdatePanelsCallback; //Field offset: 0x0
	internal static Action<Boolean> RepaintPanelsCallback; //Field offset: 0x8
	internal static Action RenderOffscreenPanelsCallback; //Field offset: 0x10

	public static void RegisterPlayerloopCallback() { }

	[RequiredByNativeCode]
	public static void RenderOffscreenPanels() { }

	[RequiredByNativeCode]
	public static void RepaintPanels(bool onlyOffscreen) { }

	public static void UnregisterPlayerloopCallback() { }

	[RequiredByNativeCode]
	public static void UpdatePanels() { }

	public static void VisualElementCreation() { }

}

