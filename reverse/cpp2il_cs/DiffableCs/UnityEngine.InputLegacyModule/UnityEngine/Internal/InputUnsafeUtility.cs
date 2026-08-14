namespace UnityEngine.Internal;

[NativeHeader("Runtime/Input/InputBindings.h")]
internal static class InputUnsafeUtility
{

	[NativeThrows]
	internal static float GetAxis(string axisName) { }

	[NativeThrows]
	internal static float GetAxis__Unmanaged(Byte* axisName, int axisNameLen) { }

	private static float GetAxis_Injected(ref ManagedSpanWrapper axisName) { }

	[NativeThrows]
	internal static float GetAxisRaw(string axisName) { }

	[NativeThrows]
	internal static float GetAxisRaw__Unmanaged(Byte* axisName, int axisNameLen) { }

	private static float GetAxisRaw_Injected(ref ManagedSpanWrapper axisName) { }

	[NativeThrows]
	internal static bool GetButton(string buttonName) { }

	[NativeThrows]
	internal static bool GetButton__Unmanaged(Byte* buttonName, int buttonNameLen) { }

	private static bool GetButton_Injected(ref ManagedSpanWrapper buttonName) { }

	[NativeThrows]
	internal static bool GetButtonDown(string buttonName) { }

	[NativeThrows]
	internal static byte GetButtonDown__Unmanaged(Byte* buttonName, int buttonNameLen) { }

	private static bool GetButtonDown_Injected(ref ManagedSpanWrapper buttonName) { }

	[NativeThrows]
	internal static bool GetButtonUp(string buttonName) { }

	[NativeThrows]
	internal static bool GetButtonUp__Unmanaged(Byte* buttonName, int buttonNameLen) { }

	private static bool GetButtonUp_Injected(ref ManagedSpanWrapper buttonName) { }

	[NativeThrows]
	internal static bool GetKeyDownString__Unmanaged(Byte* name, int nameLen) { }

	[NativeThrows]
	internal static bool GetKeyString__Unmanaged(Byte* name, int nameLen) { }

	[NativeThrows]
	internal static bool GetKeyUpString__Unmanaged(Byte* name, int nameLen) { }

}

