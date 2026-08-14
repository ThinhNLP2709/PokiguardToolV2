namespace UnityEngine;

[NativeHeader("Runtime/Input/InputBindings.h")]
public class Input
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static bool <simulateTouchEnabled>k__BackingField; //Field offset: 0x0

	[NativeThrows]
	public static bool anyKey
	{
		 get { } //Length: 42
	}

	[NativeThrows]
	public static bool anyKeyDown
	{
		 get { } //Length: 42
	}

	public static Vector2 compositionCursorPos
	{
		 get { } //Length: 59
		 set { } //Length: 52
	}

	public static string compositionString
	{
		 get { } //Length: 164
	}

	public static IMECompositionMode imeCompositionMode
	{
		 get { } //Length: 42
		 set { } //Length: 49
	}

	[NativeThrows]
	public static Vector3 mousePosition
	{
		 get { } //Length: 62
	}

	public static bool mousePresent
	{
		 get { } //Length: 109
	}

	[NativeThrows]
	public static Vector2 mouseScrollDelta
	{
		 get { } //Length: 59
	}

	public static bool simulateMouseWithTouches
	{
		 set { } //Length: 51
	}

	internal static bool simulateTouchEnabled
	{
		[CompilerGenerated]
		internal get { } //Length: 54
	}

	public static int touchCount
	{
		[FreeFunction("GetTouchCount")]
		 get { } //Length: 42
	}

	public static Touch[] touches
	{
		 get { } //Length: 331
	}

	public static bool touchSupported
	{
		 get { } //Length: 112
	}

	internal static bool CheckDisabled() { }

	[NativeThrows]
	public static void ClearLastPenContactEvent() { }

	public static bool get_anyKey() { }

	public static bool get_anyKeyDown() { }

	public static Vector2 get_compositionCursorPos() { }

	private static void get_compositionCursorPos_Injected(out Vector2 ret) { }

	public static string get_compositionString() { }

	private static void get_compositionString_Injected(out ManagedSpanWrapper ret) { }

	public static IMECompositionMode get_imeCompositionMode() { }

	public static Vector3 get_mousePosition() { }

	private static void get_mousePosition_Injected(out Vector3 ret) { }

	public static bool get_mousePresent() { }

	public static Vector2 get_mouseScrollDelta() { }

	private static void get_mouseScrollDelta_Injected(out Vector2 ret) { }

	[CompilerGenerated]
	internal static bool get_simulateTouchEnabled() { }

	[FreeFunction("GetTouchCount")]
	public static int get_touchCount() { }

	public static Touch[] get_touches() { }

	public static bool get_touchSupported() { }

	public static float GetAxis(string axisName) { }

	public static float GetAxisRaw(string axisName) { }

	public static bool GetButton(string buttonName) { }

	public static bool GetButtonDown(string buttonName) { }

	public static bool GetButtonUp(string buttonName) { }

	public static bool GetKey(KeyCode key) { }

	public static bool GetKeyDown(KeyCode key) { }

	[NativeThrows]
	private static bool GetKeyDownInt(KeyCode key) { }

	[NativeThrows]
	private static bool GetKeyInt(KeyCode key) { }

	public static bool GetKeyUp(KeyCode key) { }

	[NativeThrows]
	private static bool GetKeyUpInt(KeyCode key) { }

	[NativeThrows]
	public static PenData GetLastPenContactEvent() { }

	private static void GetLastPenContactEvent_Injected(out PenData ret) { }

	[NativeThrows]
	public static bool GetMouseButton(int button) { }

	[NativeThrows]
	public static bool GetMouseButtonDown(int button) { }

	[NativeThrows]
	public static bool GetMouseButtonUp(int button) { }

	[FreeFunction("GetMousePresent")]
	private static bool GetMousePresentInternal() { }

	[NativeThrows]
	public static Touch GetTouch(int index) { }

	private static void GetTouch_Injected(int index, out Touch ret) { }

	[FreeFunction("IsTouchSupported")]
	private static bool GetTouchSupportedInternal() { }

	public static void set_compositionCursorPos(Vector2 value) { }

	private static void set_compositionCursorPos_Injected(in Vector2 value) { }

	public static void set_imeCompositionMode(IMECompositionMode value) { }

	public static void set_simulateMouseWithTouches(bool value) { }

}

