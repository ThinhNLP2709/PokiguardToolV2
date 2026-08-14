namespace UnityEngine;

[NativeHeader("Modules/IMGUI/GUIManager.h")]
[NativeHeader("Runtime/Camera/RenderLayers/GUITexture.h")]
[NativeHeader("Runtime/Utilities/CopyPaste.h")]
[NativeHeader("Runtime/Input/InputManager.h")]
[NativeHeader("Modules/IMGUI/GUIUtility.h")]
[NativeHeader("Runtime/Input/InputBindings.h")]
public class GUIUtility
{
	internal static int s_ControlCount; //Field offset: 0x0
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static int s_SkinMode; //Field offset: 0x4
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static int s_OriginalID; //Field offset: 0x8
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static Action takeCapture; //Field offset: 0x10
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static Action releaseCapture; //Field offset: 0x18
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static Func<Int32, IntPtr, Boolean> processEvent; //Field offset: 0x20
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static Action cleanupRoots; //Field offset: 0x28
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static Func<Exception, Boolean> endContainerGUIFromException; //Field offset: 0x30
	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static Action guiChanged; //Field offset: 0x38
	internal static Action<EventType, KeyCode, EventModifiers> beforeEventProcessed; //Field offset: 0x40
	private static Event m_Event; //Field offset: 0x48
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState::Never (0))]
	private static bool <guiIsExiting>k__BackingField; //Field offset: 0x50
	internal static Func<Boolean> s_HasCurrentWindowKeyFocusFunc; //Field offset: 0x58

	[StaticAccessor("InputBindings", StaticAccessorType::DoubleColon (2))]
	internal static Vector2 compositionCursorPos
	{
		internal set { } //Length: 101
	}

	[StaticAccessor("InputBindings", StaticAccessorType::DoubleColon (2))]
	internal static string compositionString
	{
		internal get { } //Length: 222
	}

	[NativeProperty("GetGUIState().m_OnGUIDepth", True, TargetType::Field (1))]
	internal static int guiDepth
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
		internal get { } //Length: 42
	}

	internal static bool guiIsExiting
	{
		[CompilerGenerated]
		internal set { } //Length: 84
	}

	public static int hotControl
	{
		 get { } //Length: 91
		 set { } //Length: 98
	}

	[StaticAccessor("InputBindings", StaticAccessorType::DoubleColon (2))]
	internal static IMECompositionMode imeCompositionMode
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
		internal set { } //Length: 49
	}

	public static int keyboardControl
	{
		 get { } //Length: 91
		 set { } //Length: 98
	}

	[NativeProperty("GetGUIState().m_CanvasGUIState.m_IsMouseUsed", True, TargetType::Field (1))]
	internal static bool mouseUsed
	{
		internal set { } //Length: 51
	}

	[NativeProperty("GetGUIState().m_PixelsPerPoint", True, TargetType::Field (1))]
	internal static float pixelsPerPoint
	{
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
		internal get { } //Length: 42
		[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
		internal set { } //Length: 58
	}

	public static string systemCopyBuffer
	{
		[FreeFunction("GetCopyBuffer")]
		 get { } //Length: 222
		[FreeFunction("SetCopyBuffer")]
		 set { } //Length: 395
	}

	[StaticAccessor("GetInputManager()", StaticAccessorType::Dot (0))]
	internal static bool textFieldInput
	{
		internal get { } //Length: 42
		internal set { } //Length: 51
	}

	private static GUIUtility() { }

	public static Rect AlignRectToDevice(Rect rect, out int widthInPixels, out int heightInPixels) { }

	public static Rect AlignRectToDevice(Rect rect) { }

	private static void AlignRectToDevice_Injected(in Rect rect, out int widthInPixels, out int heightInPixels, out Rect ret) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void BeginContainer(ObjectGUIState objectGUIState) { }

	private static void BeginContainer_Injected(IntPtr objectGUIState) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void BeginContainerFromOwner(ScriptableObject owner) { }

	private static void BeginContainerFromOwner_Injected(IntPtr owner) { }

	[RequiredByNativeCode]
	internal static void BeginGUI(int skinMode, int instanceID, int useGUILayout) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static int CheckForTabEvent(Event evt) { }

	private static int CheckForTabEvent_Injected(IntPtr evt) { }

	internal static void CheckOnGUI() { }

	[RequiredByNativeCode]
	internal static void DestroyGUI(int instanceID) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void EndContainer() { }

	[RequiredByNativeCode]
	internal static bool EndContainerGUIFromException(Exception exception) { }

	[RequiredByNativeCode]
	internal static void EndGUI(int layoutType) { }

	[RequiredByNativeCode]
	internal static bool EndGUIFromException(Exception exception) { }

	public static void ExitGUI() { }

	internal static string get_compositionString() { }

	private static void get_compositionString_Injected(out ManagedSpanWrapper ret) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static int get_guiDepth() { }

	public static int get_hotControl() { }

	public static int get_keyboardControl() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static float get_pixelsPerPoint() { }

	[FreeFunction("GetCopyBuffer")]
	public static string get_systemCopyBuffer() { }

	private static void get_systemCopyBuffer_Injected(out ManagedSpanWrapper ret) { }

	internal static bool get_textFieldInput() { }

	public static int GetControlID(int hint, FocusType focusType, Rect rect) { }

	public static int GetControlID(FocusType focus) { }

	public static int GetControlID(int hint, FocusType focus) { }

	internal static GUISkin GetDefaultSkin() { }

	public static object GetStateObject(Type t, int controlID) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static bool HasFocusableControls() { }

	internal static bool HasKeyFocus(int controlID) { }

	internal static bool HitTest(Rect rect, Event evt) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static bool HitTest(Rect rect, Vector2 point, bool isDirectManipulationDevice) { }

	internal static bool HitTest(Rect rect, Vector2 point, int offset) { }

	[NativeMethod("EndContainer")]
	internal static void Internal_EndContainer() { }

	private static void Internal_ExitGUI() { }

	[FreeFunction("GetGUIState().GetControlID")]
	private static int Internal_GetControlID(int hint, FocusType focusType, Rect rect) { }

	private static int Internal_GetControlID_Injected(int hint, FocusType focusType, in Rect rect) { }

	private static object Internal_GetDefaultSkin(int skinMode) { }

	private static int Internal_GetHotControl() { }

	private static int Internal_GetKeyboardControl() { }

	private static void Internal_SetHotControl(int value) { }

	private static void Internal_SetKeyboardControl(int value) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static bool IsExitGUIException(Exception exception) { }

	[RequiredByNativeCode]
	private static void MarkGUIChanged() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static bool OwnsId(int id) { }

	[RequiredByNativeCode]
	internal static void ProcessEvent(int instanceID, IntPtr nativeEventPtr, out bool result) { }

	[RequiredByNativeCode]
	internal static void RemoveCapture() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void ResetGlobalState() { }

	public static void RotateAroundPivot(float angle, Vector2 pivotPoint) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static float RoundToPixelGrid(float v) { }

	internal static void set_compositionCursorPos(Vector2 value) { }

	private static void set_compositionCursorPos_Injected(in Vector2 value) { }

	[CompilerGenerated]
	internal static void set_guiIsExiting(bool value) { }

	public static void set_hotControl(int value) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void set_imeCompositionMode(IMECompositionMode value) { }

	public static void set_keyboardControl(int value) { }

	internal static void set_mouseUsed(bool value) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void set_pixelsPerPoint(float value) { }

	[FreeFunction("SetCopyBuffer")]
	public static void set_systemCopyBuffer(string value) { }

	private static void set_systemCopyBuffer_Injected(ref ManagedSpanWrapper value) { }

	internal static void set_textFieldInput(bool value) { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void SetKeyboardControlToFirstControlId() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static void SetKeyboardControlToLastControlId() { }

	[VisibleToOtherModules(new IL2CPP_TYPE_STRING[] {"UnityEngine.UIElementsModule"})]
	internal static bool ShouldRethrowException(Exception exception) { }

	[RequiredByNativeCode]
	internal static void TakeCapture() { }

}

