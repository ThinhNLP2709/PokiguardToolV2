namespace UnityEngine.Accessibility;

[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeManager.h")]
internal static class AccessibilityNodeManager
{

	internal static void DestroyNativeNode(int id, int parentId) { }

	[RequiredByNativeCode]
	internal static void Internal_InvokeDecremented(int id) { }

	[RequiredByNativeCode]
	internal static bool Internal_InvokeDismissed(int id) { }

	[RequiredByNativeCode]
	internal static void Internal_InvokeFocusChanged(int id, bool isNodeFocused) { }

	[RequiredByNativeCode]
	internal static void Internal_InvokeIncremented(int id) { }

	[RequiredByNativeCode]
	internal static bool Internal_InvokeSelected(int id) { }

	internal static void SetActions(int id, AccessibilityAction[] actions) { }

	internal static void SetChildren(int id, Int32[] childIds) { }

	private static void SetChildren_Injected(int id, ref ManagedSpanWrapper childIds) { }

	internal static void SetFrame(int id, Rect frame) { }

	private static void SetFrame_Injected(int id, in Rect frame) { }

}

