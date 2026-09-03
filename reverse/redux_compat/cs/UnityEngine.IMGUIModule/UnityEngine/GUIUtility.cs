/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[NativeHeader("Runtime/Input/InputBindings.h")]
	[NativeHeader("Modules/IMGUI/GUIManager.h")]
	[NativeHeader("Runtime/Input/InputManager.h")]
	[NativeHeader("Runtime/Camera/RenderLayers/GUITexture.h")]
	[NativeHeader("Modules/IMGUI/GUIUtility.h")]
	[NativeHeader("Runtime/Utilities/CopyPaste.h")]
	public class GUIUtility // TypeDefIndex: 13943
	{
		// Fields
		[NoAutoStaticsCleanup]
		internal static int s_ControlCount; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static int s_SkinMode; // 0x04
		[AutoStaticsCleanupOnCodeReload]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static EntityId s_OriginalID; // 0x08
		[NoAutoStaticsCleanup]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static Action takeCapture; // 0x10
		[NoAutoStaticsCleanup]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static Action releaseCapture; // 0x18
		[NoAutoStaticsCleanup]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static Func<Exception, bool> endContainerGUIFromException; // 0x20
		[NoAutoStaticsCleanup]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static Action guiChanged; // 0x28
		[CompilerGenerated]
		private static bool _guiIsExiting_k__BackingField; // 0x30
		[NoAutoStaticsCleanup]
		internal static Func<bool> s_HasCurrentWindowKeyFocusFunc; // 0x38
		[CompilerGenerated]
		private static bool _isUITK_k__BackingField; // 0x40
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x48
	
		// Properties
		[NativeProperty("GetGUIState().m_PixelsPerPoint", true, TargetType.Field)]
		internal static float pixelsPerPoint { [VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEditor.UIToolkitAuthoringModule" })] get; [VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })] set; } // 0x000000018228BF00-0x000000018228BF30 0x000000018228C2C0-0x000000018228C300
		[NativeProperty("GetGUIState().m_OnGUIDepth", true, TargetType.Field)]
		internal static int guiDepth { [VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })] get; } // 0x000000018228BE10-0x000000018228BE40 
		[NativeProperty("GetGUIState().m_CanvasGUIState.m_IsMouseUsed", true, TargetType.Field)]
		internal static bool mouseUsed { set; } // 0x000000018228C280-0x000000018228C2C0
		[StaticAccessor("GetInputManager()", StaticAccessorType.Dot)]
		internal static bool textFieldInput { get; set; } // 0x000000018228C060-0x000000018228C090 0x000000018228C4C0-0x000000018228C500
		public static string systemCopyBuffer { [FreeFunction("GetCopyBuffer")] get; [FreeFunction("SetCopyBuffer")] set; } // 0x000000018228BF70-0x000000018228C060 0x000000018228C340-0x000000018228C4C0
		[StaticAccessor("InputBindings", StaticAccessorType.DoubleColon)]
		internal static string compositionString { get; } // 0x000000018228BD20-0x000000018228BE10 
		[StaticAccessor("InputBindings", StaticAccessorType.DoubleColon)]
		internal static Vector2 compositionCursorPos { set; } // 0x000000018228C0D0-0x000000018228C140
		[AutoStaticsCleanupOnCodeReload]
		internal static bool guiIsExiting { [CompilerGenerated] set; } // 0x000000018228C140-0x000000018228C1A0
		public static int hotControl { get; set; } // 0x000000018228BE40-0x000000018228BEA0 0x000000018228C1A0-0x000000018228C210
		public static int keyboardControl { get; set; } // 0x000000018228BEA0-0x000000018228BF00 0x000000018228C210-0x000000018228C280
	
		// Constructors
		static GUIUtility(); // 0x000000018228BBA0-0x000000018228BCE0
	
		// Methods
		[FreeFunction("GetGUIState().GetControlID")]
		private static int Internal_GetControlID(int hint, FocusType focusType, Rect rect); // 0x000000018228B0F0-0x000000018228B170
		public static int GetControlID(int hint, FocusType focusType, Rect rect); // 0x000000018228A850-0x000000018228A920
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void BeginContainerFromOwner(ScriptableObject owner); // 0x0000000182289CF0-0x0000000182289D60
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void BeginContainer(ObjectGUIState objectGUIState); // 0x0000000182289DA0-0x0000000182289E10
		[NativeMethod("EndContainer")]
		internal static void Internal_EndContainer(); // 0x000000018228B040-0x000000018228B070
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static int CheckForTabEvent(Event evt); // 0x000000018228A090-0x000000018228A100
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void SetKeyboardControlToFirstControlId(); // 0x000000018228B970-0x000000018228B9A0
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void SetKeyboardControlToLastControlId(); // 0x000000018228B9A0-0x000000018228B9D0
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static bool HasFocusableControls(); // 0x000000018228AB70-0x000000018228ABA0
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static bool OwnsId(int id); // 0x000000018228B380-0x000000018228B3C0
		private static int Internal_GetHotControl(); // 0x000000018228B1B0-0x000000018228B1E0
		private static int Internal_GetKeyboardControl(); // 0x000000018228B1E0-0x000000018228B210
		private static void Internal_SetHotControl(int value); // 0x000000018228B210-0x000000018228B250
		private static void Internal_SetKeyboardControl(int value); // 0x000000018228B250-0x000000018228B290
		private static object Internal_GetDefaultSkin(int skinMode); // 0x000000018228B170-0x000000018228B1B0
		private static void Internal_ExitGUI(); // 0x000000018228B070-0x000000018228B0A0
		[RequiredByNativeCode]
		private static void MarkGUIChanged(); // 0x000000018228B310-0x000000018228B380
		public static int GetControlID(FocusType focus); // 0x000000018228A920-0x000000018228A970
		public static int GetControlID(int hint, FocusType focus); // 0x000000018228A6D0-0x000000018228A850
		public static object GetStateObject(Type t, int controlID); // 0x000000018228AA10-0x000000018228AB70
		[RequiredByNativeCode]
		internal static void TakeCapture(); // 0x000000018228BA80-0x000000018228BAF0
		[RequiredByNativeCode]
		internal static void RemoveCapture(); // 0x000000018228B3C0-0x000000018228B430
		internal static bool HasKeyFocus(int controlID); // 0x000000018228ABA0-0x000000018228AC80
		public static void ExitGUI(); // 0x000000018228A660-0x000000018228A6D0
		internal static GUISkin GetDefaultSkin(); // 0x000000018228A970-0x000000018228AA10
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void EndContainer(); // 0x000000018228A300-0x000000018228A380
		[RequiredByNativeCode]
		internal static void BeginGUI(int skinMode, EntityId entityId, int useGUILayout); // 0x0000000182289E10-0x000000018228A050
		[RequiredByNativeCode]
		internal static void DestroyGUI(EntityId entityId); // 0x000000018228A1C0-0x000000018228A280
		[RequiredByNativeCode]
		internal static void EndGUI(); // 0x000000018228A480-0x000000018228A660
		[RequiredByNativeCode]
		internal static bool EndGUIFromException(Exception exception); // 0x000000018228A380-0x000000018228A480
		[RequiredByNativeCode]
		internal static bool EndContainerGUIFromException(Exception exception); // 0x000000018228A280-0x000000018228A300
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void ResetGlobalState(); // 0x000000018228B430-0x000000018228B5D0
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static bool IsExitGUIException(Exception exception); // 0x000000018228B290-0x000000018228B310
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static bool ShouldRethrowException(Exception exception); // 0x000000018228B9D0-0x000000018228BA80
		internal static void CheckOnGUI(); // 0x000000018228A100-0x000000018228A1C0
		internal static void WarnOnGUI(); // 0x00000001802E76C0-0x00000001802E76D0
		public static void RotateAroundPivot(float angle, Vector2 pivotPoint); // 0x000000018228B5D0-0x000000018228B970
		internal static bool HitTest(Rect rect, Vector2 point, int offset); // 0x000000018228AE80-0x000000018228AF50
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static bool HitTest(Rect rect, Vector2 point, bool isDirectManipulationDevice); // 0x000000018228AF50-0x000000018228B040
		internal static bool HitTest(Rect rect, Event evt); // 0x000000018228AC80-0x000000018228AE80
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018228BAF0-0x000000018228BBA0
		private static void get_systemCopyBuffer_Injected(); // 0x000000018228BF30-0x000000018228BF70
		private static void set_systemCopyBuffer_Injected(ref ManagedSpanWrapper value); // 0x000000018228C300-0x000000018228C340
		private static int Internal_GetControlID_Injected(int hint, FocusType focusType, in Rect rect); // 0x000000018228B0A0-0x000000018228B0F0
		private static void BeginContainerFromOwner_Injected(IntPtr owner); // 0x0000000182289CB0-0x0000000182289CF0
		private static void BeginContainer_Injected(IntPtr objectGUIState); // 0x0000000182289D60-0x0000000182289DA0
		private static int CheckForTabEvent_Injected(IntPtr evt); // 0x000000018228A050-0x000000018228A090
		private static void get_compositionString_Injected(); // 0x000000018228BCE0-0x000000018228BD20
		private static void set_compositionCursorPos_Injected(in Vector2 value); // 0x000000018228C090-0x000000018228C0D0
	}
}
